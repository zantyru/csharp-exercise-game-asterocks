using System;

namespace Engine
{
    /// <summary>
    /// Базовый класс для всех представлений ошибок движка.
    /// </summary>
    public class EngineException : Exception
    {
        public EngineException(string message) : base(message)
        { }
    }

    /// <summary>
    /// "Создание группы сцен уже начато."
    /// </summary>
    public class SceneGroupAlreadyBegun : EngineException
    {
        public SceneGroupAlreadyBegun() :
            base("Создание группы сцен уже начато.")
        { }
    }

    /// <summary>
    /// "Такое имя группы сцен уже существует."
    /// </summary>
    public class SceneGroupAlreadyExists : EngineException
    {
        public SceneGroupAlreadyExists() :
            base("Такое имя группы сцен уже существует.")
        { }
    }

    /// <summary>
    /// "Такой группы сцен не существует."
    /// </summary>
    public class SceneGroupDoesNotExists : EngineException
    {
        public SceneGroupDoesNotExists() :
            base("Такой группы сцен не существует.")
        { }
    }

    /// <summary>
    /// "Группа сцен не может иметь пустое имя."
    /// </summary>
    public class SceneGroupCanNotHaveEmptyName : EngineException
    {
        public SceneGroupCanNotHaveEmptyName() :
            base("Группа сцен не может иметь пустое имя.")
        { }
    }

    /// <summary>
    /// "Создание группы сцен ещё не начато."
    /// </summary>
    public class SceneGroupDoesNotBegunYet : EngineException
    {
        public SceneGroupDoesNotBegunYet() :
            base("Создание группы сцен ещё не начато.")
        { }
    }

    /// <summary>
    /// "Завершение создания группы без указания начала."
    /// </summary>
    public class SceneGroupEndedWithoutBeginning : EngineException
    {
        public SceneGroupEndedWithoutBeginning() :
            base("Завершение создания группы без указания начала.")
        { }
    }

    /// <summary>
    /// "Создание группы сцен во время обработки кадра."
    /// </summary>
    public class SceneGroupBegunDuringFrameProcessing : EngineException
    {
        public SceneGroupBegunDuringFrameProcessing() :
            base("Создание группы сцен во время обработки кадра.")
        { }
    }
}
