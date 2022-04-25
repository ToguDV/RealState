using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealState.Entities
{
    public class PropertyTrace
    {
        public int Id { get; set; }
        public string DateSale { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public float Tax { get; set; }
        public int IdProperty { get; set; }
    }
}
