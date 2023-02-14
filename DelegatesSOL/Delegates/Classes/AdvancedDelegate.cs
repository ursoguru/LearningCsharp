using System;
namespace Delegates.Classes
{
	public class AdvancedDelegate
	{
		delegate void LogDel(string text);
		public AdvancedDelegate()
		{
		}
        public void Run()
        {
			LogA log = new LogA();

			LogDel LogTextToScreenDel, LogTextToFileDel;

            LogTextToScreenDel = new LogDel(log.LogTextToScreen);

            LogTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;

            Console.WriteLine("Emter name: ADVANCED:");

			var name = Console.ReadLine();

			LogText(multiLogDel, name);

			Console.ReadKey();
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }

     /*   static void LogTextToScreen(string text)
		{
            Console.WriteLine($"{DateTime.Now}: {text}");

        } */
    }


    public class LogA
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
    
}



