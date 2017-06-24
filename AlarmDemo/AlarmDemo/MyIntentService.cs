using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace AlarmDemo
{
    [Service(Label = "MyIntentService")]
    public class MyIntentService : IntentService
    {
        private Handler handler;
        public MyIntentService() : base("MyIntentService")
        {
            handler = new Handler(Looper.MainLooper);
        }

        protected override void OnHandleIntent(Intent intent)
        {
            string key = intent.GetStringExtra(MyBroadcastReceiver.KEY_WL);
            handler.Post(() =>
            {
                Toast.MakeText(this,
                               "rrrrriiiiiinnngggg",
                               ToastLength.Short).Show();
            });
            MyBroadcastReceiver.ReleaseWakeLock(this, key);
        }
    }
}
