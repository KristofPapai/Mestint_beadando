using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_bead_bntet0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A 2.28-as probléma megoldása konzolon");
            Peak startPeak = new Peak(new Task());
            Console.WriteLine("A Keresőnk egy 10 mélységi korlátos emlékezetes backtrack");
            AFinder backtrack = new Backtrack(startPeak, 10, true);
            backtrack.DisplaySolution(backtrack.Search());
            Console.ReadKey();
        }
    }
}
