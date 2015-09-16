
namespace EC.ServiceAgents
{
    using DocumentResponse;
    using Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IFieldsService : IUpdatableUrl
    {
        Task<List<Field>> GetFields();

        Task<List<Field>> GetFields(FilterOptionModel filter);

        Task<List<Field>> GetFields(string keywords, string lat, string lon);
       
    }
}
