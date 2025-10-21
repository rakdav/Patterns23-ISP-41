using System.Collections;
FlyweightFactory flyweightFactory=new FlyweightFactory(new List<Shared>()
{
    new Shared("Microsoft","manager"),
    new Shared("Google","manager"),
    new Shared("Google","developer"),
    new Shared("Apple","developer")
});
flyweightFactory.ListFlyweights();
AddSpecialistDatabase(flyweightFactory,"Google", "developer",
    "George","12345");
AddSpecialistDatabase(flyweightFactory, "Apple", "manager",
    "Mark", "67895");
flyweightFactory.ListFlyweights();
void AddSpecialistDatabase(FlyweightFactory flyweightFactory,
    string company,string position,string name,string passport)
{
    Console.WriteLine();
    Flyweight flyweight = flyweightFactory.GetFlyWeight(new Shared(company, position));
    flyweight.Process(new Unique(name,passport));
}

struct Shared
{
    private string company;
    private string position;
    public Shared(string company, string position)
    {
        this.company = company;
        this.position = position;
    }
    public string Company { get =>company; }
    public string Position { get => position; }
}
struct Unique
{
    private string name;
    private string passport;
    public Unique(string name, string password)
    {
        this.name = name;
        this.passport = password;
    }
    public string Name { get => this.name; }
    public string Passport { get => this.passport; }
}

class Flyweight
{
    private Shared shared;
    public Flyweight(Shared shared)
    {
        this.shared = shared;
    }
    public void Process(Unique unique)
    {
        Console.WriteLine("New data: shared-"+shared.Company+"_"+shared.Position+" unique- "+unique.Name+"_"+unique.Passport);
    }
    public string GetData()=>shared.Company+"_"+shared.Position;
}

class FlyweightFactory
{
    private Hashtable flyweights;
    private string GetKey(Shared shared)=>shared.Company+"_"+shared.Position;

    public FlyweightFactory(List<Shared> shareds)
    {
        flyweights=new Hashtable();
        foreach (Shared shared in shareds)
        {
            flyweights.Add(GetKey(shared), new Flyweight(shared));
        }
    }
    public Flyweight GetFlyWeight(Shared shared)
    {
        string key=GetKey(shared);
        if (!flyweights.Contains(key))
        {
            Console.WriteLine("Flyweight factory: object not found" + key);
            flyweights.Add (key, new Flyweight(shared));
        }
        else
        {
            Console.WriteLine("Flyweight factory: object found" + key);
        }
        return (Flyweight)flyweights[key]!;
    }
    public void ListFlyweights()
    {
        int count=flyweights.Count;
        Console.WriteLine("Flyweight factory: count="+count);
        foreach (Flyweight values in flyweights.Values)
        {
            Console.WriteLine(values.GetData());
        }
    }
}
