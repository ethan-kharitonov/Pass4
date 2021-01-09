using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGameEngine
{
    class Wall : Body
    {
        private static new readonly Image image = Helper.LoadImage("Images/Wall.txt");

        public Wall(int x, int y) : base(image, x, y)
        {

        }

        public override void CollideWith(Player player)
        {
           
        }

        public override void CollideWith(Wall wall)
        {
           
        }

        public override void CollideWith(Crate crate)
        {
           
        }

        public override Rectangle NextFrameCells()
        {
            return new Rectangle(pos.x, pos.y, width, height);
        }

        public override void InformCollisionTo(Body entity)
        {
            entity.CollideWith(this);
        }
    }
}
