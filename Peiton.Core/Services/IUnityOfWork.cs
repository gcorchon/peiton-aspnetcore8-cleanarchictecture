namespace Peiton.Core;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    void Clear();
}
