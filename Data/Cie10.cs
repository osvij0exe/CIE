using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CIE.WebApp.Data;

[Table("CIE10")]
public partial class Cie10
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string Sexo { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string Vigente { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Catalogo { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string ClaveCategoria { get; set; } = null!;

    public int? CategoriaEnfermedadId { get; set; }

    [ForeignKey("CategoriaEnfermedadId")]
    [InverseProperty("Cie10s")]
    public virtual CategoriaEnfermedad? CategoriaEnfermedad { get; set; }
}
