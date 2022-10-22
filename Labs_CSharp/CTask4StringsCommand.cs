namespace Labs_CSharp
{
    internal class CTask4StringsCommand : CTask4Strings
    {
        /// <summary>Чтение данных</summary>
        public override bool ReadingData()
        {
            // Текст должен быть в двойных кавычках
            str1 = CInputOutput.FindPar("-s1");
            str2 = CInputOutput.FindPar("-s2");
            CInputOutput.Write("1я строка: " + str1);
            CInputOutput.Write("2я строка: " + str2);
            return true;
        }
    }
}
