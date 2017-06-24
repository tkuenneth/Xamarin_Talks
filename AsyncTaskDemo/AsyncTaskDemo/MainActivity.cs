using Android.App;
using Android.Widget;
using Android.OS;

namespace AsyncTaskDemo
{
    [Activity(Label = "AsyncTaskDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Android.Views.View v;
        private AsyncTask t;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            v = FindViewById<Android.Views.View>(Resource.Id.view);
        }

        protected override void OnStart()
        {
            base.OnStart();
            t = new MyAsyncTask(v).Execute();
        }

        protected override void OnPause()
        {
            base.OnPause();
            t.Cancel(true);
        }
    }
}

