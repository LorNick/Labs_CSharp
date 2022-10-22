namespace Labs_CSharp
{
    /// <summary>Стартуем программу (по умолчанию в консоли)</summary>
    internal class CStartCommand : CStart
    {
        /// <summary>Формируем список задач</summary>
        public override void BuildingListTasks()
        {
            tasks.Add(new CTask0Exit());
            tasks.Add(new CTask1HelloWorld());
            tasks.Add(new CTask2CalcCommand());
            tasks.Add(new CTask3RecuriosnDateCommand());
            tasks.Add(new CTask4StringsCommand());
        }

        /// <summary>Запускаем задачу</summary>
        public override void RunTask()
        {
            // Ищем задачу по найденному номеру задачи из командной строки
            var task = FindTask(CInputOutput.FindPar("-mi"));
            if (task != null)
                task.Run();
        }
    }
}
