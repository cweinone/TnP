using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TnP.Model.Dictionaries;

namespace TnP.SubForm
{
    public partial class TaskBook : Form
    {
        private long taskID;
        private Model.Elements.Task task;

        public TaskBook(long id)
        {
            InitializeComponent();
            taskID = id;
        }

        private void TaskBook_Load(object sender, EventArgs e)
        {
            task = TaskDictionary.GetInstance().find(taskID);
            if(task.staskID != null && task.staskID.Count != 0)
            {
                
            }
        }
    }
}
