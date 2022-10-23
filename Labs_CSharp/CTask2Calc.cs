namespace Labs_CSharp
{
    internal class CTask2Calc : CTask
    {
        protected int x, y, z;

        /// <summary>Конструктор</summary>
        public CTask2Calc() : base()
        {
            Number = "2";
            Description = "Calc: Y-sqrt(X))/Z";
        }

        /// <summary>Чтение данных</summary>
        public override bool ReadingData()
        {
            x = CInputOutput.ReadNumber("X", true, false);
            y = CInputOutput.ReadNumber("Y");
            z = CInputOutput.ReadNumber("Z", false);
            return true;
        }

        /// <summary>Расчет</summary>
        public override bool Сalculation()
        {            
            Rezult = $"{Description} = {Formula(x, y, z)}";
            return true;
        }

        /// <summary>Вывод результата</summary>
        public string Formula(int x, int y, int z)
        {
            double rez = (y - Math.Sqrt(x)) / z;
            return $"{rez:F3}";
        }
    }
}