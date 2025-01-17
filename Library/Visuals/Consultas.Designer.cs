namespace Inventario.Vistas
{
    partial class Consultas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewLibros = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TituloColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeneroColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibros)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLibros
            // 
            this.dataGridViewLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.TituloColumn,
            this.GeneroColumn,
            this.EstadoColumn});
            this.dataGridViewLibros.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewLibros.Name = "dataGridViewLibros";
            this.dataGridViewLibros.Size = new System.Drawing.Size(776, 426);
            this.dataGridViewLibros.TabIndex = 0;
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.Visible = false;
            // 
            // TituloColumn
            // 
            this.TituloColumn.HeaderText = "Título";
            this.TituloColumn.Name = "TituloColumn";
            this.TituloColumn.Width = 200;
            // 
            // GeneroColumn
            // 
            this.GeneroColumn.HeaderText = "Género";
            this.GeneroColumn.Name = "GeneroColumn";
            this.GeneroColumn.Width = 150;
            // 
            // EstadoColumn
            // 
            this.EstadoColumn.HeaderText = "Estado";
            this.EstadoColumn.Name = "EstadoColumn";
            this.EstadoColumn.Width = 100;
            // 
            // Consultas
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewLibros);
            this.Name = "Consultas";
            this.Text = "Consultas de Libros";
            this.Load += new System.EventHandler(this.Consultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibros)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TituloColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeneroColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoColumn;
    }
}
