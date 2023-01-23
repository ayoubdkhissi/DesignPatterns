using Flyweight;

Console.Title = "Flyweight";

var someCharacters = "abbbaa";
var charFactory = new CharacterFactory();


var character0 = charFactory.GetCharacter(someCharacters[0]);
character0.Draw("Arial", 12);

var character1 = charFactory.GetCharacter(someCharacters[1]);
character1.Draw("Roboto", 17);

var character2 = charFactory.GetCharacter(someCharacters[2]);
character2.Draw("Philosopher", 8);

var character3 = charFactory.GetCharacter(someCharacters[3]);
character3.Draw("Arial", 3);


var paragraph = charFactory.CreateParagraph(1, new List<ICharacter>()
{
    character0, 
    character1, 
    character2, 
    character3
});

paragraph.Draw("Arial", 12);