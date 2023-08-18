namespace MyDeveloperTools.Core.Interfaces
{
    public interface IClipboardService
    {
        Task CopyToClipboardAsync(string text);
    }
}
