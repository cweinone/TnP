using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TnP.Common;
using TnP.Control;
using TnP.Model;
using TnP.Model.Dictionaries;
using TnP.Model.Elements;
using TnP.SubForm;
using TnP.User;

namespace TnP
{
    public partial class TnP : Form
    {
        #region Variable
        private string filePath = Application.StartupPath + "\\save.xml";
        private XmlDocument xmlDoc = new XmlDocument();
        private List<EPlan> ePlan = new List<EPlan>();//plan list
                                                      //private int sameNameCount = 0;
        #endregion

        public TnP()
        {
            InitializeComponent();
        }

        #region TnP_Load
        private void TnP_Load(object sender, EventArgs e)
        {
            try
            {
                //Initialization
                Initialization.Init();
                ViewInit();
            }
            catch (Exception ex)
            {
                Logger.WriteLogs("MainForm Load Error: " + ex.Message);
            }
        }
        #endregion

        #region TnP_FormClosing
        private void TnP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit", "Quit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    stopPlanButton.PerformClick();
                    foreach(SubTask sub in SubTaskDictionary.GetInstance().GetList())
                    {
                        if (sub.ready) sub.ready = false;
                    }
                    xmlIO.SaveXML(filePath, xmlDoc);
                }
                catch (Exception ex)
                {
                    Logger.WriteLogs("MainForm Close Error: " + ex.Message);
                }
            }
            else
            {
                e.Cancel = true;
            }

        }
        #endregion

        #region addButton_Click
        private void addButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == taskTabPage)
            {
                //get task name
                Add input = new Add();
                input.ShowDialog();
                string task;
                if (input.s != null)
                {
                    task = isSameName(input.s);

                    //AddTask();
                    UserOperation.GetInstance().Add("ADD_TASK", task);
                    if (UserOperation.GetInstance().count() == 1)
                    {
                        long id = IDGenerator.generateID(); 
                        if (MainFormController.AddTask(task, id))
                        {
                            UserOperation.GetInstance().Remove();
                            TreeNode node = new TreeNode();
                            node.Text = task;
                            node.Tag = id;
                            taskTreeView.Nodes.Add(node);
                        }
                            
                    }
                }

            }
            if (tabControl1.SelectedTab == ePlanTabPage)
            {
                //get plan name
                Add input = new Add();
                input.ShowDialog();
                
                //AddPlan();
                string plan;
                if (input.s != null)
                {
                    plan = isSameName(input.s);

                    UserOperation.GetInstance().Add("ADD_EPLAN", plan);
                    if (UserOperation.GetInstance().count() == 1)
                    {
                        long id = IDGenerator.generateID();
                        if (MainFormController.AddPlan(plan, id))
                        {
                            UserOperation.GetInstance().Remove();
                            TreeNode node = new TreeNode();
                            node.Text = plan;
                            node.Tag = id;
                            planTreeView.Nodes.Add(node);
                        }

                    }
                }
                
            }
            

        }
        #endregion

        #region deleteButton_Click
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == ePlanTabPage)
            {
                if (planTreeView.SelectedNode == null)
                {
                    MessageBox.Show("Please select an item first");
                }
                else
                {
                    //RemovePlan();
                    UserOperation.GetInstance().Add("DEL_EPLAN");
                    if (UserOperation.GetInstance().count() == 1)
                    {
                        long id = (long)planTreeView.SelectedNode.Tag;
                        if (MainFormController.RemovePlan(id))
                        {
                            UserOperation.GetInstance().Remove();
                            planTreeView.Nodes.Remove(planTreeView.SelectedNode);
                        }

                    }
                }
            }
                

        }
        #endregion

        #region startPlanButton_Click
        private void startPlanButton_Click(object sender, EventArgs e)
        {
            if (planTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                //start plan
                UserOperation.GetInstance().Add("START_EPLAN");
                if (UserOperation.GetInstance().count() == 1)
                {
                    long id = (long)planTreeView.SelectedNode.Tag;
                    if (MainFormController.StartPlan(id))
                    {
                        UserOperation.GetInstance().Remove();
                        foreach (TreeNode n in planTreeView.Nodes) n.BackColor = Color.Empty;
                        planTreeView.SelectedNode.BackColor = Color.Black;
                        planTreeView.SelectedNode.ForeColor = Color.White;
                    }
                }
                //if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)) != null
                //    && planTreeView.SelectedNode.Parent == null)//
                //{
                    //    toolStripProgressBar1.Value = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress;
                    //    toolStripLabel5.Text = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress.ToString()+"%";
                    //    //int sec = (int)EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).lastT.TotalSeconds;

                    //    planTreeView.SelectedNode.BackColor = Color.GreenYellow;
                    //    timer.Start();

                    //}
            }
        }
        #endregion


        #region stopPlanButton_Click
        private void stopPlanButton_Click(object sender, EventArgs e)
        {
            //stop plan
            UserOperation.GetInstance().Add("STOP_EPLAN");
            if (UserOperation.GetInstance().count() == 1)
            {
                if (MainFormController.StopPlan())
                {
                    UserOperation.GetInstance().Remove();
                    foreach (TreeNode n in planTreeView.Nodes)
                    {
                        n.BackColor = Color.Empty;
                        n.ForeColor = Color.Black;
                    }
                }
            }
            
            //timer.Stop();
            //timeHour.Text = "00";
            //timeMin.Text = "00";
            //timeSec.Text = "00";
            //toolStripProgressBar1.Value = 0;
            //toolStripLabel5.Text = "0%";

        }
        #endregion

        #region generateStepButton_Click
        private void generateStepButton_Click(object sender, EventArgs e)
        {
            //if (planTreeView.SelectedNode == null)
            //{
            //    MessageBox.Show("Please select an item first");
            //}
            //else
            //{
            //    if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)) != null)
            //    {
            //        AddSteps adstep = new AddSteps();
            //        adstep.ShowDialog();
            //        if (adstep.step != null && adstep.step != "")
            //        {
            //            Step step = new Step();
            //            step.name = adstep.step;
            //            if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps != null)
            //                step.id = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps.Count;
            //            EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps.Add(step);

            //            planTreeView.SelectedNode.Nodes.Add(step.name);
            //            planTreeView.ExpandAll();

            //        }
            //    }

            //}
        }
        #endregion

        #region finishPlanButton_Click
        private void finishPlanButton_Click(object sender, EventArgs e)
        {
            
            if (planTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                //finish plan
                UserOperation.GetInstance().Add("DONE_EPLAN");
                long id = (long)planTreeView.SelectedNode.Tag;
                if (MainFormController.DonePlan(id))
                {
                    UserOperation.GetInstance().Remove();
                    TreeNode tn = planTreeView.SelectedNode;
                    tn.BackColor = Color.Empty;
                    tn.ForeColor = Color.Black;
                    planTreeView.Nodes.Remove(planTreeView.SelectedNode);
                    closedTreeView.Nodes.Add(tn);
                }
            }
            //{
            //    if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)) != null
            //        && planTreeView.SelectedNode.Parent == null)
            //    {
            //        bool allStepsFlag = true;
            //        if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps != null)
            //        {
            //            foreach (Step s in EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps)
            //            {
            //                if (s.state == false)
            //                {
            //                    allStepsFlag = false;
            //                    break;
            //                }
            //            }
            //        }
            //        if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).state && allStepsFlag)
            //        {
            //            timer.Stop();
            //            timeHour.Text = "00";
            //            timeMin.Text = "00";
            //            timeSec.Text = "00";

              
                //            toolStripProgressBar1.Value = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress;
                //            toolStripLabel5.Text = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress.ToString()+"%";


                //            closedTreeView.Nodes.Add(planTreeView.SelectedNode.Text);
                //            if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps != null)
                //            {
                //                for (int j = 0; j < EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps.Count; j++)
                //                {
                //                    closedTreeView.Nodes[closedTreeView.Nodes.Count - 1].Nodes.Add(EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps[j].name);
                //                }
                //            }

                //            MessageBox.Show("Congratualtions! You have done the plan --"
                //            + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).name
                //            + "\r\n"
                //            + "The plan was first shown at "
                //            + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).showT.ToString()
                //            + "\r\n"
                //            + "First attempted at "
                //            + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).startT.ToString()
                //            + "\r\n"
                //            + "Started times = "
                //            + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).startF.ToString()
                //            + "\r\n"
                //            + "Stopped times = "
                //            + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).stopF.ToString()
                //            + "\r\n"
                //            + "Total used time = "
                //            + ((int)EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).lastT.TotalMinutes).ToString()
                //            + "Minutes \r\n"
                //            + "Finally finished at "
                //            + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).endT.ToString());


                //            planTreeView.Nodes.Remove(planTreeView.SelectedNode);

                //            toolStripProgressBar1.Value = 0;
                //            toolStripLabel5.Text = "0%";

                //        }
                //    }
                //    else
                //    {
                //        if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text))
                //        .steps.Find(p => (p.name == planTreeView.SelectedNode.Text)).state == false
                //        && EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).state)
                //        {
                //            EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text))
                //            .steps.Find(p => (p.name == planTreeView.SelectedNode.Text)).state = true;
                //            EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).progress += 10;
                //            toolStripProgressBar1.Value = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).progress;
                //            toolStripLabel5.Text = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).progress.ToString()+"%";

                //            planTreeView.SelectedNode.BackColor = Color.LightGreen;
                //        }
                //    }

                //}

        }
        #endregion

        #region taskTreeView_MouseDoubleClick
        private void taskTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(taskTreeView.SelectedNode != null)
            {
                long id = (long)taskTreeView.SelectedNode.Tag;
                TaskBook tb = new TaskBook(id);
                tb.ShowDialog();
            }
            
        }
        #endregion

        #region Timer_Tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (EPlan p in EPlanDictionary.GetInstance().GetList())
            {
                if (p.state == true)
                {
                    int sec = (int)(DateTime.Now - p.startT.Last() + p.lastT).TotalSeconds;
                    if (sec < 60)
                    {
                        timeHour.Text = "00";
                        timeMin.Text = "00";
                        if (sec < 10) timeSec.Text = "0" + sec.ToString();
                        else timeSec.Text = sec.ToString();

                    }
                    else if (sec < 3600)
                    {
                        int min = sec / 60;
                        int s = (sec - min * 60);
                        timeHour.Text = "00";
                        if (min < 10) timeMin.Text = "0" + min.ToString();
                        else timeMin.Text = min.ToString();
                        if (sec < 10) timeSec.Text = "0" + sec.ToString();
                        else timeSec.Text = sec.ToString();
                    }
                    else
                    {
                        int h = sec / 3600;
                        int min = (sec - 3600 * h) / 60;
                        int s = (sec - min * 60 - h * 3600);
                        if (h < 10) timeHour.Text = "0" + h.ToString();
                        else timeHour.Text = h.ToString();
                        if (min < 10) timeMin.Text = "0" + min.ToString();
                        else timeMin.Text = min.ToString();
                        if (sec < 10) timeSec.Text = "0" + sec.ToString();
                        else timeSec.Text = sec.ToString();
                    }

                    if (sec <= 9000)
                    {
                        if (sec == 600 || sec == 1200 || sec == 1800 ||
                        sec == 2400 || sec == 3000 || sec == 3600 ||
                        sec == 4200 || sec == 4800 || sec == 5400 ||
                        sec == 6000 || sec == 6600 || sec == 7200 ||
                        sec == 7800 || sec == 8400 || sec == 9000)
                        {
                            p.progress += 1;
                            toolStripProgressBar1.Value = (p.progress < 100) ? p.progress : 100;
                            toolStripLabel5.Text = p.progress.ToString() + '%';
                        }
                    }
                }
            }
        }
        #endregion

        #region Methods

        #region isSameName
        private string isSameName(string name)
        {
            if (EPlanDictionary.GetInstance().GetList().Exists(p => (p.name == name)))
            {
                //sameNameCount += 1;
                return isSameName(name + "*");
            }
            else
            {
                return name;
            }

        }
        #endregion

        #region ViewInit
        private void ViewInit()
        {
            //"Everyday" initialization
            //"Closed" initialization
            if (EPlanDictionary.GetInstance().GetList() != null)
            {
                for (int i = 0; i < EPlanDictionary.GetInstance().GetList().Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = EPlanDictionary.GetInstance().GetList()[i].name;
                    node.Tag = EPlanDictionary.GetInstance().GetList()[i].id;
                    if (EPlanDictionary.GetInstance().GetList()[i].endState)
                    {
                        closedTreeView.Nodes.Add(node);
                        if (EPlanDictionary.GetInstance().GetList()[i].steps != null)
                        {
                            for (int j = 0; j < EPlanDictionary.GetInstance().GetList()[i].steps.Count; j++)
                            {
                                closedTreeView
                                .Nodes[closedTreeView.Nodes.Count - 1]
                                .Nodes
                                .Add(EPlanDictionary.GetInstance().GetList()[i].steps[j].name);
                            }
                        }
                    }
                    else
                    {
                        planTreeView.Nodes.Add(node);
                        if (EPlanDictionary.GetInstance().GetList()[i].steps != null)
                        {
                            for (int j = 0; j < EPlanDictionary.GetInstance().GetList()[i].steps.Count; j++)
                            {
                                planTreeView
                                .Nodes[planTreeView.Nodes.Count - 1]
                                .Nodes
                                .Add(EPlanDictionary.GetInstance().GetList()[i].steps[j].name);
                            }
                        }

                        //set the color of started plan
                        if (EPlanDictionary.GetInstance().GetList()[i].state)
                        {
                            planTreeView.Nodes.Find(node.Text, false)[0].BackColor = Color.Green;
                            toolStripProgressBar1.Value = EPlanDictionary.GetInstance().GetList()[i].progress;
                            toolStripLabel2.Text = EPlanDictionary.GetInstance().GetList()[i].progress.ToString();
                        }

                    }
                }
                planTreeView.ExpandAll();
                closedTreeView.ExpandAll();
            }

            //initial "task" 
            if (TaskDictionary.GetInstance().GetList() != null)
            {
                for(int i = 0; i < TaskDictionary.GetInstance().GetList().Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = TaskDictionary.GetInstance().GetList()[i].name;
                    node.Tag = TaskDictionary.GetInstance().GetList()[i].id;
                    taskTreeView.Nodes.Add(node);
                }
            }
            
            //initial "Everyday1"
            DateTime dt = DateTime.Now;
            int h = dt.Hour;
            int tn;
            if (dt.Minute < 30) tn = h*100;
            else tn = h*100+50;
            int[] timescale = new int[48];
            int loca = 16;
            while(true)
            {
                timescale[loca] = tn;
                loca++;
                loca = (loca > 47) ? loca - 48 : loca;
                tn += 50;
                tn = (tn >= 2400) ? tn - 2400 : tn;
                if (loca == 16) break;
            }
            label1.Text = ((timescale[0]/100 < 10) ? ("0"+ (timescale[0] / 100).ToString()) : (timescale[0] / 100).ToString()) 
                + ":" + ((timescale[0] % 100 == 0) ? "00" : "30") + " __";
            label2.Text = ((timescale[1] / 100 < 10) ? ("0" + (timescale[1] / 100).ToString()) : (timescale[1] / 100).ToString())
                + ":" + ((timescale[1] % 100 == 0) ? "00" : "30") + " __";
            label3.Text = ((timescale[2] / 100 < 10) ? ("0" + (timescale[2] / 100).ToString()) : (timescale[2] / 100).ToString())
                + ":" + ((timescale[2] % 100 == 0) ? "00" : "30") + " __";
            label4.Text = ((timescale[3] / 100 < 10) ? ("0" + (timescale[3] / 100).ToString()) : (timescale[3] / 100).ToString())
                + ":" + ((timescale[3] % 100 == 0) ? "00" : "30") + " __";
            label5.Text = ((timescale[4] / 100 < 10) ? ("0" + (timescale[4] / 100).ToString()) : (timescale[4] / 100).ToString())
                + ":" + ((timescale[4] % 100 == 0) ? "00" : "30") + " __";
            label6.Text = ((timescale[5] / 100 < 10) ? ("0" + (timescale[5] / 100).ToString()) : (timescale[5] / 100).ToString())
                + ":" + ((timescale[5] % 100 == 0) ? "00" : "30") + " __";
            label7.Text = ((timescale[6] / 100 < 10) ? ("0" + (timescale[6] / 100).ToString()) : (timescale[6] / 100).ToString())
                + ":" + ((timescale[6] % 100 == 0) ? "00" : "30") + " __";
            label8.Text = ((timescale[7] / 100 < 10) ? ("0" + (timescale[7] / 100).ToString()) : (timescale[7] / 100).ToString())
                + ":" + ((timescale[7] % 100 == 0) ? "00" : "30") + " __";
            label9.Text = ((timescale[8] / 100 < 10) ? ("0" + (timescale[8] / 100).ToString()) : (timescale[8] / 100).ToString())
                + ":" + ((timescale[8] % 100 == 0) ? "00" : "30") + " __";
            label10.Text = ((timescale[9] / 100 < 10) ? ("0" + (timescale[9] / 100).ToString()) : (timescale[9] / 100).ToString())
                + ":" + ((timescale[9] % 100 == 0) ? "00" : "30") + " __";
            label11.Text = ((timescale[10] / 100 < 10) ? ("0" + (timescale[10] / 100).ToString()) : (timescale[10] / 100).ToString())
                + ":" + ((timescale[10] % 100 == 0) ? "00" : "30") + " __";
            label12.Text = ((timescale[11] / 100 < 10) ? ("0" + (timescale[11] / 100).ToString()) : (timescale[11] / 100).ToString())
                + ":" + ((timescale[11] % 100 == 0) ? "00" : "30") + " __";
            label13.Text = ((timescale[12] / 100 < 10) ? ("0" + (timescale[12] / 100).ToString()) : (timescale[12] / 100).ToString())
                + ":" + ((timescale[12] % 100 == 0) ? "00" : "30") + " __";
            label14.Text = ((timescale[13] / 100 < 10) ? ("0" + (timescale[13] / 100).ToString()) : (timescale[13] / 100).ToString())
                + ":" + ((timescale[13] % 100 == 0) ? "00" : "30") + " __";
            label15.Text = ((timescale[14] / 100 < 10) ? ("0" + (timescale[14] / 100).ToString()) : (timescale[14] / 100).ToString())
                + ":" + ((timescale[14] % 100 == 0) ? "00" : "30") + " __";
            label16.Text = ((timescale[15] / 100 < 10) ? ("0" + (timescale[15] / 100).ToString()) : (timescale[15] / 100).ToString())
                + ":" + ((timescale[15] % 100 == 0) ? "00" : "30") + " __";
            label17.Text = ((timescale[16] / 100 < 10) ? ("0" + (timescale[16] / 100).ToString()) : (timescale[16] / 100).ToString())
                + ":" + ((timescale[16] % 100 == 0) ? "00" : "30") + " __";
            label18.Text = ((timescale[17] / 100 < 10) ? ("0" + (timescale[17] / 100).ToString()) : (timescale[17] / 100).ToString())
                + ":" + ((timescale[17] % 100 == 0) ? "00" : "30") + " __";
            label19.Text = ((timescale[18] / 100 < 10) ? ("0" + (timescale[18] / 100).ToString()) : (timescale[18] / 100).ToString())
                + ":" + ((timescale[18] % 100 == 0) ? "00" : "30") + " __";
            label20.Text = ((timescale[19] / 100 < 10) ? ("0" + (timescale[19] / 100).ToString()) : (timescale[19] / 100).ToString())
                + ":" + ((timescale[19] % 100 == 0) ? "00" : "30") + " __";
            label21.Text = ((timescale[20] / 100 < 10) ? ("0" + (timescale[20] / 100).ToString()) : (timescale[20] / 100).ToString())
                + ":" + ((timescale[20] % 100 == 0) ? "00" : "30") + " __";
            label22.Text = ((timescale[21] / 100 < 10) ? ("0" + (timescale[21] / 100).ToString()) : (timescale[21] / 100).ToString())
                + ":" + ((timescale[21] % 100 == 0) ? "00" : "30") + " __";
            label23.Text = ((timescale[22] / 100 < 10) ? ("0" + (timescale[22] / 100).ToString()) : (timescale[22] / 100).ToString())
                + ":" + ((timescale[22] % 100 == 0) ? "00" : "30") + " __";
            label24.Text = ((timescale[23] / 100 < 10) ? ("0" + (timescale[23] / 100).ToString()) : (timescale[23] / 100).ToString())
                + ":" + ((timescale[23] % 100 == 0) ? "00" : "30") + " __";
            label25.Text = ((timescale[24] / 100 < 10) ? ("0" + (timescale[24] / 100).ToString()) : (timescale[24] / 100).ToString())
                + ":" + ((timescale[24] % 100 == 0) ? "00" : "30") + " __";
            label26.Text = ((timescale[25] / 100 < 10) ? ("0" + (timescale[25] / 100).ToString()) : (timescale[25] / 100).ToString())
                + ":" + ((timescale[25] % 100 == 0) ? "00" : "30") + " __";
            label27.Text = ((timescale[26] / 100 < 10) ? ("0" + (timescale[26] / 100).ToString()) : (timescale[26] / 100).ToString())
                + ":" + ((timescale[26] % 100 == 0) ? "00" : "30") + " __";
            label28.Text = ((timescale[27] / 100 < 10) ? ("0" + (timescale[27] / 100).ToString()) : (timescale[27] / 100).ToString())
                + ":" + ((timescale[27] % 100 == 0) ? "00" : "30") + " __";
            label29.Text = ((timescale[28] / 100 < 10) ? ("0" + (timescale[28] / 100).ToString()) : (timescale[28] / 100).ToString())
                + ":" + ((timescale[28] % 100 == 0) ? "00" : "30") + " __";
            label30.Text = ((timescale[29] / 100 < 10) ? ("0" + (timescale[29] / 100).ToString()) : (timescale[29] / 100).ToString())
                + ":" + ((timescale[29] % 100 == 0) ? "00" : "30") + " __";
            label31.Text = ((timescale[30] / 100 < 10) ? ("0" + (timescale[30] / 100).ToString()) : (timescale[30] / 100).ToString())
                + ":" + ((timescale[30] % 100 == 0) ? "00" : "30") + " __";
            label32.Text = ((timescale[31] / 100 < 10) ? ("0" + (timescale[31] / 100).ToString()) : (timescale[31] / 100).ToString())
                + ":" + ((timescale[31] % 100 == 0) ? "00" : "30") + " __";
            label33.Text = ((timescale[32] / 100 < 10) ? ("0" + (timescale[32] / 100).ToString()) : (timescale[32] / 100).ToString())
                + ":" + ((timescale[32] % 100 == 0) ? "00" : "30") + " __";
            label34.Text = ((timescale[33] / 100 < 10) ? ("0" + (timescale[33] / 100).ToString()) : (timescale[33] / 100).ToString())
                + ":" + ((timescale[33] % 100 == 0) ? "00" : "30") + " __";
            label35.Text = ((timescale[34] / 100 < 10) ? ("0" + (timescale[34] / 100).ToString()) : (timescale[34] / 100).ToString())
                + ":" + ((timescale[34] % 100 == 0) ? "00" : "30") + " __";
            label36.Text = ((timescale[35] / 100 < 10) ? ("0" + (timescale[35] / 100).ToString()) : (timescale[35] / 100).ToString())
                + ":" + ((timescale[35] % 100 == 0) ? "00" : "30") + " __";
            label37.Text = ((timescale[36] / 100 < 10) ? ("0" + (timescale[36] / 100).ToString()) : (timescale[36] / 100).ToString())
                + ":" + ((timescale[36] % 100 == 0) ? "00" : "30") + " __";
            label38.Text = ((timescale[37] / 100 < 10) ? ("0" + (timescale[37] / 100).ToString()) : (timescale[37] / 100).ToString())
                + ":" + ((timescale[37] % 100 == 0) ? "00" : "30") + " __";
            label39.Text = ((timescale[38] / 100 < 10) ? ("0" + (timescale[38] / 100).ToString()) : (timescale[38] / 100).ToString())
                + ":" + ((timescale[38] % 100 == 0) ? "00" : "30") + " __";
            label40.Text = ((timescale[39] / 100 < 10) ? ("0" + (timescale[39] / 100).ToString()) : (timescale[39] / 100).ToString())
                + ":" + ((timescale[39] % 100 == 0) ? "00" : "30") + " __";
            label41.Text = ((timescale[40] / 100 < 10) ? ("0" + (timescale[40] / 100).ToString()) : (timescale[40] / 100).ToString())
                + ":" + ((timescale[40] % 100 == 0) ? "00" : "30") + " __";
            label42.Text = ((timescale[41] / 100 < 10) ? ("0" + (timescale[41] / 100).ToString()) : (timescale[41] / 100).ToString())
                + ":" + ((timescale[41] % 100 == 0) ? "00" : "30") + " __";
            label43.Text = ((timescale[42] / 100 < 10) ? ("0" + (timescale[42] / 100).ToString()) : (timescale[42] / 100).ToString())
                + ":" + ((timescale[42] % 100 == 0) ? "00" : "30") + " __";
            label44.Text = ((timescale[43] / 100 < 10) ? ("0" + (timescale[43] / 100).ToString()) : (timescale[43] / 100).ToString())
                + ":" + ((timescale[43] % 100 == 0) ? "00" : "30") + " __";
            label45.Text = ((timescale[44] / 100 < 10) ? ("0" + (timescale[44] / 100).ToString()) : (timescale[44] / 100).ToString())
                + ":" + ((timescale[44] % 100 == 0) ? "00" : "30") + " __";
            label46.Text = ((timescale[45] / 100 < 10) ? ("0" + (timescale[45] / 100).ToString()) : (timescale[45] / 100).ToString())
                + ":" + ((timescale[45] % 100 == 0) ? "00" : "30") + " __";
            label47.Text = ((timescale[46] / 100 < 10) ? ("0" + (timescale[46] / 100).ToString()) : (timescale[46] / 100).ToString())
                + ":" + ((timescale[46] % 100 == 0) ? "00" : "30") + " __";
            label48.Text = ((timescale[47] / 100 < 10) ? ("0" + (timescale[47] / 100).ToString()) : (timescale[47] / 100).ToString())
                + ":" + ((timescale[47] % 100 == 0) ? "00" : "30") + " __";
            label49.Text = ((timescale[0] / 100 < 10) ? ("0" + (timescale[0] / 100).ToString()) : (timescale[0] / 100).ToString())
                + ":" + ((timescale[0] % 100 == 0) ? "00" : "30") + " __";

        }

        #endregion

        #region ProgressBar

        #endregion

        #endregion

        
    }
}
