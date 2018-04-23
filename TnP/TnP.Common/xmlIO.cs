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

            try
            {
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
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("Saving eplan XML error: " + ex.Message);
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Saving lplan XML error: " + ex.Message);
            }

            try
            {
                //root
                XmlNode root_allsub = xmlDoc.CreateElement("AllSub");
                root.AppendChild(root_allsub);
                //save allsub
                if (AllSubDictionary.GetInstance().GetList() != null)
                {
                    List<AllSub> list = AllSubDictionary.GetInstance().GetList();
                    for (int i = 0; i < list.Count; i++)
                    {

                        //sub
                        XmlElement xmllsub = xmlDoc.CreateElement("Sub");
                        xmllsub.SetAttribute("id", (i + 1).ToString());

                        XmlElement name = xmlDoc.CreateElement("name");
                        XmlElement id = xmlDoc.CreateElement("id");

                        name.InnerText = list[i].name;
                        id.InnerText = list[i].id.ToString();

                        xmllsub.AppendChild(name);
                        xmllsub.AppendChild(id);

                        root_allsub.AppendChild(xmllsub);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Saving lplan XML error: " + ex.Message);
            }

            try
            {
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
                        XmlElement progress = xmlDoc.CreateElement("progress");
                        XmlElement goalID = xmlDoc.CreateElement("goalID");
                        XmlElement staskIDs = xmlDoc.CreateElement("staskIDs");
                        XmlElement allSubIDs = xmlDoc.CreateElement("allSubIDs");
                        XmlElement expecT = xmlDoc.CreateElement("expecT");
                        XmlElement dailyDoneCount = xmlDoc.CreateElement("dailyDoneCount");
                        XmlElement creatT = xmlDoc.CreateElement("creatT");
                        XmlElement totalT = xmlDoc.CreateElement("totalT");
                        XmlElement totalSubtaskNum = xmlDoc.CreateElement("totalSubtaskNum");
                        XmlElement doneSubtaskNum = xmlDoc.CreateElement("doneSubtaskNum");
                        XmlElement popularity = xmlDoc.CreateElement("popularity");
                        XmlElement reward = xmlDoc.CreateElement("reward");
                        XmlElement state = xmlDoc.CreateElement("state");

                        name.InnerText = list[i].name;
                        id.InnerText = list[i].id.ToString();
                        progress.InnerText = list[i].progress.ToString();
                        goalID.InnerText = list[i].goalID.ToString();
                        //staskIDs.RemoveAll();
                        for (int j = 0; j < list[i].staskID.Count; j++)
                        {
                            XmlElement staskID = xmlDoc.CreateElement("staskID");
                            staskID.InnerText = list[i].staskID[j].ToString();
                            staskIDs.AppendChild(staskID);
                        }
                        //allSubIDs.RemoveAll();
                        for (int j = 0; j < list[i].allSubID.Count; j++)
                        {
                            XmlElement allSubID = xmlDoc.CreateElement("allSubID");
                            allSubID.InnerText = list[i].allSubID[j].ToString();
                            allSubIDs.AppendChild(allSubID);
                        }
                        expecT.InnerText = list[i].expecT.ToString();
                        //dailyDoneCount.RemoveAll();
                        for (int j = 0; j < list[i].dailyDoneCount.Count; j++)
                        {
                            XmlElement doneCount = xmlDoc.CreateElement("doneCount");
                            doneCount.InnerText = list[i].dailyDoneCount[j].ToString();
                            dailyDoneCount.AppendChild(doneCount);
                        }
                        creatT.InnerText = list[i].creatT.ToString();
                        totalT.InnerText = list[i].totalT.ToString();
                        totalSubtaskNum.InnerText = list[i].totalSubtaskNum.ToString();
                        doneSubtaskNum.InnerText = list[i].doneSubtaskNum.ToString();
                        popularity.InnerText = list[i].popularity.ToString();
                        reward.InnerText = list[i].reward.ToString();
                        if (list[i].state) state.InnerText = "closed";
                        else state.InnerText = "open";

                        xmltask.AppendChild(name);
                        xmltask.AppendChild(id);
                        xmltask.AppendChild(progress);
                        xmltask.AppendChild(goalID);
                        xmltask.AppendChild(staskIDs);
                        xmltask.AppendChild(allSubIDs);
                        xmltask.AppendChild(expecT);
                        xmltask.AppendChild(dailyDoneCount);
                        xmltask.AppendChild(creatT);
                        xmltask.AppendChild(totalT);
                        xmltask.AppendChild(totalSubtaskNum);
                        xmltask.AppendChild(doneSubtaskNum);
                        xmltask.AppendChild(popularity);
                        xmltask.AppendChild(reward);
                        xmltask.AppendChild(state);

                        root_task.AppendChild(xmltask);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Saving task XML error: " + ex.Message);
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Saving goal XML error: " + ex.Message);
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Saving thought XML error: " + ex.Message);
            }

            try
            {
                //root
                XmlNode root_stask = xmlDoc.CreateElement("STasks");
                root.AppendChild(root_stask);
                // save thoughts
                if (STaskDictionary.GetInstance().GetList() != null)
                {
                    List<STask> list = STaskDictionary.GetInstance().GetList();
                    for (int i = 0; i < list.Count; i++)
                    {

                        //sub
                        XmlElement xmlstask = xmlDoc.CreateElement("STask");
                        xmlstask.SetAttribute("id", (i + 1).ToString());

                        XmlElement name = xmlDoc.CreateElement("name");
                        XmlElement id = xmlDoc.CreateElement("id");
                        XmlElement taskID = xmlDoc.CreateElement("taskID");
                        XmlElement order = xmlDoc.CreateElement("order");
                        XmlElement procedure = xmlDoc.CreateElement("procedure");
                        XmlElement structure = xmlDoc.CreateElement("structure");
                        XmlElement lplanID = xmlDoc.CreateElement("lplanID");
                        XmlElement subtaskIDs = xmlDoc.CreateElement("subtaskIDs");
                        XmlElement state = xmlDoc.CreateElement("state");
                        XmlElement totalT = xmlDoc.CreateElement("totalT");
                        XmlElement totalSubtaskNum = xmlDoc.CreateElement("totalSubtaskNum");
                        XmlElement doneSubtaskNum = xmlDoc.CreateElement("doneSubtaskNum");
                        XmlElement reward = xmlDoc.CreateElement("reward");


                        name.InnerText = list[i].name;
                        id.InnerText = list[i].id.ToString();
                        taskID.InnerText = list[i].taskID.ToString();
                        order.InnerText = list[i].order.ToString();
                        if (list[i].procedure) procedure.InnerText = "procedure";
                        else procedure.InnerText = "nprocedure";
                        if (list[i].structure) structure.InnerText = "structure";
                        else structure.InnerText = "nstructure";
                        lplanID.InnerText = list[i].lplanID.ToString();
                        //subtaskIDs.RemoveAll();
                        for (int j = 0; j < list[i].subtaskID.Count; j++)
                        {
                            XmlElement subtaskID = xmlDoc.CreateElement("subtaskID");
                            subtaskID.InnerText = list[i].subtaskID[j].ToString();
                            subtaskIDs.AppendChild(subtaskID);
                        }
                        if (list[i].state) state.InnerText = "closed";
                        else state.InnerText = "open";
                        totalT.InnerText = list[i].totalT.ToString();
                        totalSubtaskNum.InnerText = list[i].totalSubtaskNum.ToString();
                        doneSubtaskNum.InnerText = list[i].doneSubtaskNum.ToString();
                        reward.InnerText = list[i].reward.ToString();

                        xmlstask.AppendChild(name);
                        xmlstask.AppendChild(id);
                        xmlstask.AppendChild(taskID);
                        xmlstask.AppendChild(order);
                        xmlstask.AppendChild(procedure);
                        xmlstask.AppendChild(structure);
                        xmlstask.AppendChild(lplanID);
                        xmlstask.AppendChild(subtaskIDs);
                        xmlstask.AppendChild(state);
                        xmlstask.AppendChild(totalT);
                        xmlstask.AppendChild(totalSubtaskNum);
                        xmlstask.AppendChild(doneSubtaskNum);
                        xmlstask.AppendChild(reward);

                        root_stask.AppendChild(xmlstask);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Saving stask XML error: " + ex.Message);
            }

            try
            {
                //root
                XmlNode root_subtask = xmlDoc.CreateElement("SubTasks");
                root.AppendChild(root_subtask);
                // save thoughts
                if (SubTaskDictionary.GetInstance().GetList() != null)
                {
                    List<SubTask> list = SubTaskDictionary.GetInstance().GetList();
                    for (int i = 0; i < list.Count; i++)
                    {

                        //sub
                        XmlElement xmlsubtask = xmlDoc.CreateElement("SubTask");
                        xmlsubtask.SetAttribute("id", (i + 1).ToString());

                        XmlElement name = xmlDoc.CreateElement("name");
                        XmlElement id = xmlDoc.CreateElement("id");
                        XmlElement staskID = xmlDoc.CreateElement("staskID");
                        XmlElement order = xmlDoc.CreateElement("order");
                        XmlElement eplanID = xmlDoc.CreateElement("eplanID");
                        XmlElement ready = xmlDoc.CreateElement("ready");
                        XmlElement inout = xmlDoc.CreateElement("inout");
                        XmlElement state = xmlDoc.CreateElement("state");
                        XmlElement difficulty = xmlDoc.CreateElement("difficulty");
                        XmlElement reward = xmlDoc.CreateElement("reward");



                        name.InnerText = list[i].name;
                        id.InnerText = list[i].id.ToString();
                        staskID.InnerText = list[i].staskID.ToString();
                        order.InnerText = list[i].order.ToString();
                        if (list[i].ready) ready.InnerText = "is_ready";
                        else ready.InnerText = "not_ready";
                        if (list[i].inout) inout.InnerText = "in";
                        else inout.InnerText = "out";
                        eplanID.InnerText = list[i].eplanID.ToString();
                        if (list[i].state) state.InnerText = "closed";
                        else state.InnerText = "open";
                        difficulty.InnerText = list[i].difficulty.ToString();
                        reward.InnerText = list[i].reward.ToString();

                        xmlsubtask.AppendChild(name);
                        xmlsubtask.AppendChild(id);
                        xmlsubtask.AppendChild(staskID);
                        xmlsubtask.AppendChild(order);
                        xmlsubtask.AppendChild(ready);
                        xmlsubtask.AppendChild(inout);
                        xmlsubtask.AppendChild(eplanID);
                        xmlsubtask.AppendChild(difficulty);
                        xmlsubtask.AppendChild(state);
                        xmlsubtask.AppendChild(reward);

                        root_subtask.AppendChild(xmlsubtask);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Saving subtask XML error: " + ex.Message);
            }
            
            
            //save file
            xmlDoc.Save(filePath);
        }

        public static void ReadXML(string filePath, XmlDocument xmlDoc)
        {
            xmlDoc.Load(filePath);

            try
            {
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
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("Loading eplan XML error: " + ex.Message);
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Loading lplan XML error: " + ex.Message);
            }

            try
            {
                //load allsub

                XmlNodeList subNodeList = xmlDoc.SelectSingleNode("Information/AllSub").ChildNodes;


                foreach (XmlNode xnode in subNodeList)
                {

                    AllSub alls = new AllSub();
                    XmlElement xe = (XmlElement)xnode;

                    alls.name = xe.GetElementsByTagName("name")[0].InnerText;
                    alls.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);

                    AllSubDictionary.GetInstance().Add(alls);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Loading lplan XML error: " + ex.Message);
            }

            try
            {
                //load task
                XmlNodeList taskNodeList = xmlDoc.SelectSingleNode("Information/Tasks").ChildNodes;


                foreach (XmlNode xnode in taskNodeList)
                {

                    Task task = new Task();
                    XmlElement xe = (XmlElement)xnode;

                    task.name = xe.GetElementsByTagName("name")[0].InnerText;
                    task.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                    task.progress = int.Parse(xe.GetElementsByTagName("progress")[0].InnerText);
                    task.goalID = long.Parse(xe.GetElementsByTagName("goalID")[0].InnerText);
                    for (int i = 0; i < xe.GetElementsByTagName("staskIDs")[0].ChildNodes.Count; i++)
                    {
                        long l = long.Parse(xe.GetElementsByTagName("staskIDs")[0].ChildNodes[i].InnerText);
                        task.staskID.Add(l);
                    }
                    for (int i = 0; i < xe.GetElementsByTagName("allSubIDs")[0].ChildNodes.Count; i++)
                    {
                        long l = long.Parse(xe.GetElementsByTagName("allSubIDs")[0].ChildNodes[i].InnerText);
                        task.allSubID.Add(l);
                    }
                    task.expecT = Convert.ToDateTime(xe.GetElementsByTagName("expecT")[0].InnerText);
                    task.creatT = Convert.ToDateTime(xe.GetElementsByTagName("creatT")[0].InnerText);
                    task.totalT = TimeSpan.Parse(xe.GetElementsByTagName("totalT")[0].InnerText);
                    for (int i = 0; i < xe.GetElementsByTagName("dailyDoneCount")[0].ChildNodes.Count; i++)
                    {
                        int l = int.Parse(xe.GetElementsByTagName("dailyDoneCount")[0].ChildNodes[i].InnerText);
                        task.dailyDoneCount.Add(l);
                    }
                    task.totalSubtaskNum = int.Parse(xe.GetElementsByTagName("totalSubtaskNum")[0].InnerText);
                    task.doneSubtaskNum = int.Parse(xe.GetElementsByTagName("doneSubtaskNum")[0].InnerText);
                    task.popularity = int.Parse(xe.GetElementsByTagName("popularity")[0].InnerText);
                    task.reward = int.Parse(xe.GetElementsByTagName("reward")[0].InnerText);
                    if (xe.GetElementsByTagName("state")[0].InnerText == "closed") task.state = true;
                    else if (xe.GetElementsByTagName("state")[0].InnerText == "open") task.state = false;


                    TaskDictionary.GetInstance().Add(task);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Loading task XML error: " + ex.Message);
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Loading goal XML error: " + ex.Message);
            }

            try
            {
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
            catch (Exception ex)
            {
                Logger.WriteLogs("Loading thought XML error: " + ex.Message);
            }

            try
            {
                //load stask

                XmlNodeList sTaskNodeList = xmlDoc.SelectSingleNode("Information/STasks").ChildNodes;


                foreach (XmlNode xnode in sTaskNodeList)
                {

                    STask sTask = new STask();
                    XmlElement xe = (XmlElement)xnode;

                    sTask.name = xe.GetElementsByTagName("name")[0].InnerText;
                    sTask.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                    sTask.taskID = long.Parse(xe.GetElementsByTagName("taskID")[0].InnerText);
                    sTask.order = int.Parse(xe.GetElementsByTagName("order")[0].InnerText);
                    sTask.lplanID = int.Parse(xe.GetElementsByTagName("lplanID")[0].InnerText);
                    sTask.totalSubtaskNum = int.Parse(xe.GetElementsByTagName("totalSubtaskNum")[0].InnerText);
                    sTask.doneSubtaskNum = int.Parse(xe.GetElementsByTagName("doneSubtaskNum")[0].InnerText);
                    sTask.reward = int.Parse(xe.GetElementsByTagName("reward")[0].InnerText);
                    for (int i = 0; i < xe.GetElementsByTagName("subtaskIDs")[0].ChildNodes.Count; i++)
                    {
                        long l = long.Parse(xe.GetElementsByTagName("subtaskIDs")[0].ChildNodes[i].InnerText);
                        sTask.subtaskID.Add(l);
                    }
                    if (xe.GetElementsByTagName("state")[0].InnerText == "closed") sTask.state = true;
                    else if (xe.GetElementsByTagName("state")[0].InnerText == "open") sTask.state = false;
                    if (xe.GetElementsByTagName("procedure")[0].InnerText == "procedure") sTask.procedure = true;
                    else if (xe.GetElementsByTagName("procedure")[0].InnerText == "nprocedure") sTask.procedure = false;
                    if (xe.GetElementsByTagName("structure")[0].InnerText == "structure") sTask.structure = true;
                    else if (xe.GetElementsByTagName("structure")[0].InnerText == "nstructure") sTask.structure = false;
                    sTask.totalT = TimeSpan.Parse(xe.GetElementsByTagName("totalT")[0].InnerText);


                    STaskDictionary.GetInstance().Add(sTask);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Loading stask XML error: " + ex.Message);
            }

            try
            {
                //load subtask

                XmlNodeList subTaskNodeList = xmlDoc.SelectSingleNode("Information/SubTasks").ChildNodes;


                foreach (XmlNode xnode in subTaskNodeList)
                {

                    SubTask subTask = new SubTask();
                    XmlElement xe = (XmlElement)xnode;

                    subTask.name = xe.GetElementsByTagName("name")[0].InnerText;
                    subTask.id = long.Parse(xe.GetElementsByTagName("id")[0].InnerText);
                    subTask.staskID = long.Parse(xe.GetElementsByTagName("staskID")[0].InnerText);
                    subTask.order = int.Parse(xe.GetElementsByTagName("order")[0].InnerText);
                    subTask.eplanID = long.Parse(xe.GetElementsByTagName("eplanID")[0].InnerText);
                    subTask.difficulty = int.Parse(xe.GetElementsByTagName("difficulty")[0].InnerText);
                    subTask.reward = int.Parse(xe.GetElementsByTagName("reward")[0].InnerText);
                    if (xe.GetElementsByTagName("state")[0].InnerText == "closed") subTask.state = true;
                    else if (xe.GetElementsByTagName("state")[0].InnerText == "open") subTask.state = false;
                    if (xe.GetElementsByTagName("ready")[0].InnerText == "is_ready") subTask.ready = true;
                    else if (xe.GetElementsByTagName("ready")[0].InnerText == "not_ready") subTask.ready = false;
                    if (xe.GetElementsByTagName("inout")[0].InnerText == "in") subTask.inout = true;
                    else if (xe.GetElementsByTagName("inout")[0].InnerText == "out") subTask.inout = false;


                    SubTaskDictionary.GetInstance().Add(subTask);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("Loading subtask XML error: " + ex.Message);
            }
        }

    }
}
