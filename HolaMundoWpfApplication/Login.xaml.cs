using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HolaMundoWpfApplication.Model;

namespace HolaMundoWpfApplication
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ICollection<UsuarioModel> _usuarios;
        public Login()
        {
            InitializeComponent();
            _usuarios = (UsuariosModel) FindResource("ListaUsuarios");
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string nombreUsuario = usuariosComboBox.SelectedItem.ToString();
            string palabraDePaso = palabraDePasoTextBox.Text;
            string password;
            if(TryGetValue(nombreUsuario, out password))
            {
                if (password == palabraDePaso)
                {
                    MessageBox.Show(string.Format("Hola {0}", nombreUsuario));
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    UsuarioActivo.Nombre = nombreUsuario;
                    UsuarioActivo.PalabraDePaso = palabraDePaso;
                }
                else
                {
                    MessageBox.Show(string.Format("Error en la palabra de paso {0}", palabraDePaso));
                }
            }
            else
            {
                MessageBox.Show(string.Format("El usuario {0} no existe en el sistema", nombreUsuario));
            }
        }

        private bool TryGetValue(string nombreUsuario, out string password)
        {
            foreach (var item in _usuarios)
            {
                if (item.Nombre == nombreUsuario)
                {
                    password = item.PalabraDePaso;
                    return true;
                }   
            }
            password = "";
            return false;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void usuariosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //usuarioTextBox.Text = usuariosComboBox.SelectedValue.ToString();
        }
    }
}
