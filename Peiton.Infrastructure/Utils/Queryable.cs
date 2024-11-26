namespace Peiton.Infrastructure.Utils;

public static class Queryable
{
    public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> source, int page, int total)
    {
        return source.Skip((page - 1) * total)
                     .Take(total);
    }
}