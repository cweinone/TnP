using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TnP.Model.Elements;
//using System.Threading.Tasks;

namespace TnP.Model.Dictionaries
{
    public class TaskDictionary
    {
        private static TaskDictionary _tl = null;
        public static TaskDictionary GetInstance()
        {
            if (_tl == null)
            {
                _tl = new TaskDictionary();
            }
            return _tl;
        }

        private static object _lock = new object();
        private Dictionary<int, Task> taskDictionary = new Dictionary<int, Task>();

        public void Add(Task t)
        {
            if (!taskDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (!taskDictionary.ContainsKey(t.id)) taskDictionary.Add(t.id, t);
                }
            }
        }

        public bool Upgrade(Task oldt, Task newt)
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

        public void Remove(Task t)
        {
            if (taskDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (taskDictionary.ContainsKey(t.id)) taskDictionary.Remove(t.id);
                }
            }
        }

        public List<Task> GetList()
        {
            List<Task> tList = new List<Task>();
            foreach (KeyValuePair<int, Task> kvp in taskDictionary)
            {
                tList.Add(kvp.Value);
            }
            return tList;
        }
    }
}
