using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetStarter.Logic
{
    public class Rover
    {
        public readonly Tuple<List<int>, List<int>> map;
        public int x;
        public int y;
        public Direction facingDirection = Direction.North;

        public Rover(int x, int y, Tuple<List<int>, List<int>> map)
        {
            this.x = x;
            this.y = y;
            this.map = map;
        }

        public void Move(char[] commands)
        {
            commands.ToList().ForEach(c => Move(c));
        }

        private void Move(char command)
        {
            switch (command)
            {
                case 'f' when y < map.Item2.Max():
                    y++;
                    break;
                case 'f' when y == map.Item2.Max():
                    y = map.Item2.Min();
                    break;
                case 'b' when y > map.Item2.Min():
                    y--;
                    break;
                case 'b' when y == map.Item2.Min():
                    y = map.Item2.Max();
                    break;
                case 'r' when x < map.Item1.Max():
                    x++;
                    break;
                case 'r' when x == map.Item1.Max():
                    x = map.Item1.Min();
                    break;
                case 'l' when x > map.Item1.Min():
                    x--;
                    break;
                case 'l' when x == map.Item1.Min():
                    x = map.Item1.Max();
                    break;
                default:
                    break;
            }


        }

        private void SetDirection(char command)
        {
            switch (facingDirection)
            {
                case Direction.North when command == 'l':
                    facingDirection = Direction.West;
                    break;
                case Direction.North when command == 'r':
                    facingDirection = Direction.East;
                    break;
                case Direction.North when command == 'b':
                    facingDirection = Direction.South;
                    break;
            }
        }
    }
}
