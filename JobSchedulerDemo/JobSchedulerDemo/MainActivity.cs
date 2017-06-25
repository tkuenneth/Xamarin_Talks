using Android.App;
using Android.Widget;
using Android.OS;
using Android.App.Job;
using Android.Content;
using Java.Lang;

namespace JobSchedulerDemo
{
    [Activity(Label = "JobSchedulerDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button b = FindViewById<Button>(Resource.Id.button);
            b.Click += delegate
            {

                ComponentName cn = new ComponentName(this, Class.FromType(typeof(MyJobService)));
                JobInfo.Builder builder = new JobInfo.Builder(123, cn);

                long millis = 5 * 60 * 1000;
                builder.SetPeriodic(millis);

                JobScheduler js = (JobScheduler)GetSystemService(Context.JobSchedulerService);
                js.Schedule(builder.Build());
            };

        }
    }
}

