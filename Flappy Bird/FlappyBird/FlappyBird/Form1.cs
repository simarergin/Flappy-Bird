namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int boruHýzý = 8;
        int gravity = 0;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    gameTimer.Enabled = true;
        //}
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            BoruAlt.Left -= boruHýzý;
            BoruUst.Left -= boruHýzý;
            scoreText.Text = "Score: " + score;

            if (BoruAlt.Left<-150)
            {
                BoruAlt.Left = 800;
                score++;
            }
            if(BoruUst.Left<-180)
            {
                BoruUst.Left = 950;
                score++;
            }
            if(flappyBird.Bounds.IntersectsWith(BoruAlt.Bounds)||flappyBird.Bounds.IntersectsWith(BoruUst.Bounds)||flappyBird.Bounds.IntersectsWith(Zemin.Bounds))
            {
                endGame();
            }
            if(score>5)
            {
                boruHýzý = 12;
            }
            if(flappyBird.Top<-25)
            {
                endGame();    
            }
        }
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.Space)
            {
                labelTest.Text = "down";
                gravity = -10;
            }
        }
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                labelTest.Text = "up";
                gravity = 10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over!!!";
        }

    }
}