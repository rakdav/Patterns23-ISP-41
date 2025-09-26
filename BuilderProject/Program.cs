IDeveloper androidDeveloper = new AndroidDeveloper();
Director director=new Director(androidDeveloper);
Phone samsung=director.MountFullPhone();
Console.WriteLine(samsung.AboutPhone());
IDeveloper iphoneDeveloper=new IphoneDeveloper();
director.SetDeveloper(iphoneDeveloper);
Phone iphone=director.MountOnlyPhone();
Console.WriteLine(iphone.AboutPhone());

class Phone
{
    private string data;
    public Phone() => data = "";
    public string AboutPhone() => data;
    public void AppendData(string str) => data += str;
}
interface IDeveloper
{
    void CreateDisplay();
    void CreateBox();
    void SystemInstall();
    Phone GetPhone();
}
class AndroidDeveloper:IDeveloper
{
    private Phone phone;
    public AndroidDeveloper()=>phone = new Phone();
    public void CreateBox()=>phone.AppendData("(create) corpus Samsung");
    public void CreateDisplay()=> phone.AppendData("(create) display Samsung");
    public Phone GetPhone() => phone;
    public void SystemInstall() { phone.AppendData("(install) system Android"); }
}
class IphoneDeveloper : IDeveloper
{
    private Phone phone;
    public IphoneDeveloper()=>phone=new Phone();
    public void CreateBox() => phone.AppendData("(create) corpus Iphone");
    public void CreateDisplay() => phone.AppendData("(create) display Iphone");
    public Phone GetPhone() => phone;
    public void SystemInstall() { phone.AppendData("(install) system IOS"); }
}
class Director
{
    private IDeveloper developer;
    public Director(IDeveloper _developer) => developer = _developer;
    public void SetDeveloper(IDeveloper _developer)=> developer = _developer;
    public Phone MountOnlyPhone()
    {
        developer.CreateBox();
        developer.CreateDisplay();
        return developer.GetPhone();
    }
    public Phone MountFullPhone()
    {
        developer.CreateBox();
        developer.CreateDisplay();
        developer.SystemInstall();
        return developer.GetPhone();
    }
}