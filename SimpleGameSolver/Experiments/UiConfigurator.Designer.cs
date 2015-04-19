namespace SimpleGameSolver.Experiments
{
    partial class UiConfigurator
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
            this.NoConfigurationFieldsLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NoConfigurationFieldsLbl
            // 
            this.NoConfigurationFieldsLbl.AutoSize = true;
            this.NoConfigurationFieldsLbl.Location = new System.Drawing.Point(4, 4);
            this.NoConfigurationFieldsLbl.Name = "NoConfigurationFieldsLbl";
            this.NoConfigurationFieldsLbl.Size = new System.Drawing.Size(218, 13);
            this.NoConfigurationFieldsLbl.TabIndex = 0;
            this.NoConfigurationFieldsLbl.Text = "This experiment hasn\'t fields for configuration";
            // 
            // UiConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.NoConfigurationFieldsLbl);
            this.Name = "UiConfigurator";
            this.Size = new System.Drawing.Size(225, 17);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NoConfigurationFieldsLbl;
    }
}
