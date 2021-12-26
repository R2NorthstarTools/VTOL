namespace Northstar_Manger
{
    internal static class Mod_Manager_Main
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
    
        static void Main()
        {
           
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());

        }
    }
}