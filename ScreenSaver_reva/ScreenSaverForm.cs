using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver_reva
{
    public partial class ScreenSaverForm : Form
    {
        int speed = -5;
      

        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Size = new Size(Bounds.Width, Bounds.Height);
            this.Bounds = Bounds;
        }
        /*
        public pictureBox1(Rectangle Bounds)
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Bounds = Bounds;
        }
        */


        private Point mouseLocation;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                    Math.Abs(mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }

            // Update current mouse location
            mouseLocation = e.Location;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        
        private void pictureBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }
        

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
          

            moveTimer.Tick += new EventHandler(moveTimer_Tick);
            
            

            moveTimer.Start();
        }

        private void moveTimer_Tick(object sender, System.EventArgs e) {
            Random r = new Random();
            pictureBox1.Location = new Point(pictureBox1.Location.X + speed, pictureBox1.Location.Y);
            //Console.WriteLine(pictureBox1.Location.X);
            if (pictureBox1.Location.X < -55)
            {
                speed = 5;

                moveTimer.Interval = 5000;
            }
            else if (pictureBox1.Location.X > 55)
            {
                speed = -5;

                moveTimer.Interval = 5000;
            }
            else if (pictureBox1.Location.X == 0)
            {
                moveTimer.Interval = 9000;
            }
            else
            {
                moveTimer.Interval = 30;
            }

            /*
             for (int i=1;i<10;i++){
                 System.Threading.Thread.Sleep(30);
                 Console.WriteLine("minus");
             }
             for (int i = 1; i < 10; i++)
             {
                 System.Threading.Thread.Sleep(30);
                 pictureBox1.Location = new Point(pictureBox1.Location.X + 3, pictureBox1.Location.Y);
                 Console.WriteLine("plus");
             }
             */
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
