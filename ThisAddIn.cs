using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace CategoryThis
{
    public partial class ThisAddIn
    {
        private CategorySelectPane categorySelectPane;
        private Microsoft.Office.Tools.CustomTaskPane categorgySelectCustomTaskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            categorySelectPane = new CategorySelectPane();
            categorgySelectCustomTaskPane = this.CustomTaskPanes.Add(categorySelectPane, "Category Select Pane");
            categorySelectPane.Visible = true;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
