namespace SimpleGameSolver
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label7 = new System.Windows.Forms.Label();
            this.SecondPlayerStartPosition = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.FirstPlayerStartPosition = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.IterationCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.SecondPlayerStrategesCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstPlayerStrategesCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SecondPlayerMatrix = new System.Windows.Forms.DataGridView();
            this.FirstPlayerMatrix = new System.Windows.Forms.DataGridView();
            this.Graphics = new System.Windows.Forms.TabPage();
            this.Solve = new System.Windows.Forms.TabPage();
            this.FirstPlayerSolve = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.SecondPlayerSolve = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.TableSplit = new System.Windows.Forms.SplitContainer();
            this.secondPlayerSolveTable = new System.Windows.Forms.DataGridView();
            this.firstPlayerSolveTable = new System.Windows.Forms.DataGridView();
            this.SolveInformation = new System.Windows.Forms.TabControl();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SolveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerStartPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerStartPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerStrategesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerStrategesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerMatrix)).BeginInit();
            this.Graphics.SuspendLayout();
            this.Solve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerSolve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerSolve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableSplit)).BeginInit();
            this.TableSplit.Panel1.SuspendLayout();
            this.TableSplit.Panel2.SuspendLayout();
            this.TableSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondPlayerSolveTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstPlayerSolveTable)).BeginInit();
            this.SolveInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 509);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Начальное состояние для второго игрока";
            // 
            // SecondPlayerStartPosition
            // 
            this.SecondPlayerStartPosition.AllowUserToAddRows = false;
            this.SecondPlayerStartPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SecondPlayerStartPosition.ColumnHeadersVisible = false;
            this.SecondPlayerStartPosition.Location = new System.Drawing.Point(14, 531);
            this.SecondPlayerStartPosition.Name = "SecondPlayerStartPosition";
            this.SecondPlayerStartPosition.RowHeadersVisible = false;
            this.SecondPlayerStartPosition.Size = new System.Drawing.Size(342, 30);
            this.SecondPlayerStartPosition.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Начальное состояние для первого игрока";
            // 
            // FirstPlayerStartPosition
            // 
            this.FirstPlayerStartPosition.AllowUserToAddRows = false;
            this.FirstPlayerStartPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FirstPlayerStartPosition.ColumnHeadersVisible = false;
            this.FirstPlayerStartPosition.Location = new System.Drawing.Point(16, 476);
            this.FirstPlayerStartPosition.Name = "FirstPlayerStartPosition";
            this.FirstPlayerStartPosition.RowHeadersVisible = false;
            this.FirstPlayerStartPosition.Size = new System.Drawing.Size(342, 30);
            this.FirstPlayerStartPosition.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Число итераций: ";
            // 
            // IterationCount
            // 
            this.IterationCount.Location = new System.Drawing.Point(145, 421);
            this.IterationCount.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.IterationCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IterationCount.Name = "IterationCount";
            this.IterationCount.Size = new System.Drawing.Size(213, 20);
            this.IterationCount.TabIndex = 22;
            this.IterationCount.ThousandsSeparator = true;
            this.IterationCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Число стратегий второго игрока: ";
            // 
            // SecondPlayerStrategesCount
            // 
            this.SecondPlayerStrategesCount.Location = new System.Drawing.Point(254, 39);
            this.SecondPlayerStrategesCount.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.SecondPlayerStrategesCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.SecondPlayerStrategesCount.Name = "SecondPlayerStrategesCount";
            this.SecondPlayerStrategesCount.Size = new System.Drawing.Size(104, 20);
            this.SecondPlayerStrategesCount.TabIndex = 20;
            this.SecondPlayerStrategesCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.SecondPlayerStrategesCount.ValueChanged += new System.EventHandler(this.SecondPlayerStrategesCount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Число стратегий первого игрока: ";
            // 
            // FirstPlayerStrategesCount
            // 
            this.FirstPlayerStrategesCount.Location = new System.Drawing.Point(254, 7);
            this.FirstPlayerStrategesCount.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.FirstPlayerStrategesCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.FirstPlayerStrategesCount.Name = "FirstPlayerStrategesCount";
            this.FirstPlayerStrategesCount.Size = new System.Drawing.Size(104, 20);
            this.FirstPlayerStrategesCount.TabIndex = 18;
            this.FirstPlayerStrategesCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.FirstPlayerStrategesCount.ValueChanged += new System.EventHandler(this.FirstPlayerStrategesCount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Матрица второго игрока";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Матрица первого игрока";
            // 
            // SecondPlayerMatrix
            // 
            this.SecondPlayerMatrix.AllowUserToAddRows = false;
            this.SecondPlayerMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SecondPlayerMatrix.ColumnHeadersVisible = false;
            this.SecondPlayerMatrix.Location = new System.Drawing.Point(16, 270);
            this.SecondPlayerMatrix.Name = "SecondPlayerMatrix";
            this.SecondPlayerMatrix.RowHeadersVisible = false;
            this.SecondPlayerMatrix.Size = new System.Drawing.Size(342, 132);
            this.SecondPlayerMatrix.TabIndex = 15;
            // 
            // FirstPlayerMatrix
            // 
            this.FirstPlayerMatrix.AllowUserToAddRows = false;
            this.FirstPlayerMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FirstPlayerMatrix.ColumnHeadersVisible = false;
            this.FirstPlayerMatrix.Location = new System.Drawing.Point(16, 100);
            this.FirstPlayerMatrix.Name = "FirstPlayerMatrix";
            this.FirstPlayerMatrix.RowHeadersVisible = false;
            this.FirstPlayerMatrix.Size = new System.Drawing.Size(342, 132);
            this.FirstPlayerMatrix.TabIndex = 14;
            // 
            // Graphics
            // 
            this.Graphics.BackColor = System.Drawing.Color.LightGray;
            this.Graphics.Controls.Add(this.chart2);
            this.Graphics.Controls.Add(this.chart1);
            this.Graphics.Location = new System.Drawing.Point(4, 22);
            this.Graphics.Name = "Graphics";
            this.Graphics.Size = new System.Drawing.Size(628, 657);
            this.Graphics.TabIndex = 1;
            this.Graphics.Text = "Графики";
            // 
            // Solve
            // 
            this.Solve.BackColor = System.Drawing.Color.LightGray;
            this.Solve.Controls.Add(this.TableSplit);
            this.Solve.Controls.Add(this.label8);
            this.Solve.Controls.Add(this.SecondPlayerSolve);
            this.Solve.Controls.Add(this.label9);
            this.Solve.Controls.Add(this.FirstPlayerSolve);
            this.Solve.Location = new System.Drawing.Point(4, 22);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(628, 657);
            this.Solve.TabIndex = 0;
            this.Solve.Text = "Решение";
            // 
            // FirstPlayerSolve
            // 
            this.FirstPlayerSolve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FirstPlayerSolve.ColumnHeadersVisible = false;
            this.FirstPlayerSolve.Location = new System.Drawing.Point(12, 31);
            this.FirstPlayerSolve.Name = "FirstPlayerSolve";
            this.FirstPlayerSolve.ReadOnly = true;
            this.FirstPlayerSolve.RowHeadersVisible = false;
            this.FirstPlayerSolve.Size = new System.Drawing.Size(342, 43);
            this.FirstPlayerSolve.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Оптимальная стратегия первого игрока";
            // 
            // SecondPlayerSolve
            // 
            this.SecondPlayerSolve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SecondPlayerSolve.ColumnHeadersVisible = false;
            this.SecondPlayerSolve.Location = new System.Drawing.Point(12, 104);
            this.SecondPlayerSolve.Name = "SecondPlayerSolve";
            this.SecondPlayerSolve.ReadOnly = true;
            this.SecondPlayerSolve.RowHeadersVisible = false;
            this.SecondPlayerSolve.Size = new System.Drawing.Size(342, 43);
            this.SecondPlayerSolve.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Оптимальная стратегия второго игрока";
            // 
            // TableSplit
            // 
            this.TableSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableSplit.Location = new System.Drawing.Point(3, 213);
            this.TableSplit.Name = "TableSplit";
            // 
            // TableSplit.Panel1
            // 
            this.TableSplit.Panel1.Controls.Add(this.firstPlayerSolveTable);
            // 
            // TableSplit.Panel2
            // 
            this.TableSplit.Panel2.Controls.Add(this.secondPlayerSolveTable);
            this.TableSplit.Size = new System.Drawing.Size(622, 441);
            this.TableSplit.SplitterDistance = 302;
            this.TableSplit.TabIndex = 20;
            // 
            // secondPlayerSolveTable
            // 
            this.secondPlayerSolveTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondPlayerSolveTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.secondPlayerSolveTable.Location = new System.Drawing.Point(3, 3);
            this.secondPlayerSolveTable.Name = "secondPlayerSolveTable";
            this.secondPlayerSolveTable.Size = new System.Drawing.Size(310, 432);
            this.secondPlayerSolveTable.TabIndex = 19;
            // 
            // firstPlayerSolveTable
            // 
            this.firstPlayerSolveTable.AllowUserToAddRows = false;
            this.firstPlayerSolveTable.AllowUserToDeleteRows = false;
            this.firstPlayerSolveTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstPlayerSolveTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.firstPlayerSolveTable.Location = new System.Drawing.Point(3, 3);
            this.firstPlayerSolveTable.Name = "firstPlayerSolveTable";
            this.firstPlayerSolveTable.ReadOnly = true;
            this.firstPlayerSolveTable.Size = new System.Drawing.Size(296, 432);
            this.firstPlayerSolveTable.TabIndex = 18;
            // 
            // SolveInformation
            // 
            this.SolveInformation.Controls.Add(this.Solve);
            this.SolveInformation.Controls.Add(this.Graphics);
            this.SolveInformation.Location = new System.Drawing.Point(378, 7);
            this.SolveInformation.Name = "SolveInformation";
            this.SolveInformation.SelectedIndex = 0;
            this.SolveInformation.Size = new System.Drawing.Size(636, 683);
            this.SolveInformation.TabIndex = 28;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(622, 320);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(3, 337);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(622, 320);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(234, 567);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(122, 46);
            this.SolveButton.TabIndex = 29;
            this.SolveButton.Text = "Решить";
            this.SolveButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 688);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.SolveInformation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SecondPlayerStartPosition);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FirstPlayerStartPosition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IterationCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SecondPlayerStrategesCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FirstPlayerStrategesCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecondPlayerMatrix);
            this.Controls.Add(this.FirstPlayerMatrix);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerStartPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerStartPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerStrategesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerStrategesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerMatrix)).EndInit();
            this.Graphics.ResumeLayout(false);
            this.Solve.ResumeLayout(false);
            this.Solve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerSolve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerSolve)).EndInit();
            this.TableSplit.Panel1.ResumeLayout(false);
            this.TableSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableSplit)).EndInit();
            this.TableSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondPlayerSolveTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstPlayerSolveTable)).EndInit();
            this.SolveInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView SecondPlayerStartPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView FirstPlayerStartPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown IterationCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SecondPlayerStrategesCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown FirstPlayerStrategesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SecondPlayerMatrix;
        private System.Windows.Forms.DataGridView FirstPlayerMatrix;
        private System.Windows.Forms.TabPage Graphics;
        private System.Windows.Forms.TabPage Solve;
        private System.Windows.Forms.SplitContainer TableSplit;
        private System.Windows.Forms.DataGridView firstPlayerSolveTable;
        private System.Windows.Forms.DataGridView secondPlayerSolveTable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView SecondPlayerSolve;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView FirstPlayerSolve;
        private System.Windows.Forms.TabControl SolveInformation;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button SolveButton;
    }
}

