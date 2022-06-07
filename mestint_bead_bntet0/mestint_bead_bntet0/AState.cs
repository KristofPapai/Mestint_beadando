using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_bead_bntet0
{
    public abstract class AState : ICloneable
    {
        public abstract bool IsState();
        public abstract bool IsGoalState();
        public abstract int NumberOfOperators();
        public abstract bool SuperOperator(int i);

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
