namespace Labs_CSharp
{
    internal class CTask0Exit : CTask
    {
        /// <summary>Конструктор</summary>
        public CTask0Exit() : base()       
        {
            Number = "0";
            Description = "Exit";
        }

        /// <summary>Запуск задачи</summary>
        public override void Run()
        {
            // Выходим из программы
            Environment.Exit(0);            
        }
    }
}