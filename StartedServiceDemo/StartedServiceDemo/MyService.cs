using Android.App;
using Android.Content;

namespace StartedServiceDemo
{
    [Service(Label = "MyService")]
    public class MyService : IntentService
    {
        static readonly string TAG = typeof(MyService).Name;

        private bool shouldRun;
        private long counter;
        public MyService() : base("MyService")
        {
            shouldRun = true;
            counter = 0;
        }

        protected override void OnHandleIntent(Intent intent)
        {
            while (shouldRun) {
                Android.Util.Log.Debug(TAG, $"{counter++}");
                Java.Lang.Thread.Sleep(2000);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            shouldRun = false;
        }
    }
}
