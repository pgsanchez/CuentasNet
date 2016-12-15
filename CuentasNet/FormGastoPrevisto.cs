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
    public partial class FormGastoPrevisto : Form
    {
        public Prevision prev = new Prevision();
        public List<Categoria> listaCat = new List<Categoria>();

        public FormGastoPrevisto()
        {
            InitializeComponent();
        }

        public FormGastoPrevisto(List<Categoria> lista)
        {
            InitializeComponent();

            foreach (Categoria cat in lista)
            {
                listaCat.Add(cat);
            }

            ActualizarComboBoxCategorias();
        }

        public FormGastoPrevisto(List<Categoria> lista, Prevision previs)
        {
            InitializeComponent();

            prev = previs;

            foreach (Categoria cat in lista)
            {
                listaCat.Add(cat);
            }

            ActualizarComboBoxCategorias();

            txtBoxCantidad.Text = prev.Cantidad.ToString();
            cmbBoxCat.SelectedItem = prev.Categoria;
        }

        private int ActualizarComboBoxCategorias()
        {
            foreach (Categoria cat in listaCat)
            {
                cmbBoxCat.Items.Add(cat.Nombre);
            }
            return 0;
        }

        private void txtBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            prev.Cantidad = Convert.ToSingle(txtBoxCantidad.Text);
        }
    }
}
