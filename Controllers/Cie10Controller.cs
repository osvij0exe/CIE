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

        public async Task<IActionResult> MedicalIssueIndex(Cie10ViewModel model)
        {
            

            var response = await _services.MedicalIssueListAsync(
                code: model.Codigo,
                descripcion: model.Nombre,
                sexo: model.Sexo,
                claveCategoria: model.ClaveCategoria);

            var medicalIssuesModel = _mapper.Map<PaginationBaseResponse<Cie10ResponseDto>>(response);

            if(response.Success)
            {
                model.Cie10 = medicalIssuesModel.Data;
            }

            return View(model);
        }
    }
}
