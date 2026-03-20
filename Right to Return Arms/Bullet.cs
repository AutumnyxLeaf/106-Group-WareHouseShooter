using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms
{
    internal class Bullet : GameObject
    {
        // <--------------------------------------- Fields --------------------------------------->


        // <------------------------------------- Properties --------------------------------------->




        // <--------------------------------------- Constructor --------------------------------------->

        public Bullet(Texture2D sprite, Rectangle transform, float bouncyness = 0) : base(sprite, transform, CollisionTags.Bullet, bouncyness)
        {

        }


        // <--------------------------------------- Methods --------------------------------------->
        
        
    }
}
