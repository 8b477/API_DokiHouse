
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DokiHouse.Interfaces
{
    public interface IEntity<U>
    {
        U Id { get; set; }
    }
}
