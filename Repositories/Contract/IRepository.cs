using AdayaTestWeb.Models;

namespace AdayaTestWeb.Repositories.Contract
{
    public interface IRepository
    {
        Task<IEnumerable<GenerateDataModel>> ListAsync();
        Task<int> DeleteAsync();
        Task GenerateAsync(IList<GenerateDataModel> models);

    }
}
