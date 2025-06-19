using OldPhonePad.Core.Services;
using OldPhonePad.Core.Interfaces;

namespace OldPhonePad.Tests.Services;

public class OldPhoneInterpreterTests
{
    private readonly IOldPhoneInterpreter _interpreter;

    public OldPhoneInterpreterTests()
    {
        var keyMap = new OldPhoneKeyMap();
        _interpreter = new OldPhoneInterpreter(keyMap);
    }

    [Theory]
    [InlineData("2#", "A")]
    [InlineData("22#", "B")]
    [InlineData("222#", "C")]
    [InlineData("3#", "D")]
    [InlineData("33#", "E")]
    [InlineData("7777#", "S")]
    public void Interpret_WhenValidInput_ReturnsSingleLetter(string input, string expected)
    {
        // Act
        var result = _interpreter.Interpret(input);

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Interpret_WhenInputIs4433555_555666_ReturnsHello()
    {
        // Arrange
        var input = "4433555 555666#";
        var expected = "HELLO";

        // Act
        var result = _interpreter.Interpret(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Interpret_WhenAsteriskIsUsed_AppliesBackspace()
    {
        // Arrange
        var input = "22*2#"; // Press B, backspace, then A
        var expected = "A";

        // Act
        var result = _interpreter.Interpret(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Interpret_WhenPauseBetweenSameButton_HandlesCorrectly()
    {
        // Arrange
        var input = "222 2 22#"; // C A B
        var expected = "CAB";

        // Act
        var result = _interpreter.Interpret(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Interpret_WhenInputIsEmptyOrMissingHash_ReturnsEmpty()
    {
        // Arrange & Act & Assert
        Assert.Equal(string.Empty, _interpreter.Interpret(""));
        Assert.Equal(string.Empty, _interpreter.Interpret("234"));
        Assert.Equal(string.Empty, _interpreter.Interpret("###"));
    }

    [Fact]
    public void Interpret_WhenContainsUnknownCharacters_IgnoresUnknownCharacters()
    {
        // Arrange
        var input = "2a2b2#"; // treat as 222 (C)
        var expected = "C";

        // Act
        var result = _interpreter.Interpret(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Interpret_WhenOnOnlyBackspace_HandlesGracefully()
    {
        // Arrange
        var input = "*#"; // should be empty
        var expected = "";

        // Act
        var result = _interpreter.Interpret(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
