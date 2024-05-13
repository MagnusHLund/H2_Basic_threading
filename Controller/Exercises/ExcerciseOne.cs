using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Basic_threading.Controller
{
	internal class ExerciseOne
	{
		private readonly View.View view = new View.View();

		/// <summary>
		/// Repeat a message a specific amount of time. 
		/// A message will by default loop 5 times.
		/// </summary>
		/// <param name="message">The message to repeat</param>
		/// <param name="repeatAmount">Total amount of times the message should be written. Default 5 value is 5.</param>
		internal void RepeatMessage(string message, int repeatAmount = 5)
		{
			for (int i = 0; i < repeatAmount; i++)
			{
				view.OutputLine(message);
			}
		}
	}
}
