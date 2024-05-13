using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Basic_threading.View
{
	internal class View
	{
		/// <summary>
		/// Outputs a message on a new line, based on a parameter.
		/// </summary>
		/// <param name="message">String which holds the message that should be output</param>
		internal void OutputLine(string message)
		{
			Console.WriteLine(message);
		}

		/// <summary>
		/// Outputs a char, based on a parameter.
		/// </summary>
		/// <param name="charValue">Parameter which determines which char should be outputted</param>
		internal void OutputChar(char charValue)
		{
			Console.Write(charValue);
		}

		/// <summary>
		/// Reads a user input and parses it to an int.
		/// </summary>
		/// <returns>Users input, converted to an int</returns>
		internal sbyte NumberUserInput()
		{
			// Infinite loop, incase of invalid input
			while(true)
			{
				try
				{
					// Reads user input and converts it to int32
					string userInput = Console.ReadLine();
					return sbyte.Parse(userInput);
				}
				catch
				{
					OutputLine("Invalid input, please write a number between 0 and 4");
				}
			}

		}

		/// <summary>
		/// Reads a user input and converts it to casts it to a char.
		/// Once the value is read, the console foreground color will change, due to RandomTextColor().
		/// If the input value is a whitespace, then it returns an asterisk instead. 
		/// </summary>
		/// <returns></returns>
		internal char CharUserInput()
		{
			// Casts the string input as a char
			char input = (char)Console.Read();

			// Changes the color to a random color, except for black.
			RandomTextColor();
			
			// If the input is not a carriage return, then return the input char, else return '*'
			if(input != '\r')
			{
				return input;
			} else
			{
				return '*';
			}
		}

		/// <summary>
		/// Clears the console for any text and resets the text color to white.
		/// </summary>
		internal void Clear()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
		}

		/// <summary>
		/// Assigns a random color as text color. 
		/// Black is not available, due to it being invisible with a black background.
		/// </summary>
		internal void RandomTextColor()
		{
			// Array containing each consoleColor
			ConsoleColor[] allColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

			// gets a random color
			Random random = new Random();
			byte randomValue = (byte)random.Next(allColors.Length);
			ConsoleColor randomColor = allColors[randomValue];

			// If the color is black, set it as white, else use the random color.
			if(randomColor == ConsoleColor.Black)
			{
				Console.ForegroundColor = ConsoleColor.White;
			} else
			{
				Console.ForegroundColor = randomColor;
			}
		}

		/// <summary>
		/// Specify a console color based on the color parameter.
		/// </summary>
		/// <param name="color">Parameter which states the color that should be used.</param>
		internal void SpecifyForegroundColor(ConsoleColor color)
		{
			Console.ForegroundColor = color;
		}
	}
}
