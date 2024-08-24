using CIE.WebApp.Models.Response;

namespace CIE.WebApp.Models.ViewModels
{
    public class Cie10ViewModel
    {
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Sexo { get; set; } = default!;
        public string Catalogo { get; set; } = default!;
        public string ClaveCategoria { get; set; } = default!;
        public ICollection<Cie10ResponseDto> Cie10 { get; set; } = default!;
        public int? CategoriaSeleccionada { get; set; }

    }
}
