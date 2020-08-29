namespace Engine
{
    /// <summary>
    /// Описывает объект сцены, который обладает свойством конкретного
    /// позиционирования в её пределах.
    /// </summary>
    public class ScenePositionableObject : SceneObject
    {
        /// <summary>
        /// Координаты объекта в пространстве игровой сцены.
        /// </summary>
        public Math.Vector2 Position { set; get; }

        /// <summary>
        /// Размер объекта (минимальный прямоугольник, в который
        /// помещается объект).
        /// </summary>
        public Math.Vector2 Size { set; get; }

        /// <summary>
        /// Инициализирует объект положением в пространстве и размером.
        /// </summary>
        /// <param name="position">Координаты объекта на игровой сцене.</param>
        /// <param name="size">Размер объекта.</param>
        public ScenePositionableObject(Math.Vector2 position, Math.Vector2 size)
        {
            Position = position;
            Size = size;
        }

        /// <summary>
        /// Инициализирует объект только положением в пространстве. Размер при этом
        /// устанавливается в ноль.
        /// </summary>
        /// <param name="position">Координаты объекта на игровой сцене.</param>
        public ScenePositionableObject(Math.Vector2 position) : this(position, new Math.Vector2())
        {
            // That is all
        }

        /// <summary>
        /// Инициализирует объект нулевыми значениями координат и размера.
        /// </summary>
        public ScenePositionableObject() : this(new Math.Vector2(), new Math.Vector2())
        {
            // That is all
        }
    }
}
