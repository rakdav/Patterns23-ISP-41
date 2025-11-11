Transmitter analogTransmitter = new AnalogTransmitter();
analogTransmitter.ProcessStart();
Console.WriteLine();
Transmitter digitalTransmitter= new DigitalTransmitter();
digitalTransmitter.ProcessStart();

abstract class Transmitter
{
    protected virtual void VoiceRecord() => Console.WriteLine("recording a fragmrent a speach");
    protected virtual void Simpling() {}
    protected virtual void Digitization() {}
    protected virtual void Modulation() {}
    protected virtual void Transmission() => Console.WriteLine("signal transmission via radio channel");
    public void ProcessStart()
    {
        VoiceRecord();
        Simpling();
        Digitization();
        Modulation();
        Transmission();
    }
}
class AnalogTransmitter : Transmitter
{
    protected override void Modulation()
    {
        Console.WriteLine("modulation of the analog signal");
    }
}

class DigitalTransmitter : Transmitter
{
    protected override void Digitization()
    {
        Console.WriteLine("digitization");
    }

    protected override void Modulation()
    {
        Console.WriteLine("digital signal modulation");
    }

    protected override void Simpling()
    {
        Console.WriteLine("sampling of the recorded fragment");
    }
}
