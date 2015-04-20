using System.Windows.Forms;

namespace SimpleGameSolver.Experiments
{
    public partial class UiConfigurator : UserControl
    {
        private Experiment experiment;

        public UiConfigurator()
            : this(new EmptyExperiment())
        {
        }

        public UiConfigurator(Experiment experiment)
        {
            this.experiment = experiment;
            InitializeComponent();
        }
        
        public virtual Experiment ConfiguredExperiment
        {
            get { return experiment; }
        }

        public virtual bool IsConfigurationValid
        {
            get { return true; }
        }

        public virtual string ConfigurationError
        {
            get { return string.Empty; }
        }
    }
}
