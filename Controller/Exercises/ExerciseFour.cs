using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Basic_threading.Controller.Exercises
{

	internal class ExerciseFour
	{
		private readonly View.View view = new View.View();
		private bool stopExercise = false;
		private char ch = '*';

		/// <summary>
		/// Reads user input until stopExercise is true.
		/// </summary>
		internal void Reader()
		{
			while (!stopExercise)
			{
				ch = view.CharUserInput();
				KillThreads();
			}
		}

		/// <summary>
		/// Writes user input until stopExercise is true.
		/// </summary>
		internal void Writer() 
		{
			while(!stopExercise)
			{
				view.OutputChar(ch);
				KillThreads();
			}
		}

		/// <summary>
		/// Checks if the char is '1', if it is then the while loops stop and the class execution ends.
		/// </summary>
		private void KillThreads()
		{
			if (ch == '1')
			{
				stopExercise = true;
				view.Clear();
			}
		}
	}
}
