using System.Windows.Forms;

namespace SimpleGameSolver.Experiments
{
    public partial class UiConfigurator : UserControl
    {
        public UiConfigurator()
            : this(new EmptyExperiment())
        {
        }

        public UiConfigurator(Experiment experiment)
        {
            this.ConfiguredExperiment = experiment;
            InitializeComponent();
        }

        public virtual Experiment ConfiguredExperiment
        {
            get;
            protected set;
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
