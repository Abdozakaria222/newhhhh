namespace newhhhh
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.btnTestDns = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 15;
            this.listBoxResults.Location = new System.Drawing.Point(12, 12);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(560, 334);
            this.listBoxResults.TabIndex = 0;
            // 
            // btnTestDns
            // 
            this.btnTestDns.Location = new System.Drawing.Point(12, 360);
            this.btnTestDns.Name = "btnTestDns";
            this.btnTestDns.Size = new System.Drawing.Size(120, 40);
            this.btnTestDns.TabIndex = 1;
            this.btnTestDns.Text = "اختبار DNS";
            this.btnTestDns.UseVisualStyleBackColor = true;
            this.btnTestDns.Click += new System.EventHandler(this.btnTestDns_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Location = new System.Drawing.Point(150, 360);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(120, 40);
            this.btnUpdateList.TabIndex = 2;
            this.btnUpdateList.Text = "تحديث القائمة";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.Location = new System.Drawing.Point(288, 360);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(120, 40);
            this.btnSaveResults.TabIndex = 3;
            this.btnSaveResults.Text = "حفظ النتائج";
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 410);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "جاري التحميل...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 436);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSaveResults);
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.btnTestDns);
            this.Controls.Add(this.listBoxResults);
            this.Name = "MainForm";
            this.Text = "DNS Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button btnTestDns;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.Label lblStatus;
    }
}
