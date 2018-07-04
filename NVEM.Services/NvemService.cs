using NVEM.Common.Models;
using System.Collections.Generic;

namespace NVEM.Services
{

    public class NvemService
    {

        private readonly Settings m_settings;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settingsDictionary"></param>
        public NvemService(Dictionary<string, string> settingsDictionary)
        {
            m_settings = new Settings(settingsDictionary);
        }



    }
}
