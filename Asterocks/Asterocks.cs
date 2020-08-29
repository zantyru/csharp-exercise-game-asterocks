using System;
using System.Drawing;
using Engine;

namespace Asterocks
{
    /// <summary>
    /// Реализует игровой процесс.
    /// </summary>
    public class Asterocks
    {
        /// <summary>
        /// Точка входа.
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args)
        {
            GameMainWindow gmw = new GameMainWindow(800, 600);
            PrepareScenes();
            Core.CurrentSceneGroup = Const.SG_MAIN_MENU;
            gmw.Run();
        }

        /// <summary>
        /// Создание объектов сцены и размещение их в пространстве игровой сцены.
        /// </summary>
        private static void PrepareScenes()
        {
            Core.SceneGroupBegin(Const.SG_MAIN_MENU);
            Core.AddScene(new SceneMenuMain());
            Core.SceneGroupEnd();

            Core.SceneGroupBegin(Const.SG_GAME_PLAY);
            Core.AddScene(new SceneGameBackground());
            Core.AddScene(new SceneGameStarField(
                450,
                new Engine.Math.Vector2(-200.0F, 0.0F),
                new Engine.Math.Vector2(190.0F, 0.0F),
                Image.FromFile(Const.FILENAME_STAR0001)
            ));
            Core.AddScene(new SceneGameStarField(
                25,
                new Engine.Math.Vector2(-350.0F, 0.0F),
                new Engine.Math.Vector2(100.0F, 0.0F),
                Image.FromFile(Const.FILENAME_STAR0002)
            ));
            Core.AddScene(new SceneGamePlay());
            Core.AddScene(new SceneGamePlayGUI());
            Core.SceneGroupEnd();
        }
    }
}
