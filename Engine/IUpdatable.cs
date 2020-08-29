namespace Engine
{
    /// <summary>
    /// Задаёт интерфейс обновления состояния объекта.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Сбрасывает состояние объекта в исходное.
        /// </summary>
        void Reset();

        /// <summary>
        /// Обновляет состояние объекта.
        /// </summary>
        /// <param name="dt">Интервал времени в секундах.</param>
        void Update(float dt);
    }
}
