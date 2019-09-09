using SurfShark.Core;
using System;
using System.Windows.Forms;


namespace SurfShark
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainComponent());
        }
    }
}
