using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Core.Entities;

namespace Framework.Northwind.Entities.ComplexTypes
{
    public class ProductDetail:IEntity
    {
    public virtual int ProductId { get; set; }
    public virtual string ProductName { get; set; }
    public virtual string CategoryName { get; set; }

    }
}
