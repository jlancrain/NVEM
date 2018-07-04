using System;
using System.Collections.Generic;

namespace NVEM.Common.Models
{
    /// <summary>
    /// Configuration Settings Data Model
    /// </summary>
    public class Settings
    {
        private readonly Dictionary<string, string> m_settingsDictionary;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settingsDictionary"></param>
        public Settings(Dictionary<string, string> settingsDictionary)
        {
            m_settingsDictionary = settingsDictionary;
        }

        /// <summary>
        /// Configuration Property to enable scanning of the NetVision API
        /// </summary>
        public bool NetVisionEnable
        {
            get
            {
                return m_settingsDictionary.ContainsKey("NetVisionEnable")
                    ? Convert.ToBoolean(m_settingsDictionary["NetVisionEnable"])
                    : false;
            }
        }

        /// <summary>
        /// Configuration property to set the URL for Net Vision
        /// </summary>
        public string NetVisionBaseUrl
        {
            get
            {
                return m_settingsDictionary.ContainsKey("NetVisionBaseUrl")
                    ? m_settingsDictionary["NetVisionBaseUrl"]
                    : string.Empty;
            }
        }

        /// <summary>
        /// Configuration property to set the port used by the HTTP driver to communicate to the Net Vision API
        /// </summary>
        public int NetVisionPort
        {
            get
            {
                return m_settingsDictionary.ContainsKey("NetVisionPort")
                    ? Convert.ToInt32(m_settingsDictionary["NetVisionPort"])
                    : 0;
            }
        }

        /// <summary>
        /// Configuration property to set the delay between reads
        /// </summary>
        public int NetVisionPollingRateMs
        {
            get
            {
                return m_settingsDictionary.ContainsKey("NetVisionPollingRateMs")
                    ? Convert.ToInt32(m_settingsDictionary["NetVisionPollingRateMs"])
                    : 0;
            }
        }

    }
}