namespace Peiton.Core;

public interface IUnityOfWork
{
    Task<int> SaveChangesAsync();
}
