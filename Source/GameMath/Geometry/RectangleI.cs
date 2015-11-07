﻿namespace GameMath
{
    using System;

    /// <summary>
    ///   Rectangle with integer position and extent.
    ///   Origin is top-left.
    ///   Note that rectangles are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct RectangleI : IEquatable<RectangleI>
    {
        #region Fields

        /// <summary>
        ///   Position of this rectangle.
        /// </summary>
        private readonly Vector2I position;

        /// <summary>
        ///   Size of this rectangle, its width and height.
        /// </summary>
        private readonly Vector2I size;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the rectangle position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the rectangle position.
        /// </param>
        /// <param name="width">
        ///   Rectangle width.
        /// </param>
        /// <param name="height">
        ///   Rectangle height.
        /// </param>
        public RectangleI(int x, int y, int width, int height)
            : this(new Vector2I(x, y), new Vector2I(width, height))
        {
        }

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the rectangle position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the rectangle position.
        /// </param>
        /// <param name="size">
        ///   Rectangle size.
        /// </param>
        public RectangleI(int x, int y, Vector2I size)
            : this(new Vector2I(x, y), size)
        {
        }

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Rectangle position.
        /// </param>
        /// <param name="width">
        ///   Rectangle width.
        /// </param>
        /// <param name="height">
        ///   Rectangle height.
        /// </param>
        public RectangleI(Vector2I position, int width, int height)
            : this(position, new Vector2I(width, height))
        {
        }

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Rectangle position.
        /// </param>
        /// <param name="size">
        ///   Rectangle size.
        /// </param>
        public RectangleI(Vector2I position, Vector2I size)
        {
            if (size.X < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Width must be non-negative.");
            }

            if (size.Y < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Height must be non-negative.");
            }

            this.position = position;
            this.size = size;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the area of this rectangle, the product of its width and height.
        /// </summary>
        public int Area
        {
            get
            {
                return this.Size.X * this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the y-component of the bottom side of this rectangle.
        /// </summary>
        public int Bottom
        {
            get
            {
                return this.Position.Y + this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the position of the bottom left corner of this rectangle.
        /// </summary>
        public Vector2I BottomLeft
        {
            get
            {
                return this.Position + new Vector2I(0, this.Size.Y);
            }
        }

        /// <summary>
        ///   Gets the position of the bottom right corner of this rectangle.
        /// </summary>
        public Vector2I BottomRight
        {
            get
            {
                return this.Position + this.Size;
            }
        }

        /// <summary>
        ///   Gets the position of the center of this rectangle.
        /// </summary>
        public Vector2I Center
        {
            get
            {
                return (this.Position + this.Size) / 2;
            }
        }

        /// <summary>
        ///   Gets or sets the height of this rectangle.
        /// </summary>
        public int Height
        {
            get
            {
                return this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the x-component of the left side of this rectangle.
        /// </summary>
        public int Left
        {
            get
            {
                return this.Position.X;
            }
        }

        /// <summary>
        ///   Position of this rectangle.
        /// </summary>
        public Vector2I Position
        {
            get
            {
                return this.position;
            }
        }

        /// <summary>
        ///   Gets the x-component of the right side of this rectangle.
        /// </summary>
        public int Right
        {
            get
            {
                return this.Position.X + this.Size.X;
            }
        }

        /// <summary>
        ///   Gets or sets the size of this rectangle, its width and height.
        /// </summary>
        public Vector2I Size
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        ///   Gets the y-component of the top side of this rectangle.
        /// </summary>
        public int Top
        {
            get
            {
                return this.Position.Y;
            }
        }

        /// <summary>
        ///   Gets the position of the top left corner of this rectangle.
        /// </summary>
        public Vector2I TopLeft
        {
            get
            {
                return this.Position;
            }
        }

        /// <summary>
        ///   Gets the position of the top right corner of this rectangle.
        /// </summary>
        public Vector2I TopRight
        {
            get
            {
                return this.Position + new Vector2I(this.Size.X, 0);
            }
        }

        /// <summary>
        ///   Gets or sets the width of this rectangle.
        /// </summary>
        public int Width
        {
            get
            {
                return this.Size.X;
            }
        }

        /// <summary>
        ///   Gets or sets the x-component of the position of this rectangle.
        /// </summary>
        public int X
        {
            get
            {
                return this.Position.X;
            }
        }

        /// <summary>
        ///   Gets or sets the y-component of the position of this rectangle.
        /// </summary>
        public int Y
        {
            get
            {
                return this.Position.Y;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether this rectangle entirely encompasses the passed other one.
        /// </summary>
        /// <param name="other">
        ///   Rectangle to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this rectangle contains <paramref name="other" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(RectangleI other)
        {
            return (this.Left <= other.Left && this.Right >= other.Right)
                   && (this.Top <= other.Top && this.Bottom >= other.Bottom);
        }

        /// <summary>
        ///   Checks whether this rectangle contains the point denoted by the specified vector.
        /// </summary>
        /// <param name="point">
        ///   Point to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this rectangle contains <paramref name="point" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(Vector2I point)
        {
            return point.X.IsWithinBounds(this.Left, this.Right) && point.Y.IsWithinBounds(this.Top, this.Bottom);
        }

        /// <summary>
        ///   Compares the passed rectangle to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(RectangleI other)
        {
            return this.Position.Equals(other.Position) && this.Size.Equals(other.Size);
        }

        /// <summary>
        ///   Compares the passed rectangle to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType() && this.Equals((RectangleI)obj);
        }

        /// <summary>
        ///   Gets the hash code of this rectangle.
        /// </summary>
        /// <returns>
        ///   Hash code of this rectangle.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Position.GetHashCode() * 397) ^ this.Size.GetHashCode();
            }
        }

        /// <summary>
        ///   Checks whether this rectangle at least partially intersects the passed other one.
        /// </summary>
        /// <param name="other">
        ///   Rectangle to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this rectangle intersects <paramref name="other" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Intersects(RectangleI other)
        {
            return (this.Right > other.Left && this.Left < other.Right)
                   && (this.Bottom > other.Top && this.Top < other.Bottom);
        }

        /// <summary>
        ///   Compares the passed rectangles for equality.
        /// </summary>
        /// <param name="first">
        ///   First rectangle to compare.
        /// </param>
        /// <param name="second">
        ///   Second rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(RectangleI first, RectangleI second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed rectangles for inequality.
        /// </summary>
        /// <param name="first">
        ///   First rectangle to compare.
        /// </param>
        /// <param name="second">
        ///   Second rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(RectangleI first, RectangleI second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this rectangle.
        /// </summary>
        /// <returns>
        ///   This rectangle as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Position: {0}, Size: {1}", this.Position, this.Size);
        }

        #endregion
    }
}