namespace Labs_CSharp
{
    internal class CTask2CalcCommand : CTask2Calc
    {
        /// <summary>Запуск задачи</summary>
        public override bool ReadingData()
        {
            bool rezultX = CInputOutput.ReadNumber("X", "-x", out x, true, false);
            bool rezultY = CInputOutput.ReadNumber("Y", "-y", out y);
            bool rezultZ = CInputOutput.ReadNumber("Z", "-z", out z, false);

            if (!rezultX || !rezultY || !rezultZ)
            {
                CInputOutput.Write("ERROR: Ошибка данных");
                return false;
            }

            return true;
        }
    }
}