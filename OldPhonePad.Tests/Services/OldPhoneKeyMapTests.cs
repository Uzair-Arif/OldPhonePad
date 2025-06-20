using OldPhonePad.Core.Services;

namespace OldPhonePad.Tests.Services;

public class OldPhoneKeyMapTests
{
    private readonly OldPhoneKeyMap _keyMap = new();

    [Theory]
    [InlineData('1', "1")]
    [InlineData('2', "ABC")]
    [InlineData('3', "DEF")]
    [InlineData('4', "GHI")]
    [InlineData('5', "JKL")]
    [InlineData('6', "MNO")]
    [InlineData('7', "PQRS")]
    [InlineData('8', "TUV")]
    [InlineData('9', "WXYZ")]
    [InlineData('0', " ")]
    public void GetLetters_WhenValidKey_ReturnssExpectedLetters(char key, string expected)
    {
        // Act & Assert
        Assert.Equal(expected, _keyMap.GetLetters(key));
    }

    [Fact]
    public void GetLetters_WhenInvalidKey_ReturnsEmptyString()
    {
        // Act & Assert
        Assert.Equal("", _keyMap.GetLetters('X'));
    }
}