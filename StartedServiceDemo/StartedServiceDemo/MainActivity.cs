using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace StartedServiceDemo
{
    [Activity(Label = "StartedServiceDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Intent service = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Button b = FindViewById<Button>(Resource.Id.button);
            b.Click += delegate
            {
                service = new Intent(this, Java.Lang.Class.FromType(typeof(MyService)));
                StartService(service);
            };
        }

        protected override void OnPause()
        {
            base.OnPause();
            StopService(service);
            service = null;
        }
    }
}

