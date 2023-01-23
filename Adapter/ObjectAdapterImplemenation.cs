namespace Adapter;



public class City
{
    public string Name { get; private set; }
    public int Inhabitants { get; private set; }
    public City(string name, int inhabitants)
    {
        Name = name;
        Inhabitants = inhabitants;
    }
}
public class CityFromExternalClass
{
    public string NickName { get; private set; }
    public string Name { get; private set; }
    public int Inhabitants { get; private set; }
    public CityFromExternalClass(string nickName, string nameName, int inhabitants)
    {
        NickName = nickName;
        Name = nameName;
        Inhabitants = inhabitants;
    }
}


public class ExternalSystem
{
    public CityFromExternalClass GetCity()
    {
        return new CityFromExternalClass("Casa", "Casablanca", 5000000);
    }
}

public interface ICityAdapter
{
    City GetCity();
}

public class CityAdapter : ICityAdapter
{
    // This normally should be injected 
    public ExternalSystem _externalSystem { get; private set; } = new();

    public City GetCity()
    {
        CityFromExternalClass oldCity = _externalSystem.GetCity();

        City newCity = new City($"{oldCity.NickName} - {oldCity.Name}", oldCity.Inhabitants);
        return newCity;
    }
}
