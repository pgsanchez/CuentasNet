using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CuentasNet
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection();
        String cadenaConexion;

        // Listas generales
        List<Categoria> listaCategorias = new List<Categoria>();
        List<Mes> listaMeses = new List<Mes>();
        List<String> listaEtiquetas = new List<string>();
        List<FormaPago> listaFormasPago = new List<FormaPago>();
        // Listas de ingresos/gastos de cada mes
        List<Ingreso> listaIngresos = new List<Ingreso>();
        List<Gasto> listaGastos = new List<Gasto>();
        List<Prevision> listaGastosPrevistos = new List<Prevision>();
        // Listas auxiliares para diversos cálculos
        List<Gasto> listaGastosAux = new List<Gasto>();
        List<Gasto> listaGastosAux2 = new List<Gasto>();

        float totalGastos = 0; // Suma de los gastos de la ListaGastos
        float totalIngresos = 0; // Suma de los ingresos de la ListaIngresos

        int idGastoActual = 0;
        int idIngresoActual = 0;
        int idGastoPrevActual = 0;
        int idFormaPagoActual = 0;

        bool hayPrevisionMensual = false;

        Mes mesActual = new Mes();
        Mes mesSeleccionado = new Mes();

        public Form1()
        {
            InitializeComponent();

            // Datos de conexión de la BD y abrirla.
            cadenaConexion = "Server=127.0.0.1; Database=pruebaspedro; Uid=root; Pwd=''";
            conn.ConnectionString = cadenaConexion;

            LeerBDListaMeses();
            ActualizarCmbBoxMes(mesSeleccionado);

            // Parte de la interfaz de la ventana principal (Form1)
            // Columnas Lista Formas de Pago
            listFormasPago.Columns.Add("Nombre", 130);
            LeerBDFormasPago();
            ActualizarListaFormasPagoDlg();

            // Columnas Lista Gastos x Forma_pago
            listGastosXMetodo.Columns.Add("Metodo", 80);
            listGastosXMetodo.Columns.Add("Cantidad", 80);

            // Columnas Lista Gastos x Etiqueta
            listGastosEtiqueta.Columns.Add("Fecha", 50);
            listGastosEtiqueta.Columns.Add("Concepto", 50);
            listGastosEtiqueta.Columns.Add("Categoria", 50);
            listGastosEtiqueta.Columns.Add("Cantidad", 50);

            // Columnas Lista Categorías
            listCat.Columns.Add("Categoria", 100);
            listCat.Columns.Add("Gasto", 50);
            listCat.Columns.Add("Ingreso", 50);
            LeerBDListaCat();
            ActualizarListaCatDlg();

            LeerBDEtiquetas();
            ActualizarCmbEtiquetas();

            // Columnas Lista Gastos
            listGastos.Columns.Add("Fecha", 80);
            listGastos.Columns.Add("Cantidad", 80);
            listGastos.Columns.Add("Categoria", 100);
            listGastos.Columns.Add("Concepto", 100);
            listGastos.Columns.Add("Forma Pago", 100);
            listGastos.Columns.Add("Etiqueta", 100);
            listGastos.Columns.Add("Id", 0);
            LeerBDListaGastos(mesActual);
            ActualizarListaGastosDlg();

            // Columnas Lista Ingresos
            listIngresos.Columns.Add("Fecha", 80);
            listIngresos.Columns.Add("Cantidad", 80);
            listIngresos.Columns.Add("Categoria", 100);
            listIngresos.Columns.Add("Concepto", 100);
            listIngresos.Columns.Add("Id", 0);
            LeerBDListaIngresos(mesActual);
            ActualizarListaIngresosDlg();

            // Columnas Lista Resumen
            listResumen.Columns.Add("Categoria", 120);
            listResumen.Columns.Add("Prevision", 80);
            listResumen.Columns.Add("Gastado", 80);
            //listResumen.Columns.Add("Fecha", 70);
            //listResumen.Columns.Add("Concepto", 100);
            //listResumen.Columns.Add("Id", 0);
            listResumen.Columns.Add("Balance", 80);
            listResumen.Columns.Add("%", 80);

            // Columnas Lista Prevision
            listPrev.Columns.Add("Categoria", 100);
            listPrev.Columns.Add("Cantidad", 30);
            listPrev.Columns.Add("Id", 0);
            LeerBDListaGastosPrev(mesActual);
            ActualizarListaPrevisionDlg();

            ConfigAparienciaDlg();

            // Gastos totales
            calcularGastosTotales();
            calcularIngresosTotales();
            calcularDiferencia();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void ConfigAparienciaDlg()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: // Pestaña de Gastos
                    listGastos.Visible = true;
                    listIngresos.Visible = true;
                    button1.Visible = true;
                    btnEdtGasto.Visible = true;
                    btnBorrarGasto.Visible = true;
                    edtTotalGastos.Visible = true;
                    edtTotalIng.Visible = true;
                    btnBorrarIngreso.Visible = true;
                    btnEdtIngreso.Visible = true;
                    btnNuevoIngreso.Visible = true;
                    listCat.Visible = false;
                    btnBorrarCat.Visible = false;
                    btnEditCat.Visible = false;
                    btnNuevaCat.Visible = false;
                    listResumen.Visible = false;
                    listPrev.Visible = false;
                    btnAddPrev.Visible = false;
                    btnEditPrev.Visible = false;
                    btnBorrarPrev.Visible = false;
                    break;
                case 1: // Pestaña de previsiones
                    listGastos.Visible = false;
                    listIngresos.Visible = false;
                    button1.Visible = false;
                    btnEdtGasto.Visible = false;
                    btnBorrarGasto.Visible = false;
                    edtTotalGastos.Visible = false;
                    edtTotalIng.Visible = false;
                    btnBorrarIngreso.Visible = false;
                    btnEdtIngreso.Visible = false;
                    btnNuevoIngreso.Visible = false;
                    listCat.Visible = false;
                    btnBorrarCat.Visible = false;
                    btnEditCat.Visible = false;
                    btnNuevaCat.Visible = false;
                    listResumen.Visible = false;
                    listPrev.Visible = true;
                    btnAddPrev.Visible = true;
                    btnEditPrev.Visible = true;
                    btnBorrarPrev.Visible = true;
                    break;
                case 2: // Pestaña de Categorías
                    listGastos.Visible = false;
                    listIngresos.Visible = false;
                    button1.Visible = false;
                    btnEdtGasto.Visible = false;
                    btnBorrarGasto.Visible = false;
                    edtTotalGastos.Visible = false;
                    edtTotalIng.Visible = false;
                    btnBorrarIngreso.Visible = false;
                    btnEdtIngreso.Visible = false;
                    btnNuevoIngreso.Visible = false;
                    listCat.Visible = true;
                    btnBorrarCat.Visible = true;
                    btnEditCat.Visible = true;
                    btnNuevaCat.Visible = true;
                    listResumen.Visible = false;
                    listPrev.Visible = false;
                    btnAddPrev.Visible = false;
                    btnEditPrev.Visible = false;
                    btnBorrarPrev.Visible = false;
                    break;
                case 3: // Pestaña Resumen
                    listGastos.Visible = false;
                    listIngresos.Visible = false;
                    button1.Visible = false;
                    btnEdtGasto.Visible = false;
                    btnBorrarGasto.Visible = false;
                    edtTotalGastos.Visible = false;
                    edtTotalIng.Visible = false;
                    btnBorrarIngreso.Visible = false;
                    btnEdtIngreso.Visible = false;
                    btnNuevoIngreso.Visible = false;
                    listCat.Visible = false;
                    btnBorrarCat.Visible = false;
                    btnEditCat.Visible = false;
                    btnNuevaCat.Visible = false;
                    listResumen.Visible = true;
                    listPrev.Visible = false;
                    btnAddPrev.Visible = false;
                    btnEditPrev.Visible = false;
                    btnBorrarPrev.Visible = false;
                    calcularResumenGastos();
                    calcularGastosXFormaPago();
                    break;
                case 4:
                    btnBorrarFormaPago.Enabled = false;
                    btnEditFormaPago.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        private void ActualizarCmbBoxMes(Mes mesElegido)
        {
            foreach (Mes it in listaMeses)
            {
                cmbBoxMes.Items.Add(it.Nombre + it.Anno.ToString());
            }
            cmbBoxMes.SelectedItem = mesElegido.Nombre + mesElegido.Anno.ToString(); 
        }
        //***********************************************************************************//
        //*************************** FORMAS DE PAGO ****************************************//
        //***********************************************************************************//
        private int LeerBDFormasPago()
        {
            idFormaPagoActual = 0;
            listaFormasPago.Clear();
            conn.Open();
            MySqlCommand instruccion = conn.CreateCommand();
            instruccion.CommandText = "SELECT Id, nombre from metodos_pago";
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                FormaPago obj = new FormaPago();
                obj.Id = reader.GetInt16("Id");
                obj.Nombre = reader["nombre"].ToString();
                listaFormasPago.Add(obj);
                if (idFormaPagoActual < obj.Id)
                    idFormaPagoActual = obj.Id;
            }
            conn.Close();
            return 0;
        }

        private int AddDBNuevaFormaPago(FormaPago nuevaForma)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "insert into metodos_pago(Id,nombre) values('"
                    + nuevaForma.Id + "','" + nuevaForma.Nombre + "');";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

        private int DelDBFormaPago(String nombre)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "delete from metodos_pago where nombre = '" + nombre + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

        private int UpdBDFormaPago(String oldnombre, string nueva)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "update metodos_pago set nombre = '" + nueva + "' where nombre = '" + oldnombre + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int ActualizarListaFormasPagoDlg()
        {
            listFormasPago.Items.Clear();
            foreach (FormaPago obj in listaFormasPago)
            {
                //ListViewItem item1 = new ListViewItem(obj.Id.ToString(), 0);
                ListViewItem item1 = new ListViewItem(obj.Nombre, 0);
                //item1.SubItems.Add(obj.Nombre);
                listFormasPago.Items.Add(item1);
            }
            return 0;
        }

        // Botón de Añadir una nueva Forma de Pago
        private void btnAddFormaPago_Click(object sender, EventArgs e)
        {
            // Hay que comprobar aquí que no existe ya esa forma de pago
            foreach (FormaPago obj in listaFormasPago)
            {
                if (obj.Nombre == txtBoxFormaPago.Text)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Ya existe esa forma de pago", "Error", buttons);
                    return;
                }
            }

            FormaPago nueva = new FormaPago();
            if (txtBoxFormaPago.Text != "")
            {
                nueva.Nombre = txtBoxFormaPago.Text;
                idFormaPagoActual++;
                nueva.Id = idFormaPagoActual;
                AddDBNuevaFormaPago(nueva);
                txtBoxFormaPago.Text = "";
            }

            LeerBDFormasPago();
            ActualizarListaFormasPagoDlg();
        }

        private void listFormasPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBorrarFormaPago.Enabled = true;
            btnEditFormaPago.Enabled = true;
        }

        private void btnBorrarFormaPago_Click(object sender, EventArgs e)
        {
            String cad = listFormasPago.SelectedItems[0].SubItems[0].Text;
            DelDBFormaPago(cad);
            LeerBDFormasPago();
            ActualizarListaFormasPagoDlg();
        }

        private void btnEditFormaPago_Click(object sender, EventArgs e)
        {
            String cad = listFormasPago.SelectedItems[0].SubItems[0].Text;
            String nueva = txtBoxFormaPago.Text;
            UpdBDFormaPago(cad, nueva);
            LeerBDFormasPago();
            ActualizarListaFormasPagoDlg();
        }

        private String getNombreFormaPago(int formaPago)
        {
            foreach (FormaPago obj in listaFormasPago)
            {
                if (obj.Id == formaPago)
                    return obj.Nombre;
            }
            return "---";
        }

        //***********************************************************************************//
        //*************************** CATEGORIAS ********************************************//
        //***********************************************************************************//
        private void btnNuevaCat_Click(object sender, EventArgs e)
        {
            Form2 newCatForm = new Form2();
            newCatForm.ShowDialog();
            Categoria nuevaCat = new Categoria();
            nuevaCat.Nombre = newCatForm.Nombre;
            nuevaCat.Gasto = newCatForm.chkGasto;
            nuevaCat.Ingreso = newCatForm.chkIngreso;
            // Comprobar si la nueva categoría ya existe  *****
            // Se añade la nueva categoría a la BD
            AddBDCategoria(nuevaCat);
            // Se actualiza la lista y el diálogo de la pantalla
            LeerBDListaCat();
            ActualizarListaCatDlg();
        }

        private int LeerBDListaCat()
        {
            listaCategorias.Clear();
            conn.Open();
            MySqlCommand instruccion = conn.CreateCommand();
            instruccion.CommandText = "SELECT nombre, gasto, ingreso from categorias";
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                Categoria obj = new Categoria();
                obj.Nombre = reader["nombre"].ToString();
                obj.Gasto = reader.GetBoolean("gasto");
                obj.Ingreso = reader.GetBoolean("ingreso");
                listaCategorias.Add(obj);
            }
            conn.Close();
            return 0;
        }

        private int AddBDCategoria(Categoria newCat)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                short a=0;
                short b=0;
                if (newCat.Gasto) a = 1;
                if (newCat.Ingreso) b = 1;
                instruccion.CommandText = "insert into categorias(nombre,gasto,ingreso) values('"
                    + newCat.Nombre + "','" + a + "','" + b + "');";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

        private int UpdBDCategoria(String oldcat, Categoria cat)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                short a = 0;
                short b = 0;
                if (cat.Gasto) a = 1;
                if (cat.Ingreso) b = 1;
                instruccion.CommandText = "update categorias set nombre = '" + cat.Nombre + "', gasto = '" + a + "', ingreso = '" + b + "' where nombre = '" + oldcat + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int DelBDCategoria(String cat)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "delete from categorias where nombre = '" + cat + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int ActualizarListaCatDlg()
        {
            listCat.Items.Clear();
            foreach(Categoria cat in listaCategorias)
            {
                ListViewItem item1 = new ListViewItem(cat.Nombre, 0);
                if (cat.Gasto == true)
                    item1.SubItems.Add("OK");
                else
                    item1.SubItems.Add("no");

                if (cat.Ingreso == true)
                    item1.SubItems.Add("OK");
                else
                    item1.SubItems.Add("no");

                listCat.Items.Add(item1);
            }
            return 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String cadena = listCat.SelectedItems[0].SubItems[0].Text;
            Categoria item = listaCategorias.Find(x => x.Nombre == cadena);
            Form2 newCatForm = new Form2(item.Nombre, item.Gasto, item.Ingreso);
            // Se muestra el diálogo
            newCatForm.ShowDialog();
            // Se recogen los resultados
            Categoria nuevaCat = new Categoria();
            nuevaCat.Nombre = newCatForm.Nombre;
            nuevaCat.Gasto = newCatForm.chkGasto;
            nuevaCat.Ingreso = newCatForm.chkIngreso;
            // Se actualiza la BD con los datos modificados
            UpdBDCategoria(cadena, nuevaCat);
            // Se actualiza el diálogo y la lista de categorías
            LeerBDListaCat();
            ActualizarListaCatDlg();
        }

        private void btnBorrarCat_Click(object sender, EventArgs e)
        {
            String cadena = listCat.SelectedItems[0].SubItems[0].Text;
            DelBDCategoria(cadena);
            LeerBDListaCat();
            ActualizarListaCatDlg();
        }

        private void listCat_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //***********************************************************************************//
        //******************************* GASTOS ********************************************//
        //***********************************************************************************//
        private int ActualizarListaGastosDlg()
        {
            listGastos.Items.Clear();
            foreach (Gasto gasto in listaGastos)
            {
                ListViewItem item1 = new ListViewItem(gasto.Fecha.ToString("dd/MM/yyyy"), 0);
                item1.SubItems.Add(gasto.Cantidad.ToString());
                item1.SubItems.Add(gasto.Categoria);
                item1.SubItems.Add(gasto.Concepto);
                item1.SubItems.Add(getNombreFormaPago(gasto.FormaPago));
                item1.SubItems.Add(gasto.Etiqueta1);
                item1.SubItems.Add(gasto.Id.ToString());
                if (gasto.Cantidad < 0)
                    item1.ForeColor = Color.Red;
                else
                    item1.ForeColor = Color.Green;
                listGastos.Items.Add(item1);
            }

            calcularGastosTotales();
            calcularDiferencia();
            return 0;
        }

        // Función para Añadir un gasto nuevo
        private void button1_Click(object sender, EventArgs e)
        {
            List<Categoria> listaTemp = new List<Categoria>();
            foreach (Categoria item in listaCategorias)
            {
                if (item.Gasto)
                    listaTemp.Add(item);
            }

            DialogResult dr = new DialogResult();
            FormGasto nuevoGastoForm = new FormGasto(listaTemp, listaFormasPago);
            dr = nuevoGastoForm.ShowDialog();
            Gasto nuevo = new Gasto();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else if (nuevoGastoForm.gasto.Cantidad == 0)
            {
                return;
            }
            else
            {
                nuevo.Categoria = nuevoGastoForm.gasto.Categoria;
                nuevo.Cantidad = nuevoGastoForm.gasto.Cantidad;
                nuevo.Concepto = nuevoGastoForm.gasto.Concepto;
                nuevo.Fecha = nuevoGastoForm.gasto.Fecha;
                //idGastoActual++;
                //nuevo.Id = idGastoActual;
                nuevo.FormaPago = nuevoGastoForm.gasto.FormaPago;
                nuevo.Etiqueta1 = nuevoGastoForm.gasto.Etiqueta1;

                AddDBGasto(nuevo);

                //listaGastos.Add(nuevo);
                LeerBDListaGastos(mesSeleccionado);
                ActualizarListaGastosDlg();
            }
        }

        private int AddDBGasto(Gasto nuevoGasto)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "insert into gastos(cantidad,concepto,categoria,fecha, metodo_pago, Etiqueta1) values('"
                    + nuevoGasto.Cantidad + "','" + nuevoGasto.Concepto + "','" + nuevoGasto.Categoria + "','" + nuevoGasto.Fecha.ToString("yyyy-MM-dd") + "','" + nuevoGasto.FormaPago + "','" + nuevoGasto.Etiqueta1 + "');";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

        private int DelBDGasto(int idGasto)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "delete from gastos where Id = '" + idGasto + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int LeerBDListaGastos()
        {
            try
            {
                listaGastos.Clear();
                idGastoActual = 0;
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "SELECT Id, cantidad, concepto,categoria, fecha, metodo_pago from gastos";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Gasto obj = new Gasto();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    obj.FormaPago = reader.GetInt16("metodo_pago");
                    if (idGastoActual < obj.Id)
                        idGastoActual = obj.Id;
                    listaGastos.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int LeerBDListaGastos(Mes mesSeleccionado)
        {
            try
            {
                listaGastos.Clear();
                idGastoActual = 0;
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                String temp = mesSeleccionado.GetFechaInicioSqlPlus();
                instruccion.CommandText = "SELECT Id, cantidad, concepto,categoria, fecha, metodo_pago, Etiqueta1 from gastos where fecha >= '" + mesSeleccionado.GetFechaInicioSqlPlus() + "' and fecha <= '" + mesSeleccionado.GetFechaFinSqlPlus() + "';";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Gasto obj = new Gasto();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    obj.FormaPago = reader.GetInt16("metodo_pago");
                    obj.Etiqueta1 = reader["Etiqueta1"].ToString();
                    if (idGastoActual < obj.Id)
                        idGastoActual = obj.Id;
                    listaGastos.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int UpdBDGasto(int idOldGasto, Gasto nuevoGasto)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "update gastos set cantidad = '" + nuevoGasto.Cantidad + "', concepto = '" + nuevoGasto.Concepto + "', categoria = '" + nuevoGasto.Categoria + "', fecha = '" + nuevoGasto.Fecha.ToString("yyyy-MM-dd") + "', metodo_pago = '" + nuevoGasto.FormaPago + "', Etiqueta1 = '" + nuevoGasto.Etiqueta1 + "' where Id = '" + idOldGasto + "' and fecha > '" + mesActual.Inicio.ToString("yyyy-MM-dd") + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private void btnEdtGasto_Click(object sender, EventArgs e)
        {
            String strId = listGastos.SelectedItems[0].SubItems[6].Text;
            int id = int.Parse(strId);

            Gasto item = listaGastos.Find(x => x.Id == id);
            //FormGasto edtGastoForm = new FormGasto(listaCategorias, item.Fecha, item.Categoria, item.Concepto, item.Cantidad, listaFormasPago);
            FormGasto edtGastoForm = new FormGasto(listaCategorias, item, listaFormasPago);
            edtGastoForm.ShowDialog();
            if (edtGastoForm.gasto.Cantidad == 0)
                return;
            // Se recogen los resultados
            Gasto nuevoGasto = new Gasto();
            nuevoGasto = edtGastoForm.gasto;
            // Se actualiza la BD con los datos modificados
            UpdBDGasto(id, nuevoGasto);
            // Se actualiza el diálogo y la lista de gastos
            LeerBDListaGastos(mesSeleccionado);
            ActualizarListaGastosDlg();
        }

        private void btnBorrarGasto_Click(object sender, EventArgs e)
        {
            String strId = listGastos.SelectedItems[0].SubItems[6].Text;
            int id = int.Parse(strId);
            // Se borra el Gasto de la BD
            DelBDGasto(id);
            // Se actualiza el diálogo y la lista de gastos
            LeerBDListaGastos(mesSeleccionado);
            ActualizarListaGastosDlg();
        }

        //***********************************************************************************//
        //******************************* INGRESOS ******************************************//
        //***********************************************************************************//
        private int LeerBDListaIngresos()
        {
            try
            {
                listaIngresos.Clear();
                idIngresoActual = 0;

                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "SELECT Id, cantidad, concepto,categoria, fecha from ingresos";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Ingreso obj = new Ingreso();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    if (idIngresoActual < obj.Id)
                        idIngresoActual = obj.Id;
                    listaIngresos.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int LeerBDListaIngresos(Mes mesSeleccionado)
        {
            try
            {
                listaIngresos.Clear();
                idIngresoActual = 0;

                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "SELECT Id, cantidad, concepto,categoria, fecha from ingresos where fecha >= '" + mesSeleccionado.GetFechaInicioSqlPlus() + "' and fecha <= '" + mesSeleccionado.GetFechaFinSqlPlus() + "';";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Ingreso obj = new Ingreso();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    if (idIngresoActual < obj.Id)
                        idIngresoActual = obj.Id;
                    listaIngresos.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int AddDBIngreso(Ingreso nuevoIngreso)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "insert into ingresos(cantidad,concepto,categoria,fecha) values('"
                    + nuevoIngreso.Cantidad + "','" + nuevoIngreso.Concepto + "','" + nuevoIngreso.Categoria + "','" + nuevoIngreso.Fecha.ToString("yyyy-MM-dd") + "');";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

        private int DelBDIngreso(int idIngreso)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "delete from ingresos where Id = '" + idIngreso + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int UpdBDIngreso(int idOldIngreso, Ingreso nuevoIngreso)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "update ingresos set cantidad = '" + nuevoIngreso.Cantidad + "', concepto = '" + nuevoIngreso.Concepto + "', categoria = '" + nuevoIngreso.Categoria + "', fecha = '" + nuevoIngreso.Fecha.ToString("yyyy-MM-dd") + "' where Id = '" + idOldIngreso + "' and fecha > '" + mesActual.Inicio.ToString("yyyy-MM-dd") + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int ActualizarListaIngresosDlg()
        {
            listIngresos.Items.Clear();
            foreach (Ingreso ingreso in listaIngresos)
            {
                ListViewItem item1 = new ListViewItem(ingreso.Fecha.ToString("dd/MM/yyyy"), 0);
                item1.SubItems.Add(ingreso.Cantidad.ToString());
                item1.SubItems.Add(ingreso.Categoria);
                item1.SubItems.Add(ingreso.Concepto);
                item1.SubItems.Add(ingreso.Id.ToString());
                listIngresos.Items.Add(item1);
            }

            calcularIngresosTotales();
            calcularDiferencia();
            return 0;
        }

        // Botón Añadir Ingreso
        private void btnNuevoIngreso_Click(object sender, EventArgs e)
        {
            List<Categoria> listaTemp = new List<Categoria>();
            foreach (Categoria item in listaCategorias)
            {
                if (item.Ingreso)
                    listaTemp.Add(item);
            }
            DialogResult dr = new DialogResult();
            FormIngreso nuevoIngresoForm = new FormIngreso(listaTemp);
            dr = nuevoIngresoForm.ShowDialog();
            Ingreso nuevo = new Ingreso();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else if (nuevoIngresoForm.ingreso.Cantidad == 0)
            {
                return;
            }
            else
            {
                nuevo.Categoria = nuevoIngresoForm.ingreso.Categoria;
                nuevo.Cantidad = nuevoIngresoForm.ingreso.Cantidad;
                nuevo.Concepto = nuevoIngresoForm.ingreso.Concepto;
                nuevo.Fecha = nuevoIngresoForm.ingreso.Fecha;
                //idIngresoActual++;
                //nuevo.Id = idIngresoActual;

                AddDBIngreso(nuevo);

                LeerBDListaIngresos(mesSeleccionado);
                ActualizarListaIngresosDlg();
            }
        }

        private void btnEdtIngreso_Click(object sender, EventArgs e)
        {
            List<Categoria> listaTemp = new List<Categoria>();
            foreach (Categoria item in listaCategorias)
            {
                if (item.Ingreso)
                    listaTemp.Add(item);
            }

            String strId = listIngresos.SelectedItems[0].SubItems[4].Text;
            int id = int.Parse(strId);

            Ingreso obj = listaIngresos.Find(x => x.Id == id);
            FormIngreso edtIngForm = new FormIngreso(listaTemp, obj.Fecha, obj.Categoria, obj.Concepto, obj.Cantidad);
            edtIngForm.ShowDialog();
            // Se recogen los resultados
            Ingreso nuevoIngreso = new Ingreso();
            nuevoIngreso = edtIngForm.ingreso;
            // Se actualiza la BD con los datos modificados
            UpdBDIngreso(id, nuevoIngreso);
            // Se actualiza el diálogo y la lista de ingresos
            LeerBDListaIngresos(mesSeleccionado);
            ActualizarListaIngresosDlg();
        }

        private void btnBorrarIngreso_Click(object sender, EventArgs e)
        {
            String strId = listIngresos.SelectedItems[0].SubItems[4].Text;
            int id = int.Parse(strId);
            // Se borra el ingreso de la BD
            DelBDIngreso(id);
            // Se actualiza el diálogo y la lista de ingresos
            LeerBDListaIngresos(mesSeleccionado);
            ActualizarListaIngresosDlg();
        }

        private void tabGastos_Click(object sender, EventArgs e)
        {
            ConfigAparienciaDlg();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigAparienciaDlg();
        }

        //***********************************************************************************//
        //******************************* CALCULOS ******************************************//
        //***********************************************************************************//

        private int calcularGastosTotales()
        {
            totalGastos = 0;
            foreach (Gasto item in listaGastos)
            {
                totalGastos += item.Cantidad;
            }

            edtTotalGastos.Text = totalGastos.ToString();
            return 0;
        }

        private int calcularIngresosTotales()
        {
            totalIngresos = 0;
            foreach (Ingreso item in listaIngresos)
            {
                totalIngresos += item.Cantidad;
            }

            edtTotalIng.Text = totalIngresos.ToString();
            return 0;
        }

        private int calcularDiferencia()
        {
            txtBoxDiferencia.Text = (totalIngresos + totalGastos).ToString();
            return 0;
        }

        private int calcularResumenGastos()
        {
            listResumen.Items.Clear();

            // La lista de Previsiones tiene que tener un elemento por cada categoría de Gasto. Aunque la
            // previsión sea de 0€.
            float totalPrevisto = 0;

            // Hay que recorrer esa lista y compararla con la de gastos y con eso crear la lista Balance.
            foreach (Prevision it1 in listaGastosPrevistos)
            {
                ListViewItem item1 = new ListViewItem(it1.Categoria, 0);
                item1.SubItems.Add(it1.Cantidad.ToString());
                
                float gastototal = 0;
                float balance = 0;
                foreach (Gasto it2 in listaGastos)
                {
                    if (it2.Categoria == it1.Categoria)
                    {
                        gastototal += it2.Cantidad;
                    }
                }
                item1.SubItems.Add(gastototal.ToString());
                balance = it1.Cantidad + gastototal;
                if (balance >= 0)
                    item1.ForeColor = Color.Green;
                else
                    item1.ForeColor = Color.Red;
                item1.SubItems.Add(balance.ToString());

                if (it1.Cantidad != 0)
                    item1.SubItems.Add(((gastototal / it1.Cantidad)*100).ToString());
                else
                    item1.SubItems.Add("---");

                listResumen.Items.Add(item1);

                totalPrevisto += it1.Cantidad;
            }
            
            // Hacemos un cálculo del total previsto y gastado.
            ListViewItem item2 = new ListViewItem("TOTAL", 0);
            item2.SubItems.Add(totalPrevisto.ToString());
            item2.SubItems.Add(totalGastos.ToString());
            item2.SubItems.Add((totalPrevisto + totalGastos).ToString());

            item2.SubItems.Add(((totalGastos / totalPrevisto)*100).ToString());

            listResumen.Items.Add(item2);

            txtBoxTotalPrev.Text = totalPrevisto.ToString();
            txtBoxTotalGas.Text = totalGastos.ToString();
            txtBoxTotalBal.Text = (totalPrevisto + totalGastos).ToString();
            float tmp = totalGastos / totalPrevisto;
            txtBoxPorcent.Text = ((totalGastos / totalPrevisto) * 100).ToString();
            
            return 0;
        }

        private int calcularGastosXFormaPago()
        {
            float suma = 0;
            listGastosXMetodo.Items.Clear();
            foreach (FormaPago it in listaFormasPago)
            {
                suma = 0;
                ListViewItem item1 = new ListViewItem(it.Nombre, 0);
                foreach (Gasto it2 in listaGastos)
                {
                    if (it2.FormaPago == it.Id)
                    {
                        suma += it2.Cantidad;
                    }
                }
                item1.SubItems.Add(suma.ToString());
                listGastosXMetodo.Items.Add(item1);
            }
            return 0;
        }

        private void actualizarListaResumen()
        {
        }

        private int calcularGastosXEtiqueta()
        {
            float suma = 0;
            listGastosEtiqueta.Items.Clear();

            foreach (Gasto it in listaGastosAux)
            {
                ListViewItem item1 = new ListViewItem(it.Fecha.ToString(), 0);
                item1.SubItems.Add(it.Concepto);
                item1.SubItems.Add(it.Categoria);
                item1.SubItems.Add(it.Cantidad.ToString());
                suma += it.Cantidad;

                listGastosEtiqueta.Items.Add(item1);
            }
            txtBoxTotalEtiqueta.Text = suma.ToString();
            return 0;
        }

        //***********************************************************************************//
        //******************************* PREVISION *****************************************//
        //***********************************************************************************//
        
        /*
         * Inserta un objeto Previsión en la BD.
         * 
         */
        private int AddDBGastoPrev(Prevision nuevaPrev)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "insert into prevision(Id,cantidad,concepto,categoria,fecha, mes, anno) values('"
                    + nuevaPrev.Id + "','" + nuevaPrev.Cantidad + "','" + nuevaPrev.Concepto + "','" + nuevaPrev.Categoria + "','" + nuevaPrev.Fecha.ToString("yyyy-MM-dd") + "','" + nuevaPrev.Mes + "','" + nuevaPrev.Anno + "');";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

        /*
         * Esta función Borra de la BD las TODAS las previsiones del mes actual
         * El parámetro idPrev no hace nada; no se utiliza.
         */
        private int DelBDGastoPrev(int idPrev)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "delete from prevision where mes = '" + mesActual.Nombre + "' and anno = '" + mesActual.Anno + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int LeerBDListaGastosPrev()
        {
            try
            {
                listaGastosPrevistos.Clear();
                idGastoPrevActual = 0;
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "SELECT Id, cantidad, concepto,categoria, fecha, mes, anno from prevision";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Prevision obj = new Prevision();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    obj.Mes = reader["mes"].ToString();
                    obj.Anno = reader.GetInt16("anno");
                    if (idGastoPrevActual < obj.Id)
                        idGastoPrevActual = obj.Id;
                    listaGastosPrevistos.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        /*
         * Lee de la BD la Previsión del mes que se le pasa como parámetro. 
         * Si no hay previsión para ese mes, se muestra un mensaje indicándolo, se inhabilita la lista
         * y se habilita el botón de "Nueva Previsión"
         * 
         * Esta función solo tiene sentido utilizarla para ver la previsión del Mes Actual.
         * */
        private int LeerBDListaGastosPrev(Mes mesSeleccionado)
        {
            try
            {
                listaGastosPrevistos.Clear();
                idGastoPrevActual = 0;
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "SELECT Id, cantidad, concepto,categoria, fecha, mes, anno from prevision where mes = '" + mesSeleccionado.Nombre + "' and anno = '" + mesSeleccionado.Anno + "';";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Prevision obj = new Prevision();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    obj.Mes = reader["mes"].ToString();
                    obj.Anno = reader.GetInt16("anno");
                    if (idGastoPrevActual < obj.Id)
                        idGastoPrevActual = obj.Id;
                    listaGastosPrevistos.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Si la lista de Gastos Previstos esta vacía, se crea una con todas las previsiones a 0
            if (listaGastosPrevistos.Count == 0)
            {
                //CrearPrevisionVacia();
                btnAddPrev.Enabled = true;
                listPrev.Enabled = false;
                hayPrevisionMensual = false;
                textMsgPrevisiones.Text = "No hay previsiones creadas para este mes.";
            }
            else
            {
                btnAddPrev.Enabled = false;
                listPrev.Enabled = true;
                hayPrevisionMensual = true;
                textMsgPrevisiones.Text = "";
            }

            return 0;
        }

        /*
         * Crea una Previsión (objeto Previsión) con el mes y año actuales y los valores a un 
         * valor por defecto de 100.
         * Además, añade esta Previsión a la BD. Será la Previsión del Mes Actual.
         * */
        private void CrearPrevisionVacia()
        {
            // Se crea la lista con todas las previsiones a 0 y se almacena en la BD
            foreach (Categoria cat in listaCategorias)
            {
                Prevision nPrev = new Prevision();
                if (cat.Gasto)
                {
                    idGastoPrevActual++;
                    nPrev.Id = idGastoPrevActual;
                    nPrev.Categoria = cat.Nombre;
                    nPrev.Cantidad = 100;
                    nPrev.Fecha = mesActual.Inicio;
                    nPrev.Concepto = "";
                    nPrev.Mes = mesActual.Nombre;
                    nPrev.Anno = mesActual.Anno;
                    listaGastosPrevistos.Add(nPrev);

                    AddDBGastoPrev(nPrev);
                }
            }
        }

        /* Actualiza un registro en la tabla "prevision" de la BD
         * Se le pasa el id del antiguo registro y el nuevo registro.
         * Hay que tener en cuenta que actualiza el registro con ese "id" DEL MES ACTUAL
         * */
        private int UpdBDGastoPrev(int idOldGasto, Prevision nuevaPrev)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "update prevision set cantidad = '" + nuevaPrev.Cantidad + "' where Id = '" + idOldGasto + "' and mes = '" + mesActual.Nombre + "' and anno = '" + mesActual.Anno + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int ActualizarListaPrevisionDlg()
        {
            listPrev.Items.Clear();
            foreach (Prevision prev in listaGastosPrevistos)
            {
                ListViewItem item1 = new ListViewItem(prev.Categoria, 0);
                item1.SubItems.Add(prev.Cantidad.ToString());
                //item1.SubItems.Add(gasto.Fecha.ToString());
                //item1.SubItems.Add(gasto.Concepto);
                item1.SubItems.Add(prev.Id.ToString());
                listPrev.Items.Add(item1);
            }

            //calcularGastosTotales();
            return 0;
        }

        /*
         * Esta función crea una previsión de gastos vacía (con valores por defecto),
         * la guarda en la BD y la muestra en la ventana de Previsiones. 
         */
        private void btnAddPrev_Click(object sender, EventArgs e)
        {
            if (hayPrevisionMensual == false)
            {
                CrearPrevisionVacia();
                LeerBDListaGastosPrev(mesActual);
                ActualizarListaPrevisionDlg();
            }
        }

        private void btnEditPrev_Click(object sender, EventArgs e)
        {
            String strId = listPrev.SelectedItems[0].SubItems[2].Text;
            int id = int.Parse(strId);

            Prevision item = listaGastosPrevistos.Find(x => x.Id == id);
            //Gasto item = listaGastosPrevistos.Find(x => x.Id == id);
            //FormGasto edtGastoForm = new FormGasto(listaCategorias, item.Fecha, item.Categoria, item.Concepto, item.Cantidad);
            //edtGastoForm.ShowDialog();
            FormGastoPrevisto edtGastoPrev = new FormGastoPrevisto(listaCategorias, item);
            edtGastoPrev.ShowDialog();
            // Se recogen los resultados
            Prevision nuevaPrev = new Prevision();
            nuevaPrev = edtGastoPrev.prev;
            //Gasto nuevoGasto = new Gasto();
            //nuevoGasto = edtGastoForm.gasto;
            // Se actualiza la BD con los datos modificados
            UpdBDGastoPrev(id, nuevaPrev);
            //UpdBDGastoPrev(id, nuevoGasto);
            // Se actualiza el diálogo y la lista de gastos Previstos
            LeerBDListaGastosPrev(mesSeleccionado);
            ActualizarListaPrevisionDlg();
        }

        private void btnBorrarPrev_Click(object sender, EventArgs e)
        {
            DelBDGastoPrev(0);
            // Se actualiza el diálogo y la lista de gastos Previstos
            LeerBDListaGastosPrev(mesSeleccionado);
            ActualizarListaPrevisionDlg();

            /*String strId = listPrev.SelectedItems[0].SubItems[2].Text;
            int id = int.Parse(strId);
            // Se borra el Gasto de la BD
            DelBDGastoPrev(id);
            // Se actualiza el diálogo y la lista de gastos
            LeerBDListaGastosPrev();
            ActualizarListaPrevisionDlg();*/
        }


        //***********************************************************************************//
        //*********************************** MESES *****************************************//
        //***********************************************************************************//

        // Leer lista de meses
        private int LeerBDListaMeses()
        {
            try
            {
                listaMeses.Clear();

                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "SELECT nombre, anno, inicio,fin from meses";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Mes obj = new Mes();

                    obj.Nombre = reader["nombre"].ToString();
                    obj.Anno = reader.GetInt16("anno");
                    obj.Inicio = reader.GetDateTime("inicio");
                    if (reader.GetDateTime("fin").Year != 3000)
                    {
                        obj.Fin = reader.GetDateTime("fin");
                    }
                    else
                    {
                        mesActual = obj;
                        mesSeleccionado = mesActual;
                    }
                    listaMeses.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int AddDBNuevoMes(Mes nuevoMes)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "insert into meses(nombre,anno,inicio,fin) values('"
                    + nuevoMes.Nombre + "','" + nuevoMes.Anno + "','" + nuevoMes.Inicio.ToString("yyyy-MM-dd") + "','" + nuevoMes.Fin.ToString("yyyy-MM-dd") + "');";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

        private int UpdBDMesAnterior(Mes actual, Mes nuevoMes)
        {
            try
            {
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "update meses set fin = '" + nuevoMes.Inicio.AddDays(-1).ToString("yyyy-MM-dd") + "' where nombre = '" + actual.Nombre + "' and anno = '" + actual.Anno + "';";
                instruccion.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 0;
        }

        // A esta función se la llama con el botón "Nuevo Mes". Abre el diálogo Nuevo Mes, recoge los datos
        // y, si hay que establecer un Mes Nuevo, lo añade a la BD. Además, modifica el registro de la BD 
        // del mes anterior para cambiar la fecha de fin y poner la fecha en la que empieza este nuevo mes.
        private void button2_Click(object sender, EventArgs e)
        {
            int error = 0;
            NuevoMes nuevoMesForm = new NuevoMes(mesActual);
            nuevoMesForm.ShowDialog();
            // Se recogen los resultados
            // Imagino que tiene que haber otra forma de recoger los resultados, porque si se sale del
            // diálogo sin hacer cambios, esta parte se ejecuta igual, y eso no debería ser así.
            if (nuevoMesForm.btnCancelar == 1)
            {
                Mes nuevoMes = new Mes();
                nuevoMes = nuevoMesForm.mes;
                error = UpdBDMesAnterior(mesActual, nuevoMes);
                if (error == 0)
                    AddDBNuevoMes(nuevoMes);
            }
        }

        private void cmbBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String nuevoMesSeleccionado = cmbBoxMes.SelectedItem.ToString();
            foreach (Mes it in listaMeses)
            {
                if (it.Nombre + it.Anno.ToString() == nuevoMesSeleccionado)
                    mesSeleccionado = it;
            }

            // Hay que recargar las listas de Gastos, Ingresos y previsiones (con el nuevo mes)
            // y calcular el nuevo balance de ese mes
            LeerBDListaGastos(mesSeleccionado);
            ActualizarListaGastosDlg();
            LeerBDListaIngresos(mesSeleccionado);
            ActualizarListaIngresosDlg();
            LeerBDListaGastosPrev(mesSeleccionado);
            ActualizarListaPrevisionDlg();
            calcularDiferencia();
        }

        
        //*************************************** ETIQUETAS ****************************//
        private int LeerBDEtiquetas()
        {
            try
            {
                listaEtiquetas.Clear();
                
                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                instruccion.CommandText = "SELECT distinct Etiqueta1 from gastos";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaEtiquetas.Add(reader["Etiqueta1"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private int LeerBDGastosXEtiqueta(String etiq1)
        {
            try
            {
                listaGastosAux.Clear();

                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                String temp = mesSeleccionado.GetFechaInicioSqlPlus();
                instruccion.CommandText = "SELECT Id, cantidad, concepto,categoria, fecha, metodo_pago, Etiqueta1 from gastos where Etiqueta1 = '" + etiq1 + "';";
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Gasto obj = new Gasto();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    obj.FormaPago = reader.GetInt16("metodo_pago");
                    obj.Etiqueta1 = reader["Etiqueta1"].ToString();
                    listaGastosAux.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private void cmbEtiqueta1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeerBDGastosXEtiqueta(cmbEtiqueta1.SelectedItem.ToString());
            calcularGastosXEtiqueta();
        }

        private void ActualizarCmbEtiquetas()
        {
            foreach (String cad in listaEtiquetas)
            {
                cmbEtiqueta1.Items.Add(cad);
            }
        }

        // Función para buscar un gasto por el texto que se le pase. Lo guarda en una lista listaGastosAux2
        // Hay que ver qué se hace con esta lista y donde se muestra.
        private int BuscarBDGastosXTexto(String texto)
        {
            try
            {
                listaGastosAux2.Clear();

                conn.Open();
                MySqlCommand instruccion = conn.CreateCommand();
                String temp = mesSeleccionado.GetFechaInicioSqlPlus();
                instruccion.CommandText = "SELECT from gastos where (lower(concepto) like lower('%" + texto + "%')) or (lower(categoria) like lower('%" + texto + "%')) or (lower(Etiqueta1) like lower('%" + texto + "%'));";

                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    Gasto obj = new Gasto();
                    obj.Id = reader.GetInt16("Id");
                    obj.Cantidad = reader.GetFloat("cantidad");
                    obj.Concepto = reader["concepto"].ToString();
                    obj.Categoria = reader["categoria"].ToString();
                    obj.Fecha = reader.GetDateTime("fecha");
                    obj.FormaPago = reader.GetInt16("metodo_pago");
                    obj.Etiqueta1 = reader["Etiqueta1"].ToString();
                    listaGastosAux.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        

        

       

        

    }
}
