using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesktopClient.Util
{
    public class ExceptionLogger
    {
        #region Declarations
        private const string path = "C:\\ProgramData\\Microinvest\\LibraryDemo";
        private const string fileName = "ExceptionsRentACar.txt";
        #endregion

        #region Methods
        public static void LoggException(Exception e)
        {
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                using (StreamWriter file = new StreamWriter(path + "\\" + fileName, append: true))
                {
                    file.WriteLine(string.Format("DataTime: {1}\nException: {0}\n", e, DateTime.Now));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion
    }
}
