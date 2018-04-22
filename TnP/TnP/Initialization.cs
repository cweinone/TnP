using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TnP.Common;
using TnP.Model;
using TnP.Model.Dictionaries;

namespace TnP
{
    public class Initialization
    {
        public static void Init()
        {
            FileInit();
            ViewInit();
        }

        private static void FileInit()
        {
            string filePath = Application.StartupPath + "\\save.xml";
            XmlDocument xmlDoc = new XmlDocument();
            //add the plan from xml file to the tree
            if (File.Exists(filePath)) xmlIO.ReadXML(filePath, xmlDoc);
        }

        private static void ViewInit()
        {
            
            
        }
    }
}
