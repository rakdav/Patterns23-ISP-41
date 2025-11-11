ResourceReader resourceReader = new ResourceReader(new NewSitereader());
string url = "mail.ru";
resourceReader.Read(url);

url = "vk.ru";
resourceReader.SetStrategy(new SocialNetworkReader());
resourceReader.Read(url);

interface IReader
{
    void Parse(string url);
}
class ResourceReader
{
    private IReader _reader;
    public ResourceReader(IReader reader)
    {
        _reader = reader;
    }
    public void SetStrategy(IReader reader)=>this._reader = reader;
    public void Read(string url)=>_reader.Parse(url);
}
class NewSitereader : IReader
{
    public void Parse(string url)
    {
        Console.WriteLine("parse site "+url);
    }
}
class SocialNetworkReader : IReader
{
    public void Parse(string url)
    {
        Console.WriteLine("parse social networksl " + url);
    }
}
