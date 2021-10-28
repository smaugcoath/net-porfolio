using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Application.Items.Queries.GetAll
{
    public class GetAllResponse
    {
        public IEnumerable<Item>  Items{ get; set; }

        public class Item
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Details { get; set; }
            public bool IsDone { get; set; }
        }
    }
}
