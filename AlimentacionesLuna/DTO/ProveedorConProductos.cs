using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProveedorConProductos
    {
        int offset { get; set; }
        List<Producto> producto { get; set; }
    }
}
