using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class Jackal : MovableObject
    {
        private string jackalState;
        private bool isDead;


        
        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }
        public string JackalState
        {
            set { jackalState = value; }
        }
        public Jackal(Texture2D jackalImage)
            : base(new Rectangle(1300,200,200,200), 0)
        {
            Image = jackalImage;
            speed = 7;
            gravity = true;
            gravAccel = 0;
            jackalState = "attack";
            this.Destination = new Rectangle(40, 19, 756, 511);
            Random rand = new Random();
            if (rand.Next(2) == 1)
            {
                this.Loc = new Rectangle(-1300, 200, 200, 200);
                this.direction = 1;
            }

        }


        //Leaving the possibility to add more Jackal behavoirs
        public void JackalActions()
        {
            if (jackalState == "attack")
            {
                Move();
            }
        }

        public override void Move()
        {
            if (direction == 1)
            {
                Loc = new Rectangle(Loc.X + speed, Loc.Y, Loc.Width, Loc.Height);
            }
            else
            {
                Loc = new Rectangle(Loc.X - speed, Loc.Y, Loc.Width, Loc.Height);
            }

        }
    }
}
