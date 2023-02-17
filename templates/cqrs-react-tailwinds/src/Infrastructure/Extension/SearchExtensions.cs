using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Extension
{
    public static class SearchExtensions
    {
        public static IEnumerable<T> FindAll<T>(this IEnumerable<T> source, string searchString)
        {
            return source.Where(d => d.SearchObj(searchString)).ToList();
        }
        public static IEnumerable<T> Find<T>(this IEnumerable<T> source, string key, string searchString)
        {
            var property = typeof(T).GetProperty(key, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (property == null)
                return source;

            return source.Where(d => ((string)property.GetValue(d)).Contains(searchString)).ToList();
        }

        public static bool SearchObj<T>(this T obj, string s)
        {
            if (obj == null) return false;
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase).Select(f => f.Name).ToList();
            if (props == null) return false;
            return props.Where(p => obj.GetPropValue(p).ToString().ToLower().Contains(s.ToLower())).ToList().Count > 0; ;
        }

        public static object GetPropValue(this object src, string propName)
        {
            var type = src.GetType().GetProperty(propName).PropertyType;

            if (src == null || !type.IsSimpleType())
                return "";
            var value = src.GetType().GetProperty(propName).GetValue(src, null);
            if(typeof(DateTime) == type){
                return Convert.ToDateTime(value).ToString("yyyy/MM/dd hh:mm");
            }
            return value == null ? "" : value;
        }
        public static bool IsSimpleType(this Type type)
        {
            return
                type.IsPrimitive ||
                new Type[] {
            typeof(string),
            typeof(decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid)
                }.Contains(type) ||
                type.IsEnum ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }
    }
}