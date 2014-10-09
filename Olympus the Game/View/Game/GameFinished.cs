using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View.Game
{
    public partial class GameFinished : Form
    {
        public GameFinished()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        public GameFinished(FinishType type)
            : this()
        {
            int score = Scoreboard.Score;
            switch (type)
            {
                case FinishType.DEAD:
                    berichtLabel.Text = "Helaas, je bent dood gegaan! Wat wil je doen?";
                    break;
                case FinishType.CAKE:
                    berichtLabel.Text = "Gefeliciteerd! Je hebt gewonnen!";
                    break;
            }
            this.score.Text = string.Format("Score: {0}", score.ToString("D5"));
            bool first = true;
            StringBuilder builder = new StringBuilder();
            foreach (ScoreType scoreType in Enum.GetValues(typeof(ScoreType)))
            {
                int typeScore = Scoreboard.GetScore(scoreType);
                if (score != 0)
                {
                    if (!first)
                        builder.Append(Environment.NewLine);
                    builder.Append(scoreType.ToString() + ":" + typeScore);
                    first = false;
                }
            }
            this.ScoreDescr.Text = builder.ToString();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
