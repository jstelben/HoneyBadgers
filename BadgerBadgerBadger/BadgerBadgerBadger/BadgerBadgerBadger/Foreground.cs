using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class Foreground
    {
        private Texture2D foregroundImage;
        private Rectangle foregroundRectangle1;
        private Rectangle destinationRectangle1;
        private Rectangle destinationRectangle2;
        private Rectangle locationRectangle1;
        private Rectangle locationRectangle2;

        public Texture2D ForegroundImage
        {
            get { return foregroundImage; }
            set { foregroundImage = value; }
        }
        public Rectangle ForegroundRectangle1
        {
            get { return foregroundRectangle1; }
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

        public Foreground()
        {
            foregroundRectangle1 = new Rectangle(0, 0, 4093, 532);
            destinationRectangle1 = new Rectangle(0, 208, 4093, 305);
            destinationRectangle2 = new Rectangle(0 , 208, 4093, 305);
            locationRectangle1 = new Rectangle(0, 0, 2047, 532);
            locationRectangle2 = new Rectangle(2047, 0, 2047, 532);
        }

        public void UpdateForeground()
        {
            locationRectangle1 = new Rectangle(locationRectangle1.X - 1, 500, 2047, 100);
            locationRectangle2 = new Rectangle(locationRectangle2.X - 1, 500, 2047, 100);
            if (locationRectangle1.X < -2047)
            {
                locationRectangle1 = new Rectangle(2043, 532, 2047, 68);
            }
            if (locationRectangle2.X < -2047)
            {
                locationRectangle2 = new Rectangle(2047, 532, 2047, 68);
            }
        }
    }
}
