namespace SimpleGameSolver.Experiments
{
    public partial class EmptyUiConfigurator : UiConfigurator
    {
        private Experiment experiment;

        public EmptyUiConfigurator()
            : this(new EmptyExperiment())
        {
        }

        public EmptyUiConfigurator(Experiment experiment)
        {
            this.experiment = experiment;
            InitializeComponent();
        }
    }
}
