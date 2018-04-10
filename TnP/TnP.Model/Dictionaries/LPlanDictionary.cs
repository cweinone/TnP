using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Elements;

namespace TnP.Model.Dictionaries
{
    public class LPlanDictionary
    {
        private static LPlanDictionary _pl = null;
        public static LPlanDictionary GetInstance()
        {
            if (_pl == null)
            {
                _pl = new LPlanDictionary();
            }
            return _pl;
        }

        private static object _lock = new object();
        private Dictionary<int, LPlan> planDictionary = new Dictionary<int, LPlan>();

        public void Add(LPlan p)
        {
            if (!planDictionary.ContainsKey(p.id))
            {
                lock (_lock)
                {
                    if (!planDictionary.ContainsKey(p.id)) planDictionary.Add(p.id, p);
                }
            }
        }

        public bool Upgrade(LPlan oldp, LPlan newp)
        {
            try
            {
                lock (_lock)
                {
                    if (planDictionary.ContainsKey(oldp.id)) planDictionary.Remove(oldp.id);
                    planDictionary.Add(newp.id, newp);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Remove(LPlan p)
        {
            if (planDictionary.ContainsKey(p.id))
            {
                lock (_lock)
                {
                    if (planDictionary.ContainsKey(p.id)) planDictionary.Remove(p.id);
                }
            }
        }

        public List<LPlan> GetList()
        {
            List<LPlan> pList = new List<LPlan>();
            foreach (KeyValuePair<int, LPlan> kvp in planDictionary)
            {
                pList.Add(kvp.Value);
            }
            return pList;
        }
    }
}
