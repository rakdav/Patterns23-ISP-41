IWorkShop creator = new CarWorkShop();
IProduction car=creator.Create();
creator=new TruckWorkShop();
IProduction truck=creator.Create();
car.Release();
truck.Release();
interface IProduction
{
    void Release();
}
class Car : IProduction
{
    public void Release() => Console.WriteLine("car");
}
class Truck : IProduction
{
    public void Release() => Console.WriteLine("car");
}
interface IWorkShop
{
    IProduction Create();
}
class CarWorkShop : IWorkShop
{
    public IProduction Create()=>new Car();
}
class TruckWorkShop : IWorkShop
{
    public IProduction Create() => new Truck();
}