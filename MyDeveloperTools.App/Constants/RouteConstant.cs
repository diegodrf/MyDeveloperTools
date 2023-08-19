using System.Reflection;

namespace MyDeveloperTools.App.Constants
{
    public static class RouteConstant
    {
        public const string Base64Converter = "/tools/base64-converter";
        public const string GuidGenerator = "/tools/guid-generator";

        public static string GetRelativePath(this string path) => path.TrimStart('/');
        public static string GetPathTitle(this string path)
        {
            return string.Join(' ', path
                .Split('/')
                .Last()
                .Split('-')
                .Select(x => x[0].ToString().ToUpper() + x[1..]));
        }

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
