using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealState.Entities
{
    public class PropertyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
    }
}
