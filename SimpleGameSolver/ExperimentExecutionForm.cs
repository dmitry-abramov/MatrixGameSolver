using SimpleGameSolver.Experiments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleGameSolver
{
    public partial class ExperimentExecutionForm : Form
    {
        public ExperimentExecutionForm()
        {
            InitializeComponent();

            methodList.Items.AddRange(DynamicResourceLoader.GetBrownMethodImplementations().ToArray());
            methodList.DisplayMember = "Name";
            methodList.ValueMember = "Name";
            methodList.SelectedIndex = 0;

            experimentList.Items.AddRange(DynamicResourceLoader.GetExperiments().ToArray());
            experimentList.DisplayMember = "Name";
            experimentList.ValueMember = "Name";
            experimentList.SelectedIndex = 0;
        }

        private void ExecuteExperimentBtnClick(object sender, EventArgs e)
        {
            var experiment = (Experiment)experimentList.SelectedItem;
            var method = (BrownMethodBase)methodList.SelectedItem;

            var experimentator = new Experimentator(experiment, method, experimentProgressBar);

            experimentator.MakeExperiment();
        }

        private void ExperimentListSelectedIndexChanged(object sender, EventArgs e)
        {
            var experiment = (Experiment)experimentList.SelectedItem;

            UiConfiguratorContainer.Controls.Clear();
            UiConfiguratorContainer.Controls.Add(experiment.GetUiConfigurator());
        }
    }
}
