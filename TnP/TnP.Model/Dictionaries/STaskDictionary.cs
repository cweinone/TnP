using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Elements;

namespace TnP.Model.Dictionaries
{
    public class STaskDictionary
    {
        private static STaskDictionary _tl = null;
        public static STaskDictionary GetInstance()
        {
            if (_tl == null)
            {
                _tl = new STaskDictionary();
            }
            return _tl;
        }

        private static object _lock = new object();
        private Dictionary<long, STask> taskDictionary = new Dictionary<long, STask>();

        public void Add(STask t)
        {
            if (!taskDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (!taskDictionary.ContainsKey(t.id)) taskDictionary.Add(t.id, t);
                }
            }
        }

        public bool Upgrade(STask oldt, STask newt)
        {
            try
            {
                lock (_lock)
                {
                    if (taskDictionary.ContainsKey(oldt.id)) taskDictionary.Remove(oldt.id);
                    taskDictionary.Add(newt.id, newt);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Remove(STask t)
        {
            if (taskDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (taskDictionary.ContainsKey(t.id)) taskDictionary.Remove(t.id);
                }
            }
        }

        public  void RemoveAll()
        {
            taskDictionary = new Dictionary<long, STask>();
        }

        public STask find(long id)
        {
            if (taskDictionary.ContainsKey(id))
            {
                lock (_lock)
                {
                    if (taskDictionary.ContainsKey(id)) return taskDictionary[id];
                }
            }
            return null;
        }

        public List<STask> GetList()
        {
            List<STask> tList = new List<STask>();
            foreach (KeyValuePair<long, STask> kvp in taskDictionary)
            {
                tList.Add(kvp.Value);
            }
            return tList;
        }
    }
}
