using Engine;

namespace Asterocks
{
    /// <summary>
    /// Сцена (слой) для вывода шкалы здоровья, очков и прочего подобного.
    /// </summary>
    public class SceneGamePlayGUI : Scene
    {
        public SceneGamePlayGUI()
        {
            Add(new GUIHealthBar());
        }
    }
}
