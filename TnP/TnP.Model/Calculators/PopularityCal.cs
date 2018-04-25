using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Dictionaries;

namespace TnP.Model.Calculators
{
    public class PopularityCal
    {
        public static void Calculator()
        {
            foreach (Elements.Task t in TaskDictionary.GetInstance().GetList())
            {
                if (t.dailyDoneCount.Count == 0) t.popularity = 0;
                else if (t.dailyDoneCount.Count < 3)
                {
                    t.popularity = 0;
                    foreach (int i in t.dailyDoneCount) t.popularity += i;
                }
                else
                {
                    t.popularity = 0;
                    for (int i = t.dailyDoneCount.Count - 1; i > t.dailyDoneCount.Count - 4; i--) t.popularity += t.dailyDoneCount[i];
                }
            }


        }
    }
}
