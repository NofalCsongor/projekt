using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading; //Ezt hozzá kell adni!

namespace SimonSays
{

    public partial class MainWindow : Window
    {
        DispatcherTimer timer; //Időzítő
        Button[] gombok;
        SolidColorBrush[] eredeti, villan;
        int[] generalt = new int[5];
        int aktualis = 0;
        bool modosit = true;
        int pontszam=0;

        public MainWindow()
        {
            InitializeComponent();
            eredeti = new SolidColorBrush[4];
            villan = new SolidColorBrush[4];
            eredeti[0] = new SolidColorBrush(Color.FromArgb(0xff, 0x0e, 0xd1, 0x45));
            eredeti[1] = new SolidColorBrush(Color.FromArgb(0xff, 0xec, 0x1c, 0x24));
            eredeti[2] = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xf2, 0x00));
            eredeti[3] = new SolidColorBrush(Color.FromArgb(0xff, 0x3f, 0x48, 0xcc));
            villan[0] = new SolidColorBrush(Color.FromArgb(0xff, 0x84, 0xf5, 0xa4));
            villan[1] = new SolidColorBrush(Color.FromArgb(0xff, 0xf4, 0x82, 0x82));
            villan[2] = new SolidColorBrush(Color.FromArgb(0xff, 0xf1, 0xed, 0x9e));
            villan[3] = new SolidColorBrush(Color.FromArgb(0xff, 0xae, 0xb1, 0xe9));
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += timer_Tick;
            gombok =new Button[4] {zold,piros,sarga,kek };
        }

        private void inditasKattint(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            aktualis = 0;
            for (int i = 0; i < 5; i++)
            {
                generalt[i] = r.Next(0, 4);
            }
            timer.Start();


        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (aktualis > 4)
            {
                aktualis = 0;
                timer.Stop();
            }
            else
            {
                int melyiket = generalt[aktualis];
                if (modosit == true)
                {
                    gombok[melyiket].Background = villan[melyiket];
                    modosit = false;
                }
                else
                {
                    gombok[melyiket].Background = eredeti[melyiket];
                    aktualis++;
                    modosit = true;
                }
            }
        }

        private void Kattint(int n)
        {
            if (generalt[aktualis] == n)
            {
                pontszam++;
                label.Content = pontszam + " pont";
            }
            aktualis++;
            if (aktualis > 4)
                aktualis = 0;
        }

        private void zoldKattint(object sender, RoutedEventArgs e)
        {
            Kattint(0);
        }

        private void pirosKattint(object sender, RoutedEventArgs e)
        {
            Kattint(1);
        }

        private void sargaKattint(object sender, RoutedEventArgs e)
        {
            Kattint(2);
        }

        private void kekKattint(object sender, RoutedEventArgs e)
        {
            Kattint(3);

        }
    }
}