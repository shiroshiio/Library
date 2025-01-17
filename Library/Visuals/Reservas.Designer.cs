namespace Inventario.Vistas
{
    partial class Reservas
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar recursos no administrados.
        /// </summary>
        /// <param name="disposing">true si se deben liberar recursos administrados; false de lo contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Inicialización de los componentes del formulario.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxLibros = new System.Windows.Forms.ComboBox();
            this.textBoxUsuarioID = new System.Windows.Forms.TextBox();
            this.buttonReservar = new System.Windows.Forms.Button();
            this.labelLibro = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxLibros
            // 
            this.comboBoxLibros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLibros.FormattingEnabled = true;
            this.comboBoxLibros.Location = new System.Drawing.Point(12, 29);
            this.comboBoxLibros.Name = "comboBoxLibros";
            this.comboBoxLibros.Size = new System.Drawing.Size(260, 21);
            this.comboBoxLibros.TabIndex = 0;
            // 
            // textBoxUsuarioID
            // 
            this.textBoxUsuarioID.Location = new System.Drawing.Point(12, 83);
            this.textBoxUsuarioID.Name = "textBoxUsuarioID";
            this.textBoxUsuarioID.Size = new System.Drawing.Size(260, 20);
            this.textBoxUsuarioID.TabIndex = 1;
            // 
            // buttonReservar
            // 
            this.buttonReservar.Location = new System.Drawing.Point(197, 109);
            this.buttonReservar.Name = "buttonReservar";
            this.buttonReservar.Size = new System.Drawing.Size(75, 23);
            this.buttonReservar.TabIndex = 2;
            this.buttonReservar.Text = "Reservar";
            this.buttonReservar.UseVisualStyleBackColor = true;
            this.buttonReservar.Click += new System.EventHandler(this.ButtonReservar_Click);
            // 
            // labelLibro
            // 
            this.labelLibro.AutoSize = true;
            this.labelLibro.Location = new System.Drawing.Point(12, 13);
            this.labelLibro.Name = "labelLibro";
            this.labelLibro.Size = new System.Drawing.Size(34, 13);
            this.labelLibro.TabIndex = 3;
            this.labelLibro.Text = "Libro:";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(12, 67);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(49, 13);
            this.labelUsuario.TabIndex = 4;
            this.labelUsuario.Text = "Usuario:";
            // 
            // Reservas
            // 
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.labelLibro);
            this.Controls.Add(this.buttonReservar);
            this.Controls.Add(this.textBoxUsuarioID);
            this.Controls.Add(this.comboBoxLibros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Reservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservar Libro";
            this.Load += new System.EventHandler(this.Reservas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxLibros;
        private System.Windows.Forms.TextBox textBoxUsuarioID;
        private System.Windows.Forms.Button buttonReservar;
        private System.Windows.Forms.Label labelLibro;
        private System.Windows.Forms.Label labelUsuario;
    }
}
