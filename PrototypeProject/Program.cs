IAnimal sheepSoroka = new Sheep();
sheepSoroka.SetName("Сорока");
IAnimal sheepClone=sheepSoroka.Clone();
Console.WriteLine(sheepSoroka.GetName());
Console.WriteLine(sheepClone.GetName());
interface IAnimal
{
    void SetName(string name);
    string GetName();
    IAnimal Clone();
}
class Sheep:IAnimal
{
    private string _name;
    public Sheep() { }
    public Sheep(Sheep ship)=>this._name = ship._name;
    public IAnimal Clone()=>new Sheep(this);
    public string GetName() => _name;
    public void SetName(string name)=>this._name = name;
}
