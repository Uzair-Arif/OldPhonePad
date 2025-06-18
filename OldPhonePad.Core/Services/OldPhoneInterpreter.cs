using OldPhonePad.Core.Interfaces;
using System.Text;

namespace OldPhonePad.Core.Services;

public class OldPhoneInterpreter : IOldPhoneInterpreter
{
    private readonly IKeyMapProvider _keyMap;

    public OldPhoneInterpreter(IKeyMapProvider keyMap)
    {
        _keyMap = keyMap;
    }

    public string Interpret(string input)
    {
        if (string.IsNullOrWhiteSpace(input) || !input.EndsWith('#'))
            return string.Empty;

        var result = new StringBuilder();
        var buffer = new StringBuilder();

        foreach (char current in input)
        {
            if (current == '#')
            {
                FlushBuffer(buffer, result);
            }
            else if (current == '*')
            {
                FlushBuffer(buffer, result);
                if (result.Length > 0)
                    result.Length--; // backspace
            }
            else if (current == ' ')
            {
                FlushBuffer(buffer, result); // pause between same key
            }
            else if (char.IsDigit(current))
            {
                if (buffer.Length == 0 || buffer[0] == current)
                {
                    buffer.Append(current); // keep building
                }
                else
                {
                    FlushBuffer(buffer, result); // flush previous
                    buffer.Append(current);      // start new
                }
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Converts the buffered key presses into the corresponding letter and appends it to the output.
    /// Clears the buffer after processing.
    /// </summary>
    /// <param name="buffer">The buffer containing repeated key presses.</param>
    /// <param name="output">The output StringBuilder to append the interpreted letter to.</param>
    private void FlushBuffer(StringBuilder buffer, StringBuilder output)
    {
        if (buffer.Length == 0) return;

        var letters = _keyMap.GetLetters(buffer[0]);
        if (!string.IsNullOrEmpty(letters))
            output.Append(letters[(buffer.Length - 1) % letters.Length]);

        buffer.Clear();
    }
}
