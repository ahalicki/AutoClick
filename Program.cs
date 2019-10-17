using System;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Threading;
using static AutoClick.Win32Interops;
using System.Threading.Tasks;

namespace AutoClick
{
    /// <summary>
    /// A simple program with the purpose being to force a UI mouse click 
    /// (single or double) at an interval specified by the user. 
    /// I use this personally as a hack for infinitely looping movie tracks
    /// by forcing mouse clicks on the track bar to reset it.
    /// </summary>
    class AutoClickProgram
    {
        #region Private Members

        private static double mWaitMinutes;
        private static Point mClickCoordinates;
        private static ClickType mClickType = ClickType.Single;

        #endregion

        private static void Main()
        {
            InitializeSettings();

            // Convert minutes to milliseconds.
            double minutesAsMilliseconds = (mWaitMinutes * 60000);

            // Run an infinite background thread to listen for keystrokes and draw on desktop.
           Task.Run(Thread_PerformBackgroundWork);

            // Start a timer to perform clicks at set location every set minutes.
            StartTimer(minutesAsMilliseconds);

            // Display instructions for the user.
            DisplayInstructions(minutesAsMilliseconds);

            // Uncomment to hide console window if desired. 
            // However, this currently leaves no options for "ending" 
            // the program for the user.
            //HideConsoleWindow();

            Thread.Sleep(Timeout.Infinite);
        }

        private static void DisplayInstructions(double minutesAsMilliseconds)
        {
            // Stringify output
            var timespan = TimeSpan.FromMilliseconds(minutesAsMilliseconds);
            var displayTime = timespan.TotalMinutes < 1 ? 
                                    timespan.TotalSeconds.ToString() + " seconds" :
                                    timespan.TotalMinutes == 1 ?
                                    timespan.TotalMinutes.ToString() + " minute" :
                                    timespan.TotalMinutes.ToString() + " minutes";

            var clickTypeName = Enum.GetName(typeof(ClickType), mClickType);

            Console.WriteLine($"Program Running...You may minimize this screen.{Environment.NewLine}" +
                              $"(Close screen to end program.)");

            Console.WriteLine($"\nPerforming {clickTypeName} mouse click every {displayTime} at {mClickCoordinates.ToString()}.");

            Console.WriteLine($"{Environment.NewLine}To set a new click area, move the mouse over a spot and" +
                              $"{Environment.NewLine}press UP ARROW on your keyboard.");

            Console.WriteLine($"{Environment.NewLine}To determine area coordinates, move the mouse over a spot and" +
                              $"{Environment.NewLine}press DOWN ARROW on your keyboard.");
        }

        #region Private Methods

        private static void InitializeSettings()
        {
            // Gather app settings using a user form.
            using (var form = new SettingsForm())
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();

                if (!form.Confirmed)
                {
                    // The user canceled the application.
                    Environment.Exit(0);
                }

                mWaitMinutes = Convert.ToDouble(form.WaitMinutes);
                mClickCoordinates = form.ClickLocation;
                mClickType = form.ClickType;
            }
        }

        private static void Thread_PerformBackgroundWork()
        {
            // Keep looping to read for user input.
            while (true)
            {
                var key = Console.ReadKey(intercept: false);

                if (key.Key == ConsoleKey.DownArrow)
                {
                    // Draw coordinates on down arrow press.
                    DrawCoordinates(Cursor.Position);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    // Record a new mouse click location on up arrow press.
                    var clickLocation = new Point(Cursor.Position.X, Cursor.Position.Y);
                    mClickCoordinates = clickLocation;

                    MessageBox.Show($"Click spot recorded at ({clickLocation.X}, {clickLocation.Y}).\n\n" +
                                    $"Clicking here from now on.");
                }
            }
        }

        private static void StartTimer(double ElapseTime)
        {
            var timer = new System.Timers.Timer(ElapseTime);
            timer.Elapsed += (s, e) => DoMouseClick(mClickCoordinates);
            timer.Start();
        }

        private static void DoMouseClick(Point location)
        {
            var pt = location == null ?
                    new Point(200, 855) :
                    location;

            Cursor.Position = pt;
            DrawCoordinates(pt);

            if (mClickType == ClickType.Single)
            {
                //single click.
                mouse_event((int)(MouseEventFlags.LEFTDOWN), pt.X, pt.Y, 0, 0);
                mouse_event((int)(MouseEventFlags.LEFTUP), pt.X, pt.Y, 0, 0);
            }
            else
            {
                //double click.
                mouse_event((int)(MouseEventFlags.LEFTDOWN), pt.X, pt.Y, 0, 0);
                mouse_event((int)(MouseEventFlags.LEFTUP), pt.X, pt.Y, 0, 0);
                mouse_event((int)(MouseEventFlags.LEFTDOWN), pt.X, pt.Y, 0, 0);
                mouse_event((int)(MouseEventFlags.LEFTUP), pt.X, pt.Y, 0, 0);
            }
        }

        private static void DrawCoordinates(Point pt)
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                g.DrawString("point:" + pt.X + " " + pt.Y, 
                    new Font("Arial", 24), 
                    new SolidBrush(Color.Red), pt.X, pt.Y);
            } 
        }

        /// <summary>
        /// Hides the console window.
        /// </summary>
        private static void HideConsoleWindow()
        {
            var hWnd = System.Diagnostics.Process.GetCurrentProcess()
                                                 .MainWindowHandle;

            // Protect against hiding the main window
            // on accident.
            if (hWnd != IntPtr.Zero)
            {
                // Hide the window.
                Win32Interops.ShowWindow(hWnd, 0); // (0 = SW_HIDE in win32 messages).
            }
        }

        #endregion
    }
}
