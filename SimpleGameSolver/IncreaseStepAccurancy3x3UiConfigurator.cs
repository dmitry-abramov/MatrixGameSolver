using SimpleGameSolver.Experiments;

namespace SimpleGameSolver
{
    public partial class IncreaseStepAccurancy3x3UiConfigurator : UiConfigurator
    {
        public IncreaseStepAccurancy3x3UiConfigurator()
        {
            InitializeComponent();

            groupBox1.Text = ConfiguredExperiment.Name;
        }

        public override Experiment ConfiguredExperiment
        {
            get
            {
                return GetConfiguredExperiment();
            }
        }

        private Experiment GetConfiguredExperiment()
        {
            if (useDefaultSeed.Checked && useDefaultStepIncreaseCoefficient.Checked)
            {
                return new IncreaseStepAccurancy3x3Experiment();
            }
            if (useDefaultSeed.Checked)
            {
                return new IncreaseStepAccurancy3x3Experiment(GetUserStepIncreaseCoefficient());
            }
            if (useDefaultStepIncreaseCoefficient.Checked)
            {
                return new IncreaseStepAccurancy3x3Experiment(GetUserSeed());
            }

            return new IncreaseStepAccurancy3x3Experiment(
                GetUserSeed(),
                GetUserStepIncreaseCoefficient());
        }

        private int GetUserSeed()
        {
            return int.Parse(userSeed.Text);
        }

        private double GetUserStepIncreaseCoefficient()
        {
            return double.Parse(userStepIncreaseCoefficient.Text);
        }
    }
}
