List<IPlace> places = new List<IPlace> { new Zoo(),
new Cinema(),new Circus()};
foreach(IPlace place in places)
{
    HolidayMaker visitor = new HolidayMaker();
    place.Accept(visitor);
    Console.WriteLine(visitor.Value);
}
interface IPlace
{
    void Accept(IVisitor visitor);
}
class Zoo : IPlace
{
    public void Accept(IVisitor v) => v.Visit(this);
}
class Cinema : IPlace
{
    public void Accept(IVisitor v) => v.Visit(this);
}
class Circus : IPlace
{
    public void Accept(IVisitor v) => v.Visit(this);
}
interface IVisitor
{
    void Visit(Zoo zoo);
    void Visit(Cinema cinema);
    void Visit(Circus circus);
}
class HolidayMaker : IVisitor
{
    public string Value;

    public void Visit(Zoo zoo) => Value = "zoo";

    public void Visit(Cinema cinema)=> Value = "cinema";

    public void Visit(Circus circus)=> Value = "circus";

}

