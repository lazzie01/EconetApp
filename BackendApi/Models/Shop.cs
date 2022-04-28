using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
    }
}
