using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HolaMundoWpfApplication
{
    class BarraEstadoDependencyProperty
    {
        public static readonly DependencyProperty EsAplicadaBarraEstadoProperty = DependencyProperty.RegisterAttached("EsAplicadaBarraEstado",
                                                                                    typeof(Boolean),
                                                                                    typeof(BarraEstadoDependencyProperty),
                                                                                    new FrameworkPropertyMetadata(EsAplicadaBarraEstadoChanged));

        public static void SetEsAplicadaBarraEstado(DependencyObject element, Boolean value)
        {
            element.SetValue(EsAplicadaBarraEstadoProperty, value);
        }

        public static Boolean GetEsAplicadaBarraEstado(DependencyObject element)
        {
            return (Boolean)element.GetValue(EsAplicadaBarraEstadoProperty);
        }

        /// <summary>
        /// Se llama cuando el usuario de la propidedad adjunta la cambia
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public static void EsAplicadaBarraEstadoChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
            {
                if (obj is Window)
                {
                    Window wnd = (Window)obj;
                    wnd.Loaded += new RoutedEventHandler(wnd_Loaded);
                }
            }
        }

        /// <summary>
        /// Añade un dockpanel que contenga la ventana actual (top) y uno nuevo que simula la barra de estado(buttom)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void wnd_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DockPanel dp = new DockPanel(); //crea el dockpanel que contendrá a ambos(actual+nuevo)
                dp.LastChildFill = true;
                StackPanel sp = new StackPanel(); //crea un stack panel para introducir la etiqueta de estado y lo introduce en el Dockpanel al final
                dp.Children.Add(sp);
                sp.Background = new SolidColorBrush(Colors.CornflowerBlue);
                sp.Orientation = Orientation.Vertical;
                sp.SetValue(DockPanel.DockProperty, Dock.Bottom);
                Label label = new Label(); //crea la etiqueda y la añada el stack panel
                label.Content = "Barra de estado";
                sp.Children.Add(label);
                UIElement el = ((DependencyObject)sender as Window).Content as UIElement; //guarda al contenido de la ventana
                el.SetValue(DockPanel.DockProperty, Dock.Top); // lo pone como Top
                ((DependencyObject)sender as Window).Content = null; //anula el contenido actual de la venta
                dp.Children.Add(el); //añade al dockpanel el contenido guardado de la ventana
                ((DependencyObject)sender as Window).Content = dp;//estable el nuevo contenido de la ventana
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                string.Format("Exception : {0}", ex.Message));
            }
        }
    }
}
