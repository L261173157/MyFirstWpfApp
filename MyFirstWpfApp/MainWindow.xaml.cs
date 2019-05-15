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

namespace MyFirstWpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        SolidColorBrush mySolidColorBrush = new SolidColorBrush();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mySolidColorBrush.Color = Color.FromArgb(0, 0, 0, 0);
            Rectangle1.Fill = mySolidColorBrush;
        }

        private void BlackButton_Click(object sender, RoutedEventArgs e)
        {
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            Rectangle1.Fill = mySolidColorBrush;
        }
    }
}
