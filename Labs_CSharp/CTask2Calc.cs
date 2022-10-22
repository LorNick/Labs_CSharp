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
            double rez = ((double)y - Math.Sqrt(x)) / z;
            Rezult = $"(Y-sqrt(X))/Z = ({y}-sqrt({x})/{z} = {rez:F3}";
            return true;
        }
    }
}