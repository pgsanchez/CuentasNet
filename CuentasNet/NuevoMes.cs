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
    public partial class NuevoMes : Form
    {
        public Mes mes = new Mes();
        Mes actual = new Mes();

        public int btnCancelar = 0; // 1 --> Salir sin cambios: Cancel

        public NuevoMes()
        {
            InitializeComponent();
        }

        public NuevoMes(Mes mesActual)
        {
            InitializeComponent();
            actual = mesActual;

            txtMesAct.Text = mesActual.Nombre + " " + mesActual.Anno.ToString();
            txtNuevoMes.Text = mesActual.mesSiguiente();
            //dateTimePicker1.Value = 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Devolver los datos y preparar el nuevo mes. Y cerrar la ventana.
            mes.Nombre = txtNuevoMes.Text;
            if (actual.Nombre == "Diciembre")
                mes.Anno = actual.Anno + 1;
            else
                mes.Anno = actual.Anno;
            mes.Inicio = dateTimePicker1.Value;
            // la fecha de fin no se toca. Será 1/1/3000
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancelar = 1;
            this.Close();
        }
    }
}
