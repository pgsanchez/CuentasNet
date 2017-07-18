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
        public Mes mes = new Mes(); // Objeto Mes de este Form
        Mes actual = new Mes(); // Mes en el que está actualmente la aplicacion

        public int btnCancelar = 0; // 0 --> Salir SIN cambios (Cancel); 1 --> Salir CON cambios 

        public NuevoMes()
        {
            InitializeComponent();
        }

        public NuevoMes(Mes mesActual)
        {
            InitializeComponent();
            actual = mesActual;
            txtMesAct.Enabled = false;
            // el objeto "mes" se carga con la fecha de hoy.
            mes.Inicio = DateTime.Today;
            mes.Anno = mes.Inicio.Year;
            mes.Nombre = mes.GetMesFromNumero(mes.Inicio.Month);

            txtMesAct.Text = mesActual.Nombre + " " + mesActual.Anno.ToString();
            txtNuevoMes.Text = mes.mesSiguiente();
            txtNuevoAnno.Text = mes.Anno.ToString();

        }

        // Botón "Nuevo Mes". Se cogen los datos del Form y se vuelve a la ventana padre con 
        // el valor btnCancelar = 1, que indica que los cambios son buenos y que hay que iniciar 
        // un nuevo mes con dichos datos.
        private void button1_Click(object sender, EventArgs e)
        {
            // Devolver los datos y preparar el nuevo mes. Y cerrar la ventana.
            mes.Inicio = dateTimePicker1.Value;
            mes.Nombre = txtNuevoMes.Text; // Este nombre habrá que cogerlo de un ComboBox
            mes.Anno = Convert.ToInt16(txtNuevoAnno.Text);
            btnCancelar = 1; // 1 --> Salir CON cambios 
            this.Close();
            // la fecha de fin no se toca. Será 1/1/3000
        }

        // Botón "Cancelar". Se vuelve a la ventana padre con el valor btnCancelar = 0 que 
        // indica que no hay que hacer cambios.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancelar = 0; // 0 --> Salir SIN cambios (Cancel)
            this.Close();
        }
    }
}
