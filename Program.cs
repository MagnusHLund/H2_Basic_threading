using H2_Basic_threading.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Basic_threading
{
	internal class Program
	{
		/// <summary>
		/// Entry point for the program.
		/// Calls the ExerciseHandler class, HandleExercises() method.
		/// </summary>
		public static void Main()
		{
			new ExerciseHandler().HandleExercises();
		}
	}
}