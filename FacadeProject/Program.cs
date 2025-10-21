using System.Threading.Channels;
MarketPlace marketPlace=new MarketPlace();
marketPlace.ProductReceipt();
marketPlace.ProductRelease();
class ProviderCommunication
{
    public void Receive() => Console.WriteLine("receiving products from the manifacture");
    public void Payment() => Console.WriteLine("payment");
}
class Site
{
    public void Placement() => Console.WriteLine("placement of the website");
    public void Del() => Console.WriteLine("removal from the site");
}
class Database
{
    public void Insert() => Console.WriteLine("writing to the database");
    public void Del() => Console.WriteLine("deleting from the database");
}

class MarketPlace
{
    private ProviderCommunication providerCommunication;
    private Site site;
    private Database database;
    public MarketPlace()
    {
        providerCommunication=new ProviderCommunication();
        site=new Site();
        database=new Database();
    }
    public void ProductReceipt()
    {
        providerCommunication.Receive();
        site.Placement();
        database.Insert();
    }
    public void ProductRelease()
    {
        providerCommunication.Payment();
        site.Del();
        database.Del();
    }
}
