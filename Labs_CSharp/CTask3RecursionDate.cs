namespace Labs_CSharp
{
    internal class CTask3RecuriosnDate : CTask
    {
        protected DateTime dataAStart, dataAEnd, dataBStart, dataBEnd;

        protected int N;

        /// <summary>Конструктор</summary>
        public CTask3RecuriosnDate() : base()
        {
            Number = "3";
            Description = "Recursion date";
        }

        /// <summary>Чтение данных</summary>
        public override bool ReadingData()
        {
            dataAStart = CInputOutput.ReadDate("Начальная дата 1го диапазона");
            dataAEnd = CInputOutput.ReadDate("Конечная дата 1го диапазона", dataAStart);
            dataBStart = CInputOutput.ReadDate("Начальная дата 2го диапазона");
            dataBEnd = CInputOutput.ReadDate("Конечная дата 2го диапазона", dataBStart);
            return true;
        }

        /// <summary>Расчет</summary>
        public override bool Сalculation()
        {
            if (dataAEnd < dataBStart || dataBEnd < dataAStart)
            {
                // Как минимум для Фиббоначи
                Rezult = $"Расчет невозможен, так как пересечений интервалов дат нет. N = 0";
                return true;
            }

            DateTime dateStart = dataAStart > dataBStart ? dataAStart : dataBStart;
            DateTime dateEnd = dataAEnd < dataBEnd ? dataAEnd : dataBEnd;
            TimeSpan interval = dateEnd - dateStart;
            N = interval.Days + 1;

            Rezult = Fibonachi();
            return true;
        }

        /// <summary>Выводим ряд Фибоначчи</summary>
        protected string Fibonachi()
        {
            string fib = $"Ряд Фибоначчи для N = {N}: 0";

            int j = 1;
            for (int i = 1; i <= N; i += j)
            {
                j = i - j;
                fib += " " + i;
            }
            return fib;
        }
    }
}
