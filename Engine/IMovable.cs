namespace Engine
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="dt">Интервал времени в секундах.</param>
        void Move(Math.Vector2 velocity, float dt);
    }
}
