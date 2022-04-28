using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.Models
{
    public class Area
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Shop> Shops { get; set; }
    }
}
