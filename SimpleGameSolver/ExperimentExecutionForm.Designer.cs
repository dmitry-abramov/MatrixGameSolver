namespace SimpleGameSolver
{
    partial class ExperimentExecutionForm
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
            this.UiConfiguratorContainer = new System.Windows.Forms.Panel();
            this.experimentProgressBar = new System.Windows.Forms.ProgressBar();
            this.ExecuteExperimentBtn = new System.Windows.Forms.Button();
            this.StopExecutionBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.methodList = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.experimentList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // UiConfiguratorContainer
            // 
            this.UiConfiguratorContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiConfiguratorContainer.Location = new System.Drawing.Point(12, 60);
            this.UiConfiguratorContainer.Name = "UiConfiguratorContainer";
            this.UiConfiguratorContainer.Size = new System.Drawing.Size(581, 231);
            this.UiConfiguratorContainer.TabIndex = 0;
            // 
            // experimentProgressBar
            // 
            this.experimentProgressBar.Location = new System.Drawing.Point(12, 297);
            this.experimentProgressBar.Name = "experimentProgressBar";
            this.experimentProgressBar.Size = new System.Drawing.Size(417, 30);
            this.experimentProgressBar.TabIndex = 1;
            // 
            // ExecuteExperimentBtn
            // 
            this.ExecuteExperimentBtn.Location = new System.Drawing.Point(435, 299);
            this.ExecuteExperimentBtn.Name = "ExecuteExperimentBtn";
            this.ExecuteExperimentBtn.Size = new System.Drawing.Size(76, 29);
            this.ExecuteExperimentBtn.TabIndex = 2;
            this.ExecuteExperimentBtn.Text = "Выполнить";
            this.ExecuteExperimentBtn.UseVisualStyleBackColor = true;
            this.ExecuteExperimentBtn.Click += new System.EventHandler(this.ExecuteExperimentBtnClick);
            // 
            // StopExecutionBtn
            // 
            this.StopExecutionBtn.Location = new System.Drawing.Point(517, 298);
            this.StopExecutionBtn.Name = "StopExecutionBtn";
            this.StopExecutionBtn.Size = new System.Drawing.Size(76, 29);
            this.StopExecutionBtn.TabIndex = 3;
            this.StopExecutionBtn.Text = "Остановить";
            this.StopExecutionBtn.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Реализация метода:";
            // 
            // methodList
            // 
            this.methodList.DisplayMember = "0";
            this.methodList.FormattingEnabled = true;
            this.methodList.Location = new System.Drawing.Point(133, 33);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(228, 21);
            this.methodList.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Эксперимент:";
            // 
            // experimentList
            // 
            this.experimentList.DisplayMember = "0";
            this.experimentList.FormattingEnabled = true;
            this.experimentList.Location = new System.Drawing.Point(133, 6);
            this.experimentList.Name = "experimentList";
            this.experimentList.Size = new System.Drawing.Size(228, 21);
            this.experimentList.TabIndex = 35;
            this.experimentList.SelectedIndexChanged += new System.EventHandler(this.ExperimentListSelectedIndexChanged);            
            // 
            // ExperimentExecutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 340);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.experimentList);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.methodList);
            this.Controls.Add(this.StopExecutionBtn);
            this.Controls.Add(this.ExecuteExperimentBtn);
            this.Controls.Add(this.experimentProgressBar);
            this.Controls.Add(this.UiConfiguratorContainer);
            this.Name = "ExperimentExecutionForm";
            this.Text = "Experimrnts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel UiConfiguratorContainer;
        private System.Windows.Forms.ProgressBar experimentProgressBar;
        private System.Windows.Forms.Button ExecuteExperimentBtn;
        private System.Windows.Forms.Button StopExecutionBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox methodList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox experimentList;
    }
}