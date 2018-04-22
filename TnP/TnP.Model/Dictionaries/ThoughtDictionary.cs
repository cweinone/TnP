using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Elements;

namespace TnP.Model.Dictionaries
{
    public class ThoughtDictionary
    {
        private static ThoughtDictionary _tl = null;
        public static ThoughtDictionary GetInstance()
        {
            if (_tl == null)
            {
                _tl = new ThoughtDictionary();
            }
            return _tl;
        }

        private static object _lock = new object();
        private Dictionary<long, Thought> thoughtDictionary = new Dictionary<long, Thought>();

        public void Add(Thought t)
        {
            if (!thoughtDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (!thoughtDictionary.ContainsKey(t.id)) thoughtDictionary.Add(t.id, t);
                }
            }
        }

        public bool Upgrade(Thought oldt, Thought newt)
        {
            try
            {
                lock (_lock)
                {
                    if (thoughtDictionary.ContainsKey(oldt.id)) thoughtDictionary.Remove(oldt.id);
                    thoughtDictionary.Add(newt.id, newt);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Remove(Thought t)
        {
            if (thoughtDictionary.ContainsKey(t.id))
            {
                lock (_lock)
                {
                    if (thoughtDictionary.ContainsKey(t.id)) thoughtDictionary.Remove(t.id);
                }
            }
        }

        public List<Thought> GetList()
        {
            List<Thought> tList = new List<Thought>();
            foreach (KeyValuePair<long, Thought> kvp in thoughtDictionary)
            {
                tList.Add(kvp.Value);
            }
            return tList;
        }
    }
}
