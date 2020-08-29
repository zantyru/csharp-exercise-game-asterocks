using Engine;
using Engine.Math;

namespace Asterocks
{
    public class SceneGamePlay : Scene
    {
        public SceneGamePlay()
        {
            // Добавляем на сцену корабль игрока
            Ship objShip = new Ship(new Vector2());
            objShip.Position = new Vector2(
                10.0F,
                (Core.WindowHeight - objShip.Size.Y) / 2.0F
            );
            Add(objShip);

            // В случайном порядке создаём астероиды за кадром справа.
            for(int i = 0; i < 10; i++)
            {
                Add(
                    new Asteroid(
                        new Vector2(
                            Core.WindowWidth + Core.Random.Next() % (Core.WindowWidth - 200),
                            Core.Random.Next() % Core.WindowHeight
                        ),
                        new Vector2(
                            -1.0F,
                            0.0F
                        )
                    )
                );
            }
        }
    }
}
