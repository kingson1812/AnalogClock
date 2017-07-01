using System;
using System.Windows;
using System.Windows.Input;
using System.Timers;
using System.Windows.Threading;

namespace AnalogClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer clockTimer;
        public MainWindow()
        {
            InitializeComponent();
            Source.MouseEventHandler.CreateInstance();

            RotateLongNeedle.Angle = DateTime.Now.Second * 6 - 90;
            RotateMediumNeedle.Angle = DateTime.Now.Minute * 6 - 90;
            RotateShortNeedle.Angle = DateTime.Now.Hour * 30 + DateTime.Now.Minute * 0.5 - 90;//1h = 30d + 1m = 0.5d

            clockTimer = new Timer();
            clockTimer.Interval = 10;
            clockTimer.Elapsed += ClockTimer_Elapsed;
            clockTimer.Start();
        }

        /// <summary>
        /// Calculate clock angles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Console.WriteLine("DateTime.Now " + DateTime.Now.Second);
                RotateLongNeedle.Angle = (DateTime.Now.Second-1) * 6 + ((double)DateTime.Now.Millisecond/1000.0d)*6 - 90;
                RotateMediumNeedle.Angle = DateTime.Now.Minute * 6 + DateTime.Now.Second * 0.1 - 90;
                RotateShortNeedle.Angle = DateTime.Now.Hour * 30 + DateTime.Now.Minute * 0.5 - 90;
            }));
        }

        /// <summary>
        /// Handle mouse input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageBlankClock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Source.MouseEventHandler.GetInstance().OnLeftClickDown();
            this.DragMove();
        }
    }
}
