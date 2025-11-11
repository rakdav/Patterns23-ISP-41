Product p=new Product(400);
Wholesale wholesale=new Wholesale(p);
Buyer buyer=new Buyer(p);
p.ChangePrice(320);
p.ChangePrice(280);


interface IObserver
{
    void Update(double p);
}
interface IObservable
{
    void AddObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void Notify();
}

class Product : IObservable
{
    private List<IObserver> _observers;
    private double _price;

    public Product(double price)
    {
        _price = price;
        _observers = new List<IObserver>();
    }
    public void ChangePrice(double p)
    {
        _price = p;
        Notify();
    }

    public void AddObserver(IObserver o)
    {
        _observers.Add(o);
    }

    public void Notify()
    {
        foreach(IObserver o in _observers.ToList())
        {
            o.Update(_price);
        }
    }

    public void RemoveObserver(IObserver o)
    {
       _observers.Remove(o);
    }
}
class Wholesale : IObserver
{
    private IObservable product;

    public Wholesale(IObservable obj)
    {
        product = obj;
        obj.AddObserver(this);
    }
    public void Update(double p)
    {
        if (p < 300)
        {
            Console.WriteLine("the wholesaler bought the goods at a price "+p);
            product.RemoveObserver(this);
        }
    }
}

class Buyer:IObserver
{
    private IObservable product;

    public Buyer(IObservable obj)
    {
        product = obj;
        obj.AddObserver(this);
    }

    public void Update(double p)
    {
        if (p < 350)
        {
            Console.WriteLine("the buyer purschased the goods at a price " + p);
            product.RemoveObserver(this);
        }
    }
}