using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.ServiceProcess;
using System.Timers;
using System.Windows.Forms;

namespace ScreenService
{
    public partial class ScreenCervice : ServiceBase
    {
        private System.Timers.Timer timer = null;

        public ScreenCervice()
        {
            InitializeComponent();

            timer = new System.Timers.Timer(30000);//создаём объект таймера 
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Domain.Methods.GetScreen();
            }
            catch(Exception ex)
            { }
        }

        

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        
    }
}
