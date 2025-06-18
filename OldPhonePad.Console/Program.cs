using Microsoft.Extensions.DependencyInjection;
using OldPhonePad.Console.ServiceConfigurator;
using OldPhonePad.Core.Interfaces;

var serviceProvider = ServiceConfigurator.Configure();

var interpreter = serviceProvider.GetRequiredService<IOldPhoneInterpreter>();

Console.WriteLine("Enter keypad input:");
string input = Console.ReadLine() ?? string.Empty;

var output = interpreter.Interpret(input);
Console.WriteLine($"Output: {output}");