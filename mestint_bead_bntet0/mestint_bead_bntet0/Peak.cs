using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_bead_bntet0
{
    public class Peak
    {
        AState state;
        int depth;
        Peak parent;
        public Peak(AState startState)
        {
            state = startState;
            depth = 0;
            parent = null;
        }
        public Peak(Peak parent)
        {
            state = (AState)parent.state.Clone();
            depth = parent.depth + 1;
            this.parent = parent;
        }


        public Peak GetParent() 
        {
            return parent;
        }
        public int GetDepth() 
        {
            return depth;
        }
        public bool IsTerminalPeak()
        {
            return state.IsGoalState();
        }
        public int NumberOfOperators()
        {
            return state.NumberOfOperators();
            //itt lehet hibat dob majd arra figyelni kell
        }
        public bool SuperOperator(int i)
        {
            return state.SuperOperator(i);
        }
        public override bool Equals(object obj)
        {
            Peak peak = (Peak)obj;
            return state.Equals(peak.state);
        }
        public override int GetHashCode()
        {
            return state.GetHashCode();
        }

        public List<Peak> Expansion()
        {
            List<Peak> newPeaksList = new List<Peak>();
            for (int i = 0; i < NumberOfOperators(); i++)
            {
                Peak newPeak = new Peak(this);
                if (newPeak.SuperOperator(i))
                {
                    newPeaksList.Add(newPeak);
                }
            }
            return newPeaksList;
        }
    }
}
