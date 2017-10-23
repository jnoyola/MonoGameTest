using Foundation;
using System.Diagnostics;
using UIKit;

namespace MonoGameTest
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(myWriter);
            UIApplication.Main(args, null, "AppDelegate");
        }
        
        public override void FinishedLaunching(UIApplication app)
        {
            var game = new MonoGameTest();
            game.Run();
        }
    }
}