using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Model.Elements;

namespace TnP.Model.Dictionaries
{
    public class GoalDictionary
    {
        private static GoalDictionary _gl = null;
        public static GoalDictionary GetInstance()
        {
            if (_gl == null)
            {
                _gl = new GoalDictionary();
            }
            return _gl;
        }

        private static object _lock = new object();
        private Dictionary<int, Goal> goalDictionary = new Dictionary<int, Goal>();

        public void Add(Goal g)
        {
            if (!goalDictionary.ContainsKey(g.id))
            {
                lock (_lock)
                {
                    if (!goalDictionary.ContainsKey(g.id)) goalDictionary.Add(g.id, g);
                }
            }
        }

        public bool Upgrade(Goal oldg, Goal newg)
        {
            try
            {
                lock (_lock)
                {
                    if (goalDictionary.ContainsKey(oldg.id)) goalDictionary.Remove(oldg.id);
                    goalDictionary.Add(newg.id, newg);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Remove(Goal g)
        {
            if (goalDictionary.ContainsKey(g.id))
            {
                lock (_lock)
                {
                    if (goalDictionary.ContainsKey(g.id)) goalDictionary.Remove(g.id);
                }
            }
        }

        public List<Goal> GetList()
        {
            List<Goal> gList = new List<Goal>();
            foreach (KeyValuePair<int, Goal> kvp in goalDictionary)
            {
                gList.Add(kvp.Value);
            }
            return gList;
        }
    }
}
