using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGameSolver
{
    class TableString
    {
        public int firstPlayerChoiceField;
        public int secondPlayerChoiceField;

        public TableString(int i, int j)
        {
            firstPlayerChoiceField = i;
            secondPlayerChoiceField = j;
        }

        public int firstPlayerChoice
        {
            get { return firstPlayerChoiceField; }
        }

        public int secondPlayerChoice
        {
            get { return secondPlayerChoiceField; }
        }
    }

    class SolutionTable
    {
        protected List<TableString> table;

        public SolutionTable()
        {
            table = new List<TableString>();
        }

        public SolutionTable(SolutionTable t)
        {
            table = new List<TableString>();
            for (int i = 0; i < t.table.Count; i++)
                table.Add(t.table[i]);
        }
        
        public TableString this[int i]
        {
            get { return table[i]; }
        }

        public int Count
        {
            get { return table.Count; }
        }
    }    

    //создает SolutionTable, позволяя добавлять строки
    class SolutionTableCreator : SolutionTable
    {
        public SolutionTableCreator()
        {
            table = new List<TableString>();            
        }

        public void CreateNewTable()
        {
            table = new List<TableString>();
        }

        public SolutionTable GetTable()
        {
            return this;
        }

        public void Add(TableString newString)
        {
            table.Add(newString);
        }
    }

    class MixedStrategy
    {
        protected List<double> strategy;
        public MixedStrategy(int strategyCount)
        {
            strategy = new List<double>();
            for(int i = 0; i < strategyCount; i++)
                strategy.Add(0);
        }

        public MixedStrategy(MixedStrategy s)
        {
            strategy = new List<double>();
            for (int i = 0; i < s.strategy.Count; i++)
                strategy.Add(s.strategy[i]);
        }

        public MixedStrategy(List<double> s)
        {
            strategy = new List<double>();
            for (int i = 0; i < s.Count; i++)
                strategy.Add(s[i]);
        }
        
        public double this[int i]
        {
            get { return strategy[i];}
        }

        public int Count
        {
            get { return strategy.Count; }
        }
    }

    class MixedStrategyCreator : MixedStrategy
    {
        public MixedStrategyCreator() : base(0)
        {
            strategy = new List<double>();
        }

        public void NewMixedStrategy(List<double> _strategy)
        {
            strategy = new List<double>();
            for(int i = 0; i < _strategy.Count; i++)
                strategy.Add(_strategy[i]);
        }

        public MixedStrategy GetMixedStrategy()
        {
            return this;
        }
    }

    class BiMatrixGameSolve
    {
        protected MixedStrategy firstPlayerSolveField;
        protected MixedStrategy secondPlayerSolveField;
        protected double gameValueField;
        protected SolutionTable TableField;
        protected StartPosition startPosition;

        public BiMatrixGameSolve(int m, int n)
        {
            firstPlayerSolveField = new MixedStrategy(m);
            secondPlayerSolveField = new MixedStrategy(n);
            
            TableField = new SolutionTable();

            startPosition = new StartPosition(m, n);

            gameValueField = 0;
        }

        public BiMatrixGameSolve(MixedStrategy _first, MixedStrategy _second, double _v, SolutionTable _table)
        {
            firstPlayerSolveField = _first;
            secondPlayerSolveField = _second;
            gameValueField = _v;
            TableField = _table;
            startPosition = new StartPosition(_first.Count, _second.Count);
        }

        public BiMatrixGameSolve(MixedStrategy _first, MixedStrategy _second, double _v, 
            StartPosition _start, SolutionTable _table)
        {
            firstPlayerSolveField = _first;
            secondPlayerSolveField = _second;
            gameValueField = _v;
            TableField = _table;
            startPosition = _start;
        }

        public MixedStrategy firstPlayerSolveOnStep(int n)
        {
            if (n == 0)
            {
                return startPosition.firstPlayerStart;
            }

            List<double> tmp = new List<double>();
            for (int i = 0; i < firstPlayerSolveField.Count; i++)
                tmp.Add(0);

            for (int i = 0; (i < n) && i < (table.Count); i++)
                tmp[table[i].firstPlayerChoice]++;

            for (int i = 0; i < tmp.Count; i++)
                tmp[i] = (tmp[i] + startPosition.firstPlayerStart[i] *startPosition.startStep) / 
                    (n + startPosition.startStep);
            
            MixedStrategyCreator result = new MixedStrategyCreator();
            result.NewMixedStrategy(tmp);
            return result.GetMixedStrategy();
        }

        public MixedStrategy secondPlayerSolveOnStep(int n)
        {
            if (n == 0)
            {
                return startPosition.secondPlayerStart;
            }

            List<double> tmp = new List<double>();
            for (int i = 0; i < secondPlayerSolveField.Count; i++)
                tmp.Add(0);

            for (int i = 0; (i < n) && i < (table.Count); i++)
                tmp[table[i].secondPlayerChoice]++;
            
            for (int i = 0; i < tmp.Count; i++)
                tmp[i] = (tmp[i] + startPosition.secondPlayerStart[i] * startPosition.startStep) /
                    (n + startPosition.startStep);

            MixedStrategyCreator result = new MixedStrategyCreator();
            result.NewMixedStrategy(tmp);
            return result.GetMixedStrategy();
        }

        public double gameValue
        {
            get { return gameValueField; }
        }

        public MixedStrategy firstPlayerSolve
        {
            get { return firstPlayerSolveField; }
        }

        public MixedStrategy secondPlayerSolve
        {
            get { return secondPlayerSolveField; }
        }

        public SolutionTable table
        {
            get { return TableField; }
        }

        public int startStep
        {
            get { return startPosition.startStep; }
        }
    }
}
