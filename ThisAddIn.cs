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

        public static Dictionary<string, int> objectCategoryCount = new Dictionary<string, int>();

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
            //event binding for change in explorer selection
            currentExplorer = this.Application.ActiveExplorer();
            currentExplorer.SelectionChange += new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(CurrentExplorer_Event);


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


        /// <summary>
        /// For the current explorer window return a collection of selected objects (emails, meetings, etc).
        /// Based on that selection get assigned categories.
        /// </summary>
        public void CurrentExplorer_Event()
        {

            //create seperate method for this block
            List<OutlookItem> list = new List<OutlookItem>();
            foreach (Object o in Application.ActiveExplorer().Selection)
            {
                OutlookItem outlookItem = new OutlookItem(o);
                list.Add(outlookItem);
            }

            if (list.Count > 0)
            {
                //generate dictionary objectCategoryCount
                SetObjectCategoryCount(list);
                categorySelectPane.UpdateCategoryCheckboxListCheckboxStatus(objectCategoryCount, list.Count);

            }
        }


        /// <summary>
        /// Takes a collection of outlook objects and parses categories/occurence count into the objectCategoryCount collection
        /// </summary>
        /// <param name="outlookObjectList"></param>
        private void SetObjectCategoryCount(List<OutlookItem> outlookObjectList)
        {
            objectCategoryCount.Clear();
            foreach (OutlookItem outlookObject in outlookObjectList)
            {
                string[] objectCategories = outlookObject.Categories.Split(',');
                foreach (string category in objectCategories)
                {
                    string catKey = category.Trim();
                    if (objectCategoryCount.ContainsKey(catKey))
                    {
                        objectCategoryCount[catKey]++;
                    }
                    else
                    {
                        objectCategoryCount.Add(catKey, 1);
                    }
                }
            }
        }


        /// <summary>
        /// Taking a dictionary of selected categories from the checklist apply them to the outlook items based on their checklist status.
        /// </summary>
        /// <param name="selectedCategories">Dictionary object with key as category name and value as bool to indicate if indeterminate</param>
        public static void SaveCategoriesToOutlookItems(Dictionary<string, bool> selectedCategories)
        {
            //---create seperate method for this block
            Outlook.Application thisApplication = new Outlook.Application();

            List<OutlookItem> outlookItems = new List<OutlookItem>();
            foreach (Object o in thisApplication.ActiveExplorer().Selection)
            {
                OutlookItem outlookItem = new OutlookItem(o);
                outlookItems.Add(outlookItem);
            }

            //---

            foreach (OutlookItem o in outlookItems)
            {
                List<string> outlookItemCategories = ParseOutlookItemCategoriesToList(o);
                string newCategoriesString = string.Empty;

                foreach (KeyValuePair<string, bool> userSelectedCategory in selectedCategories)
                {
                    //if value == false compare to each category on outlookItem.  If there is a match add it the string.
                    //else add it to the string

                    if (userSelectedCategory.Value == false)
                    {
                        foreach (string s in outlookItemCategories)
                        {
                            if (s == userSelectedCategory.Key)
                            {
                                newCategoriesString += userSelectedCategory.Key + ", ";
                            }
                        }
                    }
                    else if (userSelectedCategory.Value == true)
                    {
                        newCategoriesString += userSelectedCategory.Key + ", ";
                    }
                }
                o.Categories = newCategoriesString;
                o.Save();
            }


        }


        /// <summary>
        /// Parses an outlookItems categories into a List containing individual categories as strings.
        /// </summary>
        /// <param name="outlookItem">An outlookItem containing categories</param>
        /// <returns></returns>
        private static List<string> ParseOutlookItemCategoriesToList(OutlookItem outlookItem)
        {

            string[] categoriesArray = outlookItem.Categories.Split(',');
            List<string> returnCategories = new List<string>();
            foreach (string s in categoriesArray)
            {
                returnCategories.Add(s.Trim());
            }

            return returnCategories;
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
