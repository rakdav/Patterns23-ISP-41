TrafficLight traphicLight = new TrafficLight(new GreenState());
traphicLight.NextState();
traphicLight.NextState();
traphicLight.NextState();
traphicLight.PreviousState();
traphicLight.PreviousState();
traphicLight.PreviousState();
abstract class State
{
    protected TrafficLight trafficLight;
    public TrafficLight TrafficLight { set => trafficLight = value; }
    public abstract void NextState();
    public abstract void PreviousState();
}

class TrafficLight
{
    private State state;

    public TrafficLight(State state) => SetState(state);
    public void SetState(State st)
    {
        this.state = st;
        this.state.TrafficLight=this;
    }
    public void NextState()
    {
        state.NextState();
    }
    public void PreviousState()
    {
        state.PreviousState();
    }
}
class GreenState : State
{
    public override void NextState()
    {
        Console.WriteLine("from green to yellow");
        trafficLight.SetState(new YellowState());
    }
    public override void PreviousState()
    {
        Console.WriteLine("Green color");
    }
}
class YellowState : State
{
    public override void NextState()
    {
        Console.WriteLine("from yellow to red");
        trafficLight.SetState(new RedState());
    }

    public override void PreviousState()
    {
        Console.WriteLine("from yellow to green");
        trafficLight.SetState(new GreenState());
    }
}

class RedState : State
{
    public override void NextState()
    {
        Console.WriteLine("red color");
    }

    public override void PreviousState()
    {
        Console.WriteLine("from red to yellow");
        trafficLight.SetState(new YellowState());
    }
}
