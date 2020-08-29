using System.Drawing;
using Engine;
using Engine.Math;

namespace Asterocks
{
    public class Asteroid : Sprite, IMovable, IUpdatable, ICollidable
    {
        // Настройки снаряда
        public const float MOTION_SPEED = 250.0F; // Пикселей в секунду

        /// <summary>
        /// Скорость и направление перемещения объекта.
        /// </summary>
        public Vector2 Velocity { set; get; } = new Vector2();

        /// <summary>
        /// Инициализирует объект.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="image"></param>
        public Asteroid(Vector2 position, Vector2 velocity) : base(position, null)
        {
            switch (Core.Random.Next() % 3)
            {
                case 0:
                    Image = Image.FromFile(Const.FILENAME_ASTEROID0001);
                    break;
                case 1:
                    Image = Image.FromFile(Const.FILENAME_ASTEROID0002);
                    break;
                case 2:
                    Image = Image.FromFile(Const.FILENAME_ASTEROID0003);
                    break;
                default:
                    break;
            }
            Velocity = velocity.Normalized() * MOTION_SPEED;
        }
        
        /// <summary>
        /// Добавляет на сцену астероид "за кулисами" справа.
        /// </summary>
        private void Spawn()
        {
            ParentScene.Add(
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="dt">Интервал времени в секундах.</param>
        public void Move(Vector2 velocity, float dt)
        {
            Position += velocity * dt;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">Интервал времени в секундах.</param>
        public void Update(float dt)
        {
            Move(Velocity, dt);

            bool isOutOfX = (Position.X + Size.X < -Core.WindowWidth) || (Position.X >= 2 * Core.WindowWidth);
            bool isOutOfY = (Position.Y + Size.Y < -Core.WindowHeight) || (Position.Y >= 2 * Core.WindowHeight);
            if (isOutOfX || isOutOfY)
            {
                ParentScene.Remove(this);
                Spawn();
            }
        }

        /// <summary>
        /// Просчитывает столкновение астероида с пулей.
        /// </summary>
        /// <param name="obj">Объект, с которым проверяется столкновение.</param>
        public void Collide(ICollidable obj)
        {
            if (!(obj is Bullet bullet)) return;
            bool xOverlap = (bullet.Position.X >= Position.X) && (bullet.Position.X < Position.X + Size.X) ||
                            (bullet.Position.X + bullet.Size.X >= Position.X) && (bullet.Position.X + bullet.Size.X < Position.X + Size.X);
            bool yOverlap = (bullet.Position.Y >= Position.Y) && (bullet.Position.Y < Position.Y + Size.Y) ||
                            (bullet.Position.Y + bullet.Size.Y >= Position.Y) && (bullet.Position.Y + bullet.Size.Y < Position.Y + Size.Y);
            // 1--------2             3----4
            // 1------3=2--4
            //            1-3====4-2
            //                        3-1==4-----2
            if (xOverlap && yOverlap)
            {
                ParentScene.Remove(bullet);
                ParentScene.Remove(this);
                Spawn();
                Spawn(); // Дважды
            }
        }
    }
}
