using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daniela.Modelo;

namespace Daniela
{
    public partial class NuevoProducto : Form
    {
        public string id;
        tbProductos Producto = null;
        public NuevoProducto(string id = null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
            {
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            using (DanielaEntities1 db = new DanielaEntities1())
            {
                int Id2 = Convert.ToInt16(id);
                Producto = db.tbProductos.Find(Id2);
                txtProducto.Text = Producto.Producto;
                txtPrecio.Text = Producto.Precio.ToString();
                txtCantida.Text = Producto.Cantidad.ToString();
                txtProveedor.Text = Producto.Proveedor;
            }
        }

        private void NuevoProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string producto = txtProducto.Text;
            int precio = Convert.ToInt16(txtPrecio.Text);
            int cantidad = Convert.ToInt16(txtCantida.Text);
            string proveedor = txtProveedor.Text;
            if (id == null)
            {
                Form1 f1 = new Form1();
                using (DanielaEntities1 db = new DanielaEntities1())
                {
                    db.PA_Insertar(producto, Convert.ToInt16(precio), Convert.ToInt16(cantidad), proveedor);
                }
                f1.Show();
                Close();
            }
            else
            {
                Form1 f1 = new Form1();
                using (DanielaEntities1 db = new DanielaEntities1())
                {
                    db.PA_Actualizar(Convert.ToInt16(id),producto, precio, cantidad, proveedor);
                }
                f1.Show();
                Close();
            }
        }
    }
}
