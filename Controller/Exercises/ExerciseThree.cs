using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Basic_threading.Controller.Exercises
{
	internal class ExerciseThree
	{
		private readonly Random rnd = new Random();
		private readonly View.View view = new View.View();

		sbyte outsideRangeCounter = 0;
		bool stopExercise = false;

		/// <summary>
		/// Entry point of ExerciseThree.
		/// Gets a random temperature between -20 and 120. 
		/// The temperature is outputted to the console.
		/// Calls the Alert() method to check if the temperature is within a specific limit.
		/// Method ends once stopExercise is false.
		/// </summary>
		internal void Start()
		{
			while(!stopExercise)
			{
				sbyte temperature = (sbyte)rnd.Next(-20, 121);

				view.OutputLine($"Temperature is {temperature}");

				Alert(temperature);

				Thread.Sleep(2000);
			}
		}

		/// <summary>
		/// Checks if the temperature is outside of a range.
		/// If it is outside the range, the outsideRangeCounter goes up by 1, which changes the text color.
		/// If outsideRangeCounter is beyond maxAlerts, then the exercise stops.
		/// </summary>
		/// <param name="temperature">Current temperature</param>
		private void Alert(sbyte temperature)
		{
			byte maxAlerts = 3;
			byte minTemperature = 0;
			byte maxTemperature = 100;

			if (temperature < minTemperature || temperature > maxTemperature)
			{
				outsideRangeCounter++;

				// Changes text color based on outsideRangeCounter's value
				switch(outsideRangeCounter)
				{
					case 1:
						view.SpecifyForegroundColor(ConsoleColor.Green);
						break;
					case 2:
						view.SpecifyForegroundColor(ConsoleColor.Blue);
						break;
					case 3:
						view.SpecifyForegroundColor(ConsoleColor.Red);
						break;
				}

				view.OutputLine("The temperature is outside the limit!");

				// Stops the exercise, if there have been too many temperatures outside the range.
				if (outsideRangeCounter >= maxAlerts)
				{
					stopExercise = true;
				}
			}
		}
	}
}
