namespace Olympus_the_Game
{
    public class Controller
    {
        public PlayField PlayField { get; private set; }

        public Controller(PlayField pf)
        {
            this.PlayField = pf;
        }

        public void ReadInput()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            PlayField.Player.DX = 1;
            PlayField.Player.Move();
            foreach(GameObject o in PlayField.GetObjects()){
                Entity e = o as Entity;
                if (e != null)
                {
                    e.Move();
                }
            }
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }
    }
}
