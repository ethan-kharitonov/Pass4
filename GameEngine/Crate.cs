using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGameEngine
{
    class Crate : Body
    {
        private static new readonly Image image = Helper.LoadImage("Images/Crate.txt");

        public Crate(int x, int y) : base(image, x, y)
        {
        }

        public override void CollideWith(Player player)
        {
            throw new NotImplementedException();
        }

        public override void CollideWith(Wall wall)
        {
            throw new NotImplementedException();
        }

        public override void CollideWith(Crate crate)
        {
            throw new NotImplementedException();
        }

        public override Rectangle NextFrameCells()
        {
            throw new NotImplementedException();
        }

        public override void InformCollisionTo(Body entity)
        {
            entity.CollideWith(this);
        }
    }
}
