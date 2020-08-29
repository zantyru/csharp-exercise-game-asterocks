using System.Drawing;
using Engine;
using Engine.Math;

namespace Asterocks
{
    class Bullet : Sprite, IMovable, IUpdatable, ICollidable
    {
        // Настройки снаряда
        public const float MOTION_SPEED = 500.0F; // Пикселей в секунду

        /// <summary>
        /// Скорость и направление перемещения объекта.
        /// </summary>
        public Vector2 Velocity { set; get; } = new Vector2();

        /// <summary>
        /// Инициализирует объект.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="image"></param>
        public Bullet(Vector2 position, Vector2 velocity) : base(position, Image.FromFile(Const.FILENAME_BULLET0001))
        {
           Velocity = velocity.Normalized() * MOTION_SPEED;
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
            // Вид
            //currentFrame += dt * ANIMATION_SPEED;
            //this.Image = listFrames[(int)System.Math.Floor(currentFrame) % listFrames.Count];

            // Положение
            Move(Velocity, dt);
            bool isOutOfX = (Position.X + Size.X < 0.0F) || (Position.X >= Core.WindowWidth);
            bool isOutOfY = (Position.Y + Size.Y < 0.0F) || (Position.Y >= Core.WindowHeight);
            if (isOutOfX || isOutOfY)
            {
                ParentScene.Remove(this);
            }
        }

        /// <summary>
        /// Этот метод, хоть и создан для рассчёта столкновния пули с астероидом,
        /// не делает этого, так как в паре "пуля - астероид" достаточно инициации
        /// проверки одним из объектов (чтобы избежать избыточности из-за не до
        /// конца продуманной архитектуры приложения и движка). Явная проверка
        /// происходит в Asteroid.Collide(...).
        /// </summary>
        /// <param name="obj">Объект, с которым проверяется столкновение.</param>
        public void Collide(ICollidable obj)
        {
            return;
        }
    }
}
