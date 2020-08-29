using System.Drawing;
using Engine;

namespace Asterocks
{
    class TitleGameOver : SceneObject, IDrawable
    {
        public void Draw(Graphics g)
        {
            g.DrawString(
                "GAME OVER",
                new Font("Courier New", 40),
                Brushes.OrangeRed,
                250.0F,
                Core.WindowHeight / 2.2F
            );
        }
    }
}
