using MyDeveloperTools.Core.Interfaces;
using System.Text;

namespace MyDeveloperTools.Core.Services
{
    public class ToolService : IBase64Converter
    {
        public string Base64ToText(string base64Text)
        {
            var base64AsBytes = Convert.FromBase64String(base64Text);
            return Encoding.UTF8.GetString(base64AsBytes);
        }

        public string TextToBase64(string text)
        {
            var textAsBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }
    }
}
