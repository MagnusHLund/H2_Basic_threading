using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Basic_threading.Controller.Exercises
{
	internal class ExerciseTwo
	{
		private readonly View.View view = new View.View();

		/// <summary>
		/// Repeats a message. The message is looped whichever amount that repeatAmount is.
		/// The message itself is determined by the message parameter.
		/// </summary>
		/// <param name="message">The message to output</param>
		/// <param name="repeatAmount">Amounts of time to loop</param>
		internal void RepeatMessage(string message, int repeatAmount = 5)
		{
			for (int i = 0; i < repeatAmount; i++)
			{
				view.OutputLine(message);
				Thread.Sleep(1000);
			}
		}
	}
}
