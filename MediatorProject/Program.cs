Designer designer = new Designer();
Director director = new Director();
Controller mediator = new Controller(designer, director);
director.GiveCommand("design");
Console.WriteLine();
designer.ExecuteWork();

interface IMediator
{
    void Notify(Employee emp,string msg);
}

abstract class Employee
{
    protected IMediator mediator;
    protected Employee(IMediator _mediator)=>this.mediator =_mediator;
    public void SetMediator(IMediator _mediator) => mediator = _mediator;
}

class Designer : Employee
{
    public Designer(IMediator mediator = null!) : base(mediator) { }
    public void ExecuteWork()
    {
        Console.WriteLine("<-the designer is at work");
        mediator.Notify(this, "the designer designs...");
    }
    public void SetWork(bool state)
    {
        if (state)
            Console.WriteLine("<-the designer is released from work");
        else
            Console.WriteLine("<-the designer is busy");
    }
}

class Director : Employee
{
    private string _text;

    public Director(IMediator _mediator=null) : base(_mediator) { }
    public void GiveCommand(string text)
    {
        _text = text;
        if (_text == "")
            Console.WriteLine("->the director knows that the designer is already working");
        else
            Console.WriteLine("->the director gave the command:" + _text);
        mediator.Notify(this, _text);
    }
}

class Controller : IMediator
{
    private Designer designer;
    private Director director;

    public Controller(Designer _designer, Director _director)
    {
        designer =_designer;
        director =_director;
        designer.SetMediator(this);
        director.SetMediator(this);
    }
    public void Notify(Employee employee, string msg)
    {
        if (employee is Director)
        {
            if (msg == "")
                designer.SetWork(false);
            else
                designer.SetWork(true);
        }
        else if (employee is Designer)
        {
            if (msg == "the designer designs...")
                director.GiveCommand("");
        }
    }
}
