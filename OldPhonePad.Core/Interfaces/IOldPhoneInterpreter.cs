namespace OldPhonePad.Core.Interfaces;

/// <summary>
/// Provides a method to interpret old phone keypad input into text.
/// </summary>
public interface IOldPhoneInterpreter
{
    /// <summary>
    /// Interprets a string of old phone keypad input and returns the corresponding text.
    /// </summary>
    /// <param name="input">The input string representing key presses.</param>
    /// <returns>The interpreted text.</returns>
    string Interpret(string input);
}
