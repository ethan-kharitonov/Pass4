using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGameEngine
{
    abstract class Body : GameObject
    {
        public static GameContainer gc;

        public Body(Image image, int x, int y) : base(gc, image , x , y, true)
        {

        }

        public abstract void CollideWith(Player player);

        public abstract void CollideWith(Wall wall);

        public abstract void CollideWith(Crate crate);

        public abstract void InformCollisionTo(Body body);

        //public abstract Rectangle NextFrameCells();
    }
}
