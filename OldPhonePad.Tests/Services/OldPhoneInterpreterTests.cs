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
    public void Should_ReturnSingleLetter_WhenValidInput(string input, string expected)
    {
        var result = _interpreter.Interpret(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_ReturnHello_WhenInputIs4433555_555666()
    {
        var input = "4433555 555666#";
        var expected = "HELLO";
        var result = _interpreter.Interpret(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_ApplyBackspace_WhenAsteriskIsUsed()
    {
        var input = "22*2#"; // Press B, backspace, then A
        var expected = "A";
        var result = _interpreter.Interpret(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_HandlePauseBetweenSameButton()
    {
        var input = "222 2 22#"; // C A B
        var expected = "CAB";
        var result = _interpreter.Interpret(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_ReturnEmpty_WhenInputIsEmptyOrMissingHash()
    {
        Assert.Equal(string.Empty, _interpreter.Interpret(""));
        Assert.Equal(string.Empty, _interpreter.Interpret("234"));
        Assert.Equal(string.Empty, _interpreter.Interpret("###"));
    }

    [Fact]
    public void Should_IgnoreUnknownCharacters()
    {
        var input = "2a2b2#"; // treat as 222 (C)
        var expected = "C";
        var result = _interpreter.Interpret(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_NotCrash_OnOnlyBackspace()
    {
        var input = "*#"; // should be empty
        var expected = "";
        var result = _interpreter.Interpret(input);
        Assert.Equal(expected, result);
    }
}
