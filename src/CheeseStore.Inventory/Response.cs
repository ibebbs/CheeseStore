using System;
using System.Collections.Generic;
using System.Linq;

namespace CheeseStore.Inventory
{
    public class Response
    {
        public Response(IEnumerable<KeyValuePair<Guid, uint>> available)
        {
            Available = available.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public Dictionary<Guid, uint> Available { get; }
    }
}
