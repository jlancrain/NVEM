using log4net;
using log4net.Config;
using NVEM.UserInterface.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace NVEM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILog m_logger;
        private DateTime m_runTimeStart;
        private MainWindow_ViewModel m_viewModel;

        public MainWindow()
        {
            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

            m_runTimeStart = DateTime.Now;

            m_logger = LogManager.GetLogger(typeof(MainWindow));
            XmlConfigurator.Configure();
            m_logger.Info("Application Started");

            //Kill duplicate process
            if (processes.Length > 1)
            {
                //This action cannot be logged because the other instance has the log file locked.
                var warningPrompt = new WarningPrompt("The application is already running and will be closed.");
                warningPrompt.BtnCancel.Visibility = Visibility.Hidden;
                warningPrompt.ShowDialog();
                if (warningPrompt.OkBtnPressed)
                {
                    this.Close();
                }
            }
            InitializeComponent();
            m_viewModel = new MainWindow_ViewModel();
            DataContext = m_viewModel;
        }

        protected void Event_WindowClosing(object sender, CancelEventArgs e)
        {
            var runTimeEnd = DateTime.Now;
            var ts = new TimeSpan(runTimeEnd.Ticks - m_runTimeStart.Ticks);
            m_logger.Info(string.Format("Application Completed - Run Time: {0:g}", ts));
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuAbout_OnClick(object sender, RoutedEventArgs e)
        {
            m_viewModel.ShowAboutPrompt();
        }

        private void MenuSettings_OnClick(object sender, RoutedEventArgs e)
        {
            m_viewModel.ShowSettingsPrompt();
        }

        private void MenuExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
