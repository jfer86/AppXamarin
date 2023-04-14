using AndroidX.AppCompat.App;
using App.Resources.BaseDeDatos;
using System.IO;
using Android.Widget;
using Android.App;
using Android.OS;
using System;
using App.Resources.models;

namespace App.Resources.Activities
{
    [Activity(Label = "EliminarActivity")]
    public class EliminarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.eliminar);

            Button eliminarButton = FindViewById<Button>(Resource.Id.btnEliminarProducto);
            eliminarButton.Click += (sender, e) =>
            {
                EditText nombreEditText = FindViewById<EditText>(Resource.Id.etNombre);
                string nombre = nombreEditText.Text;

                EliminarProducto(nombre);
            };
        }

        private void EliminarProducto(string nombre)
        {
            try
            {
                string rutaBaseDatos = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "base_datos.db3");
                BaseDatos baseDatos = new BaseDatos(rutaBaseDatos);

                baseDatos.EliminarProducto(nombre);
                Toast.MakeText(this, "Producto eliminado", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Error al eliminar el producto: " + ex.Message, ToastLength.Long).Show();
            }
        }
    }
}