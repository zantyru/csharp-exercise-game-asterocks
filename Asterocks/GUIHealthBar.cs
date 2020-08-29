using System.Drawing;
using Engine;

namespace Asterocks
{
    class GUIHealthBar : SceneObject, IDrawable, IUpdatable
    {
        private int capacityHealth = Const.PLAYER_HEALTH_MAX_DEFAULT;
        private int currentHealth = Const.PLAYER_HEALTH_MAX_DEFAULT;

        public void Draw(Graphics g)
        {
            Color color = Color.FromArgb(128, 255, 255, 255);
            Pen pen = new Pen(color, 1.0F);
            Brush brushSolid = new SolidBrush(color);
            g.DrawRectangle(
                pen,
                new Rectangle(10, 10, 200, 20)
            );
            g.FillRectangle(
                brushSolid,
                new Rectangle(12, 12, 197, 17)
            );
        }

        public void Reset()
        {
            // ...
        }

        public void Update(float dt)
        {
            // ...
        }
    }
}
