using System.Windows;

namespace NVEM.UserInterface.Views
{
    /// <summary>
    /// Interaction logic for WarningPrompt.xaml
    /// </summary>
    public partial class WarningPrompt : Window
    {
        public bool OkBtnPressed { get; set; }

        public WarningPrompt(string message)
        {
            InitializeComponent();
            LblMessage.Content = message;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            OkBtnPressed = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            OkBtnPressed = false;
            Close();
        }
    }
}
