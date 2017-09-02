namespace Task.Models
{
    public enum TaskType
    {
        None = 0,
        /// <summary>
        /// Исследование объекта задачи
        /// </summary>
        Investigation = 1,
        /// <summary>
        /// Конвертация, перевод, обработка данных от клиента в задачи
        /// </summary>
        Translation = 2,
        /// <summary>
        /// Подготовка и сбор данных перед началом работ, вопросы заказчику, обсуждение со специалистами, проектирование
        /// </summary>
        Preparation = 3,
        /// <summary>
        /// Программирование, верстка, и т.п. Любой вид деятельности, направленный на информационный прирост объема проекта
        /// </summary>
        Implementation = 4,
        /// <summary>
        /// Отладка, поиск багов
        /// </summary>
        Debug = 5,
        /// <summary>
        /// Проверка качества, инспектирование
        /// </summary>
        Review = 6,
        /// <summary>
        /// Тестирование на предмет багов и UX
        /// </summary>
        Testing = 7,
        /// <summary>
        /// Написание документации, ТЗ, договора
        /// </summary>
        Documentation = 8,
        /// <summary>
        /// Консультирование, эстимейты, отчеты по коду
        /// </summary>
        Consulting = 9,
        /// <summary>
        /// Обсуждения, митинги, собеседования
        /// </summary>
        Communication = 10
    }
}