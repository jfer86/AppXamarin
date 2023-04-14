using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;


namespace App.Resources.Activities
{
    [Activity(Label = "Activity1")]
    public class EditarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.editar);

            // Create your application here
        }
    }
}