﻿namespace CIE.WebApp.Models.ViewModels
{
    public class PaginationData
    {
        public int TotalItems { get; private set; }// total de registros
        public int CurrentPage { get; private set; }//pagina actual
        public int PageSize { get; private set; }// tamaño de pagina rows

        public int TotalPages { get; private set; } // total de paginas
        public int StartPage { get; private set; }// pagina de inicio
        public int EndPage { get; private set; }// pagina final

        public PaginationData()
        {
            
        }

        public PaginationData(int totalPages,int page, int pageSize = 10)
        {
            //int totalPages = (int)Math.Ceiling((decimal)totaltItems / (decimal)pageSize);
            int currentPage = page;

            int starPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(starPage <= 0)
            {
                endPage = endPage - (starPage - 1);
                starPage = 1;
            }

            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > 10)
                {
                    starPage = endPage - 9;
                }
            }

            //TotalItems = totaltItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = starPage;
            EndPage = endPage;
        }


    }

}
