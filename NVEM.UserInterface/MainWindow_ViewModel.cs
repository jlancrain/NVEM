using NVEM.Common.Models;
using NVEM.Services;
using NVEM.UserInterface;
using NVEM.UserInterface.Annotations;
using NVEM.UserInterface.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace NVEM
{
    public class MainWindow_ViewModel : INotifyPropertyChanged
    {

        private readonly Dictionary<string, string> m_settingsDictionary;
        private readonly string m_programVersion;
        private readonly NvemService m_NvemService;

        public MainWindow_ViewModel()
        {
            var keys = ConfigurationManager.AppSettings.AllKeys;
            m_settingsDictionary = keys.ToDictionary(key => key, key => ConfigurationManager.AppSettings.Get(key));
            m_NvemService = new NvemService(m_settingsDictionary);
            m_programVersion = SetCurrentVersion();
        }

        ~MainWindow_ViewModel()
        {
        }

        /// <summary>
        /// Method to display the About prompt which contains the Release notes
        /// </summary>
        public void ShowAboutPrompt()
        {
            var prompt = new AboutPrompt();
            prompt.LblVersion.Content = string.Format("Version {0}", m_programVersion);

            foreach (var item in RevisionNotes.GetRevNotes())
            {
                prompt.CtlReleaseList.Items.Add(item);
            }

            prompt.ShowDialog();
        }

        /// <summary>
        /// Method to display the Settings prompt which contains the configuration options
        /// </summary>
        public void ShowSettingsPrompt()
        {
            var prompt = new SettingsPrompt();
            var settingsString = new StringBuilder();
            foreach (var setting in m_settingsDictionary)
            {
                settingsString.AppendLine(string.Format("{0} : {1}", setting.Key, setting.Value));
            }
            prompt.TblkSettings.Text = settingsString.ToString();
            prompt.ShowDialog();
        }

        private string SetCurrentVersion()
        {
            Assembly assem = Assembly.GetEntryAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;

            return ver.ToString();
        }

        private Settings m_settings;
        /// <summary>
        /// Reference Property for the configuration settings
        /// </summary>
        public Settings ActiveSettings
        {
            get
            {
                if (m_settings == null)
                    m_settings = new Settings(m_settingsDictionary);
                return m_settings;
            }
        }

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }




}