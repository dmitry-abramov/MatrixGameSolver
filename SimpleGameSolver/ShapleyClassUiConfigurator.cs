using SimpleGameSolver.Experiments;

namespace SimpleGameSolver
{
    public partial class ShapleyClassUiConfigurator : UiConfigurator
    {
        public ShapleyClassUiConfigurator()
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
                return new ShapleyClassExperiment();
            }
            if (useDefaultSeed.Checked)
            {
                return new ShapleyClassExperiment(GetUserStepIncreaseCoefficient());
            }
            if (useDefaultStepIncreaseCoefficient.Checked)
            {
                return new ShapleyClassExperiment(GetUserSeed());
            }

            return new ShapleyClassExperiment(
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
