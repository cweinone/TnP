using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Elements;

namespace TnP.Model.Dictionaries
{
    public class SubTaskDictionary
    {
        private static SubTaskDictionary _tl = null;
        public static SubTaskDictionary GetInstance()
        {
            if (_tl == null)
            {
                _tl = new SubTaskDictionary();
            }
            return _tl;
        }

        private static object _lock = new object();
        private Dictionary<long, SubTask> taskDictionary = new Dictionary<long, SubTask>();

        public void Add(SubTask t)
        {
            if (!taskDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (!taskDictionary.ContainsKey(t.id)) taskDictionary.Add(t.id, t);
                }
            }
        }

        public bool Upgrade(SubTask oldt, SubTask newt)
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

        public void Remove(SubTask t)
        {
            if (taskDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (taskDictionary.ContainsKey(t.id)) taskDictionary.Remove(t.id);
                }
            }
        }

        public void RemoveAll()
        {
            taskDictionary = new Dictionary<long, SubTask>();
        }

        public SubTask find(long id)
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

        public List<SubTask> GetList()
        {
            List<SubTask> tList = new List<SubTask>();
            foreach (KeyValuePair<long, SubTask> kvp in taskDictionary)
            {
                tList.Add(kvp.Value);
            }
            return tList;
        }
    }
}
