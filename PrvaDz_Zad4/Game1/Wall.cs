using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IPhysicalObject2D
    {
        float X { get; set; }
        float Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }

    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            Rectangle aRect = new Rectangle((int)a.X, (int)a.Y, a.Width, a.Height);
            Rectangle bRect = new Rectangle((int)b.X, (int)b.Y, b.Width, b.Height);
            return aRect.Intersects(bRect);
        }
    }

    public class Wall : IPhysicalObject2D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Wall(float x, float y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}