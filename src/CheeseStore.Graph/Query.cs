using System.Collections.Generic;

namespace CheeseStore.Graph
{
    public class Query
    {
        public IEnumerable<Cheese> Cheese()
        {
            return new[] {
                new Cheese
                {
                    Name = "Test"
                }
            };
        }
    }
}
