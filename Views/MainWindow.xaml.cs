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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean widac = true;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Schowaj(object sender, RoutedEventArgs e)
        {
            if (widac)
            {
                menu.Visibility = Visibility.Hidden;
                widac = false;
                menu.Width = 1;
            }
            else
            {
                menu.Visibility = Visibility.Visible;
                widac = true;
                menu.Width = 150;
            }
            }
    }
}
