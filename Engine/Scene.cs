using System.Collections.Generic;
using System.Drawing;

namespace Engine
{
    /// <summary>
    /// Двумерное пространство, 
    /// </summary>
    public class Scene : IUpdatable, IDrawable
    {
        // Объекты сцены хранятся в словаре в виде пар <ID объекта, объект>.
        private Dictionary<int, SceneObject> sceneObjects = new Dictionary<int, SceneObject>();
        private Dictionary<int, IUpdatable> updatables = new Dictionary<int, IUpdatable>();
        private Dictionary<int, IDrawable> drawables = new Dictionary<int, IDrawable>();
        private Dictionary<int, ICollidable> collidables = new Dictionary<int, ICollidable>();

        // Хранилище отложенных объектов для последующего добавления на сцену или
        // удаления с цены. Это нужно, так как при итерировании содержимого сцены
        // какой-нибудь объект может добавить новый объект, а напрямую так делать
        // нельзя - Dictionary выкинет исключение.
        private Queue<SceneObject> sceneDeferredAdd = new Queue<SceneObject>();
        private Queue<int> sceneDeferredRemove = new Queue<int>();
        
        /// <summary>
        /// Добавляет на сцену новый объект сцены.
        /// </summary>
        /// <param name="so"></param>
        public void Add(SceneObject so) => sceneDeferredAdd.Enqueue(so);

        /// <summary>
        /// Удаляет со сцены объект.
        /// </summary>
        /// <param name="ID">ID объекта.</param>
        /// <returns></returns>
        public void Remove(int ID) => sceneDeferredRemove.Enqueue(ID);

        /// <summary>
        /// Удаляет со сцены объект.
        /// </summary>
        /// <param name="so">Объект сцены.</param>
        /// <returns></returns>
        public void Remove(SceneObject so) => Remove(so.ID);

        /// <summary>
        /// По-настоящему добавляет/удаляет все ожидающие этого объекты сцены.
        /// Для внутреннего использования.
        /// </summary>
        private void ResolveDeferredObjects()
        {
            SceneObject so;
            int ID;
            // Add
            while (sceneDeferredAdd.Count > 0)
            {
                so = sceneDeferredAdd.Dequeue();
                sceneObjects.Add(so.ID, so);
                so.RememberParentScene(this);
                if (so is IUpdatable updso) updatables.Add(so.ID, updso);
                if (so is IDrawable drwso) drawables.Add(so.ID, drwso);
                if (so is ICollidable cldso) collidables.Add(so.ID, cldso);
            }
            // Remove
            while (sceneDeferredRemove.Count > 0)
            {
                ID = sceneDeferredRemove.Dequeue();
                if (sceneObjects.Remove(ID))
                {
                    updatables.Remove(ID);
                    drawables.Remove(ID);
                    collidables.Remove(ID);
                }
            }
        }

        /// <summary>
        /// Отрисовывает все объекты сцены.
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            ResolveDeferredObjects();
            foreach (IDrawable obj in drawables.Values)
            {
                obj.Draw(g);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            ResolveDeferredObjects();
            foreach (IUpdatable obj in updatables.Values)
            {
                obj.Reset();
            }
        }

        /// <summary>
        /// Обновляет состояние всех объектов на сцене.
        /// </summary>
        /// <param name="dt">Интервал времени в секундах.</param>
        public void Update(float dt)
        {
            ResolveDeferredObjects();
            foreach (IUpdatable obj in updatables.Values)
            {
                obj.Update(dt);
            }
            
            // Наиглупейший, малопроизводительный подход к проверке
            // столкновений. Каждый с каждым. Надо будет переделать:
            // разбить пространство регулярной квадратной сеткой на
            // кластеры, и проверять между собой объекты в кластере,
            // а не всех со всеми.
            foreach (ICollidable objA in collidables.Values)
            {
                foreach (ICollidable objB in collidables.Values)
                {
                    if (objA == objB) continue;
                    objA.Collide(objB);
                }
            }
        }
    }
}
