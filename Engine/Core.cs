using System;
using System.Collections.Generic;
using System.Drawing;

namespace Engine
{
    /// <summary>
    /// Главный цикл жизни приложения: обработка очереди сообщений, обработка пользовательского
    /// ввода, работа логики движка, отрисовка изображения.
    /// </summary>
    public static class Core
    {
        // Время
        private static DateTime timePrev = DateTime.UtcNow;

        // Графика
        private static BufferedGraphicsContext gfxContext = BufferedGraphicsManager.Current;
        private static BufferedGraphics gfxBuffer;

        // Сцены в именованных группах
        private static Dictionary<string, List<Scene>> sceneGroups = new Dictionary<string, List<Scene>>();

        // Флаг подготовки группы сцен, список сцен на добавление, имя группы
        private static bool isGrouping = false;
        private static List<Scene> sceneGroup = new List<Scene>();
        private static string nameGroup;

        /// <summary>
        /// Общее время жизни приложения с начала запуска.
        /// </summary>
        public static float Time { get; private set; } = 0.0F;

        /// <summary>
        /// Источник (псевдо) случайных чисел.
        /// </summary>
        public static Random Random { get; } = new Random();

        /// <summary>
        /// Ширина области отрисовки графики.
        /// </summary>
        public static int WindowWidth { get; private set; } = 0;

        /// <summary>
        /// Высота области отрисовки графики.
        /// </summary>
        public static int WindowHeight { get; private set; } = 0;

        /// <summary>
        /// Хранилище состояний клавиш клавиатуры.
        /// </summary>
        public static Keyboard Keyboard { get; } = new Keyboard();

        /// <summary>
        /// Текущая группа сцен (имя).
        /// </summary>
        public static string CurrentSceneGroup { set; get; } = string.Empty;

        /// <summary>
        /// Настраивает размер области отрисовки и графический буфер.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Initialize(Graphics g, int width, int height)
        {
            // TODO throw 
            WindowWidth = width;
            WindowHeight = height;
            gfxBuffer = gfxContext.Allocate(g, new Rectangle(0, 0, WindowWidth, WindowHeight));
        }

        /// <summary>
        /// Проверяет наличие группы сцен с заданным именем.
        /// </summary>
        /// <param name="sgName">Имя группы сцен</param>
        /// <returns>true - сцена существует, false в противном случае.</returns>
        public static bool ContainsSceneGroup(string sgName) => sceneGroups.ContainsKey(sgName);

        /// <summary>
        /// Задаёт начало создания группы сцен.
        /// </summary>
        /// <param name="sgName">Имя создаваемой группы сцен.</param>
        public static void SceneGroupBegin(string sgName)
        {
            if (isGrouping) throw new SceneGroupAlreadyBegun();
            if (sgName == string.Empty) throw new SceneGroupCanNotHaveEmptyName();
            if (ContainsSceneGroup(sgName)) throw new SceneGroupAlreadyExists();
            isGrouping = true;
            nameGroup = sgName;
        }

        /// <summary>
        /// Завершает создание группы сцен. Группа становится доступной
        /// по ранее заданному имени.
        /// </summary>
        public static void SceneGroupEnd()
        {
            if (!isGrouping) throw new SceneGroupEndedWithoutBeginning();
            isGrouping = false;
            sceneGroups.Add(nameGroup, sceneGroup);
            sceneGroup = new List<Scene>();
        }

        /// <summary>
        /// Удаляет группу сцен.
        /// </summary>
        /// <param name="sgName">Имя удаляемой группы.</param>
        public static void SceneGroupRemove(string sgName)
        {
            if (!sceneGroups.Remove(sgName)) throw new SceneGroupDoesNotExists();
        }

        /// <summary>
        /// Добавляет сцену в создаваемую группу.
        /// </summary>
        /// <param name="scene">Сцена.</param>
        public static void AddScene(Scene scene)
        {
            if (!isGrouping) throw new SceneGroupDoesNotBegunYet();
            sceneGroup.Add(scene);
        }

        /// <summary>
        /// Обрабатывает очередной кадр с обновлением состояние всех объектов
        /// на всех сценах.
        /// </summary>
        public static void ProcessFrame()
        {
            if (isGrouping) throw new SceneGroupBegunDuringFrameProcessing();
            if (!ContainsSceneGroup(CurrentSceneGroup)) throw new SceneGroupDoesNotExists();

            // Вычисляем очередной интервал времени
            DateTime timeNow = DateTime.UtcNow;
            TimeSpan timeSpan = timeNow - timePrev;
            timePrev = timeNow;
            float dt = Convert.ToSingle(timeSpan.TotalSeconds);

            // Общее время выполнения
            Time += dt;

            // Обновление сцен и их отрисовка
            foreach (Scene scene in sceneGroups[CurrentSceneGroup])
            {
                scene.Update(dt);
                if (gfxBuffer == null) continue;
                scene.Draw(gfxBuffer.Graphics);
            }

            // Окончательная отрисовка - вывод графического буфера
            gfxBuffer?.Render();
        }
    }
}
