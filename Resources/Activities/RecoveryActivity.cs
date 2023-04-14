using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace App.Resources.Activities
{
    [Activity(Label = "Activity1")]
    public class RecoveryActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RecoverPassword);
            // Encuentra el botón "reset_password_button" por su ID y agrega la lógica para enviar correo electrónico de restablecimiento de contraseña
            Button resetPasswordButton = FindViewById<Button>(Resource.Id.reset_password_button);
            resetPasswordButton.Click += delegate
            {
                EditText resetEmailEditText = FindViewById<EditText>(Resource.Id.reset_password_email);
                String resetEmail = resetEmailEditText.Text;

                // Valida que el campo de correo electrónico no esté vacío y tenga el formato correcto
                if (TextUtils.IsEmpty(resetEmail) || !Patterns.EmailAddress.Matcher(resetEmail).Matches())
                {
                    resetEmailEditText.Error = "Ingrese un correo electrónico válido";
                }
                else
                {
                    Toast.MakeText(this, "¡Se envió el correo electrónico para recuperar la contraseña!", ToastLength.Short).Show();
                }
            };
        }
    }
}