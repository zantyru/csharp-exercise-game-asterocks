using System.Drawing;

namespace Engine
{
    /// <summary>
    /// 
    /// </summary>
    public class Sprite : ScenePositionableObject, IDrawable
    {
        /// <summary>
        /// 
        /// </summary>
        private Image image;

        /// <summary>
        /// 
        /// </summary>
        public Image Image {
            set {
                image = value;
                SetupSize();
            }
            get => image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="image"></param>
        public Sprite(Math.Vector2 position, Image image)
        {
            Position = position;
            this.image = image;
            SetupSize();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupSize()
        {
            float w = image?.Width ?? 0.0F; 
            float h = image?.Height ?? 0.0F; 
            Size.SetCoordinates(w, h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            if (Image != null)
            {
                g.DrawImage(Image, Position.X, Position.Y);
            }
        }
    }
}
