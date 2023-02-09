using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using System.Diagnostics;

namespace CategoryThis
{
    public partial class ThisAddIn
    {
        private CategorySelectPane categorySelectPane;
        private Microsoft.Office.Tools.CustomTaskPane categorgySelectCustomTaskPane;

        Outlook.Explorer currentExplorer = null;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Assign active explorer session to variable
            currentExplorer = this.Application.ActiveExplorer();

            //Display category task pane
            categorySelectPane = new CategorySelectPane();
            categorgySelectCustomTaskPane = this.CustomTaskPanes.Add(categorySelectPane, "Category Select Pane");
            categorgySelectCustomTaskPane.Visible = true;


            //refresh category list
            categorySelectPane.RefreshCblCategoryList(Globals.ThisAddIn.Application.Session.Categories);

            //refresh category cbl
            //create event bindings for explorer outlook item change.


            //create event bindings for folder change.
            currentExplorer.BeforeFolderSwitch += new Outlook.ExplorerEvents_10_BeforeFolderSwitchEventHandler(Explorer_BeforeFolderSwitch);
        }

        /// <summary>
        /// When user selects a folder that belongs to a seperate account the cblCategoryList is refreshed to show that accounts
        /// categories.
        /// </summary>
        /// <param name="newfolder">The folder being selected</param>
        /// <param name="cancel">defaulted to false</param>
        void Explorer_BeforeFolderSwitch(object newfolder, ref bool cancel)
        {
            cancel = false;
            Outlook.Folder NewFolder = (Outlook.Folder)newfolder;

            //https://learn.microsoft.com/en-us/office/client-developer/outlook/pia/how-to-get-the-account-for-a-folder
            Outlook.Store store = NewFolder.Store;
            foreach (Outlook.Account account in Application.Session.Accounts)
            {
                if (account.DeliveryStore.StoreID == store.StoreID)
                {
                    categorySelectPane.RefreshCblCategoryList(account.DeliveryStore.Categories);
                }
            }
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
