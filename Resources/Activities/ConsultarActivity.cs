using AndroidX.AppCompat.App;
using App.Resources.BaseDeDatos;
using System.IO;
using Android.Widget;
using Android.App;
using Android.OS;
using App.Resources.models;
using System.Reflection.Emit;

namespace App.Resources.Activities
{
    [Activity(Label = "ConsultarActivity")]
    public class ConsultarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.consultar);

            Button consultarButton = FindViewById<Button>(Resource.Id.btnConsultar);
            consultarButton.Click += (sender, e) =>
            {
                SearchView searchView = FindViewById<SearchView>(Resource.Id.search_view);
                int id = int.Parse(searchView.Query);

                ConsultarProducto(id);
            };
        }

        private void ConsultarProducto(int id)
        {
            string rutaBaseDatos = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "base_datos.db3");
            BaseDatos baseDatos = new BaseDatos(rutaBaseDatos);
            Producto producto = baseDatos.ObtenerProducto(id);

            if (producto != null)
            {
                // Mostrar información del producto al usuario
                TextView nombreTextView = FindViewById<TextView>(Resource.Id.tvNombre);
                TextView precioTextView = FindViewById<TextView>(Resource.Id.tvPrecio);
                TextView cantidadTextView = FindViewById<TextView>(Resource.Id.tvCantidad);

                nombreTextView.Text = "Nombre: " + producto.Nombre;
                precioTextView.Text = "Precio: " + producto.Precio.ToString();
                cantidadTextView.Text = "Cantidad: " + producto.Cantidad.ToString();
            }
            else
            {
                Toast.MakeText(this, "El ID no existe", ToastLength.Short).Show();
            }
        }
    }
}
