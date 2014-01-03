using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class ConsumableManager
    {
        private Texture2D honeyImage;
        private Texture2D eggImage;
        private Texture2D blueberryImage;
        private Texture2D strawberryImage;
        private Texture2D mushroomImage;
        private List<Food> foodList;
        private List<Food> notConsumed;

        public List<Food> NotConsumed
        {
            get { return notConsumed; }
            set { notConsumed = value; }
        }
        public Texture2D HoneyImage
        {
            get { return honeyImage; }
            set { honeyImage = value; }
        }
        public Texture2D EggImage
        {
            get { return eggImage; }
            set { eggImage = value; }
        }
        public Texture2D BlueberryImage
        {
            get { return blueberryImage; }
            set { blueberryImage = value; }
        }
        public Texture2D StrawberryImage
        {
            get { return strawberryImage; }
            set { strawberryImage = value; }
        }
        public Texture2D MushroomImage
        {
            get { return mushroomImage; }
            set { mushroomImage = value; }
        }
        public List<Food> FoodList
        {
            get { return foodList; }
            set { foodList = value; }
        }
        public ConsumableManager()
        {
            foodList = new List<Food>();
            notConsumed = new List<Food>();
        }

        public void CreateFood()
        {
            Random rand = new Random();
            switch (rand.Next(5))
            {
                case  4:
                    {
                        foodList.Add(new Food(blueberryImage, new Rectangle(203, 82, 115, 118)));
                        break;
                    }
                case 1:
                    {
                        foodList.Add(new Food(eggImage, new Rectangle(16, 31, 260, 349)));
                        break;
                    }
                case 2:
                    {
                        foodList.Add(new Food(mushroomImage, new Rectangle(7, 12, 303, 292)));
                        break;
                    }
                case 3:
                    {
                        foodList.Add(new Food(strawberryImage, new Rectangle(36, 19, 256, 312)));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void CreateHoney()
        {
            foodList.Add(new HoneyPot(honeyImage));
        }

    }
}
