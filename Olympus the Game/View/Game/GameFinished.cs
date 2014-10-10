using System;
using System.Text;
using System.Windows.Forms;
using Olympus_the_Game.Controller;

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
            int currentScore = Scoreboard.Score;
            switch (type)
            {
                case FinishType.Dead:
                    berichtLabel.Text = "Helaas, je bent dood gegaan! Wat wil je doen?";
                    break;
                case FinishType.Cake:
                    berichtLabel.Text = "Gefeliciteerd! Je hebt gewonnen!";
                    break;
            }
            score.Text = string.Format("Score: {0}", currentScore.ToString("D5"));
            bool first = true;
            StringBuilder builder = new StringBuilder();
            foreach (ScoreType scoreType in Enum.GetValues(typeof (ScoreType)))
            {
                int typeScore = Scoreboard.GetScore(scoreType);
                if (currentScore != 0)
                {
                    if (!first)
                        builder.Append(Environment.NewLine);
                    builder.Append(scoreType + ":" + typeScore);
                    first = false;
                }
            }
            ScoreDescr.Text = builder.ToString();
        }
    }
}