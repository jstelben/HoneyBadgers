using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class MovableObject : ImmovableObject
    {
        //Variables
        protected int direction;
        protected int speed;
        protected Boolean gravity;
        protected double gravAccel;
        protected int gravRound = 0;

        //Direction of object.  0 = Left, 1 = Right
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public MovableObject(Rectangle loc, int direction) : base(loc)
        {
            speed = 0;
            gravity = true;
        }

        public virtual void Move()
        {
            if (direction == 1)
            {
                Loc = new Rectangle(Loc.X + speed, Loc.Y, Loc.Width, Loc.Height);
                
                if (Loc.X > 800 - Loc.Width)
                {
                    Loc = new Rectangle(800-Loc.Width, Loc.Y, Loc.Width, Loc.Height);
                }
            }
            else
            {
                Loc = new Rectangle(Loc.X - speed, Loc.Y, Loc.Width, Loc.Height);
                if (Loc.X < 0)
                {
                    Loc = new Rectangle(0, Loc.Y, Loc.Width, Loc.Height);
                }
            }
        }
        public void Gravity()
        {
            if (gravity)
            {
                if (Loc.Y < 600 - Loc.Height)
                {
                    gravAccel += .1;
                    gravRound = (int) Math.Round(gravAccel);
                    Loc = new Rectangle(Loc.X, Loc.Y + gravRound, Loc.Width, Loc.Height);
                }
                if (Loc.Y > 600 - Loc.Height)
                {
                    Loc = new Rectangle(Loc.X, 600 - Loc.Height, Loc.Width, Loc.Height);
                    gravAccel = 0;
                }

            }
        }
    }
}
