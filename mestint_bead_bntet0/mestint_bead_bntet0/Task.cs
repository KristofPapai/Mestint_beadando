﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestint_bead_bntet0
{
    public class Task : AState
    {
        public Task() {
            goal = new int[] { 7, 7 };
            wrong_positions = new int[,] {
                { 2, 2 },
                { 7, 2 },
                { 1, 4 },
                { 5, 5 },
                { 3, 7 }
            };
            hopPosition = new int[,] { 
                { 0, 4 },
                { 0, 7 },
                { 2, 1 },
                { 2, 3 },
                { 2, 6 },
                { 3, 4 },
                { 3, 5 },
                { 4, 0 },
                { 4, 3 },
                { 6, 1 },
                { 6, 5 },
                { 7, 4 },
                { 7, 6 } 
            };
            last_x = 0;
            last_y = 0;
            hop = 2;    
        }

        int[] goal;
        int[,] wrong_positions;
        int[,] hopPosition;
        int last_x;
        int last_y;
        int hop;

        public override bool IsState()
        {
            bool state = true;
            for (int i = 0; i < (wrong_positions.GetLength(0)); i++)
            {
                if ((last_x + 1) == wrong_positions[i, 0] && last_y == wrong_positions[i, 1])
                {
                    return false;
                }
                else if ((last_x - 1) == wrong_positions[i, 0] && last_y == wrong_positions[i, 1])
                {
                    return false;
                }
                else if (last_x == wrong_positions[i, 0] && (last_y + 1) == wrong_positions[i, 1])
                {
                    return false;
                }
                else if (last_x == wrong_positions[i, 0] && (last_y - 1) == wrong_positions[i, 1])
                {
                    return false;
                }

            }
            return state;
        }

        public override bool IsGoalState()
        {
            return last_x == goal[0] && last_y == goal[1];
        }

        public override int NumberOfOperators()
        {
            return 4;
        }

        public override bool SuperOperator(int i)
        {
            switch (i)
            {
                case 0:
                    return Move(-1, 0);
                case 1:
                    return Move(0, -1);
                case 2:
                    return Move(1, 0);
                case 3:
                    return Move(0, 1);
                default:
                    return false;
            }
        }

        private bool Move(int row, int column)
        {
            try
            {
                int Row = last_x + (row * hop);
                int Column = last_y + (column * hop);
                if (preMove(Row,Column))
                {
                    if (!IsState())
                    {
                        return false;
                    }
                    last_x = Row;
                    last_y = Column;
                    Circle();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return false;
        }

        public bool preMove(int row, int column)
        {
            if (row > -1 && row < 8 && column > -1 && column < 8)
            {
                return true;
            }
            else
            {
                return false;
            }
            for (int i = 0; i < wrong_positions.GetLength(0); i++)
            {
                if (row == wrong_positions[i, 0] && column == wrong_positions[i, 1])
                {
                    return false;
                }
            }
        }

        public void Circle()
        {
            for (int i = 0; i < hopPosition.GetLength(0); i++)
            {
                if (last_x == hopPosition[i,0] && last_y == hopPosition[i,1] && hop == 2)
                {
                    hop = 3;
                }
                else if(last_x == hopPosition[i, 0] && last_y == hopPosition[i, 1] && hop == 3)
                {
                    hop = 2;
                }
            }
        }

        public override string ToString()
        {
            return "x: " + last_x + ", y: " + last_y;
        }
    }
}
