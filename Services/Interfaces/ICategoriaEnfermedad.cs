using CIE.WebApp.Data;
using CIE.WebApp.Models.Response;

namespace CIE.WebApp.Services.Interfaces
{
    public interface ICategoriaEnfermedad
    {
        Task<CollectionBaseResponseGeneric<CategoriaEnfermedad>> IssuesCategoryList();

    }
}
