using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnP.Model.Elements
{
    public class Task
    {
        public string name;
        public long id;
        public int progress;
        public long goalID;//identify origin goal
        public List<long> staskID = new List<long>();//store the all member of stask
        public List<long> allSubID = new List<long>();//store all subtasks 
        public DateTime expecT;//expect finish time
        public List<int> dailyDoneCount = new List<int>();//daily finished subtask count
        public DateTime creatT;//record time the task first created
        public TimeSpan totalT;//record time the task totally used
        public int totalSubtaskNum;//record number of total subtask
        public int doneSubtaskNum;//record number of finished subtask
        public int popularity;
        public int reward;
        public bool state;//taskbook is closed (y/n)

        public int scale;//indicate the max stask number: ext_small: 3; small: 5; standard: 7; huge: 15; ext_huge: 31
    }
}
