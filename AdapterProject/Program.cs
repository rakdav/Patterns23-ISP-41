float kg = 55.0f;
float lb = 55.0f;
IScales rScales = new RussianScales(kg);
IScales bScales = new AdapterForBritishScales(new BritishScales(lb));
Console.WriteLine(rScales.GetWeight());
Console.WriteLine(bScales.GetWeight());
interface IScales
{
    float GetWeight();
}
class RussianScales : IScales
{
    private float currentWeight;
    public RussianScales(float currentWeight)=>this.currentWeight = currentWeight;
    
    public float GetWeight() => currentWeight;
}
class BritishScales : IScales
{
    private float currentWeight;
    public BritishScales(float currentWeight) => this.currentWeight = currentWeight;
    public float GetWeight() => currentWeight;
}
class AdapterForBritishScales:IScales
{
    private BritishScales britishScales;
    public AdapterForBritishScales(BritishScales britishScales)
    {
        this.britishScales = britishScales;
    }
    public float GetWeight()
    {
      return  britishScales.GetWeight()*0.453f;
    }
}