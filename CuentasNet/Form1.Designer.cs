namespace CuentasNet
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGastos = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxDiferencia = new System.Windows.Forms.TextBox();
            this.edtTotalIng = new System.Windows.Forms.TextBox();
            this.listGastos = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEdtGasto = new System.Windows.Forms.Button();
            this.btnBorrarGasto = new System.Windows.Forms.Button();
            this.edtTotalGastos = new System.Windows.Forms.TextBox();
            this.listIngresos = new System.Windows.Forms.ListView();
            this.btnBorrarIngreso = new System.Windows.Forms.Button();
            this.btnNuevoIngreso = new System.Windows.Forms.Button();
            this.btnEdtIngreso = new System.Windows.Forms.Button();
            this.tabPrev = new System.Windows.Forms.TabPage();
            this.btnBorrarPrev = new System.Windows.Forms.Button();
            this.listPrev = new System.Windows.Forms.ListView();
            this.btnEditPrev = new System.Windows.Forms.Button();
            this.btnAddPrev = new System.Windows.Forms.Button();
            this.tabCat = new System.Windows.Forms.TabPage();
            this.listCat = new System.Windows.Forms.ListView();
            this.btnNuevaCat = new System.Windows.Forms.Button();
            this.btnEditCat = new System.Windows.Forms.Button();
            this.btnBorrarCat = new System.Windows.Forms.Button();
            this.tabResumen = new System.Windows.Forms.TabPage();
            this.cmbEtiqueta1 = new System.Windows.Forms.ComboBox();
            this.txtBoxTotalEtiqueta = new System.Windows.Forms.TextBox();
            this.listGastosEtiqueta = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxPorcent = new System.Windows.Forms.TextBox();
            this.txtBoxTotalBal = new System.Windows.Forms.TextBox();
            this.txtBoxTotalGas = new System.Windows.Forms.TextBox();
            this.listGastosXMetodo = new System.Windows.Forms.ListView();
            this.txtBoxTotalPrev = new System.Windows.Forms.TextBox();
            this.listResumen = new System.Windows.Forms.ListView();
            this.tabMeses = new System.Windows.Forms.TabPage();
            this.txtBoxFormaPago = new System.Windows.Forms.TextBox();
            this.btnAddFormaPago = new System.Windows.Forms.Button();
            this.listFormasPago = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbBoxMes = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabGastos.SuspendLayout();
            this.tabPrev.SuspendLayout();
            this.tabCat.SuspendLayout();
            this.tabResumen.SuspendLayout();
            this.tabMeses.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGastos);
            this.tabControl1.Controls.Add(this.tabPrev);
            this.tabControl1.Controls.Add(this.tabCat);
            this.tabControl1.Controls.Add(this.tabResumen);
            this.tabControl1.Controls.Add(this.tabMeses);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 388);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabGastos
            // 
            this.tabGastos.Controls.Add(this.label1);
            this.tabGastos.Controls.Add(this.txtBoxDiferencia);
            this.tabGastos.Controls.Add(this.edtTotalIng);
            this.tabGastos.Controls.Add(this.listGastos);
            this.tabGastos.Controls.Add(this.button1);
            this.tabGastos.Controls.Add(this.btnEdtGasto);
            this.tabGastos.Controls.Add(this.btnBorrarGasto);
            this.tabGastos.Controls.Add(this.edtTotalGastos);
            this.tabGastos.Controls.Add(this.listIngresos);
            this.tabGastos.Controls.Add(this.btnBorrarIngreso);
            this.tabGastos.Controls.Add(this.btnNuevoIngreso);
            this.tabGastos.Controls.Add(this.btnEdtIngreso);
            this.tabGastos.Location = new System.Drawing.Point(4, 22);
            this.tabGastos.Name = "tabGastos";
            this.tabGastos.Padding = new System.Windows.Forms.Padding(3);
            this.tabGastos.Size = new System.Drawing.Size(807, 362);
            this.tabGastos.TabIndex = 0;
            this.tabGastos.Text = "Gastos";
            this.tabGastos.UseVisualStyleBackColor = true;
            this.tabGastos.Click += new System.EventHandler(this.tabGastos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Balance";
            // 
            // txtBoxDiferencia
            // 
            this.txtBoxDiferencia.Enabled = false;
            this.txtBoxDiferencia.Location = new System.Drawing.Point(699, 336);
            this.txtBoxDiferencia.Name = "txtBoxDiferencia";
            this.txtBoxDiferencia.Size = new System.Drawing.Size(100, 20);
            this.txtBoxDiferencia.TabIndex = 16;
            this.txtBoxDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtTotalIng
            // 
            this.edtTotalIng.Location = new System.Drawing.Point(699, 109);
            this.edtTotalIng.Name = "edtTotalIng";
            this.edtTotalIng.Size = new System.Drawing.Size(100, 20);
            this.edtTotalIng.TabIndex = 15;
            // 
            // listGastos
            // 
            this.listGastos.FullRowSelect = true;
            this.listGastos.GridLines = true;
            this.listGastos.Location = new System.Drawing.Point(6, 17);
            this.listGastos.MultiSelect = false;
            this.listGastos.Name = "listGastos";
            this.listGastos.Size = new System.Drawing.Size(388, 310);
            this.listGastos.TabIndex = 1;
            this.listGastos.UseCompatibleStateImageBehavior = false;
            this.listGastos.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nuevo Gasto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEdtGasto
            // 
            this.btnEdtGasto.Location = new System.Drawing.Point(118, 333);
            this.btnEdtGasto.Name = "btnEdtGasto";
            this.btnEdtGasto.Size = new System.Drawing.Size(75, 23);
            this.btnEdtGasto.TabIndex = 8;
            this.btnEdtGasto.Text = "Editar";
            this.btnEdtGasto.UseVisualStyleBackColor = true;
            this.btnEdtGasto.Click += new System.EventHandler(this.btnEdtGasto_Click);
            // 
            // btnBorrarGasto
            // 
            this.btnBorrarGasto.Location = new System.Drawing.Point(211, 333);
            this.btnBorrarGasto.Name = "btnBorrarGasto";
            this.btnBorrarGasto.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarGasto.TabIndex = 9;
            this.btnBorrarGasto.Text = "Borrar";
            this.btnBorrarGasto.UseVisualStyleBackColor = true;
            this.btnBorrarGasto.Click += new System.EventHandler(this.btnBorrarGasto_Click);
            // 
            // edtTotalGastos
            // 
            this.edtTotalGastos.Location = new System.Drawing.Point(294, 333);
            this.edtTotalGastos.Name = "edtTotalGastos";
            this.edtTotalGastos.Size = new System.Drawing.Size(100, 20);
            this.edtTotalGastos.TabIndex = 14;
            // 
            // listIngresos
            // 
            this.listIngresos.FullRowSelect = true;
            this.listIngresos.Location = new System.Drawing.Point(411, 17);
            this.listIngresos.Name = "listIngresos";
            this.listIngresos.Size = new System.Drawing.Size(388, 72);
            this.listIngresos.TabIndex = 10;
            this.listIngresos.UseCompatibleStateImageBehavior = false;
            this.listIngresos.View = System.Windows.Forms.View.Details;
            // 
            // btnBorrarIngreso
            // 
            this.btnBorrarIngreso.Location = new System.Drawing.Point(616, 109);
            this.btnBorrarIngreso.Name = "btnBorrarIngreso";
            this.btnBorrarIngreso.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarIngreso.TabIndex = 13;
            this.btnBorrarIngreso.Text = "Borrar";
            this.btnBorrarIngreso.UseVisualStyleBackColor = true;
            this.btnBorrarIngreso.Click += new System.EventHandler(this.btnBorrarIngreso_Click);
            // 
            // btnNuevoIngreso
            // 
            this.btnNuevoIngreso.Location = new System.Drawing.Point(411, 109);
            this.btnNuevoIngreso.Name = "btnNuevoIngreso";
            this.btnNuevoIngreso.Size = new System.Drawing.Size(99, 23);
            this.btnNuevoIngreso.TabIndex = 11;
            this.btnNuevoIngreso.Text = "Nuevo Ingreso";
            this.btnNuevoIngreso.UseVisualStyleBackColor = true;
            this.btnNuevoIngreso.Click += new System.EventHandler(this.btnNuevoIngreso_Click);
            // 
            // btnEdtIngreso
            // 
            this.btnEdtIngreso.Location = new System.Drawing.Point(523, 109);
            this.btnEdtIngreso.Name = "btnEdtIngreso";
            this.btnEdtIngreso.Size = new System.Drawing.Size(75, 23);
            this.btnEdtIngreso.TabIndex = 12;
            this.btnEdtIngreso.Text = "Editar";
            this.btnEdtIngreso.UseVisualStyleBackColor = true;
            this.btnEdtIngreso.Click += new System.EventHandler(this.btnEdtIngreso_Click);
            // 
            // tabPrev
            // 
            this.tabPrev.Controls.Add(this.btnBorrarPrev);
            this.tabPrev.Controls.Add(this.listPrev);
            this.tabPrev.Controls.Add(this.btnEditPrev);
            this.tabPrev.Controls.Add(this.btnAddPrev);
            this.tabPrev.Location = new System.Drawing.Point(4, 22);
            this.tabPrev.Name = "tabPrev";
            this.tabPrev.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrev.Size = new System.Drawing.Size(807, 362);
            this.tabPrev.TabIndex = 1;
            this.tabPrev.Text = "Prevision";
            this.tabPrev.UseVisualStyleBackColor = true;
            // 
            // btnBorrarPrev
            // 
            this.btnBorrarPrev.Location = new System.Drawing.Point(238, 333);
            this.btnBorrarPrev.Name = "btnBorrarPrev";
            this.btnBorrarPrev.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarPrev.TabIndex = 19;
            this.btnBorrarPrev.Text = "Borrar";
            this.btnBorrarPrev.UseVisualStyleBackColor = true;
            this.btnBorrarPrev.Click += new System.EventHandler(this.btnBorrarPrev_Click);
            // 
            // listPrev
            // 
            this.listPrev.Location = new System.Drawing.Point(31, 17);
            this.listPrev.Name = "listPrev";
            this.listPrev.Size = new System.Drawing.Size(307, 310);
            this.listPrev.TabIndex = 20;
            this.listPrev.UseCompatibleStateImageBehavior = false;
            this.listPrev.View = System.Windows.Forms.View.Details;
            // 
            // btnEditPrev
            // 
            this.btnEditPrev.Location = new System.Drawing.Point(143, 333);
            this.btnEditPrev.Name = "btnEditPrev";
            this.btnEditPrev.Size = new System.Drawing.Size(75, 23);
            this.btnEditPrev.TabIndex = 18;
            this.btnEditPrev.Text = "Editar";
            this.btnEditPrev.UseVisualStyleBackColor = true;
            this.btnEditPrev.Click += new System.EventHandler(this.btnEditPrev_Click);
            // 
            // btnAddPrev
            // 
            this.btnAddPrev.Location = new System.Drawing.Point(47, 333);
            this.btnAddPrev.Name = "btnAddPrev";
            this.btnAddPrev.Size = new System.Drawing.Size(75, 23);
            this.btnAddPrev.TabIndex = 17;
            this.btnAddPrev.Text = "Nueva Prev";
            this.btnAddPrev.UseVisualStyleBackColor = true;
            this.btnAddPrev.Click += new System.EventHandler(this.btnAddPrev_Click);
            // 
            // tabCat
            // 
            this.tabCat.Controls.Add(this.listCat);
            this.tabCat.Controls.Add(this.btnNuevaCat);
            this.tabCat.Controls.Add(this.btnEditCat);
            this.tabCat.Controls.Add(this.btnBorrarCat);
            this.tabCat.Location = new System.Drawing.Point(4, 22);
            this.tabCat.Name = "tabCat";
            this.tabCat.Size = new System.Drawing.Size(807, 362);
            this.tabCat.TabIndex = 2;
            this.tabCat.Text = "Categorias";
            this.tabCat.UseVisualStyleBackColor = true;
            // 
            // listCat
            // 
            this.listCat.Location = new System.Drawing.Point(31, 17);
            this.listCat.Name = "listCat";
            this.listCat.Size = new System.Drawing.Size(311, 306);
            this.listCat.TabIndex = 3;
            this.listCat.UseCompatibleStateImageBehavior = false;
            this.listCat.View = System.Windows.Forms.View.Details;
            this.listCat.SelectedIndexChanged += new System.EventHandler(this.listCat_SelectedIndexChanged);
            // 
            // btnNuevaCat
            // 
            this.btnNuevaCat.Location = new System.Drawing.Point(50, 332);
            this.btnNuevaCat.Name = "btnNuevaCat";
            this.btnNuevaCat.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaCat.TabIndex = 4;
            this.btnNuevaCat.Text = "Nueva";
            this.btnNuevaCat.UseVisualStyleBackColor = true;
            this.btnNuevaCat.Click += new System.EventHandler(this.btnNuevaCat_Click);
            // 
            // btnEditCat
            // 
            this.btnEditCat.Location = new System.Drawing.Point(148, 332);
            this.btnEditCat.Name = "btnEditCat";
            this.btnEditCat.Size = new System.Drawing.Size(75, 23);
            this.btnEditCat.TabIndex = 7;
            this.btnEditCat.Text = "Editar";
            this.btnEditCat.UseVisualStyleBackColor = true;
            this.btnEditCat.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnBorrarCat
            // 
            this.btnBorrarCat.Location = new System.Drawing.Point(244, 332);
            this.btnBorrarCat.Name = "btnBorrarCat";
            this.btnBorrarCat.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarCat.TabIndex = 6;
            this.btnBorrarCat.Text = "Borrar";
            this.btnBorrarCat.UseVisualStyleBackColor = true;
            this.btnBorrarCat.Click += new System.EventHandler(this.btnBorrarCat_Click);
            // 
            // tabResumen
            // 
            this.tabResumen.Controls.Add(this.cmbEtiqueta1);
            this.tabResumen.Controls.Add(this.txtBoxTotalEtiqueta);
            this.tabResumen.Controls.Add(this.listGastosEtiqueta);
            this.tabResumen.Controls.Add(this.label2);
            this.tabResumen.Controls.Add(this.txtBoxPorcent);
            this.tabResumen.Controls.Add(this.txtBoxTotalBal);
            this.tabResumen.Controls.Add(this.txtBoxTotalGas);
            this.tabResumen.Controls.Add(this.listGastosXMetodo);
            this.tabResumen.Controls.Add(this.txtBoxTotalPrev);
            this.tabResumen.Controls.Add(this.listResumen);
            this.tabResumen.Location = new System.Drawing.Point(4, 22);
            this.tabResumen.Name = "tabResumen";
            this.tabResumen.Size = new System.Drawing.Size(807, 362);
            this.tabResumen.TabIndex = 3;
            this.tabResumen.Text = "Resumen";
            this.tabResumen.UseVisualStyleBackColor = true;
            // 
            // cmbEtiqueta1
            // 
            this.cmbEtiqueta1.FormattingEnabled = true;
            this.cmbEtiqueta1.Location = new System.Drawing.Point(460, 42);
            this.cmbEtiqueta1.Name = "cmbEtiqueta1";
            this.cmbEtiqueta1.Size = new System.Drawing.Size(121, 21);
            this.cmbEtiqueta1.TabIndex = 26;
            this.cmbEtiqueta1.SelectedIndexChanged += new System.EventHandler(this.cmbEtiqueta1_SelectedIndexChanged);
            // 
            // txtBoxTotalEtiqueta
            // 
            this.txtBoxTotalEtiqueta.Location = new System.Drawing.Point(524, 184);
            this.txtBoxTotalEtiqueta.Name = "txtBoxTotalEtiqueta";
            this.txtBoxTotalEtiqueta.Size = new System.Drawing.Size(57, 20);
            this.txtBoxTotalEtiqueta.TabIndex = 25;
            // 
            // listGastosEtiqueta
            // 
            this.listGastosEtiqueta.Location = new System.Drawing.Point(438, 69);
            this.listGastosEtiqueta.Name = "listGastosEtiqueta";
            this.listGastosEtiqueta.Size = new System.Drawing.Size(143, 97);
            this.listGastosEtiqueta.TabIndex = 24;
            this.listGastosEtiqueta.UseCompatibleStateImageBehavior = false;
            this.listGastosEtiqueta.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "%";
            // 
            // txtBoxPorcent
            // 
            this.txtBoxPorcent.Location = new System.Drawing.Point(399, 321);
            this.txtBoxPorcent.Name = "txtBoxPorcent";
            this.txtBoxPorcent.Size = new System.Drawing.Size(62, 20);
            this.txtBoxPorcent.TabIndex = 22;
            // 
            // txtBoxTotalBal
            // 
            this.txtBoxTotalBal.Location = new System.Drawing.Point(314, 321);
            this.txtBoxTotalBal.Name = "txtBoxTotalBal";
            this.txtBoxTotalBal.Size = new System.Drawing.Size(57, 20);
            this.txtBoxTotalBal.TabIndex = 21;
            // 
            // txtBoxTotalGas
            // 
            this.txtBoxTotalGas.Location = new System.Drawing.Point(226, 321);
            this.txtBoxTotalGas.Name = "txtBoxTotalGas";
            this.txtBoxTotalGas.Size = new System.Drawing.Size(66, 20);
            this.txtBoxTotalGas.TabIndex = 20;
            // 
            // listGastosXMetodo
            // 
            this.listGastosXMetodo.Location = new System.Drawing.Point(670, 21);
            this.listGastosXMetodo.Name = "listGastosXMetodo";
            this.listGastosXMetodo.Size = new System.Drawing.Size(121, 97);
            this.listGastosXMetodo.TabIndex = 19;
            this.listGastosXMetodo.UseCompatibleStateImageBehavior = false;
            this.listGastosXMetodo.View = System.Windows.Forms.View.Details;
            // 
            // txtBoxTotalPrev
            // 
            this.txtBoxTotalPrev.Location = new System.Drawing.Point(139, 321);
            this.txtBoxTotalPrev.Name = "txtBoxTotalPrev";
            this.txtBoxTotalPrev.Size = new System.Drawing.Size(63, 20);
            this.txtBoxTotalPrev.TabIndex = 17;
            // 
            // listResumen
            // 
            this.listResumen.Location = new System.Drawing.Point(25, 21);
            this.listResumen.Name = "listResumen";
            this.listResumen.Size = new System.Drawing.Size(362, 294);
            this.listResumen.TabIndex = 16;
            this.listResumen.UseCompatibleStateImageBehavior = false;
            this.listResumen.View = System.Windows.Forms.View.Details;
            // 
            // tabMeses
            // 
            this.tabMeses.Controls.Add(this.txtBoxFormaPago);
            this.tabMeses.Controls.Add(this.btnAddFormaPago);
            this.tabMeses.Controls.Add(this.listFormasPago);
            this.tabMeses.Controls.Add(this.button2);
            this.tabMeses.Location = new System.Drawing.Point(4, 22);
            this.tabMeses.Name = "tabMeses";
            this.tabMeses.Size = new System.Drawing.Size(807, 362);
            this.tabMeses.TabIndex = 4;
            this.tabMeses.Text = "Mes Actual";
            this.tabMeses.UseVisualStyleBackColor = true;
            // 
            // txtBoxFormaPago
            // 
            this.txtBoxFormaPago.Location = new System.Drawing.Point(112, 82);
            this.txtBoxFormaPago.Name = "txtBoxFormaPago";
            this.txtBoxFormaPago.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFormaPago.TabIndex = 3;
            // 
            // btnAddFormaPago
            // 
            this.btnAddFormaPago.Location = new System.Drawing.Point(12, 79);
            this.btnAddFormaPago.Name = "btnAddFormaPago";
            this.btnAddFormaPago.Size = new System.Drawing.Size(75, 23);
            this.btnAddFormaPago.TabIndex = 2;
            this.btnAddFormaPago.Text = "Nuevo";
            this.btnAddFormaPago.UseVisualStyleBackColor = true;
            this.btnAddFormaPago.Click += new System.EventHandler(this.btnAddFormaPago_Click);
            // 
            // listFormasPago
            // 
            this.listFormasPago.Location = new System.Drawing.Point(12, 14);
            this.listFormasPago.Name = "listFormasPago";
            this.listFormasPago.Size = new System.Drawing.Size(200, 59);
            this.listFormasPago.TabIndex = 1;
            this.listFormasPago.UseCompatibleStateImageBehavior = false;
            this.listFormasPago.View = System.Windows.Forms.View.Details;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(668, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Nuevo Mes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbBoxMes
            // 
            this.cmbBoxMes.FormattingEnabled = true;
            this.cmbBoxMes.Location = new System.Drawing.Point(600, 7);
            this.cmbBoxMes.Name = "cmbBoxMes";
            this.cmbBoxMes.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxMes.TabIndex = 16;
            this.cmbBoxMes.SelectedIndexChanged += new System.EventHandler(this.cmbBoxMes_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 409);
            this.Controls.Add(this.cmbBoxMes);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabGastos.ResumeLayout(false);
            this.tabGastos.PerformLayout();
            this.tabPrev.ResumeLayout(false);
            this.tabCat.ResumeLayout(false);
            this.tabResumen.ResumeLayout(false);
            this.tabResumen.PerformLayout();
            this.tabMeses.ResumeLayout(false);
            this.tabMeses.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGastos;
        private System.Windows.Forms.TabPage tabPrev;
        private System.Windows.Forms.ListView listGastos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listCat;
        private System.Windows.Forms.Button btnNuevaCat;
        private System.Windows.Forms.Button btnBorrarCat;
        private System.Windows.Forms.Button btnEditCat;
        private System.Windows.Forms.Button btnEdtGasto;
        private System.Windows.Forms.Button btnBorrarGasto;
        private System.Windows.Forms.ListView listIngresos;
        private System.Windows.Forms.Button btnNuevoIngreso;
        private System.Windows.Forms.Button btnEdtIngreso;
        private System.Windows.Forms.Button btnBorrarIngreso;
        private System.Windows.Forms.TabPage tabCat;
        private System.Windows.Forms.TextBox edtTotalGastos;
        private System.Windows.Forms.TextBox edtTotalIng;
        private System.Windows.Forms.TabPage tabResumen;
        private System.Windows.Forms.ListView listResumen;
        private System.Windows.Forms.Button btnAddPrev;
        private System.Windows.Forms.Button btnEditPrev;
        private System.Windows.Forms.Button btnBorrarPrev;
        private System.Windows.Forms.ListView listPrev;
        private System.Windows.Forms.TabPage tabMeses;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbBoxMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxDiferencia;
        private System.Windows.Forms.Button btnAddFormaPago;
        private System.Windows.Forms.ListView listFormasPago;
        private System.Windows.Forms.TextBox txtBoxFormaPago;
        private System.Windows.Forms.TextBox txtBoxTotalPrev;
        private System.Windows.Forms.ListView listGastosXMetodo;
        private System.Windows.Forms.TextBox txtBoxTotalBal;
        private System.Windows.Forms.TextBox txtBoxTotalGas;
        private System.Windows.Forms.TextBox txtBoxPorcent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEtiqueta1;
        private System.Windows.Forms.TextBox txtBoxTotalEtiqueta;
        private System.Windows.Forms.ListView listGastosEtiqueta;
    }
}

