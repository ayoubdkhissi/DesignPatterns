using Iterator;

Console.Title = "Iterator";

PeopleCollection people = new PeopleCollection();
IPeopleIterator iterator = new PeopleIterator(people);

people.Add(new Person("Lachger Abdelmonaim", "Morocco"));
people.Add(new Person("Dkhissi Ayoub", "Netherlands"));
people.Add(new Person("Amara Asmae", "Nepal"));
people.Add(new Person("Boukhallad Aissam", "Mars"));

while (!iterator.IsDone)
{
    Console.WriteLine(iterator.Current.Name);
    iterator.Next();
}