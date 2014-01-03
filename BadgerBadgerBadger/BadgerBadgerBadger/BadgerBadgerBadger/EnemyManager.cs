using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    //This one took a good amount of work
    class EnemyManager
    {
        //These double lists are important,more on that later
        private List<Jackal> jacks;
        private Texture2D jackalImage;
        private int jackalNumber;
        private List<Jackal> aliveJacks;

        public List<Jackal> Jacks
        {
            get { return jacks; }
        }
        public Texture2D JackalImage
        {
            get { return jackalImage; }
            set { jackalImage = value; }
        }
        public EnemyManager()
        {
            aliveJacks = new List<Jackal>();
            jacks = new List<Jackal>();
            jackalNumber = 0;
        }

        //Adds a jackal to the list
        public void SpawnJackal()
        {
            jacks.Add(new Jackal(jackalImage));
            jackalNumber++;
        }

        //Adds teh alive enemies to an alive list, then updtae their own list witht he alive list.
        //Basically, removes dead things form teh game
        public void EnemyUpdate()
        {
            foreach(Jackal j in jacks)
            {
                if (j.IsDead)
                {

                }
                else
                {
                    j.JackalActions();
                    aliveJacks.Add(j);
                }
            }
            jacks = aliveJacks;
            aliveJacks = new List<Jackal>();
        }


    }
}
