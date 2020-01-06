using System.Collections.Generic;

namespace CheeseStore.Graph
{
    public interface IQuery
    {
        IEnumerable<Cheese> Cheese();
    }
}
