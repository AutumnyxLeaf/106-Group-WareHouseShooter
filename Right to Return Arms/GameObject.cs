using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms
{
    public enum CollisionTags
    {
        Default,
        Bullet,
        Wall,
        Player
    }

    internal class GameObject
    {
        // <--------------------------------------- Fields --------------------------------------->


        // Sprite and transform
        Texture2D sprite;
        public Rectangle transform;

        // Physics stuff
        Vector2 velocity;
        float maxVelo;

        Vector2 acceration;
        float maxAccel;

        float bouncyness;

        CollisionTags tag;

        // Refrence to game object collided with
        GameObject objCollidedWith;

        
        // <------------------------------------- Properties --------------------------------------->



        public Rectangle Transform { get => transform; set => transform = value; }

        // Physics stuff
        public Vector2 Velocity { get => velocity; 
            set
            {
                // if the requested velocity is greater than the max velocity,
                // then keep the direction but set the magnitued to the max velo
                if (Math.Abs(maxVelo) > maxVelo)
                {
                    value.Normalize();

                    velocity = value * maxVelo;
                }
                else
                {
                    velocity = value;
                }
            }
        }

        public Vector2 VelocityDirection { 
            get
            {
                if (velocity == Vector2.Zero)
                {
                    return Vector2.Zero;
                }
                
                // Save the old velocity
                Vector2 oldVelo = new Vector2(velocity.X, velocity.Y);

                // Calculate the degrees
                velocity.Normalize();
                Vector2 normalized = new Vector2(velocity.X, velocity.Y);

                // Give it the previous value
                velocity = oldVelo;

                return normalized;
            }
            set
            {
                if (value == Vector2.Zero)
                {
                    Velocity = Vector2.Zero;
                    return;
                }
                else if (Velocity == Vector2.Zero)
                {
                    Velocity = Vector2.One;
                }

                // Makes a vector with the direction of the value passed, then mulitpies it by the length
                value.Normalize(); 
                velocity = value * velocity.Length();
            }
        }

        public int VelocityDirectionDegrees { get
            
            {
                // Returns the velocity direction in degrees
                return (int)Math.Atan2(VelocityDirection.X, VelocityDirection.Y);
            }
            set
            {
                VelocityDirection = new Vector2(MathF.Cos(MathHelper.ToRadians(value)), MathF.Sin(MathHelper.ToRadians(value))) * velocity.Length();
            }
        }
        public float MaxVelo { get => maxVelo; set => maxVelo = value; }

        public Vector2 Acceration
        {
            get => acceration;
            set
            {
                // if the requested velocity is greater than the max velocity,
                // then keep the direction but set the magnitued to the max velo
                if (Math.Abs(maxAccel) > maxAccel)
                {
                    float length = value.Length();

                    value.Normalize();

                    acceration = value * maxAccel;
                }
                else
                {
                    acceration = value;
                }
            }
        }

        public Vector2 AccerationDirection
        {
            get
            {
                // Save the old velocity
                Vector2 oldAccel = new Vector2(acceration.X, acceration.Y);

                // Calculate the degrees
                acceration.Normalize();
                Vector2 normalized = new Vector2(acceration.X, acceration.Y);

                // Give it the previous value
                acceration = oldAccel;

                return normalized;
            }
            set
            {
                // Makes a vector with the direction of the value passed, then mulitpies it by the length
                value.Normalize();
                acceration = new Vector2(value.X, value.Y) * acceration.Length();
            }
        }

        public int AccelerationDirectionDegrees
        {
            get

            {
                // Returns the velocity direction in degrees
                return (int)Math.Atan2(AccerationDirection.X, AccerationDirection.Y);
            }
            set
            {
                AccerationDirection = new Vector2(MathF.Cos(MathHelper.ToRadians(value)), MathF.Sin(MathHelper.ToRadians(value))) * acceration.Length();
            }
        }
        public float MaxAccel { get => maxAccel; set => maxAccel = value; }



        // <--------------------------------------- Constructor --------------------------------------->



        /// <summary>
        /// Full constructor for game object
        /// </summary>
        /// <param name="sprite">Sprite to use</param>
        /// <param name="transform">Transform to use</param>
        /// <param name="tag">Tag to use</param>
        public GameObject(Texture2D sprite, Rectangle transform, CollisionTags tag, float bouncyness = 0)
        {
            // Set up game object specific variables
            this.sprite = sprite;
            this.transform = transform;
            this.tag = tag;

            // Set default values
            velocity = Vector2.Zero;
            acceration = Vector2.Zero;

            maxVelo = 100;
            maxAccel = 100;

            this.bouncyness = bouncyness;
        }

        /// <summary>
        /// Constructor with a 50px transform and a default collision tag
        /// </summary>
        /// <param name="sprite">Sprite to use</param>
        public GameObject(Texture2D sprite)
            : this(sprite, new Rectangle(0, 0, 50, 50), CollisionTags.Default) { }



        // <--------------------------------------- Methods --------------------------------------->



        /// <summary>
        /// Draws the game object with the given color
        /// </summary>
        /// <param name="sb">Spritebatch to use</param>
        /// <param name="color">Color to draw with</param>
        public void Draw(SpriteBatch sb, Color color)
        {
            sb.Draw(sprite, transform, color);
        }

        /// <summary>
        /// Draws the game object
        /// </summary>
        /// <param name="sb">Spritebatch to use</param>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, transform, Color.White);
        }

        // Physics stuff
        
        /// <summary>
        /// Checks the collision of a game object and if the game object has the specified tag
        /// </summary>
        /// <param name="gameObject">Game object to check collison with</param>
        /// <param name="behavior">Behavior to run if collison was triggered</param>
        /// <param name="tagToCheck">Tag to check</param>
        /// <returns></returns>
        public bool CheckCollision(GameObject gameObject, Action behavior, CollisionTags tagToCheck = CollisionTags.Default) 
        {
            // First check if the collision is with a tag it cares about
            if (gameObject.tag == tagToCheck || tagToCheck == CollisionTags.Default)
            {
                // Next check if they overlap
                if (gameObject.transform.Intersects(transform))
                {
                    // Update the game object collided with refrence
                    objCollidedWith = gameObject;
                    
                    // Call the behavior
                    behavior();

                    // Return true since the collison was triggered
                    return true;
                }
            }

            // Return false if there was no collison
            return false;
        }

        /// <summary>
        /// Checks physics collsion with a specified object
        /// </summary>
        /// <param name="gameObject">Game object to check</param>
        /// <param name="tagToCheck">Tag to check</param>
        /// <returns></returns>
        public bool CheckCollision (GameObject gameObject, CollisionTags tagToCheck = CollisionTags.Default)
        {
            return CheckCollision(gameObject, PhyscisCollision, tagToCheck);
        }

        public void PhyscisCollision()
        {
            // First, get the collision rect
            Rectangle collisionRect = Rectangle.Intersect(transform, objCollidedWith.transform);

            // Next, resolve in the X direction
            if (collisionRect.Width <= collisionRect.Height)
            {
                // Set the player's x cooridinate to the proper location
                if (transform.X == collisionRect.X)
                {
                    Velocity = new Vector2(Velocity.X * bouncyness, Velocity.Y);

                    transform.X = collisionRect.X + collisionRect.Width;
                }
                else if (transform.X + transform.Width == collisionRect.X + collisionRect.Width)
                {
                    Velocity = new Vector2(Velocity.X * bouncyness, Velocity.Y);

                    transform.X = collisionRect.X - transform.Width;
                }
            }
            // Same as X axis, but if the area is less than 20 pixels,
            // ignore it (this is to deal with smooth wall sliding)
            else if (collisionRect.Width > collisionRect.Height && collisionRect.Height * collisionRect.Width > 20)
            {
                if (collisionRect.Width > collisionRect.Height)
                {
                    if (transform.Y + transform.Height == collisionRect.Y + collisionRect.Height)
                    {
                        Velocity = new Vector2(Velocity.X, -Velocity.Y * bouncyness);

                        transform.Y = collisionRect.Y - transform.Height;
                    }
                    else if (transform.Y == collisionRect.Y)
                    {
                        Velocity = new Vector2(Velocity.X, Velocity.Y * bouncyness);


                        transform.Y = collisionRect.Y + collisionRect.Height;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the positon of the game object
        /// </summary>
        public void Update()
        {
            // Add acceleration
            Velocity = new Vector2((int)(velocity.X + acceration.X), (int)(velocity.Y + acceration.Y));

            // Set position
            transform.Location = new Point((int)(transform.X + velocity.X), (int)(transform.Y + velocity.Y));
        }

        public int RoundDownToNextInt(float value) 
        {
            // Get the decimal component of value
            float dec = value % 1;
            
            return (int)(value - dec);
        }
    }
}
