namespace TaskMangement.Service.IService
{
    public interface IITaskService
    {
        Task<IEnumerable<Data.Models.Task>> GetAllAsync();
        Task<Data.Models.Task?> GetByIdAsync(long id);
        Task<Data.Models.Task> CreateAsync(Data.Models.Task task);
        Task<Data.Models.Task?> UpdateAsync(long id, Data.Models.Task task);
        Task<Data.Models.Task?> DeleteAsync(long id);
    }
}