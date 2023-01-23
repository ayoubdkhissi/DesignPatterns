namespace Flyweight;


/// <summary>
/// Flyweight
/// </summary>
public interface ICharacter
{
    void Draw(string fontFamily, int fontSize);
}

public class CharacterA : ICharacter
{
    private char _char = 'a';

    public void Draw(string fontFamily, int fontSize)
    {
        Console.WriteLine($"Drawing {_char}, {fontFamily} {fontSize}");
    }
}

public class CharacterB : ICharacter
{
    private char _char = 'b';

    public void Draw(string fontFamily, int fontSize)
    {
        Console.WriteLine($"Drawing {_char}, {fontFamily} {fontSize}");
    }
}


/// <summary>
/// FlyweigthFactory
/// </summary>
public class CharacterFactory
{
    private readonly Dictionary<char, ICharacter> _characters = new();
    
    public ICharacter? GetCharacter(char charId)
    {
        if(_characters.ContainsKey(charId))
        {
            Console.WriteLine($"reuse of char {charId}");
            return _characters[charId];
        }

        Console.WriteLine($"Creating char {charId}");
        switch(charId)
        {
            case 'a':
                _characters['a'] = new CharacterA();
                break;
            case 'b':
                _characters['b'] = new CharacterB();
                break;
            // c, d, e... and so on
        }
        return _characters[charId];
    }

    public ICharacter? CreateParagraph(int location, List<ICharacter> characters)
    {
        return new Paragraph(location, characters);
    }
}

public class Paragraph : ICharacter
{
    private int _location;
    private List<ICharacter> _characters = new();

    public Paragraph(int location, List<ICharacter> characters)
    {
        _location = location;
        _characters = characters;
    }

    public void Draw(string fontFamily, int fontSize)
    {
        Console.WriteLine($"Drawing paragraph at location {_location}");
        foreach(var character in _characters)
        {
            character.Draw(fontFamily, fontSize);
        }
    }
}