using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TnP.Common;
using TnP.Model;
using TnP.Model.Dictionaries;
using TnP.Model.Elements;

namespace TnP.SubForm
{
    public partial class TaskBook : Form
    {
        private long taskID;
        private Model.Elements.Task task;
        private struct names
        {
            public string name;
            public bool inall;
            public bool isfather;
        }
        private struct idn
        {
            public long id;
            public int order;
        }
        private Dictionary<long, names> asDic = new Dictionary<long, names>();
        private Dictionary<long, List<idn>> fsRel = new Dictionary<long, List<idn>>();
        

        public TaskBook(long id)
        {
            InitializeComponent();
            taskID = id;
        }

        private void TaskBook_Load(object sender, EventArgs e)
        {
            try
            {
                task = TaskDictionary.GetInstance().find(taskID);
                asDic = new Dictionary<long, names>();
                fsRel = new Dictionary<long, List<idn>>();
                try
                {
                    if (task.staskID != null && task.staskID.Count != 0)
                    {
                        string[] sTaskArray = new string[task.staskID.Count];
                        foreach (long id in task.staskID)
                        {
                            //sTaskList.Items.Add(STaskDictionary.GetInstance().find(id).name);
                            sTaskArray[STaskDictionary.GetInstance().find(id).order] = STaskDictionary.GetInstance().find(id).name;
                            names n = new names();
                            n.name = STaskDictionary.GetInstance().find(id).name;
                            n.isfather = true;
                            n.inall = false;
                            asDic.Add(id, n);
                            if (STaskDictionary.GetInstance().find(id).subtaskID != null && STaskDictionary.GetInstance().find(id).subtaskID.Count > 0)
                            {
                                fsRel.Add(id, new List<idn>());
                                foreach (long l in STaskDictionary.GetInstance().find(id).subtaskID)
                                {
                                    names n1 = new names();
                                    n1.name = SubTaskDictionary.GetInstance().find(l).name;
                                    n1.isfather = false;
                                    n1.inall = false;
                                    asDic.Add(l, n1);
                                    idn idnx = new idn();
                                    idnx.id = l;
                                    idnx.order = SubTaskDictionary.GetInstance().find(l).order;
                                    fsRel[id].Add(idnx);
                                }
                            }
                        }
                        foreach(string str in sTaskArray)
                        {
                            sTaskList.Items.Add(str);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Logger.WriteLogs("TaskBook/sTaskList Loading Error: " + ex.Message);
                }

                try
                {
                    if (task.allSubID != null && task.allSubID.Count != 0)
                    {

                        foreach (long id in task.allSubID)
                        {
                            if(!asDic.ContainsKey(id))
                            {
                                allTaskList.Items.Add(AllSubDictionary.GetInstance().find(id).name);
                                names n = new names();
                                n.name = AllSubDictionary.GetInstance().find(id).name;
                                n.isfather = false;
                                n.inall = true;
                                asDic.Add(id, n);
                            }
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogs("TaskBook/allTaskList Loading Error: " + ex.Message);
                }
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("TaskBook Loading Error: " + ex.Message);
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(taskTextBox.Text != "" && !allTaskList.Items.Contains(taskTextBox.Text))
            {
                allTaskList.Items.Add(taskTextBox.Text);
                //
                long id = IDGenerator.generateID();
                names n = new names();
                n.name = taskTextBox.Text;
                n.inall = true;
                n.isfather = false;
                asDic.Add(id, n);
                //
                taskTextBox.Clear();
            }
        }

        private void toSTaskButton_Click(object sender, EventArgs e)
        {
            if (allTaskList.SelectedItem == null) MessageBox.Show("Select an item from All Subtasks first");
            else
            {
                if (!sTaskList.Items.Contains(allTaskList.SelectedItem))
                {
                    sTaskList.Items.Add(allTaskList.SelectedItem);
                    //
                    foreach(KeyValuePair<long, names> kvp in asDic)
                    {
                        if(kvp.Value.name == allTaskList.SelectedItem.ToString())
                        {
                            names n = new names();
                            n.name = kvp.Value.name;
                            n.inall = false;
                            n.isfather = true;
                            long id = kvp.Key;
                            asDic.Remove(id);
                            asDic.Add(id, n);
                            fsRel.Add(id, new List<idn>());
                            break;
                        }
                    }
                    //
                    allTaskList.Items.Remove(allTaskList.SelectedItem);
                    //
                    
                }
            }
        }

        private void delSTaskButton_Click(object sender, EventArgs e)
        {
            if (sTaskList.SelectedItem == null) MessageBox.Show("Select an item from Specific Tasks first");
            else
            {
                //
                foreach (KeyValuePair<long, names> kvp in asDic)
                {
                    if (kvp.Value.name == sTaskList.SelectedItem.ToString())
                    {
                        names n = new names();
                        n.name = kvp.Value.name;
                        n.inall = true;
                        n.isfather = false;
                        long id = kvp.Key;
                        asDic.Remove(id);
                        asDic.Add(id, n);
                        break;
                    }
                }
                //
                allTaskList.Items.Add(sTaskList.SelectedItem);
                sTaskList.Items.Remove(sTaskList.SelectedItem);
            }
        }

        private void toSubtaskButton_Click(object sender, EventArgs e)
        {
            if (allTaskList.SelectedItem == null) MessageBox.Show("Select an item from All Subtasks first");
            else if (sTaskList.SelectedItem == null) MessageBox.Show("Select an item from Specific Tasks first");
            else
            {
                if (!subtaskList.Items.Contains(allTaskList.SelectedItem))
                {
                    subtaskList.Items.Add(allTaskList.SelectedItem);
                    //
                    long fid = 0;
                    foreach (KeyValuePair<long, names> kvp in asDic)
                    {
                        if (kvp.Value.name == sTaskList.SelectedItem.ToString())
                        {
                            fid = kvp.Key;
                            break;
                        }
                    }
                    foreach (KeyValuePair<long, names> kvp in asDic)
                    {
                        if (kvp.Value.name == allTaskList.SelectedItem.ToString())
                        {
                            names n = new names();
                            n.name = kvp.Value.name;
                            n.inall = false;
                            n.isfather = false;
                            long id = kvp.Key;
                            asDic.Remove(id);
                            asDic.Add(id, n);
                            if(fsRel.Keys.Contains(fid))
                            {
                                idn idnx = new idn();
                                idnx.id = id;
                                idnx.order = subtaskList.Items.Count - 1;
                                fsRel[fid].Add(idnx);
                            }
                            break;
                        }
                    }
                    //
                    allTaskList.Items.Remove(allTaskList.SelectedItem);
                }
            }
        }

        private void delSubtaskButton_Click(object sender, EventArgs e)
        {
            if (subtaskList.SelectedItem == null) MessageBox.Show("Select an item from Subasks first");
            else
            {
                //
                long fid = 0;
                foreach (KeyValuePair<long, names> kvp in asDic)
                {
                    if (kvp.Value.name == sTaskList.SelectedItem.ToString())
                    {
                        fid = kvp.Key;
                        break;
                    }
                }
                foreach (KeyValuePair<long, names> kvp in asDic)
                {
                    if (kvp.Value.name == subtaskList.SelectedItem.ToString())
                    {
                        names n = new names();
                        n.name = kvp.Value.name;
                        n.inall = true;
                        n.isfather = false;
                        long id = kvp.Key;
                        asDic.Remove(id);
                        asDic.Add(id, n);
                        fsRel[fid].Remove(fsRel[fid].Find(p=> p.id == id));
                        break;
                    }
                }
                //
                allTaskList.Items.Add(subtaskList.SelectedItem);
                subtaskList.Items.Remove(subtaskList.SelectedItem);
            }
        }

        private void sTaskUpButton_Click(object sender, EventArgs e)
        {
            if(sTaskList.SelectedIndex > 0)
            {
                string s = sTaskList.SelectedItem.ToString();
                int n = sTaskList.SelectedIndex;
                sTaskList.Items.Remove(sTaskList.SelectedItem);
                sTaskList.Items.Insert(n - 1, s);
            }
        }

        private void sTaskDownButton_Click(object sender, EventArgs e)
        {
            if(sTaskList.SelectedIndex < sTaskList.Items.Count -1)
            {
                string s = sTaskList.SelectedItem.ToString();
                int n = sTaskList.SelectedIndex;
                sTaskList.Items.Remove(sTaskList.SelectedItem);
                sTaskList.Items.Insert(n + 1, s);
            }
        }

        private void subtaskUpButton_Click(object sender, EventArgs e)
        {
            if (subtaskList.SelectedIndex > 0)
            {
                string s = subtaskList.SelectedItem.ToString();
                int n = subtaskList.SelectedIndex;
                //
                long idu=0, idd=0, fid=0;
                foreach(KeyValuePair<long, names> kvp in asDic)
                {
                    if (kvp.Value.name == s) idd = kvp.Key;
                    if (kvp.Value.name == subtaskList.Items[n - 1].ToString()) idu = kvp.Key;
                    if (kvp.Value.name == sTaskList.SelectedItem.ToString()) fid = kvp.Key;
                }
                idn idxu = new idn();
                idxu.id = idd;
                idxu.order = n - 1;
                idn idxd = new idn();
                idxd.id = idu;
                idxd.order = n;
                fsRel[fid].Remove(fsRel[fid].Find(p => (p.id == idd)));
                fsRel[fid].Remove(fsRel[fid].Find(p => (p.id == idu)));
                fsRel[fid].Add(idxu);
                fsRel[fid].Add(idxd);
                //
                subtaskList.Items.Remove(subtaskList.SelectedItem);
                subtaskList.Items.Insert(n - 1, s);
                
            }
        }

        private void subtaskDownButton_Click(object sender, EventArgs e)
        {
            if (subtaskList.SelectedIndex < subtaskList.Items.Count - 1)
            {
                string s = subtaskList.SelectedItem.ToString();
                int n = subtaskList.SelectedIndex;
                //
                long idu = 0, idd = 0, fid = 0;
                foreach (KeyValuePair<long, names> kvp in asDic)
                {
                    if (kvp.Value.name == s) idu = kvp.Key;
                    if (kvp.Value.name == subtaskList.Items[n + 1].ToString()) idd = kvp.Key;
                    if (kvp.Value.name == sTaskList.SelectedItem.ToString()) fid = kvp.Key;
                }
                idn idxd = new idn();
                idxd.id = idu;
                idxd.order = n + 1;
                idn idxu = new idn();
                idxu.id = idd;
                idxu.order = n;
                fsRel[fid].Remove(fsRel[fid].Find(p => (p.id == idd)));
                fsRel[fid].Remove(fsRel[fid].Find(p => (p.id == idu)));
                fsRel[fid].Add(idxu);
                fsRel[fid].Add(idxd);
                //
                subtaskList.Items.Remove(subtaskList.SelectedItem);
                subtaskList.Items.Insert(n + 1, s);
            }
        }

        private void TaskBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit", "Quit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    AllSubDictionary.GetInstance().RemoveAll();
                    STaskDictionary.GetInstance().RemoveAll();
                    SubTaskDictionary.GetInstance().RemoveAll();
                    TaskDictionary.GetInstance().find(taskID).allSubID = new List<long>();
                    TaskDictionary.GetInstance().find(taskID).staskID = new List<long>();
                    foreach (KeyValuePair<long, names> kvp in asDic)
                    {
                        if (kvp.Value.inall && !kvp.Value.isfather)
                        {
                            AllSub ast = new AllSub();
                            ast.name = kvp.Value.name;
                            ast.id = kvp.Key;
                            AllSubDictionary.GetInstance().Add(ast);
                            if(TaskDictionary.GetInstance().find(taskID) != null)
                            {
                                if(!TaskDictionary.GetInstance().find(taskID).allSubID.Contains(ast.id))
                                    TaskDictionary.GetInstance().find(taskID).allSubID.Add(ast.id);
                            }
                                
                        }
                        else if (kvp.Value.isfather && !kvp.Value.inall)
                        {
                            STask st = new STask();
                            st.name = kvp.Value.name;
                            st.id = kvp.Key;
                            st.taskID = taskID;
                            st.order = sTaskList.FindStringExact(kvp.Value.name);
                            foreach(idn i in fsRel[st.id])
                            {
                                st.subtaskID.Add(i.id);
                                SubTask subt = new SubTask();
                                subt.name = asDic[i.id].name;
                                subt.id = i.id;
                                subt.order = i.order;
                                subt.staskID = st.id;
                                SubTaskDictionary.GetInstance().Add(subt);
                            }
                            
                            STaskDictionary.GetInstance().Add(st);
                            if (TaskDictionary.GetInstance().find(taskID) != null)
                            {
                                if(!TaskDictionary.GetInstance().find(taskID).staskID.Contains(st.id))
                                    TaskDictionary.GetInstance().find(taskID).staskID.Add(st.id);
                            }
                                
                        }
                        //else if(!kvp.Value.isfather && !kvp.Value.inall)
                        //{
                        //    SubTask subt = new SubTask();
                        //    subt.name = kvp.Value.name;
                        //    subt.id = kvp.Key;
                        //    SubTaskDictionary.GetInstance().Add(subt);
                        //}

                    }
                }
                catch(Exception ex)
                {
                    Logger.WriteLogs("TaskBook FormClosing Error: "+ ex.Message);
                }
            }
            else
            {
                e.Cancel = true;
            }
                
        }

        private void sTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sTaskList.SelectedItem != null)
                {
                    long id = 0;
                    foreach (KeyValuePair<long, names> kvp in asDic)
                    {
                        if (kvp.Value.name == sTaskList.SelectedItem.ToString())
                        {
                            id = kvp.Key;
                            break;
                        }
                    }
                    subtaskList.Items.Clear();
                    if (fsRel.Keys.Contains(id))
                    {
                        string[] strArray = new string[fsRel[id].Count];
                        foreach (idn l in fsRel[id])
                        {
                            strArray[l.order] = asDic[l.id].name;
                        }
                        foreach (string str in strArray)
                        {
                            subtaskList.Items.Add(str);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.WriteLogs("TaskBook/sTaskList_SelectedIndexChanged Error: " + ex.Message);
            }
            
        }
    }
}
