namespace Labs_CSharp
{
    /// <summary>Стартуем программу (по умолчанию в консоли)</summary>
    internal class CStart
    {
        /// <summary>Список задач</summary>
        public List<CTask> tasks = new();

        /// <summary>Формируем список задач</summary>
        public virtual void BuildingListTasks()
        {
            tasks.Add(new CTask0Exit());
            tasks.Add(new CTask1HelloWorld());
            tasks.Add(new CTask2Calc());
            tasks.Add(new CTask3RecuriosnDate());
            tasks.Add(new CTask4Strings());
        }

        /// <summary>Запускаем задачу</summary>
        public virtual void RunTask()
        {
            while (true)
            {
                WriteMainMenu();

                var task = FindTask(CInputOutput.Read("Введите номер задачи"));    // находим задачу по номеру
                if (task != null)
                    task.Run();               // если нашли задачу, то выполняем её
            }
        }

        /// <summary>Выводим меню - список задач в консоль</summary>
        public void WriteMainMenu()
        {
            CInputOutput.Write("");
            foreach (CTask task in tasks)
                task.WriteMenu();
        }

        /// <summary>Ищем задачу по номеру</summary>
        /// <param name="number">Номер задачи</param>
        public CTask? FindTask(string number)
        {
            // Делаем перебор задач и сверяем их номер с заданным
            foreach (CTask task in tasks)
                if (number == task.Number)
                    return task;

            // Не нашли задачу по номеру
            CInputOutput.Write($"Ошибка, задача с номером '{number}' отсутсвтует!");
            return null;
        }
    }
}
