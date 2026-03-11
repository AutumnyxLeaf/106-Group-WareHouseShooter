using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms
{
    internal class Button
    {
        // Fields

        private Rectangle _posRect;
        private Texture2D texture;

        // Properties

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
            this.texture = texture;
            _posRect = new Rectangle(x, y, 100, 50);
        }

        /// <summary>
        /// Overload constructor that allows for a width and height to be chosen
        /// </summary>
        public Button(int x, int y, Texture2D texture, int width, int height)
            
        {
            X = x;
            Y = y;
            this.texture = texture;
            _posRect = new Rectangle(x, y, width, height);
        }
            
        // Methods



    }
}
