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
using TnP.Model;
using TnP.Model.Dictionaries;
using TnP.Model.Elements;

namespace TnP
{
    public partial class TnP : Form
    {
        #region Variable
        private XmlDocument xmlDoc = new XmlDocument();
        private string filePath = Application.StartupPath + "\\save.xml";
        private List<EPlan> ePlan = new List<EPlan>();//plan list
                                                      //private int sameNameCount = 0;
        #endregion

        public TnP()
        {
            InitializeComponent();
        }

        private void TnP_Load(object sender, EventArgs e)
        {
            try
            {
                //add the plan from xml file to the tree
                if (File.Exists(filePath)) xmlIO.ReadXML(filePath, xmlDoc);

                //EPlanTree = ListtoTree(ePlan);
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error:\r\n" + ex.Message);
            }

        }

        private void TnP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit", "Quit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    stopPlanButton.PerformClick();
                    xmlIO.SaveXML(filePath, xmlDoc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPlan planinput = new AddPlan();
            planinput.ShowDialog();
            if (planinput.plan != null && planinput.plan != "")
            {
                //update the ePlan and EPlanTree at the same time
                EPlan plan = new EPlan();
                plan.name = isSameName(planinput.plan);
                plan.id = EPlanDictionary.GetInstance().GetList().Count;//
                plan.progress = 0;
                plan.state = false;
                plan.showT = DateTime.Now;
                EPlanDictionary.GetInstance().Add(plan);
                TreeNode node = new TreeNode();
                node.Text = plan.name;
                node.Tag = plan.id;
                planTreeView.Nodes.Add(node);
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (planTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                EPlanDictionary.GetInstance().Remove(EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)));

                
                planTreeView.Nodes.Remove(planTreeView.SelectedNode);
            }

        }

