using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Extension
{
    public static class OrderByExtensions
    {
        public static IOrderedEnumerable<T> OrderBy<T>(
        this IEnumerable<T> source,
        string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }

        public static IOrderedEnumerable<T> OrderByDescending<T>(
            this IEnumerable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }

        public static IOrderedEnumerable<T> ThenBy<T>(
            this IOrderedEnumerable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }

        public static IOrderedEnumerable<T> ThenByDescending<T>(
            this IOrderedEnumerable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }
        static IOrderedEnumerable<T> ApplyOrder<T>(
            IEnumerable<T> source,
            string property,
            string methodName)
        {
            var field = typeof(T).GetProperty(property, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (field == null)
                return (IOrderedEnumerable<T>)source;

            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                {
                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);

            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Enumerable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda.Compile() });

            return (IOrderedEnumerable<T>)result;
        }
    }
}