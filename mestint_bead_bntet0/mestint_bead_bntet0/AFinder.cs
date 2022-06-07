using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_bead_bntet0
{
    public abstract class AFinder
    {
        public Peak startPeak;
        public AFinder(Peak startPeak)
        {
            this.startPeak = startPeak;
        }

        public Peak GetStartPeak()
        {
            return startPeak;
        }
    }
}
