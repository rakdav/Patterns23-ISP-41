IProcessor transmitter = new Transmitter("12345");
transmitter.Process();
Console.WriteLine();

Shell hammingCoder = new HammingCoder(transmitter);
hammingCoder.Process();
Console.WriteLine();

Shell encoder=new Encryptor(hammingCoder);
encoder.Process();

interface IProcessor
{
    void Process(); 
}
class Transmitter : IProcessor
{
    private string data;
    public Transmitter(string _data)=>this.data =_data;
    public void Process()
    {
        Console.WriteLine("Data "+data+" transmitted via the communication chennel");
    }
}
abstract class Shell : IProcessor
{
    protected IProcessor Processor;
    public Shell(IProcessor processor) => Processor = processor;
    public virtual void Process() => Processor.Process();
}
class HammingCoder : Shell
{
    public HammingCoder(IProcessor processor) : base(processor){}
    public override void Process()
    {
        Console.WriteLine("noise-resistant Hamming code has been applied->");
        Processor.Process();
    }
}
class Encryptor : Shell
{
    public Encryptor(IProcessor processor) : base(processor) { }
    public override void Process()
    {
        Console.WriteLine("data encryption->");
        Processor.Process();
    }
}
