using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CIE.WebApp.Data;

[Table("CategoriaEnfermedad")]
public partial class CategoriaEnfermedad
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? NombreCategoria { get; set; }

    [InverseProperty("CategoriaEnfermedad")]
    public virtual ICollection<Cie10> Cie10s { get; set; } = new List<Cie10>();
}
