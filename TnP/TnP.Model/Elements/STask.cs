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
        public int taskID;
        public bool procedure;
        public bool structure;
        public int order;
        public int lplanID;
        public List<int> subtaskID;
        public bool state;
        public TimeSpan totalT;
        public int totalSubtaskNum;//record number of total subtask
        public int doneSubtaskNum;//record number of finished subtask
        public int reward;
    }
}
