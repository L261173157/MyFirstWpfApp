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
using Common.Utility;
using System.ComponentModel;
using GRR;

namespace MyFirstWpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Age;
        Student student;
        GRR.GRR gRR = new GRR.GRR();
        float[,,] data = new float[3, 3, 10];
        Random ran = new Random();

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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        data[i, j, k] = ran.Next(30, 50);
                    }
                }
            }
            textBoxGRR.Text = gRR.Calculate(data, 15f, -15f).ToString();
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
    ////public class GRR
    //{
    //    private float[,,] data;         //Data 三维A,T,P
    //    private float Upper;
    //    private float Lower;
    //    private float[,] xbar;          //xbar   二维A,P
    //    private float[] averageXbar;     //averageXbar   一维A
    //    private float[,] r ;             //r         二维A,P
    //    private float[] averageR;       //averageR   一维A
    //    private float[] xp;             //xp   一维P
    //    private float averageX;
    //    private float lcl;
    //    private float ucl;
    //    private float averageRall;
    //    private float ucl1;
    //    private float rp;
    //    private float xdiff;
    //    private float k1;
    //    private float k2;
    //    private float k3;
    //    private double EV;
    //    private double AV;
    //    private double RR;
    //    private double TT;
    //    private double RRper;
    //    float[][][] aa = new float[3][][];
    //    public double Calculate(float[,,] data, float Upper, float Lower)
    //    {
    //        for (int a = 0; a < data.GetLength(0); a++) //求xbar
    //        {
    //            for (int p = 0; p < data.GetLength(2); p++)
    //            {
    //                float sum = 0f;
    //                for (int t = 0; t < data.GetLength(1); t++)
    //                {
    //                    sum += data[a, t, p];
    //                }
    //                xbar = new float[data.GetLength(0), data.GetLength(2)];
    //                xbar[a, p] = sum / data.GetLength(1);
    //            }
    //        }
    //        for (int a = 0; a < xbar.GetLength(0); a++) //求averageXbar
    //        {
    //            float sum = 0;
    //            for (int p = 0; p < xbar.GetLength(1); p++)
    //            {
    //                sum += xbar[a, p];
    //            }
    //            averageXbar=new float[data.GetLength(0)];
    //            averageXbar[a] = sum / xbar.GetLength(1);
    //        }
    //        for (int a = 0; a < data.GetLength(0); a++) //求r
    //        {
    //            for (int p = 0; p < data.GetLength(2); p++)
    //            {
    //                float max = data[a, 0, p];
    //                float min = data[a, 0, p];
    //                for (int t = 0; t < data.GetLength(1); t++)
    //                {
    //                    if (data[a, t, p] > max)
    //                        max = data[a, t, p];
    //                    if (data[a, t, p] < min)
    //                        min = data[a, t, p];
    //                }
    //                r = new float[data.GetLength(0),data.GetLength(2)];
    //                r[a, p] = max - min;
    //            }
    //        }
    //        for (int a = 0; a < r.GetLength(0); a++) //求averageR
    //        {
    //            float sum = 0;
    //            for (int p = 0; p < r.GetLength(1); p++)
    //            {
    //                sum += r[a, p];
    //            }
    //            averageR = new float[data.GetLength(0)];
    //            averageR[a] = sum / r.GetLength(1);
    //        }
    //        for (int p = 0; p < xbar.GetLength(1); p++) //求xp
    //        {
    //            float sum = 0;
    //            for (int a = 0; a < r.GetLength(0); a++)
    //            {
    //                sum += xbar[a, p];
    //            }
    //            xp = new float[data.GetLength(2)];
    //            xp[p] = sum / xbar.GetLength(0);
    //        }
    //        averageX = 0;
    //        foreach (float item in xp)
    //        {
    //            averageX += item;
    //        }
    //        averageX /= xp.Length;
    //        averageRall = 0;
    //        foreach (float item in averageR)
    //        {
    //            averageRall += item;
    //        }
    //        averageRall /= averageR.Length;
    //        switch (data.GetLength(1))//检查次数
    //        {
    //            case 2:
    //                lcl = (averageX - averageRall) * 1.88F;
    //                ucl = (averageX + averageRall) * 1.88F;
    //                ucl1 = averageRall * 3.27F;
    //                k1 = 0.8862f;
    //                break;
    //            case 3:
    //                lcl = (averageX - averageRall) * 1.023F;
    //                ucl = (averageX + averageRall) * 1.023F;
    //                ucl1 = averageRall * 2.58f;
    //                k1 = 0.5908f;
    //                break;
    //            default:
    //                break;
    //        }
    //        switch (data.GetLength(0))//检查人数
    //        {
    //            case 2:
    //                k2 = 0.7071f;
    //                break;
    //            case 3:
    //                k2 = 0.5231f;
    //                break;
    //            default:
    //                break;
    //        }
    //        switch (data.GetLength(2))//检查产品数
    //        {
    //            case 2:
    //                k3 = 0.7071f;
    //                break;
    //            case 3:
    //                k3 = 0.5231f;
    //                break;
    //            case 4:
    //                k3 = 0.4467f;
    //                break;
    //            case 5:
    //                k3 = 0.403f;
    //                break;
    //            case 6:
    //                k3 = 0.3742f;
    //                break;
    //            case 7:
    //                k3 = 0.3534f;
    //                break;
    //            case 8:
    //                k3 = 0.3375f;
    //                break;
    //            case 9:
    //                k3 = 0.3249f;
    //                break;
    //            case 10:
    //                k3 = 0.3146f;
    //                break;
    //            default:
    //                break;
    //        }
    //        float xpMax = 0f;
    //        float xpMin = 0f;
    //        foreach (float item in xp)
    //        {
    //            if (item > xpMax)
    //            {
    //                xpMax = item;
    //            }
    //            if (item < xpMin)
    //            {
    //                xpMin = item;
    //            }
    //        }
    //        rp = xpMax - xpMin;
    //        float xdiffMax = 0f;
    //        float xdiffMin = 0f;
    //        foreach (float item in averageXbar)
    //        {
    //            if (item > xdiffMax)
    //            {
    //                xdiffMax = item;
    //            }
    //            if (item < xdiffMin)
    //            {
    //                xdiffMin = item;
    //            }
    //        }
    //        xdiff = xdiffMax - xdiffMin;
    //        EV = averageRall * k1;
    //        AV = Math.Sqrt(Math.Pow(xdiff * k2, 2) - Math.Pow(EV, 2) / data.GetLength(1) / data.GetLength(2));
    //        RR = Math.Sqrt(Math.Pow(EV, 2) + Math.Pow(AV, 2));
    //        TT = (Upper - Lower);
    //        RRper = RR / (TT / 6);
    //        return RRper;
    //    }
}
