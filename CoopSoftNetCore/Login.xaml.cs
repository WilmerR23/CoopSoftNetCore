using CoopSoftNetCore;
using CoopSoftNetCore.Context;
using CoopSoftNetCore.Core.Implementations;
using CoopSoftNetCore.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CoopSoftNetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly ISampleService sampleService;
        private readonly AppSettings settings;
        private DbContextCS db;

        public Login(ISampleService sampleService, IOptions<AppSettings> settings, DbContextCS cs)
        {
            InitializeComponent();

            this.sampleService = sampleService;
            this.settings = settings.Value;
            this.db = cs;
        }

        Home welcome = new Home();
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxEmail.Text.Length == 0)
                {
                    errormessage.Text = "Ingresa un email";
                    textBoxEmail.Focus();
                }
                else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Ingresa un email valido.";
                    textBoxEmail.Select(0, textBoxEmail.Text.Length);
                    textBoxEmail.Focus();
                }
                else
                {
                    _loading.Visibility = Visibility.Visible;

                    string email = textBoxEmail.Text;
                    string password = passwordBox1.Password;

                    var usuario = await db.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Clave == password);

                    if (usuario != null)
                    {
                        string username = usuario.NombreUsuario;
                        //   welcome.TextBlockName.Text = username;//Sending value from one form to another form.  

                        _loading.Visibility = Visibility.Hidden;
                        welcome.Show();
                        Close();
                    }
                    else
                    {
                        errormessage.Text = "Por favor, ingresa credenciales existentes.";
                    }
                }
            } catch (Exception ex)
            {
                _loading.Visibility = Visibility.Hidden;
                MessageBox.Show("Error:" + ex, "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
