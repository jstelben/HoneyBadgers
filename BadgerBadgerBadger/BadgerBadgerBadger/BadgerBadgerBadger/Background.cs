using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class Background
    {
        private Texture2D backgroundImage;
        private Rectangle backgroundRectangle1;
        private Rectangle destinationRectangle1;
        private Rectangle destinationRectangle2;
        private Rectangle locationRectangle1;
        private Rectangle locationRectangle2;

        public Texture2D BackgroundImage
        {
            get { return backgroundImage; }
            set { backgroundImage = value; }
        }
        public Rectangle BackgroundRectangle1
        {
            get { return backgroundRectangle1; }
        }
        public Rectangle DestinationRectangle1
        {
            get { return destinationRectangle1; }
        }
        public Rectangle DestinationRectangle2
        {
            get { return destinationRectangle2; }
        }
        public Rectangle LocationRectangle1
        {
            get { return locationRectangle1; }
        }
        public Rectangle LocationRectangle2
        {
            get { return locationRectangle2; }
        }

        public Background()
        {
            backgroundRectangle1 = new Rectangle(0, 0, 4094, 532);
            destinationRectangle1 = new Rectangle(0, 0, 2047, 532);
            destinationRectangle2 = new Rectangle(2047, 0, 2047, 532);
            locationRectangle1 = new Rectangle(0, 0, 2047, 532);
            locationRectangle2 = new Rectangle(2047, 0, 2047, 532);
        }

        public void UpdateBackground()
        {
            locationRectangle1 = new Rectangle(locationRectangle1.X -2, 0, 2047, 532);
            locationRectangle2 = new Rectangle(locationRectangle2.X - 2, 0, 2047, 532);
            if (locationRectangle1.X < -2047)
            {
                locationRectangle1 = new Rectangle(2043, 0, 2047, 532);
            }
            if (locationRectangle2.X < -2047)
            {
                locationRectangle2 = new Rectangle(2047, 0, 2047, 532);
            }
        }
    }
}
