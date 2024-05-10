﻿using System;
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

namespace Projecte0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persona p = new Persona();
        Connexio connexio = new Connexio();
        public MainWindow()
        {
            InitializeComponent();
            connexio.ConnexioBDD();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Registrarse ventanaRegistrar = new Registrarse();
            ventanaRegistrar.Show();
            this.Close();
        }

        private void btnIniciarSessio_Click(object sender, RoutedEventArgs e)
        {
            if (txBoxUsuari.Text != "" && pwdBoxUsuari.Password != "")
            {
                
            }
        }
    }
}
