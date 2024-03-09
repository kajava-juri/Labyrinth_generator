using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_generator
{
    public class Edge
    {
        private int _weight;
        private bool _isIncluded = false;
        private bool _isPrinted = false;

        public Edge(int weightValue)
        {
            _weight = weightValue;
        }

        public int GetWeight()
        {
            return _weight;
        }

        public void SetWeight(int weight)
        {
            _weight = weight;
        }

        public bool IsIncluded()
        {
            return _isIncluded;
        }

        public void SetIncluded(bool included)
        {
            _isIncluded = included;
        }

        public bool IsPrinted()
        {
            return _isPrinted;
        }

        public void SetPrinted(bool printed)
        {
            _isPrinted = printed;
        }
    }

}
