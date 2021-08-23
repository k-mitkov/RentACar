using Data.Enums;
using DesktopClient.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DesktopClient.BussinesModels
{
    public class LocationRapper
    {
        #region Declarations
        private const string path = @"\Resources\Images\location-icon.png";
        #endregion

        #region Proparties
        public Locations Location { get; set; }

        public string LocationStr
        {
            get
            {
                var field = Location.GetType().GetField(Location.ToString());
                var attributes = field.GetCustomAttributes(false);

                DescriptionAttribute displayAttribute = null;

                if (attributes.Any())
                {
                    displayAttribute = (DescriptionAttribute)attributes.ElementAt(0);
                }
                return TranslationSource.Instance[displayAttribute.Description];
            }
        }
        public string IconPath
        {
            get
            {
                return path;
            }
        }
        #endregion
    }
}
