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

        public abstract Peak Search();

        public void DisplaySolution(Peak OneTerminalPeak)
        {
            if (OneTerminalPeak == null)
            {
                Console.WriteLine("Nincs megoldása a feladatnak.");
                return;
            }
            //meg kell forditani a csúcsok sorrendjét
            Stack<Peak> solution = new Stack<Peak>();
            Peak actualPeak = OneTerminalPeak;
            while (actualPeak != null)
            {
                solution.Push(actualPeak);
                actualPeak = actualPeak.GetParent();
            }
            foreach (Peak actual in solution)
            {
                Console.WriteLine(actual);
            }

        }
    }
}
