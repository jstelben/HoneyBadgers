using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class Badger : MovableObject
    {
        private int badgerHealth;
        private string badgerState;
        private Texture2D badgerImage;
        private int jump;
        private Boolean canJump;
        private BadgerSwipe swipe;
        private int badgerFrame;
        private int frameWait;
        private Texture2D badgerSwipeImage;

        //Sprite Variables
        private int badger_x_offset = 26;
        private const int BADGER_TOP_Y_OFFSET = 29;
        private const int BADGER_BOTTOM_Y_OFFSET = 209;
        private const int BADGER_WIDTH = 300;
        private const int BADGER_HEIGHT = 128;
        private const int BADGER_SPACING = 45;


        public int BadgerHealth
        {
            get { return badgerHealth; }
            set
            {
                badgerHealth = value;
                if (badgerHealth > 1000)
                {
                    badgerHealth = 1000;
                }
                if (badgerHealth < 0)
                {
                    badgerHealth = 0;
                }
            }

        }
        public string BadgerState
        {
            set { badgerState = value; }
        }

        public Texture2D BadgerImage
        {
            get { return badgerImage; }
            set { badgerImage = value; }
        }
        public Texture2D BadgerSwipeImage
        {
            get { return badgerSwipeImage; }
            set { badgerSwipeImage = value; }
        }

        public BadgerSwipe Swipe
        {
            get { return swipe; }
        }
        public Badger() : base(new Rectangle(0,0,200,150), 1)
        {
            frameWait = 0;
            badgerHealth = 1000;
            badgerFrame = 0;
            this.Destination = new Rectangle(badger_x_offset + badgerFrame * BADGER_WIDTH, BADGER_TOP_Y_OFFSET, BADGER_WIDTH, BADGER_HEIGHT);
            speed = 10;
            gravity = true;
            gravAccel = 0;
            jump = 0;
            canJump = true;
            swipe = new BadgerSwipe();
        }

        //Remember that finite statey maching in teh game class.  This is what it does.
        public void badgerActions()
        {
            if (Image == badgerSwipeImage)
            {
                frameWait++;
                if (frameWait >= 5)
                {
                    frameWait = 0;
                    badgerFrame++;
                }
                if (badgerFrame >= 4)
                {
                    Image = badgerImage;
                    frameWait = 0;
                    badgerFrame = 0;
                    this.Destination = new Rectangle(26, BADGER_TOP_Y_OFFSET, BADGER_WIDTH, BADGER_HEIGHT);
                }
            }

            if (badgerFrame == 11)
            {
                badgerFrame = 0;
            }
            if(Image == badgerImage)
            {
                switch (badgerFrame)
                {
                    case 0: { badger_x_offset = 27; break; }
                    case 1: { badger_x_offset = 373; break; }
                    case 2: { badger_x_offset = 721; break; }
                    case 3: { badger_x_offset = 1052; break; }
                    case 4: { badger_x_offset = 1386; break; }
                    case 5: { badger_x_offset = 1702; break; }
                    case 6: { badger_x_offset = 2019; break; }
                    case 7: { badger_x_offset = 2337; break; }
                    case 8: { badger_x_offset = 2670; break; }
                    case 9: { badger_x_offset = 3000; break; }
                    case 10: { badger_x_offset = 3318; break; }
                    case 11: { badger_x_offset = 3644; break; }
                }
            }
            else
            {
                switch (badgerFrame)
                {
                    case 0: { badger_x_offset = 60; break; }
                    case 1: { badger_x_offset = 913; break; }
                    case 2: { badger_x_offset = 1789; break; }
                    case 3: { badger_x_offset = 2694; break; }
                }
            }
            if (badgerState == "jump" && canJump)
            {
                if (Image == badgerImage)
                {
                    this.Destination = new Rectangle(26, BADGER_TOP_Y_OFFSET, BADGER_WIDTH, BADGER_HEIGHT);
                }
                else
                {
                    this.Destination = new Rectangle(badger_x_offset, 128, 748, 319);
                }
                canJump = false;
                jump = 20;
            }
            if (badgerState == "moveright")
            {

                if (Image == badgerImage)
                {
                    frameWait++;
                    if (frameWait == 10)
                    {
                        badgerFrame++;
                        frameWait = 0;
                    }
                    this.Destination = new Rectangle(badger_x_offset, BADGER_BOTTOM_Y_OFFSET, BADGER_WIDTH, BADGER_HEIGHT);
                }
                else
                {
                    this.Destination = new Rectangle(badger_x_offset, 128, 748, 319);
                }
                this.Direction = 1;
                this.Move();
            }
            if (badgerState == "moveleft")
            {

                if (Image == badgerImage)
                {
                    frameWait++;
                    if (frameWait == 10)
                    {
                        badgerFrame++;
                        frameWait = 0;
                    }
                    this.Destination = new Rectangle(badger_x_offset, BADGER_BOTTOM_Y_OFFSET, BADGER_WIDTH, BADGER_HEIGHT);
                }
                else
                {
                    this.Destination = new Rectangle(badger_x_offset, 128, 748, 319);
                }
                this.Direction = 0;
                this.Move();
            }
            if (badgerState == "stop")
            {
                if (Image == badgerImage)
                {
                    frameWait = 0;
                    badgerFrame = 0;
                    this.Destination = new Rectangle(26, BADGER_TOP_Y_OFFSET, BADGER_WIDTH, BADGER_HEIGHT);
                }
                else
                {
                    this.Destination = new Rectangle(badger_x_offset, 128, 748, 319);
                }
            }
            //Let's the badger attack by mkaing a hitbox infront of it.
            if (badgerState == "attack" && !(swipe.IsActive))
            {
                Image = badgerSwipeImage;
                this.Destination = new Rectangle(60, 128, 748, 319);
                badgerFrame = 0;
                this.swipe.Swipe(this.Loc, this.Direction);
            }
            this.Loc = new Rectangle(Loc.X, Loc.Y - jump, Loc.Width, Loc.Height);
            if (!canJump)
            {
                jump -= 1;
            }
            //Makes so you cna't jump to infinity and beyond
            if (jump == -20)
            {
                canJump = true;
                jump = 0;
            }
        }

    }
}
