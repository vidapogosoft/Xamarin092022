using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

using Plugin.Media;
using Plugin.Permissions;
//using Plugin.CurrentActivity;


namespace TabsCamaraGeoMapa.Droid
{
    [Activity(Label = "Camara-GeoMapa", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Inicio plugin de mapas
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            //Cargo el plugin de GeoLocator
            //CrossCurrentActivity.Current.Init(this, savedInstanceState);

            //Camara
            await CrossMedia.Current.Initialize();


            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}