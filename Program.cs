class Program
{
    static void Main(string[] args)
    {
        // Определяем логическое выражение
        Func<bool, bool, bool, bool, bool, bool> expression = (a, b, c, d, e) => (!a && b) || c || (d && !e);

        // Переменные
        bool[] values = { false, true };

        List<string> truthTable = [];
        List<string> sdnfTerms = [];
        List<string> sknfTerms = [];

        Console.WriteLine("Таблица истинности:");
        Console.WriteLine("a b c d e | F");

        // Проходим по всем возможным комбинациям переменных
        foreach (bool a in values)
        {
            foreach (bool b in values)
            {
                foreach (bool c in values)
                {
                    foreach (bool d in values)
                    {
                        foreach (bool e in values)
                        {
                            // Вычисляем значение выражения
                            bool result = expression(a, b, c, d, e);

                            // Добавляем строку в таблицу истинности
                            truthTable.Add($"{Convert.ToInt32(a)} {Convert.ToInt32(b)} {Convert.ToInt32(c)} {Convert.ToInt32(d)} {Convert.ToInt32(e)} | {Convert.ToInt32(result)}");

                            // Формируем СДНФ (если результат истинный) иначе формируем СКНФ
                            if (result)
                            {
                                sdnfTerms.Add(GenerateTerm(a, b, c, d, e, true));
                            }
                            else 
                            {
                                sknfTerms.Add(GenerateTerm(a, b, c, d, e, false));
                            }
                        }
                    }
                }
            }
        }

        // Вывод таблицы истинности
        foreach (var row in truthTable)
        {
            Console.WriteLine(row);
        }

        // Вывод СДНФ
        Console.WriteLine("\nСДНФ:");
        Console.WriteLine(string.Join(" | ", sdnfTerms));

        // Вывод СКНФ
        Console.WriteLine("\nСКНФ:");
        Console.WriteLine(string.Join(" & ", sknfTerms));
    }

    static string GenerateTerm(bool a, bool b, bool c, bool d, bool e, bool isSdnf)
    {
        string term = "";
        term += isSdnf ? (a ? "a" : "!a") : (a ? "!a" : "a");
        term += isSdnf ? (b ? " & b" : " & !b") : (b ? " & !b" : " & b");
        term += isSdnf ? (c ? " & c" : " & !c") : (c ? " & !c" : " & c");
        term += isSdnf ? (d ? " & d" : " & !d") : (d ? " & !d" : " & d");
        term += isSdnf ? (e ? " & e" : " & !e") : (e ? " & !e" : " & e");
        return term;
    }
}
