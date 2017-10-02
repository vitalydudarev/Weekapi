using System;

namespace Weekapi
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("No handler name/arguments passed.");
				return;
			}

			var handler = args[0];
			var arguments = new string[args.Length - 1];

			for (int i = 1; i < args.Length; i++)
				arguments[i - 1] = args[i];
			
			CommandExecutor.Run(handler, arguments);
		}
	}
}
