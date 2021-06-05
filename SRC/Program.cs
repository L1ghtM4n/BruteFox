/*
     Project > Mozilla Bruteforcer
     Author > github.com/L1ghtM4n
*/

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FFBruteforcer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #if DEBUG
                TraceListener[] listeners = new TraceListener[] { new TextWriterTraceListener(Console.Out) };
                Debug.Listeners.AddRange(listeners);
            #endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(args.Length > 0 ? new MainForm(args[0]) : new MainForm());
        }
    }
}
