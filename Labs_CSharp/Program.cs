using Labs_CSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        CStart start;

        // Смотрим есть ли параметры в командной строке
        if (args.Length == 0)
            start = new CStart();
        else
            start = new CStartCommand();

        start.BuildingListTasks();        
        start.RunTask();
    }
}