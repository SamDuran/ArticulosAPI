using System;
using System.Collections.Generic;

namespace ARTICULOS_API.Entities
{
    public partial class Articulo
    {
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public double Existencia { get; set; }
    }
}
