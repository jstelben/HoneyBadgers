using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class Food : ImmovableObject
    {
        private int healthRestore;
        private int scoreGive;

        public int HealthRestore
        {
            get { return healthRestore; }
            set { healthRestore = value; }
        }
        public int ScoreGive
        {
            get{return scoreGive;}
            set{scoreGive = value;}
        }
        public Food(Texture2D image, Rectangle destination)
            : base(new Rectangle(1000, 500, 100, 100))
        {
            this.Image = image;
            this.Destination = destination;
            healthRestore = 50;
            scoreGive = 50;
        }

        
    }
}
