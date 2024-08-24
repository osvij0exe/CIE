using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CIE.WebApp.Models.Response
{
    public class Cie10ResponseDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Sexo { get; set; } = default!;
        public string Vigente { get; set; } = default!;
        public string Catalogo { get; set; } = default!;
        public string ClaveCategoria { get; set; } = default!;
    }
}
