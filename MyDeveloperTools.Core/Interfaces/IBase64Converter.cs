namespace MyDeveloperTools.Core.Interfaces
{
    public interface IBase64Converter
    {
        string TextToBase64(string text);
        string Base64ToText(string base64Text);
    }
}
