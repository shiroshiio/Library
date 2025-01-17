namespace Library
{
    partial class UsuarioInfo
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelIDUsuario;
        private Label labelNombre;
        private Label labelApellido;
        private Label labelEmail;
        private Label labelTelefono;

        /// <summary>
        ///  Requiere el diseñador.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.labelIDUsuario = new Label();
            this.labelNombre = new Label();
            this.labelApellido = new Label();
            this.labelEmail = new Label();
            this.labelTelefono = new Label();
            this.SuspendLayout();

            // 
            // labelIDUsuario
            // 
            this.labelIDUsuario.AutoSize = true;
            this.labelIDUsuario.Location = new System.Drawing.Point(50, 50);
            this.labelIDUsuario.Name = "labelIDUsuario";
            this.labelIDUsuario.Size = new System.Drawing.Size(100, 20);
            this.labelIDUsuario.TabIndex = 0;
            this.labelIDUsuario.Text = "ID Usuario: ";

            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(50, 100);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(70, 20);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre: ";

            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(50, 150);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(75, 20);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Text = "Apellido: ";

            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(50, 200);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(55, 20);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email: ";

            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(50, 250);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(75, 20);
            this.labelTelefono.TabIndex = 4;
            this.labelTelefono.Text = "Teléfono: ";

            // 
            // UsuarioInfo
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelIDUsuario);
            this.Name = "UsuarioInfo";
            this.Text = "Información del Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
