using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace LayoutDemo
{
    [Activity(Label = "LayoutDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Button linear = FindViewById<Button>(Resource.Id.linear);
            linear.Click += delegate { 
                // Java.Lang.Thread.Sleep(15000);
                UpdateFrameLayout(Resource.Layout.Linear);
            };
            Button relative = FindViewById<Button>(Resource.Id.relative);
            relative.Click += delegate {
                UpdateFrameLayout(Resource.Layout.Relative);
			};
        }

        private void UpdateFrameLayout(int resId)
        {
            FrameLayout l = FindViewById<FrameLayout>(Resource.Id.frameLayout1);
            l.RemoveAllViews();
            LayoutInflater inflater = LayoutInflater.From(this);
            inflater.Inflate(resId, l);
        }
    }
}

