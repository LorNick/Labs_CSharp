namespace Labs_CSharp
{
    /// <summary> Класс для ввода-вывода данных</summary>
    /// <remarks>Задание 5. Приемка 2. Проверить, что выделен класс для ввода-вывода данных.</remarks>
    internal static class CInputOutput
    {
        /// <summary>Поиск параметра в командной строке по имени параметра</summary>        
        /// <param name="par">Имя параметра</param>
        /// <return>Возвращает значение параметра (если значение не найдено, то пусто)</return>
        public static string FindPar(string par)
        {            
            string[] args = Environment.GetCommandLineArgs(); // параметры командной строки
            string valuePar = "";
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == par)
                    valuePar = args[i + 1];
            }
            return valuePar;
        }

        /// <summary>Запрашиваем число через консоль</summary>
        /// <param name="name">Описание параметра</param>
        /// <param name="zero">Может ли число быть нулём (по умолчанию - ДА)</param>
        /// <param name="minus">Может ли число быть отрицательным (по умолчанию - ДА)</param>
        /// <returns>Наше число. Если ошибка то просим ввести данные заново</returns>
        public static int ReadNumber(string name, bool zero = true, bool minus = true)
        {
            int rezult = 0;
            bool success = false;

            while (!success)
            {                
                string val = Read(name);
                success = int.TryParse(val, out int value);
                if (!success)
                    Console.WriteLine($"WARN: Unable to parse {name} = '{val}'");

                if (!minus && value < 0)
                {
                    Console.WriteLine($"WARN: Не может быть отрицательным {name} = {value}");
                    success = false;
                }

                if (!zero && value == 0)
                {
                    Console.WriteLine($"WARN: На ноль делить нельзя {name} = {value}");
                    success = false;
                }
                rezult = value;
            }
            return rezult;
        }

        /// <summary>Запрашиваем число из командной строки</summary>
        /// <param name="name">Описание параметра</param>
        /// <param name="par">Имя параметра в командной строке</param>
        /// <param name="rezult">Наше число</param>
        /// <param name="zero">Может ли число быть нулём (по умолчанию - ДА)</param>
        /// <param name="minus">Может ли число быть отрицательным (по умолчанию - ДА)</param>
        /// <returns>Если ошибка то возвращаем false</returns>
        public static bool ReadNumber(string name, string par, out int rezult, bool zero = true, bool minus = true)
        {            
            bool success = true;
            rezult = 0;

            string val = CInputOutput.FindPar(par);

            Write($"{name}: {val}");
            try
            {
                rezult = Int32.Parse(val);

                if (!minus && rezult < 0)
                {
                    Console.WriteLine($"ERROR: Не может быть отрицательным {name} = {rezult}");
                    success = false;
                }

                if (!zero && rezult == 0)
                {
                    Console.WriteLine($"ERROR: На ноль делить нельзя {name} = {rezult}");
                    success = false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"ERROR: Unable to parse {name} = '{val}'");
                success = false;
            }

            return success;
        }

        /// <summary>Запрашиваем дату через консоль</summary>
        /// <param name="name">Описание параметра</param>
        /// <param name="minDate">Начальная дата (для проверки конечной даты диапазона)</param>
        /// <returns>Наша дата. Если ошибка то просим ввести данные заново</returns>
        public static DateTime ReadDate(string name, DateTime? minDate = null)
        {
            DateTime output;
            bool success;

            do
            {
                string val = Read(name);
                success = DateTime.TryParse(val, out output);
                if (!success)
                {
                    Console.WriteLine($"WARN: Unable to parse '{val}'");
                    continue;
                }

                if (minDate != null && minDate > output)
                {
                    Console.WriteLine($"WARN: Начальная дата {minDate:d} не может быть больше конечной {output:d}");
                    success = false;
                }
            } while (!success);
            return output;
        }

        /// <summary>Запрашиваем дату через консоль</summary>
        /// <param name="name">Описание параметра</param>
        /// <param name="par">Имя параметра в командной строке</param>
        /// <param name="rezult">Наша дата</param>
        /// <param name="minDate">Начальная дата (для проверки конечной даты диапазона)</param>
        /// <returns>Если ошибка то возвращаем false</returns>
        public static bool ReadDate(string name, string par, out DateTime rezult, DateTime? minDate = null)
        {           
            bool success;

            string val = CInputOutput.FindPar(par);

            Write($"{name}: {val}");

            success = DateTime.TryParse(val, out rezult);
            if (!success)
            {
                Console.WriteLine($"ERROR: Unable to parse '{val}'");
                return success;
            }

            if (minDate != null && minDate > rezult)
            {
                Console.WriteLine($"ERROR: Начальная дата {minDate:d} не может быть больше конечной {rezult:d}");
                success = false;
            }               

            return success;
        }

        /// <summary>Считываем текст с консоли</summary>
        /// <param name="text">Описание вводимого значения</param>
        public static string Read(string text)
        {
            Console.Write($"{text}: ");
            string value;
            do
            {
                value = Console.ReadLine() ?? "";
            } while (value == "");           
            return value;
        }

        /// <summary>Выводим текст в консоль</summary>
        public static void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
