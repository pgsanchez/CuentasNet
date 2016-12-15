using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasNet
{
    public partial class FormIngreso : Form
    {
        public Ingreso ingreso = new Ingreso();
        public List<Categoria> listaCat = new List<Categoria>();

        public FormIngreso()
        {
            InitializeComponent();
        }

        public FormIngreso(List<Categoria> lista)
        {
            InitializeComponent();

            foreach (Categoria cat in lista)
            {
                listaCat.Add(cat);
            }
            ActualizarComboBoxCategorias();
        }

        public FormIngreso(List<Categoria> lista, DateTime fecha, String Categoria, String Concepto, float valor)
        {
            InitializeComponent();

            ingreso.Cantidad = valor;
            ingreso.Categoria = Categoria;
            ingreso.Concepto = Concepto;
            ingreso.Fecha = fecha;
            foreach (Categoria cat in lista)
            {
                listaCat.Add(cat);
            }

            dateTimePicker1.Value = fecha;
            txtBoxCantidad.Text = valor.ToString();
            textBoxConcepto.Text = Concepto;
            ActualizarComboBoxCategorias();
            cmbBoxCategorias.SelectedItem = Categoria;
        }

        private int ActualizarComboBoxCategorias()
        {
            foreach (Categoria cat in listaCat)
            {
                cmbBoxCategorias.Items.Add(cat.Nombre);
            }
            return 0;
        }

        private void cmbBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ingreso.Categoria = cmbBoxCategorias.SelectedItem.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ingreso.Fecha = dateTimePicker1.Value;
        }

        private void txtBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            ingreso.Cantidad = Convert.ToSingle(txtBoxCantidad.Text);
        }

        private void textBoxConcepto_TextChanged(object sender, EventArgs e)
        {
            ingreso.Concepto = textBoxConcepto.Text;
        }
    }
}
