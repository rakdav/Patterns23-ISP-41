DatabaseHelper.GetConnection().InsertData("123");
Console.WriteLine("Data: "+DatabaseHelper.GetConnection().SelectData());

public class DatabaseHelper
{
    private string _data;
    private static DatabaseHelper Instance;
    private DatabaseHelper() => Console.WriteLine("connection to database");
    public static DatabaseHelper GetConnection()
    {
        if(Instance == null)
            Instance = new DatabaseHelper();
        return Instance;
    }
    public string SelectData()=>_data;
    public void InsertData(string d)
    {
        Console.WriteLine("new data: " + d + "(entered into the database)");
        _data = d;
    }
}


