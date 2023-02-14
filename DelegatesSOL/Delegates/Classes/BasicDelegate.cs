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
			Log log = new Log();

			LogDel LogTextToScreenDel, LogTextToFileDel;

            LogTextToScreenDel = new LogDel(log.LogTextToScreen);

            LogTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;

            Console.WriteLine("Emter name");

			var name = Console.ReadLine();

			multiLogDel(name);

			Console.ReadKey();
        }

		static void LogTextToScreen(string text)
		{
            Console.WriteLine($"{DateTime.Now}: {text}");

        }
    }
}

public class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");

    }

	public void LogTextToFile(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.text"), true))
		{
			sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}


