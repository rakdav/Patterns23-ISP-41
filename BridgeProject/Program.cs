Sender sender = new EmailSender(new DatabaseReader());
sender.Send();
sender.SetDataReader(new FileReader());
sender.Send();
sender = new TelegramBotSender(new DatabaseReader());
sender.Send();


interface IDataReader
{
    void Read();
}
class DatabaseReader : IDataReader
{
    public void Read() => Console.WriteLine("data from the database");
}
class FileReader : IDataReader
{
    public void Read() => Console.WriteLine("data from the file");
}
abstract class Sender
{
    protected IDataReader _reader;

    public Sender(IDataReader reader)
    {
        _reader = reader;
    }
    public void SetDataReader(IDataReader dataReader)=>_reader = dataReader;
    public abstract void Send();
}
class EmailSender : Sender
{
    public EmailSender(IDataReader reader) : base(reader)
    {
    }
    public override void Send()
    {
        _reader.Read();
        Console.WriteLine("send by mail");
    }
}
class TelegramBotSender : Sender
{
    public TelegramBotSender(IDataReader reader) : base(reader)
    {
    }
    public override void Send()
    {
        _reader.Read();
        Console.WriteLine("send by telegram bot");
    }
}
