﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver.Experiments
{
    public class ExperimentPortion
    {
        public string Name { get; private set; }

        public BimatrixGame Game { get; private set; }
        
        public Situation StartSituation { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }
        
        public ExperimentPortion(string name, BimatrixGame game, Situation startSituation, IDictionary<string, string> parameters)
        {
            Name = name;
            Game = game;
            StartSituation = startSituation;
            Parameters = parameters;
        }

        public ExperimentPortion(string name, BimatrixGame game, Situation startSituation)
            : this(name, game, startSituation, new Dictionary<string, string>())
        { 
        }

        public ExperimentPortion(string name, BimatrixGame game)
            : this(
            name,
            game, 
            new Situation(game.FirstPlayerMatrix.RowCount, game.FirstPlayerMatrix.ColumnCount),
            new Dictionary<string, string>())
        {
        }

        public ExperimentPortion(string name,BimatrixGame game, IDictionary<string, string> parameters)
            : this(
            name,
            game, 
            new Situation(game.FirstPlayerMatrix.RowCount, game.FirstPlayerMatrix.ColumnCount),
            parameters)
        {
        }
    }
}
