using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnP.Model.Elements
{
    public class STask
    {
        public string name;
        public long id;
        public long taskID;
        public bool procedure = false;
        public bool structure = false;
        public int order;
        public long lplanID;
        public List<long> subtaskID = new List<long>();
        public bool state;
        public TimeSpan totalT;
        public int totalSubtaskNum;//record number of total subtask
        public int doneSubtaskNum;//record number of finished subtask
        public int reward;
    }
}
