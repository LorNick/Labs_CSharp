namespace Labs_CSharp
{
    internal class CTask3RecuriosnDateCommand : CTask3RecuriosnDate
    {
        /// <summary>Чтение данных</summary>
        public override bool ReadingData()
        {
            bool rezultDataAStart = CInputOutput.ReadDate("Начальная дата 1го диапазона", "-d1st", out dataAStart);
            bool rezultdataAEnd = CInputOutput.ReadDate("Конечная дата 1го диапазона", "-d1end", out dataAEnd, dataAStart);
            bool rezultdataBStart = CInputOutput.ReadDate("Начальная дата 2го диапазона", "-d2st", out dataBStart);
            bool rezultdataBEnd = CInputOutput.ReadDate("Конечная дата 2го диапазона", "-d2end", out dataBEnd, dataBStart);

            if (!rezultDataAStart || !rezultdataAEnd || !rezultdataBStart || !rezultdataBEnd)
            {
                CInputOutput.Write("ERROR: Ошибка данных");
                return false;
            }

            return true;
        }
    }
}
