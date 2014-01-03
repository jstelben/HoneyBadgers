using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class HoneyPot : Food
    {
        
        public HoneyPot(Texture2D image)
            : base(image, new Rectangle(165, 3, 165, 259))
        {
            this.HealthRestore = 250;
            this.Loc = new Rectangle(1000, 500, 50, 100);
            this.ScoreGive = 250;
        }
    }
}
