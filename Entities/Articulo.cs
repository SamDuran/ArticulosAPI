using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTICULOS_API.Entities
{
    public partial class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Debe indicar la descripción.")]
        [MinLength(3, ErrorMessage = "La descripción debe tener al menos {1} caractéres.")]
        [MaxLength(50, ErrorMessage = "La descripción no debe pasar de {1} caractéres.")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "Campo obligatorio. Debe indicar la marca.")]
        [MinLength(3, ErrorMessage = "La marca debe tener al menos {1} caractéres.")]
        [MaxLength(50, ErrorMessage = "La marca no debe pasar de {1} caractéres.")]
        public string Marca { get; set; } = null!;

        [Required(ErrorMessage = ("Campo obligatorio. Debe indicar la cantidad del articulo."))]
        [Range(0, 1000000000, ErrorMessage ="La cantidad debe permanecer dentro de un rango de {1} a {2}.")]
        public double Existencia { get; set; }
    }
}
