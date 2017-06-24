using Android.App;
using Java.Lang;
using Android.OS;
using Android.Content;

namespace AlarmDemo
{
    [Activity(Label = "AlarmDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            ScheduleAlarm(this);
        }

        public static void ScheduleAlarm(Context context)
        {
            Intent data = new Intent(context,
                                     Class.FromType(typeof(MyBroadcastReceiver)));
            PendingIntent intent = PendingIntent.GetBroadcast(context,
                                                         0,
                                                         data,
                                                         PendingIntentFlags.OneShot);
            AlarmManager m = (AlarmManager)context.GetSystemService(Context.AlarmService);
            m.Set(AlarmType.ElapsedRealtimeWakeup,
                  SystemClock.ElapsedRealtime() + 5000, intent);
        }
    }
}
