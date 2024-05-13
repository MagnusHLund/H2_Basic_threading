using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Basic_threading.Controller
{
	internal class ExerciseZero
	{
		// Creates a new instance of the view class
		private readonly View.View view = new View.View();

		/// <summary>
		/// The WorkThread() method loops 10 times, using a for-loop.
		/// Each time it outputs the same string, using the View class' Output() method.
		/// </summary>
		internal void WorkThread()
		{
			// Loop 10 times
			for(int i = 0; i < 10; i++)
			{
				// Call the Output() method, within the View class to output a message.
				view.OutputLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
			}
		}
	}
}
