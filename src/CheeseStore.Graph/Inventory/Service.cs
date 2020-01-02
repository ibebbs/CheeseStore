using System;
using System.Collections.Generic;

namespace CheeseStore.Graph.Inventory
{
    public interface IService
    {
        IReadOnlyDictionary<Guid, uint> GetInventory(IReadOnlyList<Guid> cheeses);
    }

    public class Service : IService
    {
        public IReadOnlyDictionary<Guid, uint> GetInventory(IReadOnlyList<Guid> cheeses)
        {
            throw new NotImplementedException();
        }
    }
}
