using SurfShark;
using SurfShark.Core;
using System;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public class Program
    {
        public static NotifyIcon Notifier { get; private set; }
        public static bool isdebug = true;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            new MainComponent();
            Application.Run();
            return;
            try
            {

                Forms.login = new LoginDialog();
                Forms.main = new CoreSystem();
                Forms.surf = new MainProgram();
                Forms.util = new UrlUtilityForm();
                Forms.chat = new ChatWindow();

                Notifier = new NotifyIcon
                {
                    Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
                };
                Notifier.ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Show", (s, e) => {
                        Forms.main.WindowState = FormWindowState.Normal;
                    }),
                    new MenuItem("Exit", (s, e) => {
                        Notifier.Visible = false;
                        Notifier.Dispose();
                        Application.Exit();
                        Environment.Exit(0);
                    }),
                });
                Notifier.DoubleClick += new EventHandler(NotifyIcon1_DoubleClick);
                Notifier.Visible = true;

                Notifier.BalloonTipIcon = ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                Notifier.BalloonTipText = "Hello, I am your friendly neighborhood traffic Shark. If you need me just double click this icon.";
                Notifier.BalloonTipTitle = "Games-Sharks.com's Traffic Tool.";
                Notifier.Text = "Games-Sharks.com's Traffic Tool.";
                Notifier.ShowBalloonTip(500);
                Notifier.Visible = true;
                if (args.Length > 0 || isdebug)
                {
                    Application.Run();
                }
                else
                {
                    Notifier.Visible = false;
                    Notifier.Dispose();
                    Application.Exit();
                    Environment.Exit(0);
                }
                Notifier.Visible = false;
            }
            catch (Exception)
            {
                Notifier.Visible = false;
                Notifier.Dispose();
                Application.Exit();
                Environment.Exit(0);
            }
        }
        private static void NotifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            CoreSystem.Resize_window();
        }
        public static void DisposeIcon()
        {
            try
            {
                Program.Notifier.Visible = false;
                Program.Notifier.Dispose();
            }
            catch (Exception) { }

        }

    }
}
