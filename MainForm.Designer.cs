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

        private void InitializeComponent()
        {
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.btnTestDns = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // listBoxResults
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 16;
            this.listBoxResults.Location = new System.Drawing.Point(12, 12);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(420, 260);
            this.listBoxResults.TabIndex = 0;

            // btnTestDns
            this.btnTestDns.Location = new System.Drawing.Point(12, 290);
            this.btnTestDns.Name = "btnTestDns";
            this.btnTestDns.Size = new System.Drawing.Size(120, 35);
            this.btnTestDns.Text = "اختبر DNS";
            this.btnTestDns.UseVisualStyleBackColor = true;
            this.btnTestDns.Click += new System.EventHandler(this.btnTestDns_Click);

            // btnUpdateList
            this.btnUpdateList.Location = new System.Drawing.Point(150, 290);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(130, 35);
            this.btnUpdateList.Text = "تحديث القائمة";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);

            // btnSaveResults
            this.btnSaveResults.Location = new System.Drawing.Point(300, 290);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(130, 35);
            this.btnSaveResults.Text = "حفظ النتائج";
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 340);
            this.Controls.Add(this.btnSaveResults);
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.btnTestDns);
            this.Controls.Add(this.listBoxResults);
            this.Name = "MainForm";
            this.Text = "DNS Optimizer";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button btnTestDns;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.Button btnSaveResults;
    }
}
