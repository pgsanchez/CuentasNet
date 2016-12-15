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
    public partial class Form2 : Form
    {
        private String nombre = "";
        public bool chkGasto = false;
        public bool chkIngreso = false;

        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(String nom, bool gas, bool ing)
        {
            InitializeComponent();
            nombre = nom;
            chkGasto = gas;
            chkIngreso = ing;
            edtNewCat.Text = nombre;
            checkBox1.Checked = chkGasto;
            checkBox2.Checked = chkIngreso;
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            nombre = edtNewCat.Text;
        }

        private void edtNewCat_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                chkGasto = true;
            else
                chkGasto = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                chkIngreso = true;
            else
                chkIngreso = false;
        }
    }
}
