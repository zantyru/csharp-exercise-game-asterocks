using System.Collections.Generic;

namespace Engine
{
    /// <summary>
    /// Базовый класс для всех объектов сцены. Имеет конструктор с уровнем
    /// доступа protected, что запрещает создание экземпляров этого класса
    /// напрямую. Это можно сделать косвенно, будучи его потомком.
    /// </summary>
    public class SceneObject
    {
        /// <summary>
        /// Следующий наибольший свободный идентификатор.
        /// </summary>
        private static int nextBiggestID = 0;

        /// <summary>
        /// Очередь бывших в употреблении идентификаторов.
        /// </summary>
        private static Queue<int> prevDisposedIDs = new Queue<int>();

        /// <summary>
        /// Уникальный идентификатор данного объекта.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Сцена, которая хранит данный объект.
        /// </summary>
        public Scene ParentScene { get; private set; }

        /// <summary>
        /// Этот конструктор инициализирует объект, назначая ему новый уникальный
        /// идентификатор.
        /// </summary>
        protected SceneObject()
        {
            if (prevDisposedIDs.Count > 0)
            {
                ID = prevDisposedIDs.Dequeue();
            }
            else
            {
                ID = nextBiggestID;
                nextBiggestID++;
            }
        }

        /// <summary>
        /// Освобождает ресурсы объекта. В данном случае идентификатор.
        /// </summary>
        ~SceneObject()
        {
            if (ID == nextBiggestID - 1)
            {
                nextBiggestID--;
            }
            else
            {
                prevDisposedIDs.Enqueue(ID);
            }
        }

        /// <summary>
        /// Сохраняет ссылку на родительскую сцену. Этот метод вызывается
        /// сценой, когда она регистрирует данный объект.
        /// </summary>
        /// <param name="scene">Сцена, на которой размещается объект.</param>
        public void RememberParentScene(Scene scene)
        {
            ParentScene = scene;
        }
    }
}
