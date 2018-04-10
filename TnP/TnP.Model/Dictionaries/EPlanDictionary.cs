using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Elements;

namespace TnP.Model.Dictionaries
{
    public class EPlanDictionary
    {
        private static EPlanDictionary _pl = null;
        public static EPlanDictionary GetInstance()
        {
            if (_pl == null)
            {
                _pl = new EPlanDictionary();
            }
            return _pl;
        }

        private static object _lock = new object();
        private Dictionary<int, EPlan> planDictionary = new Dictionary<int, EPlan>();

        public void Add(EPlan p)
        {
            if (!planDictionary.ContainsKey(p.id))
            {
                lock (_lock)
                {
                    if (!planDictionary.ContainsKey(p.id)) planDictionary.Add(p.id, p);
                }
            }
        }

        public bool Upgrade(EPlan oldp, EPlan newp)
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

        public void Remove(EPlan p)
        {
            if (planDictionary.ContainsKey(p.id))
            {
                lock (_lock)
                {
                    if (planDictionary.ContainsKey(p.id)) planDictionary.Remove(p.id);
                }
            }
        }

        public List<EPlan> GetList()
        {
            List<EPlan> pList = new List<EPlan>();
            foreach (KeyValuePair<int, EPlan> kvp in planDictionary)
            {
                pList.Add(kvp.Value);
            }
            return pList;
        }

    }
}
