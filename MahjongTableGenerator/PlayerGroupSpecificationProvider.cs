using System.Collections.Generic;

namespace MahjongTableGenerator
{
    class PlayerGroupSpecificationProvider
    {
        public List<PlayerGroupSpecificationList> Get()
        {
            var playerGroupSpecificationLists = new List<PlayerGroupSpecificationList>
            {
                new PlayerGroupSpecificationList
                {
                    Specifications = new List<PlayerGroupSpecification>
                    {
                        new PlayerGroupSpecification(1, 1, 1, 1),
                        new PlayerGroupSpecification(2, 2, 2, 2),
                        new PlayerGroupSpecification(3, 3, 3, 3),
                        new PlayerGroupSpecification(4, 4, 4, 4)
                    }
                },
                new PlayerGroupSpecificationList
                {
                    Specifications = new List<PlayerGroupSpecification>
                    {
                        new PlayerGroupSpecification(1, 2, 3, 4),
                        new PlayerGroupSpecification(2, 1, 4, 3),
                        new PlayerGroupSpecification(3, 4, 1, 2),
                        new PlayerGroupSpecification(4, 3, 2, 1)
                    }
                },
                new PlayerGroupSpecificationList
                {
                    Specifications = new List<PlayerGroupSpecification>
                    {
                        new PlayerGroupSpecification(1, 4, 2, 3),
                        new PlayerGroupSpecification(2, 3, 1, 4),
                        new PlayerGroupSpecification(3, 2, 4, 1),
                        new PlayerGroupSpecification(4, 1, 3, 2)
                    }
                },
                new PlayerGroupSpecificationList
                {
                    Specifications = new List<PlayerGroupSpecification>
                    {
                        new PlayerGroupSpecification(1, 3, 4, 2),
                        new PlayerGroupSpecification(2, 4, 3, 1),
                        new PlayerGroupSpecification(3, 1, 2, 4),
                        new PlayerGroupSpecification(4, 2, 1, 3)
                    }
                }
            };



            return playerGroupSpecificationLists;
        }
    }
}
