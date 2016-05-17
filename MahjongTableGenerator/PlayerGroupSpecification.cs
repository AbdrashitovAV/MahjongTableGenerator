using System.Collections.Generic;

namespace MahjongTableGenerator
{
    public class PlayerGroupSpecification
    {
        public List<int> PlayerGroup;

        public PlayerGroupSpecification(int x1, int x2, int x3, int x4)
        {
            PlayerGroup = new List<int> { x1, x2, x3, x4 };
        }
    }
}
