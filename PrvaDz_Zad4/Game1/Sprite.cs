using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public abstract class Sprite : IPhysicalObject2D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary> 
        /// Represents the texture of the Sprite on the screen.
        /// Texture2D is a type defined in Monogame framework. 
        /// </summary>
        public Texture2D Texture { get; set; }
        protected Sprite(int width, int height, float x = 0, float y = 0)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }
        /// <summary> 
        /// Base draw method
        /// </summary> 
        public virtual void DrawSpriteOnScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(X, Y), new Rectangle(0, 0, Width, Height), Color.White);
        }
    }

    /// <summary> 
    /// Game background representation 
    /// </summary> 
    public class Background : Sprite
    {
        public Background(int width, int height) : base(width, height)
        {
        }
    }

    public class Ball : Sprite
    {
        /// <summary> 
        /// Defines current ball speed in time. 
        /// </summary> 
        private float _speed;
        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = (value > GameConstants.BallMaxSpeed) ? GameConstants.BallMaxSpeed : value;
            }
        }
        
        public float BumpSpeedIncreaseFactor { get; set; }
        /// <summary> /// 
        /// Defines ball direction. 
        /// Valid values (-1,-1), (1,1), (1,-1), (-1,1). 
        /// Using Vector2 to simplify game calculation. Potentially 
        /// dangerous because vector 2 can swallow other values as well. 
        /// OPTIONAL TODO: create your own, more suitable type 
        /// </summary> 
        public Vector2 Direction { get; set; }
        public Ball(int size, float speed, float defaultBallBumpSpeedIncreaseFactor) : base(size, size)
        {
            Speed = speed;
            BumpSpeedIncreaseFactor = defaultBallBumpSpeedIncreaseFactor;
            Direction = new Vector2(1, 1);
        }
    }

    /// <summary> /// 
    /// Represents player paddle.
    /// </summary> 
    public class Paddle : Sprite
    { 
        /// <summary> /// 
        /// Current paddle speed in time 
        /// </summary> 
        public float Speed { get; set; }

        public Paddle(int width, int height, float initialSpeed) : base(width, height)
        {
            Speed = initialSpeed;
        }

        /// <summary> 
        /// Overriding draw method. Masking paddle texture with black color.
        /// </summary>
        public override void DrawSpriteOnScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(X, Y), new Rectangle(0, 0, Width, Height), Color.GhostWhite);
        }
    }
}


