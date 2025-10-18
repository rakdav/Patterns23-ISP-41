Item file=new DropDownItem("File->");
Item create=new DropDownItem("Create->");
Item open = new DropDownItem("Open->");
Item exit = new DropDownItem("Exit");

file.Add(create);
file.Add(open);
file.Add(exit);

Item project = new ClickItem("project...");
Item repository = new ClickItem("repository...");
create.Add(project);
create.Add(repository);

Item solution = new ClickItem("solutiom...");
Item folder = new ClickItem("folder...");
open.Add(solution);
open.Add(folder);

file.Display();
Console.WriteLine();

file.Remove(create);
file.Display();

abstract class Item
{
    protected string ItemName;
    protected string OwnerName;
    protected Item(string name) => ItemName = name;
    public void SetOwner(string o) => OwnerName = o;
    public virtual void Add(Item subItem) { }
    public virtual void Remove(Item subItem) { }
    public abstract void Display();
}
class ClickItem : Item
{
    public ClickItem(string name) : base(name){}

    public override void Add(Item subItem)
    {
        throw new Exception();
    }
    public override void Display()
    {
        Console.WriteLine(ItemName);
    }
    public override void Remove(Item subItem)
    {
        throw new Exception();
    }
}
class DropDownItem : Item
{
    private List<Item> children;
    public DropDownItem(string name):base(name)
    {
        children = new List<Item>();
    }
    public override void Display()
    {
        foreach (Item item in children)
        {
            if(OwnerName!=null) Console.WriteLine(OwnerName+ItemName);
            item.Display();
        }
    }
    public override void Remove(Item subItem)=>children.Remove(subItem);
    public override void Add(Item subItem)
    {
        subItem.SetOwner(this.ItemName);
        children.Add(subItem);
    }
}
