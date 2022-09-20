using System.Media;

namespace TicTacToe_WinForms
{
    public partial class Form1 : Form
    {
        int round = 0; // 9 = tie;
        int turn = 1;  //X positive, O negative, 0 = empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe V1.0 \nMade by Biggie Cheese", "Tic Tac Toe About");
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            round++;

            SoundPlayer splayer = new SoundPlayer(Resource.end);
            splayer.Play();

            if (turn > 0){
                b.Text = "X";
                b.BackColor = Color.LightBlue;
            }
            else if(turn < 0){
                b.Text = "O";
                b.BackColor = Color.Crimson;
            }
            checkWinner();
            turn = turn *(-1);
        }

        private void checkWinner(){
            bool hasWinner = false;

            //horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                hasWinner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                hasWinner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                hasWinner = true;


            //vertical check
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                hasWinner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                hasWinner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                hasWinner = true;


            //diagonal check
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                hasWinner = true;
            if ((C1.Text == B2.Text) && (B2.Text == A3.Text) && (!C1.Enabled))
                hasWinner = true;

            if (hasWinner || round == 9)
            {
                disableButtons();
                //relative path of a file or add file to resource
                SoundPlayer splayer1 = new SoundPlayer(Resource.coolsound);
                splayer1.Play();

                if (turn > 0)
                    MessageBox.Show("Winner is X!");
                else if (turn < 0)
                    MessageBox.Show("Winner is O!");
                else if (round == 9)
                    MessageBox.Show("Tie!");
            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer splayer2 = new SoundPlayer(Resource.newgame);
            splayer2.Play();

            turn = 1;
            round = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.BackColor = Color.White;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}