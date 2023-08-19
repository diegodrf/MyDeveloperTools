using System.Reflection;

namespace MyDeveloperTools.App.Constants
{
    public static class RouteConstant
    {
        public const string Base64Converter = "/tools/base64-converter";
        
        public static string GetRelativePath(this string path) => path.TrimStart('/');

        public static IEnumerable<string> GetAllRoutes()
        {
            return typeof(RouteConstant)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.IsLiteral && !x.IsInitOnly && x.FieldType == typeof(string))
                .Select(x => x.GetValue(null)!.ToString()!)
                .ToList();
        }
    }
}
