namespace SimpleGameSolver.Experiments
{
    public partial class EmptyUiConfigurator : UiConfigurator
    {
        public EmptyUiConfigurator()
            : this(new EmptyExperiment())
        {
        }

        public EmptyUiConfigurator(Experiment experiment)
        {
            this.ConfiguredExperiment = experiment;
            InitializeComponent();
        }
    }
}
