using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirds
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 9;
        int gravity = 5;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            PipeBottom.Left -= pipeSpeed;
            PipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score.ToString();

            if(PipeBottom.Left < -150)
            {
                PipeBottom.Left = 800;
                score++;
            }

            if(PipeTop.Left < -150)
            {
                PipeTop.Left = 950;
                score++;
            }

            if(Bird.Bounds.IntersectsWith(PipeBottom.Bounds) || 
                Bird.Bounds.IntersectsWith(PipeTop.Bounds) ||
                Bird.Bounds.IntersectsWith(ground.Bounds) 
                )
                {
                    endGame();
                }

            if(score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!";
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }
    }
}
