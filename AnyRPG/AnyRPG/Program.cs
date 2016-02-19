using System;

namespace AnyRPG
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            UserInfo c;
            using (c = new UserInfo())
            {
                c.ShowDialog();
                
            }

            
            using (Game1 game = new Game1(c.CPlayer))
            {
                game.Run();
            }
             
        }
    }
#endif
}

