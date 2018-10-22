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
    /// Lógica de interacción para CambiarPalabraPaso.xaml
    /// </summary>
    public partial class CambiarPalabraPaso : Window
    {
        public CambiarPalabraPaso()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkpass(valorActualTextBox.Text))
            {
                if (nuevoValorTextBox.Text == repetirNuevoValorTextBox.Text)
                {
                    UsuarioActivo.PalabraDePaso = nuevoValorTextBox.Text;
                    MessageBox.Show(string.Format("El usuario {0} ha cambiado su contraseña", UsuarioActivo.Nombre));
                }
                else
                    MessageBox.Show(string.Format("Las contraseñas no coinciden, intentelo de nuevo"));
            }
            else
                MessageBox.Show(string.Format("Contraseña incorrecta"));
        }

        private bool checkpass(string password)
        {
            return password == UsuarioActivo.PalabraDePaso;                
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
