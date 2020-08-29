namespace Engine
{
    /// <summary>
    /// Математический аппарат игрового движка (система координат левая).
    /// </summary>
    namespace Math
    {
        /// <summary>
        /// Двумерный вектор в евклидовом пространстве.
        /// </summary>
        public class Vector2
        {
            /// <summary>
            /// Абсцисса (значение по оси OX).
            /// </summary>
            public float X { set; get; }

            /// <summary>
            /// Ордината (значение по оси OY).
            /// </summary>
            public float Y { set; get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Vector2(float x, float y)
            {
                SetCoordinates(x, y);
            }

            /// <summary>
            /// 
            /// </summary>
            public Vector2() : this(0.0F, 0.0F)
            {
                // That is all.
            }

            /// <summary>
            /// 
            /// </summary>
            public float LengthPow2
            {
                get => X * X + Y * Y;
            }

            /// <summary>
            /// 
            /// </summary>
            public float Length
            {
                get => System.Convert.ToSingle(System.Math.Sqrt(LengthPow2));
            }

            /// <summary>
            /// Устанавливает значения координат покомпонентно.
            /// </summary>
            /// <param name="x">Абсцисса (значение по оси OX).</param>
            /// <param name="y">Ордината (значение по оси OY).</param>
            public void SetCoordinates(float x, float y)
            {
                X = x;
                Y = y;
            }

            /// <summary>
            /// Устанавливает значения координат через заданный вектор.
            /// </summary>
            /// <param name="v">Координаты в векторной форме.</param>
            public void SetCoordinates(Vector2 v)
            {
                X = v.X;
                Y = v.Y;
            }

            /// <summary>
            /// Возвращает вектор единичный длины, сонаправленный данному.
            /// </summary>
            /// <returns></returns>
            public Vector2 Normalized()
            {
                float L = Length;
                return (L < float.Epsilon) ? new Vector2() : this / L;
            }

            /// <summary>
            /// Возвращает вектор - результат отражения исходного вектора относительно
            /// оси отражения.
            /// </summary>
            /// <param name="line">Направляющий вектор оси отражения.</param>
            /// <returns>Отражённый вектор.</returns>
            public Vector2 Mirrored(Vector2 line)
            {
                Vector2 n_line = line.Normalized();
                return 2.0F * n_line * (this * n_line) - this;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="v"></param>
            /// <returns></returns>
            public static Vector2 operator -(Vector2 v) => new Vector2(-v.X, -v.Y);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="k"></param>
            /// <param name="v"></param>
            /// <returns></returns>
            public static Vector2 operator *(float k, Vector2 v) => new Vector2(k * v.X, k * v.Y);
            

            /// <summary>
            /// 
            /// </summary>
            /// <param name="v"></param>
            /// <param name="k"></param>
            /// <returns></returns>
            public static Vector2 operator *(Vector2 v, float k) => new Vector2(v.X * k, v.Y * k);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static float operator *(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="v"></param>
            /// <param name="k"></param>
            /// <returns></returns>
            public static Vector2 operator /(Vector2 v, float k) => new Vector2(v.X / k, v.Y / k);

            /// <summary>
            /// Аналог векторного произведения в двумерном пространстве (система координат левая).
            /// В данном случае вместо результирующего вектора возвращается его длина (с учётом
            /// знака полупространства).
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static float operator ^(Vector2 a, Vector2 b) => a.Y * b.X - a.X * b.Y;
        }
    }
}
