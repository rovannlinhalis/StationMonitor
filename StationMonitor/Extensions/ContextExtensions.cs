
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Extensions
{
    public static class ContextExtensions
    {
        public static EntityEntry<T> InsertOrUpdate<T>(this DbContext context, T model)
    where T : class
        {
            EntityEntry<T> entry = context.Entry(model);
            IKey primaryKey = entry.Metadata.FindPrimaryKey();
            if (primaryKey != null)
            {
                object[] keys = primaryKey.Properties.Select(x => x.FieldInfo.GetValue(model)).ToArray();
                T result = context.Find<T>(keys);
                if (result == null)
                {
                    var resultado = context.Add(model);
                    return resultado;
                }
                else
                {
                    context.Entry(result).State = EntityState.Detached;
                    var resultado = context.Update(model);
                    return resultado;
                }
            }
            else
                return null;
        }
    }
}
