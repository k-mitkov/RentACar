using System.Collections.Generic;

namespace DesktopClient.BussinesModels
{
    public class Hours
    {
        #region Declarations
        private const string path = @"\Resources\Images\time-icon.png";
        private static List<Hours> hours;
        #endregion

        #region Proparties
        public string Hour { get; set; }

        public string IconPath
        {
            get
            {
                return path;
            }
        }
        #endregion

        #region Methods
        public static List<Hours> GetHours()
        {
            if (hours == null)
            {
                hours = new List<Hours>();
                hours.Add(new Hours()
                {
                    Hour = "00:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "01:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "02:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "03:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "04:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "05:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "06:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "07:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "08:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "09:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "10:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "11:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "12:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "13:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "14:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "15:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "16:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "17:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "18:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "19:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "20:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "21:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "22:00"
                });
                hours.Add(new Hours()
                {
                    Hour = "23:00"
                });
            }
            return hours;
        }
        #endregion
    }
}
