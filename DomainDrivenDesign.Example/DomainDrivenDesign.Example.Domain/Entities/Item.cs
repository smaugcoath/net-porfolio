using DomainDrivenDesign.Example.Domain.Enums;
using DomainDrivenDesign.Example.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Domain.Entities
{

    public class Item
    {
        public ItemId Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public EItemStatus Status { get; set; } = EItemStatus.Active;
    }

  
}
