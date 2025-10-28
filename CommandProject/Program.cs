Conveyor conveyor = new Conveyor();
Multipult multipult=new Multipult();
multipult.SetCommand(0,new ConveyorWorkCommand(conveyor));
multipult.SetCommand(1,new ConveyorAdjustCommand(conveyor));
multipult.PressOn(0);
multipult.PressOn(1);
multipult.PressCancel();
multipult.PressCancel();

interface ICommand
{
    void Positive();
    void Negative();
}
class Conveyor
{
    public void On() => Console.WriteLine("the pipeline is running");
    public void Off() => Console.WriteLine("the conveyor is stopped");
    public void SpeedIncrease()=> Console.WriteLine("increased convoyer speed");
    public void SpeedDecrease() => Console.WriteLine("reduced convoyer speed");
}
class ConveyorWorkCommand:ICommand
{
    private Conveyor conveyor;

    public ConveyorWorkCommand(Conveyor conveyor)=>this.conveyor = conveyor;

    public void Negative()=>conveyor.Off();

    public void Positive()=>conveyor.On();
}

class ConveyorAdjustCommand : ICommand
{
    private Conveyor conveyor;

    public ConveyorAdjustCommand(Conveyor conveyor) => this.conveyor = conveyor;

    public void Negative() => conveyor.SpeedDecrease();

    public void Positive() => conveyor.SpeedIncrease();
}
class Multipult
{
    private List<ICommand> commands;
    private Stack<ICommand> history;
    public Multipult()
    {
        commands = new List<ICommand> { null!, null! };
        history = new Stack<ICommand>();
    }
    public void SetCommand(int button, ICommand command) => commands[button] = command;
    public void PressOn(int button)
    {
        commands[button].Positive();
        history.Push(commands[button]);
    }
    public void PressCancel()
    {
        if(history.Count!=0) history.Pop().Negative();
    }
}