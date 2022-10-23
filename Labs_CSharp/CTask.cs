namespace Labs_CSharp
{
    /// <summary>Пункт задачи в меню</summary>
    internal class CTask
    {
        /// <summary>Номер задачи в меню</summary>
        public string Number { get; set; } = "";

        /// <summary>Описание пункта задачи</summary>
        public string Description { get; set; } = "";

        /// <summary>Описание пункта задачи в меню</summary>
        public string Munu { get { return $"[{Number}] {Description}"; } }

        /// <summary>Результат</summary>
        public string Rezult { get; set; } = "";


        /// <summary>Выводим в консоль элемент меню (ToString)</summary>
        public void WriteMenu()
        {
            CInputOutput.Write(Munu);
        }

        /// <summary>Запускаем задачу</summary>
        public virtual void Run()
        {
            if (ReadingData())
                if (Сalculation())
                    WriteRezult();
        }

        /// <summary>Чтение данных</summary>
        public virtual bool ReadingData()
        {
            return true;
        }

        /// <summary>Расчет</summary>
        public virtual bool Сalculation()
        {
            return true;
        }

        /// <summary>Вывод результата</summary>
        public void WriteRezult()
        {
            CInputOutput.Write(Rezult);            
        }
    }
}
