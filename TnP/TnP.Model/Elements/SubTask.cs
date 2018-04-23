using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnP.Model.Elements
{
    public class SubTask
    {
        public string name;
        public long id;
        public long staskID;
        public long eplanID;
        public bool ready;
        public bool inout;
        public int difficulty;
        public int reward;
        public bool state;
        public int order;
    }
}
