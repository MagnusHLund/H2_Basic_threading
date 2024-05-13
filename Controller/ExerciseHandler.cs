using H2_Basic_threading.Controller.Exercises;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Basic_threading.Controller
{
	internal class ExerciseHandler
	{
		private readonly View.View view = new View.View();

		/// <summary>
		/// Keeps track of the different exercises to run.
		/// </summary>
		internal void HandleExercises() {
			// Infinite loop, so the user can interact with the menu after each exercise has run.
			while (true)
			{
				// Outputs basic user information, and accepts an int input value.
				view.OutputLine("Please write a number between 0 and 4");
				int userInput = view.NumberUserInput();

				// Checks the userInput value and runs the appropriate exercise.
				switch (userInput)
				{
					case 0:
						ExerciseZero();
						break;
					case 1:
						ExerciseOne();
						break;
					case 2:
						ExerciseTwo();
						break;
					case 3:
						ExerciseThree();
						break;
					case 4:
						ExerciseFour();
						break;
					default:
						continue;
				}

				Reset();
			}
		}

		/// <summary>
		/// This method is responsible for calling the ExerciseZero class.
		/// </summary>
		private void ExerciseZero()
		{
			// Specify the number of threads to run
			view.OutputLine("Write numbers of threads to use:");
			int userInput = view.NumberUserInput();
			sbyte totalThreads = (sbyte)Process.GetCurrentProcess().Threads.Count;
			if(userInput > totalThreads)
			{
				view.OutputLine($"You wrote a thread value, larger than your system can handle. \nYour thread count is {totalThreads}");
				return;
			}

			// Creates a new instance of the 0th exercise.
			ExerciseZero exerciseZero = new ExerciseZero();
			for (int i = 0; i < totalThreads; i++)
			{
				Thread thread = new Thread(new ThreadStart(exerciseZero.WorkThread));
				thread.Start();
				thread.Join();
			}
		}

		/// <summary>
		/// Creates an instance of the ExerciseOne class.
		/// Creates a new thread and starts it at RepeatMessage() with an string parameter.
		/// </summary>
		private void ExerciseOne()
		{
			ExerciseOne exerciseOne = new ExerciseOne();
			Thread thread = new Thread(() => exerciseOne.RepeatMessage("C# threading is easy!"));
			thread.Start();
			thread.Join();
		}

		/// <summary>
		/// Creates an instance of the ExerciseTwo class.
		/// Creates 2 threads, which both runs the RepeatMessage method, with a message string parameter.
		/// </summary>
		private void ExerciseTwo()
		{
			ExerciseTwo exerciseTwo = new ExerciseTwo();
			Thread threadOne = new Thread(() => exerciseTwo.RepeatMessage("C# threading is easy!"));
			Thread threadTwo = new Thread(() => exerciseTwo.RepeatMessage("Also with more threads!"));

			threadOne.Start();
			threadTwo.Start();

			threadOne.Join();
			threadTwo.Join();
		}

		/// <summary>
		/// Creates an instance of ExerciseThree.
		/// Runs the thread in the Start() method, inside of exerciseThree.
		/// If the thread is not running, then it outputs "Thread is dead!" and ends the exercise.
		/// </summary>
		private void ExerciseThree()
		{
			ExerciseThree exerciseThree = new ExerciseThree();
			Thread thread = new Thread(new ThreadStart(exerciseThree.Start));
			thread.Start();

			thread.Join();
			view.OutputLine("Thread is dead!");
		}

		/// <summary>
		/// Creates an instance of ExerciseFour.
		/// Runs 2 threads. One in the Writer() method, while the other is in the Reader() method.
		/// </summary>
		private void ExerciseFour()
		{
			ExerciseFour exerciseFour = new ExerciseFour();

			Thread writerThread = new Thread(new ThreadStart(exerciseFour.Writer));
			Thread readerThread = new Thread(new ThreadStart(exerciseFour.Reader));

			writerThread.Start();
			readerThread.Start();
		}

		/// <summary>
		/// The main thread sleeps for 1 second.
		/// Then the console is cleared and the text color is reset.
		/// </summary>
		private void Reset()
		{
			Thread.Sleep(1000);
			view.Clear();
		}
	}
}