        private void startPlanButton_Click(object sender, EventArgs e)
        {
            if (planTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)) != null
                    && planTreeView.SelectedNode.Parent == null)//
                {
                    foreach (EPlan p in EPlanDictionary.GetInstance().GetList())
                    {
                        if (p.state == true)
                        {
                            p.state = false;
                            p.stopF += 1;
                            p.lastT += DateTime.Now - p.startT;
                        }
                    }
                    foreach (TreeNode n in planTreeView.Nodes)
                    {
                        n.BackColor = Color.Empty;
                    }
                    //timer1.Stop();
                    //timeHour.Text = "00";
                    //timeMin.Text = "00";
                    //timeSec.Text = "00";
                    //toolStripProgressBar1.Value = 0;
                    //toolStripLabel5.Text = "0%";

                    EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).state = true;//change the state of the plan
                    EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).startF += 1;//add start times
                    EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).startT = DateTime.Now;//record start time

                    toolStripProgressBar1.Value = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress;
                    toolStripLabel5.Text = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress.ToString()+"%";
                    //int sec = (int)EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).lastT.TotalSeconds;

                    planTreeView.SelectedNode.BackColor = Color.GreenYellow;
                    timer1.Start();

                }
            }
        }

        private void stopPlanButton_Click(object sender, EventArgs e)
        {
            foreach (EPlan p in EPlanDictionary.GetInstance().GetList())
            {
                if (p.state == true)
                {
                    p.state = false;
                    p.stopF += 1;
                    p.lastT += DateTime.Now - p.startT;
                }
            }
            foreach (TreeNode n in planTreeView.Nodes)
            {
                n.BackColor = Color.Empty;
            }
            timer1.Stop();
            timeHour.Text = "00";
            timeMin.Text = "00";
            timeSec.Text = "00";
            toolStripProgressBar1.Value = 0;
            toolStripLabel5.Text = "0%";

        }

        private void generateStepButton_Click(object sender, EventArgs e)
        {
            if (planTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)) != null)
                {
                    AddSteps adstep = new AddSteps();
                    adstep.ShowDialog();
                    if (adstep.step != null && adstep.step != "")
                    {
                        Step step = new Step();
                        step.name = adstep.step;
                        if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps != null)
                            step.id = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps.Count;
                        EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps.Add(step);

                        planTreeView.SelectedNode.Nodes.Add(step.name);
                        planTreeView.ExpandAll();

                    }
                }

            }
        }

        private void finishPlanButton_Click(object sender, EventArgs e)
        {
            if (planTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)) != null
                    && planTreeView.SelectedNode.Parent == null)
                {
                    bool allStepsFlag = true;
                    if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps != null)
                    {
                        foreach (Step s in EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps)
                        {
                            if (s.state == false)
                            {
                                allStepsFlag = false;
                                break;
                            }
                        }
                    }
                    if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).state && allStepsFlag)
                    {
                        timer1.Stop();
                        timeHour.Text = "00";
                        timeMin.Text = "00";
                        timeSec.Text = "00";

                        EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).endT = DateTime.Now;
                        EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).lastT += DateTime.Now
                        - EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).startT;
                        EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).endState = true;
                        EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress += 10;
                        toolStripProgressBar1.Value = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress;
                        toolStripLabel5.Text = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).progress.ToString()+"%";


                        closedTreeView.Nodes.Add(planTreeView.SelectedNode.Text);
                        if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps != null)
                        {
                            for (int j = 0; j < EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps.Count; j++)
                            {
                                closedTreeView.Nodes[closedTreeView.Nodes.Count - 1].Nodes.Add(EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).steps[j].name);
                            }
                        }

                        MessageBox.Show("Congratualtions! You have done the plan --"
                        + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).name
                        + "\r\n"
                        + "The plan was first shown at "
                        + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).showT.ToString()
                        + "\r\n"
                        + "First attempted at "
                        + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).startT.ToString()
                        + "\r\n"
                        + "Started times = "
                        + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).startF.ToString()
                        + "\r\n"
                        + "Stopped times = "
                        + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).stopF.ToString()
                        + "\r\n"
                        + "Total used time = "
                        + ((int)EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).lastT.TotalMinutes).ToString()
                        + "Minutes \r\n"
                        + "Finally finished at "
                        + EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Text)).endT.ToString());


                        planTreeView.Nodes.Remove(planTreeView.SelectedNode);

                        toolStripProgressBar1.Value = 0;
                        toolStripLabel5.Text = "0%";

                    }
                }
                else
                {
                    if (EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text))
                    .steps.Find(p => (p.name == planTreeView.SelectedNode.Text)).state == false
                    && EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).state)
                    {
                        EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text))
                        .steps.Find(p => (p.name == planTreeView.SelectedNode.Text)).state = true;
                        EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).progress += 10;
                        toolStripProgressBar1.Value = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).progress;
                        toolStripLabel5.Text = EPlanDictionary.GetInstance().GetList().Find(p => (p.name == planTreeView.SelectedNode.Parent.Text)).progress.ToString()+"%";

                        planTreeView.SelectedNode.BackColor = Color.LightGreen;
                    }
                }

            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (EPlan p in EPlanDictionary.GetInstance().GetList())
            {
                if (p.state == true)
                {
                    int sec = (int)(DateTime.Now - p.startT + p.lastT).TotalSeconds;
                    if (sec < 60)
                    {
                        timeHour.Text = "00";
                        timeMin.Text = "00";
                        timeSec.Text = sec.ToString();
                    }
                    else if (sec < 3600)
                    {
                        int min = sec / 60;
                        int s = (sec - min * 60);
                        timeHour.Text = "00";
                        timeMin.Text = min.ToString();
                        timeSec.Text = s.ToString();

                    }
                    else
                    {
                        int h = sec / 3600;
                        int min = (sec - 3600 * h) / 60;
                        int s = (sec - min * 60 - h * 3600);
                        timeHour.Text = h.ToString();
                        timeMin.Text = min.ToString();
                        timeSec.Text = s.ToString();
                        
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
                            toolStripProgressBar1.Value = p.progress;
                            toolStripLabel5.Text = p.progress.ToString()+'%';
                        }
                    }
                }
            }

        }

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

    }
}
