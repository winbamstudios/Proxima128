using Mirage;
/*
 *  This file is part of the Mirage Desktop Environment and Proxima128.
 *  github.com/mirage-desktop/Mirage
 *  
 *  Proxima128 version 0.30
 */
namespace Proxima128
{
    public class Kernel : Cosmos.System.Kernel
    {
        protected override void BeforeRun()
        {
            System.Console.WriteLine("Starting Proxima128...");
            Mirage.DE.DesktopEnvironment.Start("Proxima128", "0.41");
        }

        protected override void Run()
        {
        }
    }
}
