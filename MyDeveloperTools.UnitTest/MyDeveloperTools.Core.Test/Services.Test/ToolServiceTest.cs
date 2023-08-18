using MyDeveloperTools.Core.Interfaces;
using MyDeveloperTools.Core.Services;

namespace MyDeveloperTools.UnitTest.MyDeveloperTools.Core.Test.Services.Test
{
    public class ToolServiceTest
    {
        private readonly IBase64Converter _base64Converter = new ToolService();

        [Theory]
        [InlineData("Hello World!", "SGVsbG8gV29ybGQh")]
        [InlineData("email@email.com", "ZW1haWxAZW1haWwuY29t")]
        [InlineData("%*#)1sssh$$23¬l{┤;è↓", "JSojKTFzc3NoJCQyM8KsbHvilKQ7w6jihpM=")]
        public void GivenAText_WhenConvertedToBase64_ShouldReturnABase64Text(string text, string result)
        {
            var textAsBase64 = _base64Converter.TextToBase64(text);
            
            Assert.Equal(result, textAsBase64);
        }

        [Theory]
        [InlineData("SGVsbG8gV29ybGQh", "Hello World!")]
        [InlineData("ZW1haWxAZW1haWwuY29t", "email@email.com")]
        [InlineData("JSojKTFzc3NoJCQyM8KsbHvilKQ7w6jihpM=", "%*#)1sssh$$23¬l{┤;è↓")]
        public void GivenABase64String_WhenDecode_ShouldReturnAValidPlainText(string text, string result)
        {
            var textAsBase64 = _base64Converter.Base64ToText(text);

            Assert.Equal(result, textAsBase64);
        }

        [Fact]
        public void GivenAnInvalidBase64String_WhenDecode_ShouldReturnFormatException()
        {
            var invalidBase64 = "4rdHFh%2BHYoS8oLdVvbUzEVqB8Lvm7kSPnuwF0AAABYQ%3D";

            Assert.Throws<FormatException>(() => _base64Converter.Base64ToText(invalidBase64));
        }
    }
}
