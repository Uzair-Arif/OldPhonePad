using OldPhonePad.Core.Interfaces;

namespace OldPhonePad.Core.Services;

public class OldPhoneKeyMap : IKeyMapProvider
{
    private readonly Dictionary<char, string> _map = new()
        {
            {'1', "1"},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "}
        };

    public string GetLetters(char key)
    {
        return _map.ContainsKey(key) ? _map[key] : "";
    }
}
