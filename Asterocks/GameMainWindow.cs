using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Engine;

namespace Asterocks
{
    public class GameMainWindow : Form
    {
        /// <summary>
        /// Инициализация главного окна приложения.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public GameMainWindow(int width, int height) : base()
        {
            ClientSize = new Size(width, height);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            DoubleBuffered = true;
            KeyPreview = true;
            KeyDown += new KeyEventHandler(HandleKeyDown);
            KeyUp += new KeyEventHandler(HandleKeyUp);
            Core.Initialize(CreateGraphics(), width, height);
        }

        /// <summary>
        /// Запускает главный цикл игрового приложения (опрос устройств
        /// ввода - обновление состояния - отрисовка состояния).
        /// </summary>
        public void Run()
        {
            Application.Idle += new EventHandler(this.HandleApplicationIdle);
            Show();
            Application.Run(this);
        }

        /// <summary>
        /// Обрабатывает нажатие клавиши.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Описание события клавиши.</param>
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            Core.Keyboard.RemeberKeyState((int)e.KeyCode, Keyboard.KeyState.KEY_DOWN);
        }

        /// <summary>
        /// Обрабатывает отжатие клавиши.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Описание события клавиши.</param>
        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            Core.Keyboard.RemeberKeyState((int)e.KeyCode, Keyboard.KeyState.KEY_UP);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                Core.ProcessFrame();
            }
        }

        /// <summary>
        /// Показывает, свободно ли приложение от обработки сообщений (пуста ли очередь сообщений), то есть
        /// готово ли оно выполнять методы движка.
        /// </summary>
        /// <returns>true, если приложение свободно от обработки сообщений, false в противном случае.</returns>
        private bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }

        /// <summary>
        /// Структура сообщения для очереди сообщений приложения.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        /// <summary>
        /// Возвращает данные из очереди сообщений приложения.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);
    }
}
