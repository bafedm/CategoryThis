using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CategoryThis
{
    public partial class CategorySelectPane : UserControl
    {
        public CategorySelectPane()
        {
            InitializeComponent();
        }

        private void CategorySelectPane_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Refreshes the list of categories displated in the task pane checklistbox
        /// </summary>
        /// <param name="categories">A collection of category objects from the outlook session</param>
        public void RefreshCblCategoryList(Categories categories) 
        {
            cblCategoryList.Items.Clear();
            foreach (Category category in categories)
            {
                cblCategoryList.Items.Add((string)category.Name);
            }
        }


    }
}
