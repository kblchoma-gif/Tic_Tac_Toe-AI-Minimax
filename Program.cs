using System;
using System.Windows.Forms;

namespace TicTacToeAI_WinForms
{
    static class Program
    {
        // Main entry point of the application
        [STAThread] // Required for Windows Forms to use COM-based features like clipboard, drag/drop, etc.
        static void Main()
        {
            // Enables visual styles for controls (e.g., modern button rendering)
            Application.EnableVisualStyles();

            // Uses compatible text rendering for legacy compatibility (generally set to false for modern apps)
            Application.SetCompatibleTextRenderingDefault(false);

            // Starts the application by launching the main form
            Application.Run(new MainForm());
        }
    }
}
