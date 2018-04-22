using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Xml;
using TnP.Model.Dictionaries;
using TnP.Model.Elements;

namespace TnP.Common
{
    public class xmlIO
    {
        public static void SaveXML(string filePath, XmlDocument xmlDoc)
        {
            //create new
            xmlDoc.RemoveAll();

            //declaration
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(declaration);

            //root
            XmlNode root = xmlDoc.CreateElement("Information");
            xmlDoc.AppendChild(root);

            XmlNode root_plan = xmlDoc.CreateElement("Plans");
            root.AppendChild(root_plan);

            //save plans
            if (EPlanDictionary.GetInstance().GetList() != null)
            {
                List<EPlan> list = EPlanDictionary.GetInstance().GetList();
                for (int i = 0; i < list.Count; i++)
                {
                    //sub
                    XmlElement xmlplan = xmlDoc.CreateElement("Plan");
                    xmlplan.SetAttribute("id", (i + 1).ToString());

                    XmlElement name = xmlDoc.CreateElement("name");
                    XmlElement id = xmlDoc.CreateElement("id");
                    XmlElement progress = xmlDoc.CreateElement("progress");
                    XmlElement state = xmlDoc.CreateElement("state");
                    XmlElement showT = xmlDoc.CreateElement("appeared_time");
                    XmlElement startT = xmlDoc.CreateElement("started_time");
                    XmlElement endT = xmlDoc.CreateElement("end_time");
                    XmlElement finalT = xmlDoc.CreateElement("expected_end_time");
                    XmlElement startF = xmlDoc.CreateElement("started_frequency");
                    XmlElement stopF = xmlDoc.CreateElement("stopped_frequency");
                    XmlElement endState = xmlDoc.CreateElement("end_state");
                    XmlElement lastT = xmlDoc.CreateElement("last_time");
                    XmlElement steps = xmlDoc.CreateElement("steps");

                    name.InnerText = list[i].name;
                    id.InnerText = list[i].id.ToString();
                    progress.InnerText = list[i].progress.ToString();
                    if (list[i].state) state.InnerText = "activated";
                    else state.InnerText = "inactivated";
                    showT.InnerText = list[i].showT.ToString();
                    if (list[i].startT != null) startT.InnerText = list[i].startT.ToString();
                    else startT.InnerText = "0";
                    if (list[i].endT != null) endT.InnerText = list[i].endT.ToString();
                    else endT.InnerText = "0";
                    if (list[i].finalT != null) finalT.InnerText = list[i].finalT.ToString();
                    else finalT.InnerText = "0";
                    startF.InnerText = list[i].startF.ToString();
                    stopF.InnerText = list[i].stopF.ToString();
                    if (list[i].endState) endState.InnerText = "done";
                    else endState.InnerText = "gave_up";
                    lastT.InnerText = list[i].lastT.ToString();
                    for (int j = 0; j < list[i].steps.Count; j++)
                    {
                        XmlElement step = xmlDoc.CreateElement("step");
                        step.SetAttribute("order", (j + 1).ToString());
                        step.InnerText = list[i].steps[j].name;
                        steps.AppendChild(step);
                    }

                    xmlplan.AppendChild(name);
                    xmlplan.AppendChild(id);
                    xmlplan.AppendChild(progress);
                    xmlplan.AppendChild(state);
                    xmlplan.AppendChild(showT);
                    xmlplan.AppendChild(startT);
                    xmlplan.AppendChild(endT);
                    xmlplan.AppendChild(finalT);
                    xmlplan.AppendChild(startF);
                    xmlplan.AppendChild(stopF);
                    xmlplan.AppendChild(endState);
                    xmlplan.AppendChild(lastT);
                    xmlplan.AppendChild(steps);

                    root_plan.AppendChild(xmlplan);

                }
            }
            //root
            XmlNode root_lplan = xmlDoc.CreateElement("LPlans");
            root.AppendChild(root_lplan);
            //save lplan
            if (LPlanDictionary.GetInstance().GetList() != null)
            {
                List<LPlan> list = LPlanDictionary.GetInstance().GetList();
                for (int i = 0; i < list.Count; i++)
                {

                    //sub
                    XmlElement xmllplan = xmlDoc.CreateElement("LPlan");
                    xmllplan.SetAttribute("id", (i + 1).ToString());

                    XmlElement name = xmlDoc.CreateElement("name");
                    XmlElement id = xmlDoc.CreateElement("id");
                    

                    name.InnerText = list[i].name;
                    id.InnerText = list[i].id.ToString();
                    
                    xmllplan.AppendChild(name);
                    xmllplan.AppendChild(id);
                    
                    root_lplan.AppendChild(xmllplan);

                }
            }
            //root
            XmlNode root_task = xmlDoc.CreateElement("Tasks");
            root.AppendChild(root_task);
            // save task
            if (TaskDictionary.GetInstance().GetList() != null)
            {
                List<Task> list = TaskDictionary.GetInstance().GetList();
                for (int i = 0; i < list.Count; i++)
                {

                    //sub
                    XmlElement xmltask = xmlDoc.CreateElement("Task");
                    xmltask.SetAttribute("id", (i + 1).ToString());

                    XmlElement name = xmlDoc.CreateElement("name");
                    XmlElement id = xmlDoc.CreateElement("id");
                   
                    name.InnerText = list[i].name;
                    id.InnerText = list[i].id.ToString();
                    
                    xmltask.AppendChild(name);
                    xmltask.AppendChild(id);
                    
                    root_task.AppendChild(xmltask);

                }
            }
            //root
            XmlNode root_goal = xmlDoc.CreateElement("Goals");
            root.AppendChild(root_goal);
            // save goals
            if (GoalDictionary.GetInstance().GetList() != null)
            {
                List<Goal> list = GoalDictionary.GetInstance().GetList();
                for (int i = 0; i < list.Count; i++)
                {

                    //sub
                    XmlElement xmlgoal = xmlDoc.CreateElement("Goal");
                    xmlgoal.SetAttribute("id", (i + 1).ToString());

                    XmlElement name = xmlDoc.CreateElement("name");
                    XmlElement id = xmlDoc.CreateElement("id");
                   
                    name.InnerText = list[i].name;
                    id.InnerText = list[i].id.ToString();
                    
                    xmlgoal.AppendChild(name);
                    xmlgoal.AppendChild(id);
                    
                    root_goal.AppendChild(xmlgoal);

                }
            }
            //root
            XmlNode root_thought = xmlDoc.CreateElement("Thoughts");
            root.AppendChild(root_thought);
            // save thoughts
            if (ThoughtDictionary.GetInstance().GetList() != null)
            {
                List<Thought> list = ThoughtDictionary.GetInstance().GetList();
                for (int i = 0; i < list.Count; i++)
                {

                    //sub
                    XmlElement xmlthought = xmlDoc.CreateElement("Thought");
                    xmlthought.SetAttribute("id", (i + 1).ToString());

                    XmlElement name = xmlDoc.CreateElement("name");
                    XmlElement id = xmlDoc.CreateElement("id");
                    
                    name.InnerText = list[i].name;
                    id.InnerText = list[i].id.ToString();
                    
                    xmlthought.AppendChild(name);
                    xmlthought.AppendChild(id);
                    
                    root_thought.AppendChild(xmlthought);

                }
            }
            //save file
            xmlDoc.Save(filePath);
        }

