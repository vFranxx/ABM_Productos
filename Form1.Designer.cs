namespace ABM_Productos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            groupBox1 = new GroupBox();
            txtPriceDist = new TextBox();
            txtPriceMay = new TextBox();
            txtPriceUnit = new TextBox();
            dataGridView1 = new DataGridView();
            txtCode = new TextBox();
            txtDescription = new TextBox();
            cbxUndMedida = new ComboBox();
            cbxRubro = new ComboBox();
            txtUnits = new TextBox();
            groupBox2 = new GroupBox();
            btnClose = new Button();
            btnClean = new Button();
            button3 = new Button();
            btnDelete = new Button();
            btnSaveModify = new Button();
            lblFechaBaja = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "CÓDIGO:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 57);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 1;
            label2.Text = "DESCRIPCIÓN:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 88);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "STOCK:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 25);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 3;
            label4.Text = "UNITARIO:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 54);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 4;
            label5.Text = "MAYORISTA:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 83);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 5;
            label6.Text = "DISTRIBUIDOR:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(931, 168);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 6;
            label7.Text = "RUBRO:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(861, 197);
            label8.Name = "label8";
            label8.Size = new Size(118, 15);
            label8.TabIndex = 7;
            label8.Text = "UNIDAD DE MEDIDA:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPriceDist);
            groupBox1.Controls.Add(txtPriceMay);
            groupBox1.Controls.Add(txtPriceUnit);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(12, 114);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 112);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "PRECIOS";
            // 
            // txtPriceDist
            // 
            txtPriceDist.Location = new Point(124, 80);
            txtPriceDist.Name = "txtPriceDist";
            txtPriceDist.Size = new Size(72, 23);
            txtPriceDist.TabIndex = 8;
            // 
            // txtPriceMay
            // 
            txtPriceMay.Location = new Point(124, 51);
            txtPriceMay.Name = "txtPriceMay";
            txtPriceMay.Size = new Size(72, 23);
            txtPriceMay.TabIndex = 7;
            // 
            // txtPriceUnit
            // 
            txtPriceUnit.Location = new Point(124, 22);
            txtPriceUnit.Name = "txtPriceUnit";
            txtPriceUnit.Size = new Size(72, 23);
            txtPriceUnit.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.Location = new Point(12, 303);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1105, 471);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(101, 24);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(119, 23);
            txtCode.TabIndex = 10;
            txtCode.TextChanged += txtCode_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(101, 54);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(819, 23);
            txtDescription.TabIndex = 11;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // cbxUndMedida
            // 
            cbxUndMedida.FormattingEnabled = true;
            cbxUndMedida.Location = new Point(985, 194);
            cbxUndMedida.Name = "cbxUndMedida";
            cbxUndMedida.Size = new Size(132, 23);
            cbxUndMedida.TabIndex = 12;
            // 
            // cbxRubro
            // 
            cbxRubro.FormattingEnabled = true;
            cbxRubro.Location = new Point(985, 165);
            cbxRubro.Name = "cbxRubro";
            cbxRubro.Size = new Size(132, 23);
            cbxRubro.TabIndex = 13;
            // 
            // txtUnits
            // 
            txtUnits.Location = new Point(101, 85);
            txtUnits.Name = "txtUnits";
            txtUnits.Size = new Size(53, 23);
            txtUnits.TabIndex = 14;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnClose);
            groupBox2.Controls.Add(btnClean);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnSaveModify);
            groupBox2.Location = new Point(12, 241);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1105, 56);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "OPCIONES";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(352, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 17;
            btnClose.Text = "CERRAR";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnClean
            // 
            btnClean.Location = new Point(271, 20);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 16;
            btnClean.Text = "LIMPIAR";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // button3
            // 
            button3.Location = new Point(190, 20);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "BUSQUEDA";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(109, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "BORRAR";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += button2_Click;
            // 
            // btnSaveModify
            // 
            btnSaveModify.Location = new Point(28, 20);
            btnSaveModify.Name = "btnSaveModify";
            btnSaveModify.Size = new Size(75, 23);
            btnSaveModify.TabIndex = 0;
            btnSaveModify.Text = "AÑADIR";
            btnSaveModify.UseVisualStyleBackColor = true;
            btnSaveModify.Click += btnSaveModify_Click;
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Location = new Point(239, 27);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(38, 15);
            lblFechaBaja.TabIndex = 16;
            lblFechaBaja.Text = "label9";
            lblFechaBaja.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 786);
            Controls.Add(lblFechaBaja);
            Controls.Add(groupBox2);
            Controls.Add(txtUnits);
            Controls.Add(cbxRubro);
            Controls.Add(cbxUndMedida);
            Controls.Add(txtDescription);
            Controls.Add(txtCode);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "PRODUCTOS";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private TextBox txtCode;
        private TextBox txtDescription;
        private ComboBox cbxUndMedida;
        private ComboBox cbxRubro;
        private TextBox txtUnits;
        private GroupBox groupBox2;
        private Button button3;
        private Button btnDelete;
        private Button btnSaveModify;
        private TextBox txtPriceDist;
        private TextBox txtPriceMay;
        private TextBox txtPriceUnit;
        private Button btnClean;
        private Button btnClose;
        private Label lblFechaBaja;
    }
}
