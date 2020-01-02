using System.Collections.Generic;
using System.Linq;

namespace CheeseStore.Inventory
{
    public class Response
    {
        public IEnumerable<Available> Available { get; set; } = Enumerable.Empty<Available>();
    }
}
