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
    public partial class FormGasto : Form
    {
        public Gasto gasto = new Gasto();
        public List<Categoria> listaCat = new List<Categoria>();
        public List<FormaPago> listaFormPago = new List<FormaPago>();
        // Formas de pago
        // 1 - ninguna
        // 2 - efectivo
        // 3 - transferencia
        // 4 - tarjeta

        public FormGasto()
        {
            InitializeComponent();

        }

        public FormGasto(List<Categoria> lista, List<FormaPago> lista2)
        {
            InitializeComponent();

            foreach (Categoria cat in lista)
            {
                listaCat.Add(cat);
            }

            ActualizarComboBoxCategorias();

            foreach (FormaPago it in lista2)
            {
                listaFormPago.Add(it);
            }
            ActualizarComboBoxFormasPago();
        }

        public FormGasto(List<Categoria> lista, DateTime fecha, String Categoria, String Concepto, float valor, List<FormaPago> lista2)
        {
            InitializeComponent();

            gasto.Cantidad = valor;
            gasto.Categoria = Categoria;
            gasto.Concepto = Concepto;
            gasto.Fecha = fecha;
            foreach (Categoria cat in lista)
            {
                listaCat.Add(cat);
            }

            dateTimePicker1.Value = fecha;
            txtBoxCantidad.Text = valor.ToString();
            textBoxConcepto.Text = Concepto;
            ActualizarComboBoxCategorias();
            cmbBoxCategorias.SelectedItem = Categoria;

            foreach (FormaPago it in lista2)
            {
                listaFormPago.Add(it);
            }
            ActualizarComboBoxFormasPago();
        }

        public FormGasto(List<Categoria> lista, Gasto objGasto, List<FormaPago> lista2)
        {
            InitializeComponent();

            gasto.Cantidad = objGasto.Cantidad;
            gasto.Categoria = objGasto.Categoria;
            gasto.Concepto = objGasto.Concepto;
            gasto.Fecha = objGasto.Fecha;
            gasto.FormaPago = objGasto.FormaPago;
            gasto.Etiqueta1 = objGasto.Etiqueta1;
            foreach (Categoria cat in lista)
            {
                listaCat.Add(cat);
            }

            dateTimePicker1.Value = gasto.Fecha;
            txtBoxCantidad.Text = gasto.Cantidad.ToString();
            textBoxConcepto.Text = gasto.Concepto;
            ActualizarComboBoxCategorias();
            cmbBoxCategorias.SelectedItem = gasto.Categoria;

            foreach (FormaPago it in lista2)
            {
                listaFormPago.Add(it);
            }
            ActualizarComboBoxFormasPago();
            cmbBoxFormaPago.SelectedItem = gasto.FormaPago;
            txtBoxEtiq1.Text = gasto.Etiqueta1;
        }


        private int ActualizarComboBoxCategorias()
        {
            foreach (Categoria cat in listaCat)
            {
                cmbBoxCategorias.Items.Add(cat.Nombre);
            }
            return 0;
        }

        private int ActualizarComboBoxFormasPago()
        {
            foreach (FormaPago it in listaFormPago)
            {
                cmbBoxFormaPago.Items.Add(it.Nombre);
                if (it.Id == gasto.FormaPago)
                    cmbBoxFormaPago.SelectedItem = it.Nombre;
            }
            return 0;
        }

        private void cmbBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            gasto.Categoria = cmbBoxCategorias.SelectedItem.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            gasto.Fecha = dateTimePicker1.Value;
        }

        private void txtBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            gasto.Cantidad = Convert.ToSingle(txtBoxCantidad.Text);
        }

        private void textBoxConcepto_TextChanged(object sender, EventArgs e)
        {
            gasto.Concepto = textBoxConcepto.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            gasto.Categoria = cmbBoxCategorias.SelectedItem.ToString();
            gasto.Fecha = dateTimePicker1.Value;
            gasto.Cantidad = Convert.ToSingle(txtBoxCantidad.Text);
            gasto.Concepto = textBoxConcepto.Text;

            
        }

        private void cmbBoxFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (FormaPago it in listaFormPago)
            {
                if (cmbBoxFormaPago.SelectedItem.ToString() == it.Nombre)
                    gasto.FormaPago = it.Id;
            }
        }

        private void txtBoxEtiq1_TextChanged(object sender, EventArgs e)
        {
            gasto.Etiqueta1 = txtBoxEtiq1.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gasto.Clear();
        }
    }
}
