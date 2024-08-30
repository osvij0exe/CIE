using CIE.WebApp.Models.Response;

namespace CIE.WebApp.Models.ViewModels
{
    public class Cie10SearchModel
    {

        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Sexo { get; set; } = default!;
        public string Catalogo { get; set; } = default!;
        public string ClaveCategoria { get; set; } = default!;
        public ICollection<Cie10ResponseDto> Cie10 { get; set; } = default!;
        public int? CategoriaSeleccionada { get; set; }

        public int TotalItems { get; private set; }// total de registros
        public int CurrentPage { get; private set; }//pagina actual
        public int PageSize { get; private set; }// tamaño de pagina rows

        public int TotalPages { get; private set; } // total de paginas
        public int StartPage { get; private set; }// pagina de inicio
        public int EndPage { get; private set; }// pagina final

        public Cie10SearchModel()
        {

        }

        public Cie10SearchModel(
            string nombre,
            string codigo,
            string sexo,
            int totalPages,
            int page, 
            int pageSize = 10)
        {
            //int totalPages = (int)Math.Ceiling((decimal)totaltItems / (decimal)pageSize);
            int currentPage = page;

            int starPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (starPage <= 0)
            {
                endPage = endPage - (starPage - 1);
                starPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    starPage = endPage - 9;
                }
            }

            Codigo = codigo;
            Nombre = nombre;
            Sexo = sexo;
            //TotalItems = totaltItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = starPage;
            EndPage = endPage;
        }
    }
}
