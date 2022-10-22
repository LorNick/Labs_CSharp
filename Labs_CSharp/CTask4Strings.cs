using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Labs_CSharp
{
    internal class CTask4Strings : CTask
    {
        protected string str1 = "", str2 = "";

        /// <summary>Конструктор</summary>
        public CTask4Strings() : base()
        {
            Number = "4";
            Description = "Strings";
        }

        /// <summary>Чтение данных</summary>
        public override bool ReadingData()
        {
            str1 = CInputOutput.Read("1я строка");
            str2 = CInputOutput.Read("2я строка");
            return true;
        }

        /// <summary>Расчет</summary>
        public override bool Сalculation()
        {
            try
            {
                Validation1Compare(str1, str2);
                Rezult = $"Совпадают '{str1}', '{str2}' посимвольно";
            }
            catch (ValidationException ex)
            {
                Rezult = ex.Message;
            }

            try
            {
                Validation2CompareTrimLower(str1, str2);
                Rezult += $"\nСовпадают '{str1}', '{str2}' посимвольно (единый регистр, удалить лишние пробелы)";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            try
            {
                Validation3CompareReverse(str1, str2);
                Rezult += $"\nСтрока '{str1}' реверсированная строка c '{str2}'";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            try
            {
                Validation4Email(str1);
                Rezult += $"\nСтрока 1 '{str1}' email";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            try
            {
                Validation4Email(str2);
                Rezult += $"\nСтрока 2 '{str2}' email";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            try
            {
                Validation5Phone(str1);
                Rezult += $"\nСтрока 1 '{str1}' телефон";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            try
            {
                Validation5Phone(str2);
                Rezult += $"\nСтрока 2 '{str2}' телефон";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            try
            {
                Validation6IP(str1);
                Rezult += $"\nСтрока 1 '{str1}' IP-адрес";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            try
            {
                Validation6IP(str2);
                Rezult += $"\nСтрока 2 '{str2}' IP-адрес";
            }
            catch (ValidationException ex)
            {
                Rezult += "\n" + ex.Message;
            }

            return true;
        }

        /// <summary>Совпадают ли они посимвольно</summary>
        protected void Validation1Compare(string text1, string text2)
        {
            if (string.Compare(text1, text2) != 0)
                throw new ValidationException($"WARN: '{text1}' НЕ совпадает по символьно c '{text2}'");
        }

        /// <summary>Совпадают ли Если привести к одному регистру, удалить пробелы в начале и в конце + дублирование пробелов</summary>
        protected void Validation2CompareTrimLower(string text1, string text2)
        {
            // Regex.Replace(String, "\\s+", " ") - меняет множественные пробелы на 1 пробел
            if (string.Compare(Regex.Replace(text1.ToLower().Trim(), "\\s+", " "),
                                  Regex.Replace(text2.ToLower().Trim(), "\\s+", " ")) != 0)
                throw new ValidationException($"WARN: '{text1}' НЕ совпадает по символьно c '{text2}' (единый регистр, удалить лишние пробелы)");
        }

        /// <summary>Являются ли 1 строка перевёртышем к другой (символы в обратной последовательности)</summary>
        protected void Validation3CompareReverse(string text1, string text2)
        {
            // new string(text2.ToCharArray().Reverse().ToArray()) - реверсирование строки
            if (string.Compare(text1, new string(text2.ToCharArray().Reverse().ToArray())) != 0)
                throw new ValidationException($"WARN: '{text1}' НЕ реверсированная строка c '{text2}'");
        }

        /// <summary>Являются ли строки: email'ом (при помощи RegExp. Cм. https://ihateregex.io/)</summary>
        protected void Validation4Email(string text)
        {
            Regex reg = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+");
            if (!reg.IsMatch(text))
                throw new ValidationException($"WARN: '{text}' НЕ email");
        }

        /// <summary>Являются ли строки: тел. номером (при помощи RegExp. Cм. https://ihateregex.io/)</summary>
        protected void Validation5Phone(string text)
        {
            Regex reg = new Regex(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
            if (!reg.IsMatch(text))
                throw new ValidationException($"WARN: '{text}' НЕ телефон");
        }

        /// <summary>Являются ли строки: IP-адресом (при помощи RegExp. Cм. https://ihateregex.io/)</summary>
        protected void Validation6IP(string text)
        {
            Regex reg = new Regex(@"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");
            if (!reg.IsMatch(text))
                throw new ValidationException($"WARN: '{text}' НЕ IP-адрес");
        }
    }
}
