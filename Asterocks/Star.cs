using System.Drawing;
using Engine;
using Engine.Math;

namespace Asterocks
{
    public class Star : Sprite, IMovable, IUpdatable
    {
        /// <summary>
        /// Скорость и направление перемещения объекта.
        /// </summary>
        public Vector2 Velocity { set; get; } = new Vector2();

        /// <summary>
        /// Инициализирует объект.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="image"></param>
        public Star(Vector2 position, Vector2 velocity, Image image) : base(position, image)
        {
            Velocity.SetCoordinates(velocity);
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
            // X
            if (Position.X + Size.X < 0.0F)
            {
                Position.X = Core.WindowWidth - 1.0F;
            }
            else if (Position.X >= Core.WindowWidth)
            {
                Position.X = 0.0F;
            }
            // Y
            if (Position.Y + Size.Y < 0.0F)
            {
                Position.Y = Core.WindowHeight - 1.0F;
            }
            else if (Position.Y >= Core.WindowHeight)
            {
                Position.Y = 0.0F;
            }
        }
    }
}
