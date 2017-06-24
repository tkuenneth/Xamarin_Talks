using Android.OS;
using Java.Lang;
using Android.Graphics;

namespace AsyncTaskDemo
{
    public class MyAsyncTask : AsyncTask
    {
        private static readonly Color[] colors = { Color.Red, Color.Green, Color.Blue };
        private int counter = 0;

        private Android.Views.View _v;
        public MyAsyncTask(Android.Views.View v)
        {
            this._v = v;
        }

        protected override Object DoInBackground(params Object[] @params)
        {
            while (!IsCancelled)
            {
                PublishProgress(new Object[] { counter++ });
                if (counter > 2)
                {
                    counter = 0;
                }
                Thread.Sleep(2000);
            }
            return null;
        }

        protected override void OnProgressUpdate(params Object[] values)
        {
            Android.Util.Log.Debug("", values[0].ToString());
            Color col = colors[(int)values[0]];
            _v.SetBackgroundColor(col);
        }
    }
}
