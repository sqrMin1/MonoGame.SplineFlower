﻿using Microsoft.Xna.Framework;

namespace SplineSharp
{
    public class Transform
    {
        private Rectangle Size = Rectangle.Empty;
        internal Vector2 Position { get; private set; } = Vector2.Zero;
        public int Index { get; internal set; } = -1;

        internal Transform() { }
        internal Transform(Vector2 position) : this()
        {
            SetPosition(position);
        }
        internal Transform(ref Vector2 position) : this(position)
        {
            
        }

        internal void SetPosition(Vector2 position)
        {
            Position = new Vector2(position.X, position.Y);
            Size = new Rectangle(
                (int)position.X - (Setup.PointThickness / 2), 
                (int)position.Y - (Setup.PointThickness / 2), 
                Setup.PointThickness, 
                Setup.PointThickness);
        }

        public void Translate(Vector2 position)
        {
            Position += position;
            Size.X += (int)position.X;
            Size.Y += (int)position.Y;
        }

        internal bool TryGetPosition(Vector2 position)
        {
            if (Size.Contains(position)) return true;

            return false;
        }
    }
}