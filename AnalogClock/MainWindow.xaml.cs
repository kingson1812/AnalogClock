using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Timers;
using System.Windows.Media.Animation;
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
            RotateMediumNeedle.Angle = DateTime.Now.Minute * 6 -90;
            RotateShortNeedle.Angle = DateTime.Now.Hour * 30 + DateTime.Now.Minute * 0.5 - 90;//1h = 30d + 1m = 0.5d

            clockTimer = new Timer();
            clockTimer.Interval = 10;
            clockTimer.Elapsed += ClockTimer_Elapsed;
            clockTimer.Start();
        }

        private void ClockTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
           
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                //Console.WriteLine(CanvasMediumClockNeedle.Width + " " + CanvasMediumClockNeedle.Height);
                RotateLongNeedle.Angle = DateTime.Now.Second * 6 - 90;
                RotateMediumNeedle.Angle = DateTime.Now.Minute * 6 - 90;
                RotateShortNeedle.Angle = DateTime.Now.Hour * 30 + DateTime.Now.Minute * 0.5 - 90;

                //RotateLongNeedle.Angle += 1;// DateTime.Now.Second * 6 - 90;
                //RotateMediumNeedle.Angle += 1;// DateTime.Now.Minute * 6 - 90;
                //RotateShortNeedle.Angle += 1;// DateTime.Now.Hour * 30 + DateTime.Now.Minute * 0.5 - 90;
            }));
        }

        private void ImageBlankClock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Source.MouseEventHandler.GetInstance().OnLeftClickDown();
            this.DragMove();
        }
    }
}
