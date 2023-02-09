namespace CategoryThis
{
    partial class CategorySelectPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnApplyChkSelection = new System.Windows.Forms.Button();
            this.cblCategoryList = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnApplyChkSelection
            // 
            this.btnApplyChkSelection.Location = new System.Drawing.Point(16, 30);
            this.btnApplyChkSelection.Name = "btnApplyChkSelection";
            this.btnApplyChkSelection.Size = new System.Drawing.Size(57, 25);
            this.btnApplyChkSelection.TabIndex = 0;
            this.btnApplyChkSelection.Text = "Apply";
            this.btnApplyChkSelection.UseVisualStyleBackColor = true;
            this.btnApplyChkSelection.Click += new System.EventHandler(this.btnApplyChkSelection_Click);
            // 
            // cblCategoryList
            // 
            this.cblCategoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblCategoryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cblCategoryList.CheckOnClick = true;
            this.cblCategoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cblCategoryList.FormattingEnabled = true;
            this.cblCategoryList.HorizontalScrollbar = true;
            this.cblCategoryList.Location = new System.Drawing.Point(0, 80);
            this.cblCategoryList.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cblCategoryList.Name = "cblCategoryList";
            this.cblCategoryList.Size = new System.Drawing.Size(175, 376);
            this.cblCategoryList.Sorted = true;
            this.cblCategoryList.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(18, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "☑ ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(16, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 20);
            this.button3.TabIndex = 3;
            this.button3.Text = "Category";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // CategorySelectPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cblCategoryList);
            this.Controls.Add(this.btnApplyChkSelection);
            this.Name = "CategorySelectPane";
            this.Size = new System.Drawing.Size(176, 463);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApplyChkSelection;
        private System.Windows.Forms.CheckedListBox cblCategoryList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
