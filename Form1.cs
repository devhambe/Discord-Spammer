using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spammer
{
    public partial class Spammer : Form
    {
        public Spammer()
        {
            InitializeComponent();
        }

        private void TmrSpammer_Tick(object sender, EventArgs e)
        {
            int Interval = tbInterval.Value;
            tmrSpammer.Interval = Interval;
            SendKeys.Send(txtInput.Text);
            SendKeys.Send("{ENTER}");
        }

        private void TbInterval_Scroll(object sender, EventArgs e)
        {
            int tbInt = tbInterval.Value;
            nudInterval.Value = tbInt;
        }

        private void NudInterval_ValueChanged(object sender, EventArgs e)
        {
            int nudInt = Convert.ToInt32(nudInterval.Value);
            tbInterval.Value = nudInt;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            tmrSpammer.Start();
            lblStatus2.Text = "ON";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            tmrSpammer.Stop();
            lblStatus2.Text = "OFF";
        }

        private bool mouseDown;
        private Point lastLocation;

        private void PnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void PnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void PnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
