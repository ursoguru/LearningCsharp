using System;
namespace Delegates.Classes
{
	public class BasicDelegate
	{
		delegate void LogDel(string text);
		public BasicDelegate()
		{
		}
        public void Run()
        {
			LogDel logDel = new LogDel(LogTextToScreen);

			Console.WriteLine("Emter name");

			var name = Console.ReadLine();

			logDel("text");

			Console.ReadKey();
        }

		static void LogTextToScreen(string text)
		{
            Console.WriteLine($"{DateTime.Now}: {text}");

        }
    }
}

