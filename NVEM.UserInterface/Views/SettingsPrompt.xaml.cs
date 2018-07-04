using System.Windows;

namespace NVEM.UserInterface.Views
{
    /// <summary>
    /// Interaction logic for SettingsPrompt.xaml
    /// </summary>
    public partial class SettingsPrompt : Window
    {
        public bool OkBtnPressed { get; set; }

        public SettingsPrompt()
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
