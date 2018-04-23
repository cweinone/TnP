using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Elements;

namespace TnP.Model.Dictionaries
{
    public class AllSubDictionary
    {
        private static AllSubDictionary _pl = null;
        public static AllSubDictionary GetInstance()
        {
            if (_pl == null)
            {
                _pl = new AllSubDictionary();
            }
            return _pl;
        }

        private static object _lock = new object();
        private Dictionary<long, AllSub> subDictionary = new Dictionary<long, AllSub>();

        public void Add(AllSub p)
        {
            if (!subDictionary.ContainsKey(p.id))
            {
                lock (_lock)
                {
                    if (!subDictionary.ContainsKey(p.id)) subDictionary.Add(p.id, p);
                }
            }
        }

        public bool Upgrade(AllSub oldp, AllSub newp)
        {
            try
            {
                lock (_lock)
                {
                    if (subDictionary.ContainsKey(oldp.id)) subDictionary.Remove(oldp.id);
                    subDictionary.Add(newp.id, newp);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Remove(AllSub p)
        {
            if (subDictionary.ContainsKey(p.id))
            {
                lock (_lock)
                {
                    if (subDictionary.ContainsKey(p.id)) subDictionary.Remove(p.id);
                }
            }
        }

        public void RemoveAll()
        {
            subDictionary = new Dictionary<long, AllSub>();
        }

        public AllSub find(long id)
        {
            if (subDictionary.ContainsKey(id))
            {
                lock (_lock)
                {
                    if (subDictionary.ContainsKey(id)) return subDictionary[id];
                }
            }
            return null;
        }

        public List<AllSub> GetList()
        {
            List<AllSub> pList = new List<AllSub>();
            foreach (KeyValuePair<long, AllSub> kvp in subDictionary)
            {
                pList.Add(kvp.Value);
            }
            return pList;
        }
    }
}
