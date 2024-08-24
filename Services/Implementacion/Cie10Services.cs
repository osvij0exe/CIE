using AutoMapper;
using CIE.WebApp.Data;
using CIE.WebApp.Models.Request;
using CIE.WebApp.Models.Response;
using CIE.WebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CIE.WebApp.Services.Implementacion
{
    public class Cie10Services : ICie10Services
    {
        private readonly CiedbContext _context;
        private readonly ILogger<Cie10Services> _logger;
        private readonly IMapper _mapper;

        public Cie10Services(CiedbContext context,
            ILogger<Cie10Services> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<Cie10ResponseDto>> FindMedicalIssueByIdAsync(int id)
        {
            var response = new  BaseResponseGeneric<Cie10ResponseDto>();

            try
            {
                var medicalIssue = await _context.Cie10s.FirstOrDefaultAsync(m => m.Id == id);

                if(medicalIssue is not null)
                {
                    response.Data = _mapper.Map<Cie10ResponseDto>(medicalIssue);
                    response.Success = true;
                }

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Error al encontrar Enfermendad";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }
            return response;

        }

        public async Task<PaginationBaseResponse<Cie10ResponseDto>> MedicalIssueListAsync(string? code, string? descripcion, string? sexo, string? claveCategoria, int page = 1, int rows = 50)
        {
            var response = new PaginationBaseResponse<Cie10ResponseDto>();


            try
            {
                Expression<Func<Cie10, bool>> predicate = p => p.Codigo.Contains(code ?? string.Empty)
                                                                && p.Nombre.Contains(descripcion ?? string.Empty)
                                                                && p.Sexo.Contains(sexo ?? string.Empty)
                                                                && p.ClaveCategoria.Contains(claveCategoria ?? string.Empty);
                
                var medicalIssuesList = _context.Cie10s
                    .Where(predicate)
                    .AsQueryable();

                var collection = await medicalIssuesList
                    .OrderBy(m => m.Codigo)
                    .Skip((page -1) * rows)
                    .Take(rows)
                    .Select(m => new Cie10ResponseDto
                    {
                        Codigo = m.Codigo,
                        Nombre = m.Nombre,//descripcion
                        Sexo = m.Sexo,
                        ClaveCategoria = m.ClaveCategoria,
                        Catalogo = m.Catalogo,
                    })
                    .ToListAsync();

                var totlaRegisters = await medicalIssuesList.CountAsync();

                response.Data = collection;
                response.TotalPages = totlaRegisters / rows;
                response.Success = true;


            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Error al lista enfermedades";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }

            return response;

        }



        public Task<BaseResponse> AddMedicalIssueAsync(Cie10RequestDto rquest)
        {
            throw new NotImplementedException();
        }


        public Task<BaseResponse> UpdateMedicalIssueAsync(int id, Cie10RequestDto request)
        {
            throw new NotImplementedException();
        }

    }
}
