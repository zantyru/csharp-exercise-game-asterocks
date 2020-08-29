namespace Asterocks
{
    /// <summary>
    /// Сборник константных значений, используемых в разных местах кода игры.
    /// </summary>
    public static class Const
    {
        // * * * * * Группы  сцен *

        /// <summary>
        /// Имя группы сцен, изображающей главное меню.
        /// </summary>
        public const string SG_MAIN_MENU = "MainMenu";

        /// <summary>
        /// Имя группы сцен, изображающей основной игровой процесс.
        /// </summary>
        public const string SG_GAME_PLAY = "GamePlay";

        // * * * * * Изображения *

        /// <summary>
        /// Имя файла фонового изображения в главном меню.
        /// </summary>
        public const string FILENAME_BG_MAINMENU = @"..\..\pictures\bgmainmenu.png";

        /// <summary>
        /// Имя файла фонового изображения звёздного неба.
        /// </summary>
        public const string FILENAME_BG_STARFIELD0001 = @"..\..\pictures\bgstarfield0001.png";

        /// <summary>
        /// Имя файла фонового изображения звёздного неба.
        /// </summary>
        public const string FILENAME_BG_STARFIELD0002 = @"..\..\pictures\bgstarfield0002.png";

        /// <summary>
        /// Имя файла изображения со звездой.
        /// </summary>
        public const string FILENAME_STAR0001 = @"..\..\pictures\star0001.png";

        /// <summary>
        /// Имя файла изображения со звездой.
        /// </summary>
        public const string FILENAME_STAR0002 = @"..\..\pictures\star0002.png";

        /// <summary>
        /// Имя файла изображения корабля (одного кадра анимации).
        /// </summary>
        public const string FILENAME_SHIP0001_FRAME00 = @"..\..\pictures\ship0001-frame00.png";

        /// <summary>
        /// Имя файла изображения корабля (одного кадра анимации).
        /// </summary>
        public const string FILENAME_SHIP0001_FRAME01 = @"..\..\pictures\ship0001-frame01.png";

        /// <summary>
        /// Имя файла изображения пули.
        /// </summary>
        public const string FILENAME_BULLET0001 = @"..\..\pictures\bullet0001.png";

        /// <summary>
        /// Имя файла изображения астероида.
        /// </summary>
        public const string FILENAME_ASTEROID0001 = @"..\..\pictures\asteroid0001.png";

        /// <summary>
        /// Имя файла изображения астероида.
        /// </summary>
        public const string FILENAME_ASTEROID0002 = @"..\..\pictures\asteroid0002.png";

        /// <summary>
        /// Имя файла изображения астероида.
        /// </summary>
        public const string FILENAME_ASTEROID0003 = @"..\..\pictures\asteroid0003.png";

        // * * * * * Исходные параметры объектов *

        /// <summary>
        /// Исходное максимальное количество здоровья у корабля игрока.
        /// </summary>
        public const int PLAYER_HEALTH_MAX_DEFAULT = 100;
    }
}
