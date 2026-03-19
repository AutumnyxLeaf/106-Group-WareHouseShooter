using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Right_to_Return_Arms
{

    
    internal class Button
    {
        // Fields

        private Rectangle _posRect;
        private Texture2D _texture;

        // Properties

        /// <summary>
        /// X position of the Button
        /// </summary>
        public int X
        {
            get
            {
                return _posRect.X;
            }

            set
            {
                _posRect.X = value;
            }
        }

        /// <summary>
        /// Y position of the Button
        /// </summary>
        public int Y
        {
            get
            {
                return _posRect.Y;
            }

            set
            {
                _posRect.Y = value;
            }
        }

        /// <summary>
        /// Base constructor that makes a button
        /// of a default size 100 by 50
        /// </summary>
        public Button(int x, int y, Texture2D texture)
        {
            X = x;
            Y = y;
            _texture = texture;
            _posRect = new Rectangle(x, y, 100, 50);
        }

        /// <summary>
        /// Overload constructor that allows for a width and height to be chosen
        /// </summary>
        public Button(int x, int y, Texture2D texture, int width, int height)
            
        {
            X = x;
            Y = y;
            _texture = texture;
            _posRect = new Rectangle(x, y, width, height);
        }
            
        // Methods

        /// <summary>
        /// Draws the button on screen
        /// </summary>
        /// <param name="sb">Sprite batch used for the draw</param>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(_texture, _posRect, Color.White);
        }

        /// <summary>
        /// Draws the button on screen and places it at a specified point
        /// </summary>
        /// <param name="sb">Sprite batch used for the draw</param>
        public void Draw(SpriteBatch sb, int x, int y)
        {
            X = x;
            Y = y;
            sb.Draw(_texture, _posRect, Color.White);
        }

        public bool mouseIntersects(MouseState ms)
        {
            if(_posRect.Contains(ms.X, ms.Y))
            {
                return true;
            }
            return false;
        }

    }
}
