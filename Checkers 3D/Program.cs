using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Checkers.Direct3D;
using BoardGame;

namespace Checkers
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
    }
}