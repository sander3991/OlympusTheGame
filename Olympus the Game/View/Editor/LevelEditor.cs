using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View
{
    public partial class LevelEditor : Form
    {
        public PlayField pf { get; private set; }

        public LevelEditor()
            : this(new PlayField(1000, 500))
        { }

        public LevelEditor(PlayField pf)
        {
            InitializeComponent();

            this.pf = pf;
            OlympusTheGame.INSTANCE.Pause();
            this.gamePanelEditor.Playfield = this.pf;
            this.speelveldEditor1.Playfield = this.pf;
            this.gamePanelEditor.Invalidate();

            // Focus op de gamePanel zodat de nummertoetsen werken
            gamePanelEditor.Select();
        }

        #region Drag and Drop

        #region MouseDown
        private void Creeper_MouseDown(object sender, MouseEventArgs e)
        {
            Creeper.DoDragDrop(ObjectType.CREEPER, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Spider_MouseDown(object sender, MouseEventArgs e)
        {
            Spider.DoDragDrop(ObjectType.SLOWER, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Tnt_MouseDown(object sender, MouseEventArgs e)
        {
            Tnt.DoDragDrop(ObjectType.EXPLODE, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void TimeBomb_MouseDown(object sender, MouseEventArgs e)
        {
            TimeBomb.DoDragDrop(ObjectType.TIMEBOMB, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Cake_MouseDown(object sender, MouseEventArgs e)
        {
            Cake.DoDragDrop(ObjectType.FINISH, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            Home.DoDragDrop(ObjectType.START, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Obstakel_MouseDown(object sender, MouseEventArgs e)
        {
            Obstakel.DoDragDrop(ObjectType.OBSTACLE, DragDropEffects.Copy | DragDropEffects.Move);
        }

        #endregion

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

            // Add object
            switch ((ObjectType)e.Data.GetData(typeof(ObjectType)))
            {
                case ObjectType.TIMEBOMB:
                    this.pf.AddObject(new EntityTimeBomb(50, 50, l.X, l.Y, 1.0f));
                    break;
                case ObjectType.SLOWER:
                    this.pf.AddObject(new EntitySlower(50, 50, l.X, l.Y));
                    break;
                case ObjectType.FINISH:
                    this.pf.GameObjects.RemoveAll((p) => { return p.GetType() == typeof(ObjectFinish); });
                    this.pf.AddObject(new ObjectFinish(50, 50, l.X, l.Y));
                    break;
                case ObjectType.START:
                    this.pf.GameObjects.RemoveAll((p) => { return p.GetType() == typeof(ObjectStart); });
                    this.pf.AddObject(new ObjectStart(50, 50, l.X, l.Y));
                    break;
                case ObjectType.CREEPER:
                    this.pf.AddObject(new EntityCreeper(50, 50, l.X, l.Y, 1.0f));
                    break;
                case ObjectType.OBSTACLE:
                    this.pf.AddObject(new ObjectObstacle(50, 50, l.X, l.Y));
                    break;
                case ObjectType.EXPLODE:
                    this.pf.AddObject(new EntityExplode(50, 50, l.X, l.Y, 1.0f));
                    break;
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
                    PlayFieldToXml.WriteToXml(fileStream, pf);
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
                    this.pf = PlayFieldToXml.ReadFromXml(fileStream);
                    this.gamePanelEditor.Playfield = this.pf;
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
        }

        /// <summary>
        /// Vraagscherm bij afsluiten
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
                this.pf.AddObject(new EntityCreeper(50, 50, pointer.X, pointer.Y, 1.0f));
            }

            // Spider
            else if (e.KeyChar == (char)Keys.D2)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.pf.AddObject(new EntitySlower(50, 50, pointer.X, pointer.Y, 2, 2));
            }

            // TnT
            else if (e.KeyChar == (char)Keys.D3)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.pf.AddObject(new EntityExplode(50, 50, pointer.X, pointer.Y, 1.0f));
            }

            // TimeBomb
            else if (e.KeyChar == (char)Keys.D4)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.pf.AddObject(new EntityTimeBomb(50, 50, pointer.X, pointer.Y, 1.0f));
            }

            // Cake
            else if (e.KeyChar == (char)Keys.D5)
            {
                this.pf.GameObjects.RemoveAll((p) => { return p.GetType() == typeof(ObjectFinish); });
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.pf.AddObject(new ObjectFinish(50, 50, pointer.X, pointer.Y));
            }

            // Home
            else if (e.KeyChar == (char)Keys.D6)
            {
                this.pf.GameObjects.RemoveAll((p) => { return p.GetType() == typeof(ObjectStart); });
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.pf.AddObject(new ObjectStart(50, 50, pointer.X, pointer.Y));
            }

            // Obstakel
            else if (e.KeyChar == (char)Keys.D7)
            {
                Point pointer = gamePanelEditor.getCursorPlayFieldPosition();
                this.pf.AddObject(new ObjectObstacle(50, 50, pointer.X, pointer.Y));
            }
        }
    }
}
