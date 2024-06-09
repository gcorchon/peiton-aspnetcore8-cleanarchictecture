namespace Peiton.Contracts.Common;

public class PaginatedData<T>
{
    public IEnumerable<T> Items {get; set;} = new List<T>();
    public int Total {get; set ;}
}
