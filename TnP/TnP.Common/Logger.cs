using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnP.Common
{
    public class Logger
    {
        private static string fileName = AppDomain.CurrentDomain.BaseDirectory + "log";
        private static string filePath = fileName + "\\log.txt";

        public static void WriteLogs(string content)
        {
            if (!Directory.Exists(fileName)) Directory.CreateDirectory(fileName);
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "-->" + content);
                sw.Close();
            }
        }
    }
}
