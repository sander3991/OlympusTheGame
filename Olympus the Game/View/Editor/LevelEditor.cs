using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Olympus_the_Game.View
{
    public partial class LevelEditor : Form
    {
        public PlayField CurrentPlayField { get; private set; }

        public LevelEditor()
            : this(new PlayField(1000, 500))
        { }

        public LevelEditor(PlayField pf)
        {
            InitializeComponent();

            // Save vars
            this.CurrentPlayField = pf;
            this.gamePanelEditor.Playfield = this.CurrentPlayField;
            this.speelveldEditor1.Playfield = this.CurrentPlayField;

            Utils.FullScreen(this, true);

            OlympusTheGame.Pause();
        }

        private void LevelEditor_Load(object sender, System.EventArgs e)
        {
            Mp3Player.PlaySelected();
            this.gamePanelEditor.TryExpand();

            // Register events
            this.entityEditor1.EntityChanged += this.gamePanelEditor.Invalidate;

            this.entityEditor1.LocationChanged += delegate(object source, EventArgs ea) { this.gamePanelEditor.TryExpand(); };
            this.entitySourcePanelList1.LocationChanged += delegate(object source, EventArgs ea) { this.gamePanelEditor.TryExpand(); };
            this.speelveldEditor1.LocationChanged += delegate(object source, EventArgs ea) { this.gamePanelEditor.TryExpand(); };
            this.SizeChanged += delegate(object source, EventArgs ea) { this.gamePanelEditor.TryExpand(); };

            // Focus op de gamePanel zodat de nummertoetsen werken
            gamePanelEditor.Select();

            // Start music
            Mp3Player.SetResource(DataPool.gameSound);
        }

        #region Drag and Drop

        #region Inpanel Drag and Drop

        /// <summary>
        /// Item dat momenteel wordt versleept.
        /// </summary>
        private GameObject currentDraggingObject = null;

        /// <summary>
        /// De offset van de muis ten opzicht van het momenteel gesleepte object.
        /// </summary>
        private Point offset = Point.Empty;

        /// <summary>
        /// Als muis naar beneden gaat, start slepen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_InPanel_Drag(object sender, MouseEventArgs e)
        {
            // Set current dragging object
            this.currentDraggingObject = gamePanelEditor.getObjectAtCursor();
            if (this.currentDraggingObject != null)
                this.offset = new Point(gamePanelEditor.getCursorPlayFieldPosition().X - this.currentDraggingObject.X, gamePanelEditor.getCursorPlayFieldPosition().Y - this.currentDraggingObject.Y);
        }

        /// <summary>
        /// Als er wordt gesleept, verplaats item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InPanel_Mouse_Move(object sender, MouseEventArgs e)
        {
            if (this.currentDraggingObject != null)
            {
                Point p = gamePanelEditor.getCursorPlayFieldPosition();
                this.currentDraggingObject.X = p.X - this.offset.X;
                this.currentDraggingObject.Y = p.Y - this.offset.Y;
                this.gamePanelEditor.Invalidate();
            }
        }

        /// <summary>
        /// Stop met slepen als muis omhoog gaat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_InPanel_Drag(object sender, MouseEventArgs e)
        {
            if (this.currentDraggingObject != null)
            {
                this.currentDraggingObject = null;
            }
        }

        #endregion

        /// <summary>
        /// Zodra een entiteit in het panel word gesleept word bekeken of deze van het type string is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ObjectType)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Weergeef de locatie waar het object geplaatst is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drag_drop(object sender, DragEventArgs e)
        {
            // Get relative location
            /*Point l = this.gamePanelEditor.PointToClient(new Point(e.X, e.Y));
            l = new Point((int)((double)l.X / this.gamePanelEditor.SCALE), (int)((double)l.Y / this.gamePanelEditor.SCALE));*/
            Point l = gamePanelEditor.getCursorPlayFieldPosition();
            object o = e.Data.GetData(typeof(ObjectType));
            if (o == null) return;
            ObjectType ot = (ObjectType)o;

            // Add object
            Func<GameObject> f = null;
            GameObject.ConstructorList.TryGetValue(ot, out f);

            if (f != null)
            {
                GameObject g = f();
                g.X = l.X;
                g.Y = l.Y;
                CurrentPlayField.AddObject(g);
            }
            this.gamePanelEditor.Invalidate();
        }

        #endregion

        #region Remove

        /// <summary>
        /// Als er op de muis wordt geklikt wordt deze methode aangeroepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Clicked(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    gamePanelEditor.Playfield.GameObjects.Remove(gamePanelEditor.getObjectAtCursor());
                    this.gamePanelEditor.Invalidate();
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Sla .xml bestand op
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Opslaan_Click(object sender, EventArgs e)
        {
            System.IO.Stream fileStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Weergeef .xml bestanden in eerste instantie
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            // Als er op OK is geklikt
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // en er is een naam ingevoerd
                if ((fileStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Slaat het playfield op
                    PlayFieldToXml.WriteToXml(fileStream, CurrentPlayField);
                }
            }
        }

        /// <summary>
        /// Open .xml bestand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inladen_Click(object sender, EventArgs e)
        {
            System.IO.Stream fileStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            // als er op OK word gedrukt
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // en er is een bestand geselecteerd
                if ((fileStream = openFileDialog1.OpenFile()) != null)
                {
                    this.CurrentPlayField = PlayFieldToXml.ReadFromXml(fileStream);
                    this.gamePanelEditor.Playfield = this.CurrentPlayField;
                    this.gamePanelEditor.Invalidate();
                }
            }
        }

        /// <summary>
        /// Sluit het LevelEditor scherm af
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Afsluiten_Click(object sender, EventArgs e)
        {
            this.Close();
            Mp3Player.StopPlaying();
        }

        /// <summary>
        /// Vraagscherm bij afsluiten
        /// Zorgt ook ervoor dat alle objecten netjes verwijderd worden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            // Opent dialoog voor sluiten
            DialogResult dr = MessageBox.Show("Are you sure you want to exit the leveleditor? Any unsaved data will be lost.",
                "Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Sluit spel af bij JA/YES
            // Sluit dialoog af bij NEE/NO en laat spel verder draaien
            if (dr != DialogResult.Yes)
                e.Cancel = true;
            else
            {
                Utils.ShowMask(true);
                new Thread(delegate() { Utils.ShowMask(false); }).Start();
            }
        }

        /// <summary>
        /// Bij een dubbelklik word gekeken waarop is geklikt, vervolgens word
        /// dit doorgestuurd naar de EntityEdit in de LevelEditor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_DoubleClick(object sender, EventArgs e)
        {
            GameObject go = this.gamePanelEditor.getObjectAtCursor();
            this.entityEditor1.LoadData(go);
        }

        private void ApplyPlayfieldChanges()
        {
            PlayField newPF = new PlayField(speelveldEditor1.EnteredSize.Width, speelveldEditor1.EnteredSize.Height);
            newPF.InitializeGameObjects(gamePanelEditor.Playfield.GameObjects);
            gamePanelEditor.Playfield = newPF;
            speelveldEditor1.Playfield = newPF;
        }

        /// <summary>
        /// Plaats entities in het veld door de nummertoetsen 1 tot en met 7 te gebruiken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaatsEntity(object sender, KeyPressEventArgs e)
        {

            // Creeper
            if (e.KeyChar == (char)Keys.D1)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.CurrentPlayField.AddObject(new EntityCreeper(50, 50, pointer.X, pointer.Y, 1.0f));
                this.gamePanelEditor.Invalidate();
            }

            // Spider
            else if (e.KeyChar == (char)Keys.D2)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.CurrentPlayField.AddObject(new EntitySlower(50, 50, pointer.X, pointer.Y, 2, 2));
                this.gamePanelEditor.Invalidate();
            }

            // TnT
            else if (e.KeyChar == (char)Keys.D3)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.CurrentPlayField.AddObject(new EntityExplode(50, 50, pointer.X, pointer.Y, 1.0f));
                this.gamePanelEditor.Invalidate();
            }

            // TimeBomb
            else if (e.KeyChar == (char)Keys.D4)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.CurrentPlayField.AddObject(new EntityTimeBomb(50, 50, pointer.X, pointer.Y, 1.0f));
                this.gamePanelEditor.Invalidate();
            }

            // Cake
            else if (e.KeyChar == (char)Keys.D5)
            {
                this.CurrentPlayField.GameObjects.RemoveAll((p) => { return p.GetType() == typeof(ObjectFinish); });
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.CurrentPlayField.AddObject(new ObjectFinish(50, 50, pointer.X, pointer.Y));
                this.gamePanelEditor.Invalidate();
            }

            // Home
            else if (e.KeyChar == (char)Keys.D6)
            {
                this.CurrentPlayField.GameObjects.RemoveAll((p) => { return p.GetType() == typeof(ObjectStart); });
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.CurrentPlayField.AddObject(new ObjectStart(50, 50, pointer.X, pointer.Y));
                this.gamePanelEditor.Invalidate();
            }

            // Obstakel
            else if (e.KeyChar == (char)Keys.D7)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.CurrentPlayField.AddObject(new ObjectObstacle(50, 50, pointer.X, pointer.Y));
                this.gamePanelEditor.Invalidate();
            }
        }
    }
}
