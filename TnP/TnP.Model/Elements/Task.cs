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
        public int goalID;//identify origin goal
        public List<int> staskID;//storage the all member of stask
        public DateTime expecT;//expect finish time
        public List<int> dailyDoneCount;//daily finished subtask count
        public DateTime creatT;//record time the task first created
        public TimeSpan totalT;//record time the task totally used
        public int totalSubtaskNum;//record number of total subtask
        public int doneSubtaskNum;//record number of finished subtask
        public int popularity;
        public int reward;
        public bool state;//taskbook is closed (y/n)
    }
}
