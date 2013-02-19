using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGameSolver
{
    interface Matrix
    {
        double this[int i, int j]
        {
            get;
            set;
        }

        int RowCount
        {
            get;
        }

        int ColumnCount
        {
            get;
        }
    }

    class doubleMatrix : Matrix
    {        
        protected int RowCountField;
        protected int ColumnCountField;
        protected Array matrix;

        public doubleMatrix()
        {
            RowCountField = 1;
            ColumnCountField = 1;
            matrix = Array.CreateInstance( typeof(double), 1, 1);
            matrix.SetValue(0, 0, 0);
        }

        public doubleMatrix(int _RowCount, int _ColumnCount)
        {
            RowCountField = _RowCount;
            ColumnCountField = _ColumnCount;
            matrix = Array.CreateInstance(typeof(double), RowCountField, ColumnCountField);
            for (int i = 0; i < RowCountField; i++)
            {
                for (int j = 0; j < ColumnCountField; j++)
                {
                    matrix.SetValue(0, i, j);
                }
            }
        }

        public double GetValue(int i, int j)
        {
            return (double)matrix.GetValue(i, j);
        }

        public void SetValue(double v, int i, int j)
        {
            matrix.SetValue(v, i, j);
        }

        public int GetNumberOfColum()
        {
            return ColumnCountField; 
        }

		public int GetNumberOfStrings()
        {
            return RowCountField;
        }

        public double this[int i, int j]
        {
            get { return this.GetValue(i,j);}
            set { this.SetValue(value,i,j);}
        }

        public int RowCount
        {
            get { return this.GetNumberOfStrings(); }
        }

        public int ColumnCount
        {
            get { return this.GetNumberOfColum(); }
        }
    }
}
