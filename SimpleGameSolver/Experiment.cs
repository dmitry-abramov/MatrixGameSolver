using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class Experiment
    {
        public BimatrixGame Game { get; private set; }
        
        public Situation StartSituation { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }
        
        public Experiment(BimatrixGame game, Situation startSituation, IDictionary<string, string> parameters)
        {
            Game = game;
            StartSituation = startSituation;
            Parameters = parameters;
        }

        public Experiment(BimatrixGame game, Situation startSituation)
            : this(game, startSituation, new Dictionary<string, string>())
        { 
        }

        public Experiment(BimatrixGame game)
            : this(
            game, 
            new Situation(game.FirstPlayerMatrix.GetLength(0), game.FirstPlayerMatrix.GetLength(1)),
            new Dictionary<string, string>())
        {
        }

        public Experiment(BimatrixGame game, IDictionary<string, string> parameters)
            : this(
            game, 
            new Situation(game.FirstPlayerMatrix.GetLength(0), game.FirstPlayerMatrix.GetLength(1)),
            parameters)
        {
        }
    }
}
