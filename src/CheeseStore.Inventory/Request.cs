using System;
using System.Collections.Generic;
using System.Linq;

namespace CheeseStore.Inventory
{
    public class Request
    {
        public IEnumerable<Guid> Ids { get; set; } = Enumerable.Empty<Guid>();
    }
}
