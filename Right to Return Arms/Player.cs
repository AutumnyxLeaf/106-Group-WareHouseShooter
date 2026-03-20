using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms
{
    internal class Player : GameObject
    {
        // <--------------------------------------- Fields --------------------------------------->
        float speed;

        // <------------------------------------- Properties --------------------------------------->

        public float Speed { get => speed; set => speed = value; }

        // <--------------------------------------- Constructor --------------------------------------->

        public Player(Texture2D sprite, Rectangle transform, CollisionTags tag, float bouncyness = 0) 
            : base(sprite, transform, tag, bouncyness)
        { }


        // <--------------------------------------- Methods --------------------------------------->

        public void Update()
        {
            // Get the keyboard state
            KeyboardState kb = Keyboard.GetState();

            // Set the direction and magnitude to zero
            this.Velocity = Vector2.Zero;
            Vector2 inputs = Vector2.Zero;

            // Set the direction vector the player inputs

            // X axis
            if (kb.IsKeyDown(Keys.A))
            {
               inputs = new Vector2(-1, inputs.Y);
            }
            else if (kb.IsKeyDown(Keys.D))
            {
                inputs = new Vector2(1, inputs.Y);
            }

            if (kb.IsKeyDown(Keys.W))
            {
                inputs = new Vector2(inputs.X, -1);
            }
            else if (kb.IsKeyDown(Keys.S))
            {
                inputs = new Vector2(inputs.X, 1);
            }

            VelocityDirection = inputs;
            Velocity *= speed;

            // Update the player
            base.Update();
        }

    }
}
