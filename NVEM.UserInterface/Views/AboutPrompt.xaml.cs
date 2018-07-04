using System;
using System.Collections.Generic;
using System.Windows;

namespace NVEM.UserInterface.Views
{
    /// <summary>
    /// Interaction logic for AboutPrompt.xaml
    /// </summary>
    public partial class AboutPrompt : Window
    {
        public bool OkBtnPressed { get; set; }

        public AboutPrompt()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            OkBtnPressed = true;
            Close();
        }
    }
}
