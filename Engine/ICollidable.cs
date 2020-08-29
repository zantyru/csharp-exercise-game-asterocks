namespace Engine
{
    /// <summary>
    /// Задаёт интерфейс проверки и разрешения столкновений объектов.
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// Обслуживает столкновение объектов.
        /// </summary>
        /// <param name="obj">Объект, с которым проверяется столкновение.</param>
        void Collide(ICollidable obj);
    }
}
