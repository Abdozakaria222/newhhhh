namespace DNSOptimizer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView gridResults;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnApplyBest;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gridResults = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnApplyBest = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();

            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).BeginInit();
            this.SuspendLayout();

            // gridResults
            this.gridResults.AllowUserToAddRows = false;
            this.gridResults.AllowUserToDeleteRows = false;
            this.gridResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridResults.Location = new System.Drawing.Point(20, 20);
            this.gridResults.Size = new System.Drawing.Size(560, 260);

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(20, 300);
            this.btnStart.Size = new System.Drawing.Size(160, 40);
            this.btnStart.Text = "ابدأ الفحص 🚀";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnApplyBest
            this.btnApplyBest.Location = new System.Drawing.Point(200, 300);
            this.btnApplyBest.Size = new System.Drawing.Size(160, 40);
            this.btnApplyBest.Text = "تطبيق الأسرع ⚡";
            this.btnApplyBest.Click += new System.EventHandler(this.btnApplyBest_Click);

            // btnUpdateList
            this.btnUpdateList.Location = new System.Drawing.Point(380, 300);
            this.btnUpdateList.Size = new System.Drawing.Size(160, 40);
            this.btnUpdateList.Text = "تحديث القائمة 🔄";
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(20, 360);
            this.progressBar.Size = new System.Drawing.Size(560, 20);

            // MainForm
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.gridResults);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnApplyBest);
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DNS Optimizer - اختبار أسرع DNS للإنترنت";
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
