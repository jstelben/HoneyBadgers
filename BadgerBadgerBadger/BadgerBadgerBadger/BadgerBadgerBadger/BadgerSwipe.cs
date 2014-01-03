using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    //The badger attack hitbox
    class BadgerSwipe
    {
        private Rectangle swipeArea;
        private bool isActive;
        private int time;
        private Texture2D swipeImage;
        private Rectangle destination;

        public Rectangle Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public Rectangle SwipeArea
        {
            get { return swipeArea; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Texture2D SwipeImage
        {
            get { return swipeImage; }
            set { swipeImage = value; }
        }

        public BadgerSwipe()
        {
            isActive = false;
            time = 0;
            this.Destination = new Rectangle(0, 0, 479, 719);
        }

        

        public void Swipe(Rectangle badgerLoc, int badgerDir)
        {
            if (badgerDir == 0)
            {
                swipeArea = new Rectangle(badgerLoc.X - 50, badgerLoc.Y, 50, 50);
            }
            else
            {
                swipeArea = new Rectangle(badgerLoc.X + badgerLoc.Width, badgerLoc.Y, 50, 50);
            }
            time = 15;
            isActive = true;

        }

        //Makes teh swipe not be dumb
        public void SwipeUpdate(Rectangle badgerLoc, int badgerDir)
        {
            if (isActive)
            {
                if (badgerDir == 0)
                {
                    swipeArea = new Rectangle(badgerLoc.X - 50, badgerLoc.Y, 50, 50);
                }
                else
                {
                    swipeArea = new Rectangle(badgerLoc.X + badgerLoc.Width, badgerLoc.Y, 50, 50);
                }
                time -= 1;
                if (time == 0)
                {
                    isActive = false;
                }
            }
        }
    }
}
