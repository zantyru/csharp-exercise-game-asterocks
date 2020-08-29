using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine;
using Engine.Math;

namespace Asterocks
{
    public class Ship : Sprite, IMovable, IUpdatable, ICollidable
    {
        // Кадры анимации и текущий кадр (с долями)
        public const int ANIMATION_SPEED = 12;
        private List<Image> listFrames;
        private float currentFrame;

        // Таймер стрельбы
        private float timeShoot = 0.0F;

        // Настройки корабля
        public const float MOTION_SPEED = 300.0F; // Пикселей в секунду
        public const float SHOOT_SPEED = 3.0F; // Пуль в секунду

        /// <summary>
        /// Скорость и направление перемещения объекта.
        /// </summary>
        public Vector2 Velocity { set; get; } = new Vector2();

        /// <summary>
        /// Инициализирует объект.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="image"></param>
        public Ship(Vector2 position) : base(position, null)
        {
            listFrames = new List<Image>
            {
                Image.FromFile(Const.FILENAME_SHIP0001_FRAME00),
                Image.FromFile(Const.FILENAME_SHIP0001_FRAME01)
            };
            currentFrame = 0.0F;
            this.Image = listFrames[(int)currentFrame];
            //Velocity.SetCoordinates(velocity);
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
        /// Обновляет состояние объекта.
        /// </summary>
        /// <param name="dt">Интервал времени в секундах.</param>
        public void Update(float dt)
        {
            // Пользовательский ввод
            Velocity.SetCoordinates(0.0F, 0.0F);
            bool isUp = Core.Keyboard.RecallKeyState((int)Keys.Up) == Keyboard.KeyState.KEY_DOWN;
            bool isDown = Core.Keyboard.RecallKeyState((int)Keys.Down) == Keyboard.KeyState.KEY_DOWN;
            bool isLeft = Core.Keyboard.RecallKeyState((int)Keys.Left) == Keyboard.KeyState.KEY_DOWN;
            bool isRight = Core.Keyboard.RecallKeyState((int)Keys.Right) == Keyboard.KeyState.KEY_DOWN;
            bool isShoot = Core.Keyboard.RecallKeyState((int)Keys.Space) == Keyboard.KeyState.KEY_DOWN;

            if (isUp)
            {
                Velocity.Y += -1.0F;
            }

            if (isDown)
            {
                Velocity.Y += 1.0F;
            }

            if (isLeft)
            {
                Velocity.X += -1.0F;
            }

            if (isRight)
            {
                Velocity.X += 1.0F;
            }

            Velocity = Velocity.Normalized() * MOTION_SPEED;

            if (isShoot && IsShootTime()) Shoot();

            // Вид
            currentFrame += dt * ANIMATION_SPEED;
            this.Image = listFrames[(int)System.Math.Floor(currentFrame) % listFrames.Count];

            // Положение
            Move(Velocity, dt);
            // X
            if (Position.X < 0.0F)
            {
                Position.X = 0.0F;
            }
            else if (Position.X + Size.X >= Core.WindowWidth)
            {
                Position.X = Core.WindowWidth - Size.X;
            }
            // Y
            if (Position.Y < 0.0F)
            {
                Position.Y = 0.0F;
            }
            else if (Position.Y + Size.Y >= Core.WindowHeight)
            {
                Position.Y = Core.WindowHeight - Size.Y;
            }

            // Таймер стрельбы
            timeShoot -= dt;
            if (timeShoot < 0.0F) timeShoot = 0.0F;
        }

        /// <summary>
        /// Просчитывает столкновение корабля с астероидами.
        /// </summary>
        /// <param name="obj">Объект, с которым проверяется столкновение.</param>
        public void Collide(ICollidable obj)
        {
            if (!(obj is Asteroid asteroid)) return;
            bool xOverlap = (asteroid.Position.X >= Position.X) && (asteroid.Position.X < Position.X + Size.X) ||
                            (asteroid.Position.X + asteroid.Size.X >= Position.X) && (asteroid.Position.X + asteroid.Size.X < Position.X + Size.X);
            bool yOverlap = (asteroid.Position.Y >= Position.Y) && (asteroid.Position.Y < Position.Y + Size.Y) ||
                            (asteroid.Position.Y + asteroid.Size.Y >= Position.Y) && (asteroid.Position.Y + asteroid.Size.Y < Position.Y + Size.Y);
            // 1--------2             3----4
            // 1------3=2--4
            //            1-3====4-2
            //                        3-1==4-----2
            if (xOverlap && yOverlap)
            {
                ParentScene.Remove(asteroid);
                ParentScene.Remove(this);
                ParentScene.Add(new TitleGameOver());
            }
        }

        /// <summary>
        /// Показывает, пришло ли время очередного выстрела.
        /// </summary>
        /// <returns>true - можно выпустить очередную пулю, false - стрелять ещё рано.</returns>
        private bool IsShootTime() => timeShoot == 0.0F;

        /// <summary>
        /// Осуществляет стрельбу: добавляет на сцену пулю ().
        /// </summary>
        private void Shoot()
        {
            Bullet bullet = new Bullet(new Vector2(), new Vector2(1.0F, 0.0F));
            bullet.Position.SetCoordinates(
                Position.X + Size.X,
                Position.Y + (Size.Y - bullet.Size.Y) / 2.0F
            );
            ParentScene.Add(bullet);
            timeShoot = 1.0F / SHOOT_SPEED;
        }
    }
}
