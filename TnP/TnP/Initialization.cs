using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TnP.Common;
using TnP.Model;
using TnP.Model.Calculators;
using TnP.Model.Dictionaries;
using TnP.Model.Elements;

namespace TnP
{
    public class Initialization
    {
        public static void Init()
        {
            FileInit();
            ViewInit();
            LoadTodoList();
        }

        private static void FileInit()
        {
            string filePath = Application.StartupPath + "\\save.xml";
            XmlDocument xmlDoc = new XmlDocument();
            //add the plan from xml file to the tree
            if (File.Exists(filePath)) xmlIO.ReadXML(filePath, xmlDoc);
        }

        private static void ViewInit()
        {
            
            
        }

        private static void LoadTodoList()
        {
            try
            {
                PopularityCal.Calculator();
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("Load PopularityCal Error: "+ ex.Message);
            }
            
            try
            {
                float totalWorkHour = 0;
                Dictionary<long, int> popDic = new Dictionary<long, int>();
                Dictionary<long, int> sortedPopDic = new Dictionary<long, int>();
                foreach (Model.Elements.Task t in TaskDictionary.GetInstance().GetList())
                {
                    if (!t.state) popDic.Add(t.id, t.popularity);
                }
                sortedPopDic = popDic.OrderBy(o => o.Value).ToDictionary(o => o.Key, p => p.Value);
                foreach (KeyValuePair<long, int> kvp in sortedPopDic)
                {
                    if (kvp.Value == 0)
                    {
                        Dictionary<int, long> staskDic = new Dictionary<int, long>();
                        foreach (long l in TaskDictionary.GetInstance().find(kvp.Key).staskID)
                        {
                            if (!STaskDictionary.GetInstance().find(l).state) staskDic.Add(STaskDictionary.GetInstance().find(l).order, l);
                        }
                        Dictionary<int, long> sortedStaskDic = staskDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

                        Dictionary<int, long> subtaskDic = new Dictionary<int, long>();
                        foreach (long l in STaskDictionary.GetInstance().find(sortedStaskDic.First().Value).subtaskID)
                        {
                            if (!SubTaskDictionary.GetInstance().find(l).state) subtaskDic.Add(SubTaskDictionary.GetInstance().find(l).order, l);
                        }
                        Dictionary<int, long> sortedSubtaskDic = subtaskDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

                        SubTaskDictionary.GetInstance().find(sortedSubtaskDic.First().Value).ready = true;
                        if (SubTaskDictionary.GetInstance().find(sortedSubtaskDic.First().Value).expecLastT == null) totalWorkHour += 1;
                        else totalWorkHour += SubTaskDictionary.GetInstance().find(sortedSubtaskDic.First().Value).expecLastT.Hours;
                    }
                }
                Dictionary<long, int> revSortedPopDic = sortedPopDic.Reverse().ToDictionary(o => o.Key, p => p.Value);
                int maxNum = 0;
                while (totalWorkHour < 16)
                {
                    int forN = 0;
                    foreach (KeyValuePair<long, int> kvp in revSortedPopDic)
                    {
                        if (kvp.Value != 0)
                        {
                            Dictionary<int, long> staskDic = new Dictionary<int, long>();
                            foreach (long l in TaskDictionary.GetInstance().find(kvp.Key).staskID)
                            {
                                if (!STaskDictionary.GetInstance().find(l).state) staskDic.Add(STaskDictionary.GetInstance().find(l).order, l);
                            }
                            Dictionary<int, long> sortedStaskDic = staskDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

                            Dictionary<int, long> subtaskDic = new Dictionary<int, long>();
                            foreach (long l in STaskDictionary.GetInstance().find(sortedStaskDic.First().Value).subtaskID)
                            {
                                if (!SubTaskDictionary.GetInstance().find(l).state 
                                    && !SubTaskDictionary.GetInstance().find(l).ready) subtaskDic.Add(SubTaskDictionary.GetInstance().find(l).order, l);
                            }
                            Dictionary<int, long> sortedSubtaskDic = subtaskDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

                            SubTaskDictionary.GetInstance().find(sortedSubtaskDic.First().Value).ready = true;
                            if (SubTaskDictionary.GetInstance().find(sortedSubtaskDic.First().Value).expecLastT == null) totalWorkHour += 1;
                            else totalWorkHour += SubTaskDictionary.GetInstance().find(sortedSubtaskDic.First().Value).expecLastT.Hours;
                        }
                        forN += 1;
                        if (forN > maxNum) break;
                    }
                    maxNum += 1;
                    if (maxNum > 24) break;
                }
                foreach(SubTask st in SubTaskDictionary.GetInstance().GetList())
                {
                    EPlan ep = new EPlan();
                    ep.name = st.name;
                    ep.id = st.id;
                    ep.finalT = st.finalT;
                    ep.lastT = st.lastT;
                    ep.showT = st.showT;
                    ep.startF = st.startF;
                    ep.stopF = st.stopF;
                    ep.startT = st.startT;
                    ep.stopT = st.stopT;
                    EPlanDictionary.GetInstance().Add(ep);
                }
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("Load TodoList Error: " + ex.Message);
            }

        }
    }
}
