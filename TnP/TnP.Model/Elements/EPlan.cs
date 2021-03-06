﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnP.Model.Elements
{
    public class EPlan
    {
        public string name { set; get; }
        public long id { set; get; }

        public int progress = 0;//record a plan's progress
        public bool state = false;//the plan is/isn't activated

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

        public long lplanID;//belong to which long term plan
        public long taskID;//belong to which task
        public long goalID;//belong to which goal
        public long thoughtID;//belong to which thought

        public Feature feature;//record the characteristic of a plan
        public List<Step> steps = new List<Step>();//record the steps of a plan

        public List<Step> generateSteps()
        {
            return steps;
        }

    }
}
