using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class ImmovableObject
    {
        //Variables
        Rectangle loc;
        Texture2D image;
        Rectangle destination;

        public Rectangle Loc
        {
            get { return loc; }
            set { loc = value; }
        }
        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public Rectangle Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public ImmovableObject(Rectangle loc)
        {
            this.loc = loc;

        }

    }
}
