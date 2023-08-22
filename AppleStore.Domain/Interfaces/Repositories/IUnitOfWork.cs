namespace AppleStore.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
