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

using System.ComponentModel;

namespace MyFirstWpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Age;
        Student student;
        public static string myString = "abc";
        List<employee> employees = new List<employee>()
        {
            new employee(){Id=2,Name="lin",Age=10 },
            new employee(){Id=1,Name="wen",Age=11}
        };
        public MainWindow()
        {
            
            InitializeComponent();
            this.ListBoxEmployee.DisplayMemberPath = "Name";
            this.ListBoxEmployee.SelectedValuePath = "Id";
            this.ListBoxEmployee.ItemsSource = employees;
            //student = new Student();
            //Binding binding = new Binding();
            //binding.Source = student;
            //binding.Path = new PropertyPath("Name");
            //BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);
            this.textBoxName.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = student = new Student() });

        }
        SolidColorBrush mySolidColorBrush = new SolidColorBrush();

        public static string MyString { get => myString; set => myString = value; }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mySolidColorBrush.Color = Color.FromArgb(0, 0, 0, 0);
            Rectangle1.Fill = mySolidColorBrush;
            myString = "white";

        }

        private void BlackButton_Click(object sender, RoutedEventArgs e)
        {
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            Rectangle1.Fill = mySolidColorBrush;
            myString = "black";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            employees.Add(new employee() { Id = 3, Name = "li", Age = 12 });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            student.Name += "Name";
        }
    }
    public class employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Student:INotifyPropertyChanged
    {
        string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                
                if(this.PropertyChanged!=null)
                {
                    this.PropertyChanged.Invoke(this,new PropertyChangedEventArgs ("Name"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
    //class Teacher:INotifyPropertyChanged
    //{
    //    string name;

    //    public string Name { get => name; set => name = value; }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //}
    
}
