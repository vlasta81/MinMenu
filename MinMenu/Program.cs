namespace MinMenu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string targetDirectory = args.Length > 0 ? args[0] : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Links");
            Point cursorPos = Cursor.Position;
            MinMenuForm form = new MinMenuForm(targetDirectory)
            {
                Location = cursorPos
            };
            Application.Run(form);
        }
    }
}