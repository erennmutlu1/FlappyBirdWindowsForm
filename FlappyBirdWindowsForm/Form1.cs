using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdWindowsForm
{
    public partial class Form1 : Form
    {
         int pipeSpeed = 8;
         int gravity = 5;
         int score = 0;
         bool life = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                   
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score = score + 5;
            }


            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score = score + 5;
            }


            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -15)
            {
                life = false;
                endGame();
                
            }



            if (score > 25)
            {
                pipeSpeed = 15;
            }

            if (score > 50)
            {
                pipeSpeed = 25;
            }

            if (score == 105)
            {
                winner();

            }

        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {

            if (!life  && e.KeyCode==Keys.E)
            {
                restart();

            }

            if (e.KeyCode==Keys.Space)
            {
                gravity = -10;

            }

        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;

            }

            
        }


        private void restart()
        {
            life = true;
            flappyBird.Top = 270;
            pipeSpeed = 8;
            gravity = 5;
            score = 0;
            gameTimer.Start();


        }

        private void endGame()
        {

           
            gameTimer.Stop();
            scoreText.Text += " Game Over!!! If You Want To Try Again Press E";




        }


        private void winner()
        {
            gameTimer.Stop();
            scoreText.Text += "  Congratulations You Won :* !!!!!";
         

        }

      
    }

  

   
}
