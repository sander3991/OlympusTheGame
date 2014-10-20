using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model;
using Olympus_the_Game.Properties;

namespace Olympus_the_Game.View.Menu
{
    public partial class LevelDialog : UserControl
    {
        //Callback voor dingen die buiten deze thread verzoeken tot het aanpassen van de buttons

        /// <summary>
        ///     Met deze method kan een Button aangeven hoe de Playfield gemaakt moet worden
        /// </summary>
        /// <returns>Het Playfield</returns>
        public delegate PlayField GetPlayField();

        /// <summary>
        ///     Delegate voor het LevelChosen event, zo weet MainMenu dat wij een menu gekozen hebben.
        /// </summary>
        /// <param name="pf">Het Playfield dat gekozen is</param>
        public delegate void PlayFieldChosen(PlayField pf);

        private const int MAXBUTTONS = 6; //Het aantal knoppen dat maximaal zichtbaar zijn

        private readonly Dictionary<Button, GetPlayField> buttons;
            //Hierin wordt opgeslagen hoe deze button opgehalad wordt dmv de GetPlayField delegate

        private int _propScrollLoc;

        public LevelDialog()
        {
            InitializeComponent();
            buttons = new Dictionary<Button, GetPlayField>();

            //Initialiseer de built-in playfields
            Button b = CreateLevelButton();
            b.Text = "Hell";
            buttons.Add(b, () => PlayfieldLoader.ReadFromResource(Resources.mapHell));

            b = CreateLevelButton();
            b.Text = "Beach";
            buttons.Add(b, () => PlayfieldLoader.ReadFromResource(Resources.mapBeach));

            b = CreateLevelButton();
            b.Text = "Gallifrey falls no more";
            buttons.Add(b, () => PlayfieldLoader.ReadFromResource(Resources.mapGallifrey));

            b = CreateLevelButton();
            b.Text = "Eet geen worst";
            buttons.Add(b, () => PlayfieldLoader.ReadFromResource(Resources.mapWorst));

            b = CreateLevelButton();
            b.Text = "Crunchy Sausage";
            buttons.Add(b, () => PlayfieldLoader.ReadFromResource(Resources.mapSausage));

            b = CreateLevelButton();
            b.Text = "Spicy Potato Tomato";
            buttons.Add(b, () => PlayfieldLoader.ReadFromResource(Resources.mapTomato));

            //Initialiseer de custom maps
            foreach (string mapName in PlayfieldLoader.CustomMaps)
                AddCustomLevelButton(mapName);
            ScrollLoc = 0;
            PlayfieldLoader.OnCustomMapAdded += ThreadSafeAddLevelButton;
            PlayfieldLoader.OnCustomMapRemoved += ThreadSafeRemoveLevelButton;

            MouseWheel += LevelDialog_MouseWheel;
            VisibleChanged += delegate { if (Visible) Focus(); };
                //Als wij zichtbaar zijn focusen we op dit onderdeel zodat wij kunnen scrollen.
        }

        private int ScrollLoc
        {
            get { return _propScrollLoc; }
            set
            {
                if (value >= 0 && (value + MAXBUTTONS) <= buttons.Count && value != _propScrollLoc)
                {
                    _propScrollLoc = value;
                    RepositionButtons();
                }
                ScrollArrowUp.Visible = _propScrollLoc > 0;
                ScrollArrowDown.Visible = (_propScrollLoc + 6) < buttons.Count;
            }
        }

        /// <summary>
        ///     Scrollen door het menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelDialog_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ScrollLoc--;
            else if (e.Delta < 0)
                ScrollLoc++;
        }

        /// <summary>
        ///     Als wij een menu gekozen hebben, zal dit event aangeroepen worden met het gekozen menu
        /// </summary>
        public event PlayFieldChosen LevelChosen;

        /// <summary>
        ///     Voegt een custom level button toe
        /// </summary>
        /// <param name="mapName">De mapnaam van de custom button</param>
        private void AddCustomLevelButton(string mapName)
        {
            Button b = CreateLevelButton();
            b.Text = mapName;
            buttons.Add(b, () => PlayfieldLoader.LoadCustomMap(mapName));
            ScrollLoc = ScrollLoc;
        }

