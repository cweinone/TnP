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

        public DateTime expecStartT;
        public TimeSpan expecLastT;
        public int startF = 0;//record the plan-start frequency
        public int stopF = 0;//record the plan-stop frequency

        public List<DateTime> startT = new List<DateTime>();//record the time a plan begin
        public TimeSpan lastT = TimeSpan.Zero;//record the period of a plan
        public List<DateTime> stopT = new List<DateTime>();
        public DateTime finalT;//record the time a plan should be over
        public DateTime showT;//record the time a plan first appear

        public bool doneState;//the plan is finished/given up
        public bool endState;//finished or gave up
        public DateTime endT;//record the time a plan finally over
    }
}
