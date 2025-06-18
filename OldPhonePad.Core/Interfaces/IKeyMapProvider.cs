namespace OldPhonePad.Core.Interfaces;

/// <summary>
/// Provides a method to retrieve the letters associated with a specific key on an old phone keypad.
/// </summary>
public interface IKeyMapProvider
{
    /// <summary>
    /// Gets the string of letters mapped to the specified key.
    /// </summary>
    /// <param name="key">The keypad character.</param>
    /// <returns>The string of letters associated with the key, or an empty string if the key is not mapped.</returns>
    string GetLetters(char key);
}
