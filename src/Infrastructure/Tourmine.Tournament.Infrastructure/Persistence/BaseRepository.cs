using System.Linq.Expressions;

namespace Tourmine.Tournament.Infrastructure.Persistence
{
    public class BaseRepository
    {

    }

    public static class WhereExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);

            return source;
        }
    }
}
