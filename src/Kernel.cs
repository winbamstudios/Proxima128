using Mirage;
using System;
using System.Security.Cryptography.X509Certificates;
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
        public static int userHeight;
        public static int userWidth;
        protected override void BeforeRun()
        {
            Console.Write("Please enter screen width: ");
            try
            {
                userWidth = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid number, default 800 used.");
                userWidth = 800;
            }
            Console.Write("Please enter screen height: ");
            try
            {
                userHeight = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid number, default 600 used.");
                userHeight = 600;
            }

            Console.WriteLine("Starting Proxima128...");
            Mirage.DE.DesktopEnvironment.Start("Proxima128", "0.60");
        }

        protected override void Run()
        {
        }
    }
}
