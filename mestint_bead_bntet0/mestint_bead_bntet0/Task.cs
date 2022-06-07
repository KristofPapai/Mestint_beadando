using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_bead_bntet0
{
    public class Task : AState
    {
        int[] goal;
        int[,] blackField;
        int[,] hopPosition;
        int last_x;
        int last_y;
        int hop;

        public Task() {
            //a jobb alsó sarka a táblának a célállapotunk.
            goal = new int[] { 7, 7 };
            blackField = new int[,] { { 2, 2 }, { 7, 2 }, { 1, 4 }, { 5, 5 }, { 3, 7 } };
            hopPosition = new int[,] { { 0, 4 }, { 0, 7 }, { 2, 1 }, { 2, 3 }, { 2, 6 }, { 3, 4 }, { 3, 5 }, { 4, 0 }, { 4, 3 }, { 6, 1 }, { 6, 5 }, { 7, 4 }, { 7, 6 } };
            last_x = 0;
            last_y = 0;
            hop = 2;
            //Itt beállítottam a tábla kezdőállapotát a feladat alapján.        
        }
        public override bool IsState()
        {
            bool state = true;
            for (int i = 0; i < blackField.Length; i++)
            {
                if ((last_x + 1) == blackField[i, 0] && last_y == blackField[i, 1])
                {
                    return false;
                }
                else if ((last_x - 1) == blackField[i, 0] && last_y == blackField[i, 1])
                {
                    return false;
                }
                else if (last_x == blackField[i,0] && (last_y +1) == blackField[i,1])
                {
                    return false;
                }
                else if (last_x == blackField[i, 0] && (last_y - 1) == blackField[i, 1])
                {
                    return false;
                }
            }
            return state;
        }

        public override bool IsGoalState()
        {
            throw new NotImplementedException();
        }

        public override int NumberOfOperators()
        {
            throw new NotImplementedException();
        }

        public override bool SuperOperator(int i)
        {
            throw new NotImplementedException();
        }
    }
}
