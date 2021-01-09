using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGameEngine
{
    class Player : Body
    {
        private static new readonly Image image = Helper.LoadImage("Images/Player.txt");
        private Vector2F velocity = Vector2F.ZERO;

        private Point prevPos;

        public Player(int x, int y) : base(image, x, y)
        {
            prevPos = Position;
        }


        public void Update(char command)
        {
            switch (command)
            {
                case '<':
                    Move(-0.5f, 0);
                    break;

                case '>':
                    Move(0.5f, 0); ;
                    break;
            }
        }


        public bool InProgress => pos.x % MainClass.ObjectWidth != 0 || pos.y % MainClass.ObjectHeight != 0;

        public override void CollideWith(Player player)
        {
            throw new NotImplementedException("There should only be one player in the game");
        }

        public override void CollideWith(Wall wall)
        {
            if (prevPos.x < wall.Position.x)
            {
                pos.x = wall.Position.x - width;
                velocity.x = 0;
            }

            if (pos.x > wall.Position.x)
            {
                pos.x = wall.Position.x + wall.Width;
                velocity.x = 0;
            }

            if (pos.y < wall.Position.y)
            {
                pos.y = wall.Position.y - height;
                velocity.y = 0;

            }
            if (pos.y > wall.Position.y)
            {
                pos.y = wall.Position.y + wall.Height;
                velocity.y = 0;
            }
        }

        public override void CollideWith(Crate crate)
        {
            throw new NotImplementedException();
        }

        public override void InformCollisionTo(Body entity)
        {
            entity.CollideWith(this);
        }
    }

}

