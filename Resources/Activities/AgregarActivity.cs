using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using App.Resources.BaseDeDatos;
using System.IO;

namespace App.Resources.Activities
{
    [Activity(Label = "AgregarActivity")]
    public class AgregarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.agregar);

            Button agregarButton = FindViewById<Button>(Resource.Id.btnAgregar);
            agregarButton.Click += AgregarButton_Click;
        }

        private void AgregarButton_Click(object sender, System.EventArgs e)
        {
            EditText nombreEditText = FindViewById<EditText>(Resource.Id.etNombre);
            EditText precioEditText = FindViewById<EditText>(Resource.Id.etPrecio);
            EditText cantidadEditText = FindViewById<EditText>(Resource.Id.etCantidad);

            string nombre = nombreEditText.Text;
            decimal precio = decimal.Parse(precioEditText.Text);
            int cantidad = int.Parse(cantidadEditText.Text);

            string rutaBaseDatos = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "base_datos.db3");
            BaseDatos baseDatos = new BaseDatos(rutaBaseDatos);
            baseDatos.InsertarProducto(nombre, precio, cantidad);

            Toast.MakeText(this, "Producto agregado", ToastLength.Short).Show();
        }
    }
}