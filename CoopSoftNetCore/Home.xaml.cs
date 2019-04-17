using CoopSoftNetCore.Helper;
using CoopSoftNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CoopSoftNetCore
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //    this.contentControl.Content = new Usuario();
            CreateThread(Visibility.Collapsed,"-",500);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateThread(Visibility.Visible,"X",300);
        }

        public void CreateThread(Visibility vs, string mode,int duration)
        {
            Thread rn = new Thread(new ThreadStart(() => doAnimate(vs,mode,duration)));
            rn.Start();
        }

        public void doAnimate(Visibility vs, string mode,int duration)
        {
            Thread.Sleep(duration);
            Dispatcher.Invoke(() =>
            {
                MyDockPanel.Visibility = vs;
                TOOGLE.Content = mode;
            });
        }
    }
}
