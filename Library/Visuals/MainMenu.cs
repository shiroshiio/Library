using System;
using System.Windows.Forms;
using Inventario.Vistas;

namespace Library
{
    public partial class MainMenu : Form
    {
        private int _currentUserId;

        // Constructor que recibe el IDUsuario
        public MainMenu(int userId)
        {
            InitializeComponent();
            _currentUserId = userId; // Guardamos el IDUsuario
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario de información del usuario y pasar el IDUsuario
                UsuarioInfo usuarioInfoForm = new UsuarioInfo(_currentUserId);
                usuarioInfoForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de información de usuario: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario de libros
                Libros librosForm = new Libros();
                librosForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de libros: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario de reservas
                Reservas reservasForm = new Reservas();
                reservasForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de reservas: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario de consultas
                Consultas consultasForm = new Consultas();
                consultasForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de consultas: " + ex.Message);
            }
        }
    }
}