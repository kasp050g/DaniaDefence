using System;
using System.Diagnostics;
using System.Globalization;

namespace Dania_Defence_Project
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Debugger.IsAttached)
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            using (var game = new GameWorld())
                game.Run();
        }
    }
#endif
}
