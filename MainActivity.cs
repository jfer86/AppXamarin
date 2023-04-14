using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.App;
using App.Resources.Activities;

namespace App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            // Encuentro el botón por su ID y agrego el código para verificar credenciales
            Button loginButton = FindViewById<Button>(Resource.Id.login_button);
            loginButton.Click += delegate
            {
                EditText emailEditText = FindViewById<EditText>(Resource.Id.email);
                EditText passwordEditText = FindViewById<EditText>(Resource.Id.password);
                string email = emailEditText.Text;
                string password = passwordEditText.Text;
                if (TextUtils.IsEmpty(email))
                {
                    emailEditText.Error = "Usuario es requerido";
                    return;
                }
                if (TextUtils.IsEmpty(password))
                {
                    passwordEditText.Error = "Password es requerido";
                    return;
                }
                if (email == "admin" && password == "admin")
                {
                    // Iniciar la actividad de bienvenida
                    Intent intent = new Intent(this, typeof(WelcomeActivity));
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "Invalid credentials", ToastLength.Short).Show();
                }
            };

            Button forgotPasswordButton = FindViewById<Button>(Resource.Id.forgot_password);
            forgotPasswordButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(RecoveryActivity));
                StartActivity(intent);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}