        /// <summary>
        ///     Maakt een standaard Button geschikt voor in het menu.
        /// </summary>
        /// <returns>De gemaakte Button</returns>
        private Button CreateLevelButton()
        {
            var b = new Button();
            b.Size = new Size(Width - 6, 45);
            b.BackgroundImage = Resources.stone;
            b.Location = new Point(3, 53 + buttons.Count*50);
            b.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            b.ForeColor = Color.Black;
            b.Click += ButtonClick;
            Controls.Add(b);
            if (buttons.Count >= 6) //Er zijn al 6 buttons dus deze kan niet meer zichtbaar zijn!
                b.Visible = false;
            return b;
        }

        /// <summary>
        ///     Verwijderd een button die hoort bij de in de parameter genoemde map
        /// </summary>
        /// <param name="mapName">De naam van de map die verwijderd moet worden</param>
        private void RemoveCustomLevelButton(string mapName)
        {
            foreach (Button b in buttons.Keys)
                if (b.Text == mapName)
                {
                    Controls.Remove(b);
                    buttons.Remove(b);
                    break;
                }
            if (ScrollLoc != 0 && (ScrollLoc + MAXBUTTONS) > buttons.Count)
                ScrollLoc--;
            else
                RepositionButtons(); //Dit wordt al gedaan in ScrollLoc als we deze verminderen
        }

        /// <summary>
        ///     We gebruiken deze method om ervoor te zorgen dat het toevoegen van deze buttons op onze thread gebeurd. En niet een
        ///     WorkerThread
        /// </summary>
        /// <param name="mapName">De mapnaam van de toe te voegen level button</param>
        /// <param name="fileLocation">De file locatie van de toe te voegen button</param>
        private void ThreadSafeAddLevelButton(string mapName, string fileLocation)
        {
            if (InvokeRequired)
            {
                MapCallback d = AddCustomLevelButton;
                Invoke(d, new object[] {mapName});
                    //Hiermee invoken we de thread waarin deze control is aangemaakt zodat wij het veilig toe kunnen voegen
            }
            else
                AddCustomLevelButton(mapName);
        }

        /// <summary>
        ///     We gebruiken deze method om ervoor te zorgen dat het verwijderen van deze buttons op onze thread gebeurd. En niet
        ///     een WorkerThread
        /// </summary>
        /// <param name="mapName">De mapnaam van de toe te voegen level button</param>
        /// <param name="fileLocation">De file locatie van de toe te voegen button</param>
        private void ThreadSafeRemoveLevelButton(string mapName, string fileLocation)
        {
            if (InvokeRequired)
            {
                MapCallback d = RemoveCustomLevelButton;
                Invoke(d, new object[] {mapName});
                    //Hiermee invoken we de thread waarin deze control is aangemaakt zodat wij het veilig toe kunnen voegen
            }
            else
                RemoveCustomLevelButton(mapName);
        }

        /// <summary>
        ///     Bij het klikken van een button wordt in de dictionary gekeken welke delegate er aangeroepen moet worden om een
        ///     PlayField op te vragen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
                if (buttons.ContainsKey(b))
                    LevelChosen(buttons[b]());
        }

        /// <summary>
        ///     Bij het klikken op het boven pijltje wordt de scroll locatie 1tje terug gezet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollArrowUp_Click(object sender, EventArgs e)
        {
            ScrollLoc--;
        }

        /// <summary>
        ///     Bij het klikken op het beneden pijltje wordt de scroll locatie 1tje verder gezet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollArrowDown_Click(object sender, EventArgs e)
        {
            ScrollLoc++;
        }

        /// <summary>
        ///     Deze method zorgt ervoor dat alle buttons op de juiste locatie in het menu staan
        /// </summary>
        private void RepositionButtons()
        {
            int counter = 0;
            foreach (Button b in buttons.Keys)
                //de enumerator gaat op volgorde van wanneer deze is toegevoegd aan de Dictionary.
            {
                if (counter < ScrollLoc || counter >= (ScrollLoc + MAXBUTTONS))
                    b.Visible = false;
                else
                {
                    Point loc = b.Location;
                    loc.Y = (counter - ScrollLoc)*50 + 50;
                    b.Location = loc;
                    b.Visible = true;
                }
                counter++;
            }
            Invalidate();
        }

        private delegate void MapCallback(string mapName);
    }
}