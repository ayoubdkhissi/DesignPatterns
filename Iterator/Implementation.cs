namespace Iterator;



public class Person
{
    public string Name { get; set; }
    public String Country { get; set; }

    public Person(string name, string country)
    {
        Name = name;
        Country = country;
    }
}

// Iterator interface
public interface IPeopleIterator
{
    Person First();
    Person Next();
    bool IsDone { get; }
    Person Current { get; }
}

public interface IPeopleCollection
{
    IPeopleIterator CreateIterator();
}

// concrete aggregate
public class PeopleCollection : List<Person>, IPeopleCollection
{
    public IPeopleIterator CreateIterator()
    {
        return new PeopleIterator(this);
    }

}

public class PeopleIterator : IPeopleIterator
{

    private readonly PeopleCollection _peopleCollection;
    private int _current = 0;
    
    public PeopleIterator(PeopleCollection peopleCollection)
    {
        _peopleCollection = peopleCollection;
    }

    public Person First()
    {
        _current = 0;
        return _peopleCollection
            .OrderBy(p => p.Name)
            .ToList()[_current];
    }

    public bool IsDone => _peopleCollection.Count <= _current;

    public Person Current => _peopleCollection.OrderBy(p => p.Name).ToList()[_current];

    public Person Next()
    {
        _current++;
        if (IsDone)
            return null;
        return _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
    }
}
