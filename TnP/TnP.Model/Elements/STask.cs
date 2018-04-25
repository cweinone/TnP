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

        public int scale;//indicate the max subtask number: ext_small: 3; small: 5; standard: 7; huge: 15; ext_huge: 31
    }
}
