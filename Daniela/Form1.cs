using Daniela.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daniela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'danielaDataSet.tbProductos' Puede moverla o quitarla según sea necesario.
            this.tbProductosTableAdapter.Fill(this.danielaDataSet.tbProductos);

        }
        #region
        private string GetID()
        {
            try
            {
                return dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void btn_NuevoRegistro_Click(object sender, EventArgs e)
        {
            NuevoProducto Producto = new NuevoProducto();

            Producto.Show();
            Hide();
        }
        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string id = GetID();
            if (id != null)
            {
                NuevoProducto Producto = new NuevoProducto(id);
                Producto.Show();
                Hide();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = GetID();
            if (id != null)
            {
                int id2 = Convert.ToInt16(id);
                using (DanielaEntities1 db = new DanielaEntities1())
                {
                    db.PA_Eliminar(id2);
                    Form1 f1 = new Form1();

                    f1.Show();
                    this.Hide();
                }
            }
        }
    }
}
