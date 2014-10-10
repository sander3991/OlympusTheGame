using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model;
using Olympus_the_Game.Model.Entities;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game.View.Editor
{
    public partial class LevelEditor : Form
    {
        public LevelEditor()
            : this(new PlayField(1000, 500))
        {
        }

        public LevelEditor(PlayField pf)
        {
            InitializeComponent();

            // Save vars
            CurrentPlayField = pf;
            gamePanelEditor.Playfield = CurrentPlayField;
            speelveldEditor1.Playfield = CurrentPlayField;

            Utils.FullScreen(this, true);

            OlympusTheGame.Pause();
        }

        public PlayField CurrentPlayField { get; private set; }

        private void LevelEditor_Load(object sender, EventArgs e)
        {
            Mp3Player.PlaySelected();
            gamePanelEditor.TryExpand();

            // Register events
            entityEditor1.EntityChanged += gamePanelEditor.Invalidate;

            entityEditor1.LocationChanged += delegate { gamePanelEditor.TryExpand(); };
            entitySourcePanelList1.LocationChanged += delegate { gamePanelEditor.TryExpand(); };
            speelveldEditor1.LocationChanged += delegate { gamePanelEditor.TryExpand(); };
            SizeChanged += delegate { gamePanelEditor.TryExpand(); };

            // Focus op de gamePanel zodat de nummertoetsen werken
            gamePanelEditor.Select();

            // Start music
            Mp3Player.SetResource(DataPool.gameSound);
        }

        /// <summary>
        /// Sla .xml bestand op
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Opslaan_Click(object sender, EventArgs e)
        {
            Stream fileStream;
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
            Stream fileStream;
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
                    CurrentPlayField = PlayFieldToXml.ReadFromXml(fileStream);
                    gamePanelEditor.Playfield = CurrentPlayField;
                    gamePanelEditor.Invalidate();
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
            Close();
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
            DialogResult dr =
                MessageBox.Show("Are you sure you want to exit the leveleditor? Any unsaved data will be lost.",
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
            GameObject go = gamePanelEditor.getObjectAtCursor();
            entityEditor1.LoadData(go);
        }

        private void ApplyPlayfieldChanges()
        {
            PlayField playfield = gamePanelEditor.Playfield;
            if (playfield == null)
                playfield = new PlayField(speelveldEditor1.EnteredSize.Width, speelveldEditor1.EnteredSize.Height);
            playfield.Width = speelveldEditor1.EnteredSize.Width;
            playfield.Height = speelveldEditor1.EnteredSize.Height;
            gamePanelEditor.Playfield = playfield;
            gamePanelEditor.Invalidate();
            speelveldEditor1.Playfield = playfield;
            foreach (GameObject o in playfield.GameObjects)
            {
                o.X = o.X; //De setters van de GameObject handelen af of ze in bounds zijn
                o.Y = o.Y; //De setters van de GameObject handelen af of ze in bounds zijn
            }
        }

        /// <summary>
        /// Plaats entities in het veld door de nummertoetsen 1 tot en met 7 te gebruiken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaatsEntity(object sender, KeyPressEventArgs e)
        {
            // Creeper
            if (e.KeyChar == (char) Keys.D1)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                CurrentPlayField.AddObject(new EntityCreeper(50, 50, pointer.X, pointer.Y, 1.0f));
                gamePanelEditor.Invalidate();
            }

                // Spider
            else if (e.KeyChar == (char) Keys.D2)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                CurrentPlayField.AddObject(new EntitySlower(50, 50, pointer.X, pointer.Y, 2, 2));
                gamePanelEditor.Invalidate();
            }

                // TnT
            else if (e.KeyChar == (char) Keys.D3)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                CurrentPlayField.AddObject(new EntityExplode(50, 50, pointer.X, pointer.Y, 1.0f));
                gamePanelEditor.Invalidate();
            }

                // TimeBomb
            else if (e.KeyChar == (char) Keys.D4)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                CurrentPlayField.AddObject(new EntityTimeBomb(50, 50, pointer.X, pointer.Y, 1.0f));
                gamePanelEditor.Invalidate();
            }

                // Cake
            else if (e.KeyChar == (char) Keys.D5)
            {
                CurrentPlayField.GameObjects.RemoveAll(p => p.GetType() == typeof (ObjectFinish));
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                CurrentPlayField.AddObject(new ObjectFinish(50, 50, pointer.X, pointer.Y));
                gamePanelEditor.Invalidate();
            }

                // Home
            else if (e.KeyChar == (char) Keys.D6)
            {
                CurrentPlayField.GameObjects.RemoveAll(p => p.GetType() == typeof (ObjectStart));
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                CurrentPlayField.AddObject(new ObjectStart(50, 50, pointer.X, pointer.Y));
                gamePanelEditor.Invalidate();
            }

                // Obstakel
            else if (e.KeyChar == (char) Keys.D7)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                CurrentPlayField.AddObject(new ObjectObstacle(50, 50, pointer.X, pointer.Y));
                gamePanelEditor.Invalidate();
            }
        }

        #region Drag and Drop

        #region Inpanel Drag and Drop

        /// <summary>
        /// Item dat momenteel wordt versleept.
        /// </summary>
        private GameObject currentDraggingObject;

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
            currentDraggingObject = gamePanelEditor.getObjectAtCursor();
            if (currentDraggingObject != null)
                offset = new Point(gamePanelEditor.getCursorPlayFieldPosition().X - currentDraggingObject.X,
                    gamePanelEditor.getCursorPlayFieldPosition().Y - currentDraggingObject.Y);
        }

        /// <summary>
        /// Als er wordt gesleept, verplaats item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InPanel_Mouse_Move(object sender, MouseEventArgs e)
        {
            if (currentDraggingObject != null)
            {
                Point p = gamePanelEditor.getCursorPlayFieldPosition();
                currentDraggingObject.X = p.X - offset.X;
                currentDraggingObject.Y = p.Y - offset.Y;
                gamePanelEditor.Invalidate();
            }
        }

        /// <summary>
        /// Stop met slepen als muis omhoog gaat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_InPanel_Drag(object sender, MouseEventArgs e)
        {
            if (currentDraggingObject != null)
            {
                currentDraggingObject = null;
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
            if (e.Data.GetDataPresent(typeof (ObjectType)))
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
            object o = e.Data.GetData(typeof (ObjectType));
            if (o == null) return;
            ObjectType ot = (ObjectType) o;

            // Add object
            Func<GameObject> f;
            GameObject.ConstructorList.TryGetValue(ot, out f);

            if (f != null)
            {
                GameObject g = f();
                g.X = l.X;
                g.Y = l.Y;
                CurrentPlayField.AddObject(g);
            }
            gamePanelEditor.Invalidate();
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
                    gamePanelEditor.Invalidate();
                    break;
            }
        }

        #endregion
    }
}