using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CIE.WebApp.Data;

[Table("CIE09")]
public partial class Cie09
{
    [Key]
    public int Id { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string Procedimiento { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Filtro { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string DescripcionM { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Uso { get; set; } = null!;
}
