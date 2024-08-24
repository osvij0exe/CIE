using CIE.WebApp.Models.Request;
using CIE.WebApp.Models.Response;

namespace CIE.WebApp.Services.Interfaces
{
    public interface ICie10Services
    {
        Task<BaseResponseGeneric<Cie10ResponseDto>> FindMedicalIssueByIdAsync(int id);  
        Task<PaginationBaseResponse<Cie10ResponseDto>> MedicalIssueListAsync(string? code,string? descripcion,string? sexo,string? claveCategoria,int page = 1,int rows = 50);
        Task<BaseResponse> AddMedicalIssueAsync(Cie10RequestDto rquest);
        Task<BaseResponse> UpdateMedicalIssueAsync(int id, Cie10RequestDto request);
        

    }
}
