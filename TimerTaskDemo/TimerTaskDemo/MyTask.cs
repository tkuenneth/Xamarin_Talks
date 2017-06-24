using Android.Util;
using Java.Util;

namespace TimerTaskDemo
{
    public class MyTask : TimerTask
    {

        static readonly string TAG = typeof(MyTask).Name;

        private int counter = 0;

        private MainActivity _activity;
        public MyTask(MainActivity activity)
        {
            this._activity = activity;
        }

        public override void Run()
        {
            _activity.RunOnUiThread(() =>
            {
                var s = $"{counter++}";
                Log.Debug(TAG, s);
                _activity.label.Text = s;
            });
        }
    }
}
