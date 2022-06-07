using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_bead_bntet0
{
    public class Backtrack : AFinder
    {

        int limit;
        bool memorable;

        public Backtrack(Peak startPeak, int limit, bool memorable) : base(startPeak)
        {
            this.limit = limit;
            this.memorable = memorable;
        }

        public Backtrack(Peak starPeak) : this(starPeak, 0, false) 
        {
        }

        public Backtrack(Peak starPeak,int limit) : this(starPeak, limit, false)
        {
        }
        public Backtrack(Peak starPeak,bool memorable) : this(starPeak, 0, memorable)
        {
        }

        public override Peak Search()
        {
            return Search(GetStartPeak());
        }

        private Peak Search(Peak actualPeak)
        {
            int depth = actualPeak.GetDepth();
            if (limit > 0 && depth >= limit)
            {
                return null;
            }
            Peak actualParent = null;
            if (memorable)
            {
                actualParent = actualPeak.GetParent();
            }
            while (actualParent != null)
            {
                if (actualPeak.Equals(actualParent))
                {
                    return null;
                }
                actualParent = actualParent.GetParent();
            }
            if (actualPeak.IsTerminalPeak())
            {
                return actualPeak;
            }
            for (int i = 0; i < actualPeak.NumberOfOperators(); i++)
            {
                Peak newPeak = new Peak(actualPeak);
                if (newPeak.SuperOperator(i))
                {
                    Peak terminalPeak = Search(newPeak);
                    if (terminalPeak != null)
                    {
                        return terminalPeak;
                    }
                }
            }
            return null;
        }
    }
}
