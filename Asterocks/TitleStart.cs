using System.Drawing;
using System.Windows.Forms;
using Engine;

namespace Asterocks
{
    class TitleStart : SceneObject, IUpdatable, IDrawable
    {
        public void Draw(Graphics g)
        {
            g.DrawString(
                "ПРОБЕЛ - начать игру\n" +
                "ESCAPE - выйти из программы\n",
                new Font("Courier New", 20),
                Brushes.WhiteSmoke,
                180.0F,
                Core.WindowHeight / 1.6F
            );

            g.DrawString(
                "Евгений Заонегин. C#. Уровень 2.",
                new Font("Courier New", 12),
                Brushes.WhiteSmoke,
                0.0F,
                Core.WindowHeight - 20.0F
            );
        }

        public void Reset()
        {
            // ...
        }

        public void Update(float dt)
        {
            bool isStart = Core.Keyboard.RecallKeyState((int)Keys.Space) == Keyboard.KeyState.KEY_DOWN;
            bool isQuit = Core.Keyboard.RecallKeyState((int)Keys.Escape) == Keyboard.KeyState.KEY_DOWN;

            if (isStart)
            {
                Core.CurrentSceneGroup = Const.SG_GAME_PLAY;
            }
            else if (isQuit)
            {
                Application.Exit();
            }
        }
    }
}
