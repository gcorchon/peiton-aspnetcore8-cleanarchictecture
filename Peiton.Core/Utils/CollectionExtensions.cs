using Peiton.Core.Entities;
using Peiton.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Core.Utils
{
    public static class CollectionExtensions
    {
        public static void Merge<T, U, V>(this ICollection<T> collection, IEnumerable<U> data, Func<T, V> keySelector, Func<U, V?> dataKeySelector, Action<T, U, int, bool> action) where T : class, new()
        {
            var index = 0;
            foreach (var item in data)
            {
                V? dataKey = dataKeySelector(item);
                T? entity;
                bool isNew;
                if (dataKey == null)
                {
                    entity = new T();
                    collection.Add(entity);
                    isNew = true;
                }
                else
                {
                    entity = collection.SingleOrDefault(ic => keySelector(ic)!.Equals(dataKey));
                    if (entity == null) throw new ArgumentException("Entidad no válida");
                    isNew = false;
                }

                action(entity, item, index, isNew);
                index++;
            }

            var existinEntities = data.Where(c => dataKeySelector(c) != null).ToList();
            var entitiesToRemove = collection.Where(ic => !existinEntities.Any(c => dataKeySelector(c) != null && keySelector(ic)!.Equals(dataKeySelector(c)))).ToList();

            foreach (var entityToRemove in entitiesToRemove)
            {
                collection.Remove(entityToRemove);
            }
        }


        public static void Merge<T>(this ICollection<T> collection, IEnumerable<int> data, Func<T, int> keySelector, Func<int, T?> entityGetter) where T : class, new() 
        {
            foreach (var item in data)
            {
                if (collection.SingleOrDefault(u => keySelector(u) == item) == null)
                {
                    var entity = entityGetter(item);
                    if (entity == null)
                    {
                        throw new ArgumentException("Entidad incorrecta incorrecto");
                    }
                    collection.Add(entity);
                }
            }

            var entitiesToRemove = collection.Where(u => !data.Contains(keySelector(u))).ToList();

            foreach (var entity in entitiesToRemove)
            {
                collection.Remove(entity);
            }
        }
    }
}
