using Android.App;
using Android.App.Job;
using Android.Util;

namespace JobSchedulerDemo
{
    [Service(Exported = true, Name = "com.thomaskuenneth.MyJobService", Permission = "android.permission.BIND_JOB_SERVICE")]
    class MyJobService : JobService
    {
        private static readonly string TAG = typeof(MyJobService).Name;

        public override bool OnStartJob(JobParameters @params)
        {
            Log.Info(TAG, "started");
            // work to be done
            return true;
        }

        public override bool OnStopJob(JobParameters @params)
        {
            Log.Info(TAG, "started");
            // re-schedule
            return true;
        }
    }
}