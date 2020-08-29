using System.Collections.Generic;

namespace Engine
{
    /// <summary>
    /// Хранилище состояний клавиш клавиатуры.
    /// </summary>
    public class Keyboard
    {
        /// <summary>
        /// Описывает состояние клавиши "нажата" или "отжата".
        /// </summary>
        public enum KeyState { KEY_UP, KEY_DOWN }

        /// <summary>
        /// Словарь состояний клавиш. Отсутствие кода клавиши в словаре
        /// расценивается как состояние клавиши по-умолчанию.
        /// </summary>
        private Dictionary<int, KeyState> state = new Dictionary<int, KeyState>();

        /// <summary>
        /// Запоминает состояние клавиши.
        /// </summary>
        /// <param name="keyCode">Код клавиши.</param>
        /// <param name="keyState">Состояние клавиши.</param>
        public void RemeberKeyState(int keyCode, KeyState keyState) => state[keyCode] = keyState;

        /// <summary>
        /// Возвращает ("вспоминает") состояние клавиши.
        /// </summary>
        /// <param name="keyCode">Код клавиши.</param>
        /// <returns></returns>
        public KeyState RecallKeyState(int keyCode) => state.ContainsKey(keyCode) ? state[keyCode] : KeyState.KEY_UP;
    }
}
