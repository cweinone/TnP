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
                EPlan plan = new EPlan();
                plan.name = p;
                plan.id = id;
                EPlanDictionary.GetInstance().Add(plan);
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
                        p.lastT += DateTime.Now - p.startT;//*** have problem here ***
                    }
                }
                EPlan plan = EPlanDictionary.GetInstance().find(id);
                plan.state = true;
                plan.startF += 1;
                if (plan.startT == null) plan.startT = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("MainFormController/StartPlan Error: " + ex.Message);
                return false;
            }

        }

        public static bool StopPlan(long id)
        {
            try
            {
                foreach (EPlan p in EPlanDictionary.GetInstance().GetList())
                {
                    if (p.state == true)
                    {
                        p.state = false;
                        p.stopF += 1;
                        p.lastT += DateTime.Now - p.startT;//*** have problem here ***
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
                    plan.lastT += DateTime.Now - plan.startT;
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
