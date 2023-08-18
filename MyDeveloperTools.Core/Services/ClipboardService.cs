using Microsoft.JSInterop;
using MyDeveloperTools.Core.Interfaces;

namespace MyDeveloperTools.Core.Services
{
    public class ClipboardService : IClipboardService
    {
        private readonly IJSRuntime _jsInterop;
        public ClipboardService(IJSRuntime jsInterop)
        {
            _jsInterop = jsInterop;
        }

        public async Task CopyToClipboardAsync(string text)
        {
            await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}
