using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pass4
{
    class GameObject
    {
        protected Texture2D image;
        protected Point pos;
        private Vector2 truePos;
        protected int width;
        protected int height;

        public GameObject(Texture2D img, int x, int y, bool isVisible)
        {
            image = img;

            width = image.Width;
            height = image.Height;

            pos = ClampToScreen(new Point(x, y));
            truePos = pos.ToVector2();

            IsVisible = isVisible;

        }

        protected Point ClampToScreen(Point pt)
        {
            //Clamp game object within bounds
            pt.X = Helper.Clamp(pt.X, 0, MainGame.Width - width);
            pt.Y = Helper.Clamp(pt.X, 0, MainGame.Width - width);

            return pt;
        }

        protected Vector2 ClampToScreen(Vector2 pt)
        {
            pt.X = Helper.Clamp(pt.X, 0.0f, MainGame.Width - width);
            pt.Y = Helper.Clamp(pt.Y, 0.0f, MainGame.Height- height);

            return pt;
        }

        /**
         * <b><i>GetPos</b></i>
         * <p>
         * {@code public Point GetPos()}
         * <p>
         * Retrieve the on screen position of the object's top left corner
         * 
         * @return an (x,y) Point for the object's top left corner
         */
        public Point Position
        {
            get => pos; 
            
            set
            {
                pos = ClampToScreen(value);
                truePos = pos.ToVector2();
            }
        }

        /**
         * <b><i>GetTruePos</b></i>
         * <p>
         * {@code public Vector2F GetTruePos()}
         * <p>
         * Retrieve the precise position of the object's top left corner
         * 
         * @return an (x,y) Point for the object's top left corner
         */
        public Vector2 TruePos
        {
            get => truePos; 
            set
            {
                truePos = ClampToScreen(value);
                pos = truePos.ToPoint();
            }
        }

        public bool IsVisible { get; set; }

        /**
         * <b><i>ToggleVisibility</b></i>
         * <p>
         * {@code public void ToggleVisibility()}
         * <p>
         * Flip the visibility status of the object
         */
        public void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }

        /**
         * <b><i>GetWidth</b></i>
         * <p>
         * {@code public int GetWidth()}
         * <p>
         * Retrieve the width of the object
         * 
         * @return The width of the object
         */
        public int Width => width;

        /**
         * <b><i>GetHeight</b></i>
         * <p>
         * {@code public int GetHeight()}
         * <p>
         * Retrieve the height of the object
         * 
         * @return The height of the object
         */
        public int Height => height;

        public virtual void Move(float deltaX, float deltaY)
        {
            truePos.X += deltaX;
            truePos.Y += deltaY;

            truePos = ClampToScreen(truePos);

            pos = truePos.ToPoint();
        }

        public virtual void Move(Vector2 velocity) => Move(velocity.X, velocity.Y);
    }
}
