using System;
using System.Collections.Generic;
using System.IO;
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

namespace beadandó
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class ip { 
    public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }
        public int D { get; private set; }

        public ip(string s) {

            string[] m = s.Split(".");
            A= int.Parse(m[0]);
            B = int.Parse(m[1]);
            C = int.Parse(m[2]);
            D = int.Parse(m[3]);        
        }


    }
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
           
          
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            List<ip> lista = new List<ip>();
            lista.Add(new ip(TextBox1.Text));

            Dictionary<int, string> d = new Dictionary<int, string>();
            StreamReader fajl = new StreamReader("netmask.txt");
            string sor = "";

            while (!fajl.EndOfStream)
            {
                sor = fajl.ReadLine();
                string[] h = sor.Split("\t");
                d.Add(int.Parse(h[0]), h[1]);
               
            }
            string o = "";
            foreach (var item in d)
            {
                if (item.Key == int.Parse(TextBox2.Text))
                {
                    o = item.Value;
                }
              
                
            }

            StreamReader fajl2=new StreamReader("helyek.txt");
            Dictionary<int, long> f = new Dictionary<int, long>();
            foreach (var item in d)
            {
                long s = long.Parse(fajl2.ReadLine());
 
                 f.Add(item.Key, s) ;

            }
            long cím = 0;
            foreach (var item in f)
            {
                if (item.Key == int.Parse(TextBox2.Text))
                {
                    cím=item.Value;
                }
            }
            string elso = "";
            foreach (var item in lista)
            {
                foreach (var item2 in d)
                {
                    if (item2.Key >= 24)
                    {
                        elso = item.A+"."+item.B+"."+item.C+"."+(item.D+1);
                    }
                }
            }

            


            Label1.Content="első cím: "+elso;
            Label1.Content+= "Netmask: " + o+"\n";




        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }
    }
}
