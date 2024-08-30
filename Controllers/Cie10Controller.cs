using AutoMapper;
using CIE.WebApp.Models.Response;
using CIE.WebApp.Models.ViewModels;
using CIE.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CIE.WebApp.Controllers
{
    public class Cie10Controller:Controller
    {
        private readonly ICie10Services _services;
        private readonly IMapper _mapper;

        public Cie10Controller(ICie10Services services,
            IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        public async Task<IActionResult> MedicalIssueIndex(Cie10SearchModel model, int pg =1, int totalRows = 10)
        {
            

            var response = await _services.MedicalIssueListAsync(
                code: model.Codigo,
                descripcion: model.Nombre,
                sexo: model.Sexo,
                claveCategoria: model.ClaveCategoria,
                page:pg,
                rows:totalRows);

            ViewBag.Sexo = model.Sexo;
            ViewBag.Nombre = model.Nombre;
            ViewBag.Code = model.Codigo;

            var medicalIssuesModel = _mapper.Map<PaginationBaseResponse<Cie10ResponseDto>>(response);

            //const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            //int recsCount = medicalIssuesModel.Data.Count();

            var pager = new PaginationData(response.TotalPages, pg, totalRows);

            if(response.Success)
            {
                model.Cie10 = medicalIssuesModel.Data;
            }



            this.ViewBag.Pager = pager;

            return View(model);
        }
    }
}
