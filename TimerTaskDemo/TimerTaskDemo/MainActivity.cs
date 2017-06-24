using Android.App;
using Android.Widget;
using Android.OS;
using Java.Util;

namespace TimerTaskDemo
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        internal TextView label;

        private Timer timer;
        private TimerTask timerTask;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            label = FindViewById<TextView>(Resource.Id.label);
            timer = new Timer();
        }

        protected override void OnStart()
        {
            base.OnStart();
            timerTask = new MyTask(this);
            timer.ScheduleAtFixedRate(timerTask, 3000, 3000);

        }

        protected override void OnPause()
        {
            base.OnPause();
            timerTask.Cancel();
        }
    }
}

