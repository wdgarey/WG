using System;

namespace WG.Collections.Linked.Graphs
{

    public class IncidenceMatrix : Graph<int>
    {
        private bool[,] matrix;

        protected virtual bool[,] Matrix
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

        public IncidenceMatrix(int rows, int cols)
        {
            this.Matrix = new bool[rows, cols];
        }


    }
}