        public static void ReadXML(string filePath, XmlDocument xmlDoc)
        {
            xmlDoc.Load(filePath);


            //load plan

            XmlNodeList planNodeList = xmlDoc.SelectSingleNode("Information/Plans").ChildNodes;

            foreach (XmlNode xnode in planNodeList)
            {
                EPlan plan = new EPlan();
                XmlElement xe = (XmlElement)xnode;

                plan.name = xe.GetElementsByTagName("name")[0].InnerText;
                plan.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                plan.progress = int.Parse(xe.GetElementsByTagName("progress")[0].InnerText);
                if (xe.GetElementsByTagName("state")[0].InnerText == "activated") plan.state = true;
                else if (xe.GetElementsByTagName("state")[0].InnerText == "inactivated") plan.state = false;
                plan.showT = Convert.ToDateTime(xe.GetElementsByTagName("appeared_time")[0].InnerText);
                plan.startT = Convert.ToDateTime(xe.GetElementsByTagName("started_time")[0].InnerText);
                plan.endT = Convert.ToDateTime(xe.GetElementsByTagName("end_time")[0].InnerText);
                plan.finalT = Convert.ToDateTime(xe.GetElementsByTagName("expected_end_time")[0].InnerText);
                plan.startF = int.Parse(xe.GetElementsByTagName("started_frequency")[0].InnerText);
                plan.stopF = int.Parse(xe.GetElementsByTagName("stopped_frequency")[0].InnerText);
                if (xe.GetElementsByTagName("end_state")[0].InnerText == "done") plan.endState = true;
                else if (xe.GetElementsByTagName("end_state")[0].InnerText == "gave_up") plan.endState = false;
                plan.lastT = TimeSpan.Parse(xe.GetElementsByTagName("last_time")[0].InnerText);
                for (int i = 0; i < xe.GetElementsByTagName("steps")[0].ChildNodes.Count; i++)
                {
                    Step s = new Step();
                    s.name = xe.GetElementsByTagName("steps")[0].ChildNodes[i].InnerText;
                    plan.steps.Add(s);
                }

                EPlanDictionary.GetInstance().Add(plan);
            }

            //load lplan

            XmlNodeList lplanNodeList = xmlDoc.SelectSingleNode("Information/LPlans").ChildNodes;


            foreach (XmlNode xnode in lplanNodeList)
            {

                LPlan lplan = new LPlan();
                XmlElement xe = (XmlElement)xnode;

                lplan.name = xe.GetElementsByTagName("name")[0].InnerText;
                lplan.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                
                LPlanDictionary.GetInstance().Add(lplan);
            }

            //load task
            XmlNodeList taskNodeList = xmlDoc.SelectSingleNode("Information/Tasks").ChildNodes;


            foreach (XmlNode xnode in taskNodeList)
            {

                Task task = new Task();
                XmlElement xe = (XmlElement)xnode;

                task.name = xe.GetElementsByTagName("name")[0].InnerText;
                task.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                
                TaskDictionary.GetInstance().Add(task);
            }

            //load goal

            XmlNodeList goalNodeList = xmlDoc.SelectSingleNode("Information/Goals").ChildNodes;


            foreach (XmlNode xnode in goalNodeList)
            {

                Goal goal = new Goal();
                XmlElement xe = (XmlElement)xnode;

                goal.name = xe.GetElementsByTagName("name")[0].InnerText;
                goal.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                
                GoalDictionary.GetInstance().Add(goal);
            }

            //load thought

            XmlNodeList thoughtNodeList = xmlDoc.SelectSingleNode("Information/Thoughts").ChildNodes;


            foreach (XmlNode xnode in thoughtNodeList)
            {

                Thought thought = new Thought();
                XmlElement xe = (XmlElement)xnode;

                thought.name = xe.GetElementsByTagName("name")[0].InnerText;
                thought.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                
                ThoughtDictionary.GetInstance().Add(thought);
            }
        }

    }
}
