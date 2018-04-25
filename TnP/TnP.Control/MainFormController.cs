using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnP.Common;
using TnP.Model;
using TnP.Model.Dictionaries;
using TnP.Model.Elements;

namespace TnP.Control
{
    public class MainFormController
    {
        public static bool AddTask(string t, long id)
        {
            try
            {
                Model.Elements.Task task = new Model.Elements.Task();
                task.name = t;
                task.id = id;
                TaskDictionary.GetInstance().Add(task);
                return true;
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("MainFormController/AddTask Error: " + ex.Message);
                return false;
            }
            
        }

        public static bool AddPlan(string p, long id)
        {
            try
            {
                if(TaskDictionary.GetInstance().find(0) == null)
                {
                    Model.Elements.Task task = new Model.Elements.Task();
                    task.name = "DEFAULT";
                    task.id = 0;
                    task.scale = 31;
                    TaskDictionary.GetInstance().Add(task);

                    STask st = new STask();
                    st.name = "DEFAULT_STASK";
                    st.id = 0;
                    st.order = 0;
                    STaskDictionary.GetInstance().Add(st);

                    SubTask subt = new SubTask();
                    subt.name = p;
                    subt.id = id;
                    subt.showT = DateTime.Now;
                    SubTaskDictionary.GetInstance().Add(subt);

                    EPlan plan = new EPlan();
                    plan.name = p;
                    plan.id = id;
                    plan.showT = DateTime.Now;
                    EPlanDictionary.GetInstance().Add(plan);

                    st.subtaskID.Add(subt.id);
                    task.staskID.Add(st.id);
                }
                else
                {
                    Model.Elements.Task task = TaskDictionary.GetInstance().find(0);

                    SubTask subt = new SubTask();
                    subt.name = p;
                    subt.id = id;
                    subt.showT = DateTime.Now;
                    SubTaskDictionary.GetInstance().Add(subt);

                    EPlan plan = new EPlan();
                    plan.name = p;
                    plan.id = id;
                    plan.showT = DateTime.Now;
                    EPlanDictionary.GetInstance().Add(plan);

                    STaskDictionary.GetInstance().find(0).subtaskID.Add(subt.id);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("MainFormController/AddPlan Error: " + ex.Message);
                return false;
            }

        }

        public static bool RemovePlan(long id)
        {
            try
            {
                EPlanDictionary.GetInstance().Remove(EPlanDictionary.GetInstance().find(id));
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("MainFormController/RemovePlan Error: " + ex.Message);
                return false;
            }

        }

        public static bool StartPlan(long id)
        {
            try
            {
                foreach (EPlan p in EPlanDictionary.GetInstance().GetList())
                {
                    if (p.state == true)
                    {
                        p.state = false;
                        p.stopF += 1;
                        p.lastT += DateTime.Now - p.startT.Last();//*** have problem here ***
                    }
                }
                EPlan plan = EPlanDictionary.GetInstance().find(id);
                plan.state = true;
                plan.startF += 1;
                plan.startT.Add(DateTime.Now);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("MainFormController/StartPlan Error: " + ex.Message);
                return false;
            }

        }

        public static bool StopPlan()
        {
            try
            {
                foreach (EPlan p in EPlanDictionary.GetInstance().GetList())
                {
                    if (p.state == true)
                    {
                        p.state = false;
                        p.stopF += 1;
                        p.lastT += DateTime.Now - p.startT.Last();//*** have problem here ***
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("MainFormController/StopPlan Error: " + ex.Message);
                return false;
            }
        }

        public static bool DonePlan(long id)
        {
            try
            {
                EPlan plan = EPlanDictionary.GetInstance().find(id);
                if(plan.state)
                {
                    plan.endT = DateTime.Now;
                    plan.lastT += DateTime.Now - plan.startT.Last();
                    plan.endState = true;
                    plan.progress += 10;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("MainFormController/DonePlan Error: " + ex.Message);
                return false;
            }
        }
    }
}
