using Android.Content;
using Java.Lang;
using Java.Util;
using Android.OS;
using System.Collections.Generic;

namespace AlarmDemo
{
    [BroadcastReceiver]
    public class MyBroadcastReceiver : BroadcastReceiver
    {

        private static Dictionary<string, PowerManager.WakeLock> dict = new Dictionary<string, PowerManager.WakeLock>();
        private static readonly string TAG = typeof(MyBroadcastReceiver).Name;

        public const string KEY_WL = "wakelock";

        public override void OnReceive(Context context,
                                       Intent intent)
        {
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wl = pm.NewWakeLock(WakeLockFlags.Partial, TAG);
            string key = UUID.RandomUUID().ToString();
            dict.Add(key, wl);
            wl.Acquire();
            MainActivity.ScheduleAlarm(context);
            Intent service = new Intent(context,
                                       Class.FromType(typeof(MyIntentService)));
            service.PutExtra(KEY_WL, key);
            context.StartService(service);
        }

        public static void ReleaseWakeLock(Context context, string key)
        {
            PowerManager.WakeLock wl = dict[key];
            if (wl != null)
            {
                wl.Release();
            }
        }
    }
}
