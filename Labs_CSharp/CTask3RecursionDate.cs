namespace Labs_CSharp
{
    internal class CTask3RecuriosnDate : CTask
    {
        protected DateTime dataAStart, dataAEnd, dataBStart, dataBEnd;


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
            int n = IntervalN(dataAStart, dataAEnd, dataAStart, dataBStart);
            if (n == 0)
            {
                // Как минимум для Фиббоначи
                Rezult = $"Расчет невозможен, так как пересечений интервалов дат нет. N = 0";
                return true;
            }

            Rezult = Fibonachi(n);
            return true;
        }

        /// <summary>Расчет интервала</summary>
        public int IntervalN(DateTime d1st, DateTime d1end, DateTime d2st, DateTime d2end)
        {
            if (d1end < d2st || d2end < d1st)
                return 0;

            DateTime dst = d1st > d2st ? d1st : d2st;
            DateTime dend = d1end < d2end ? d1end : d2end;
            TimeSpan interval = dend - dst;
            return interval.Days + 1;
        }

        /// <summary>Выводим ряд Фибоначчи</summary>
        protected string Fibonachi(int n)
        {
            string fib = $"Ряд Фибоначчи для N = {n}: 0";

            int j = 1;
            for (int i = 1; i <= n; i += j)
            {
                j = i - j;
                fib += " " + i;
            }
            return fib;
        }
    }
}