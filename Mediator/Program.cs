using Mediator;

Console.Title = "Mediator";

ChatRoom chatRoom = new();

var ayoub = new Lawyer("Ayoub");
var ali = new Lawyer("Ali");

var asmae = new AccountManger("Asmae");
var chaymae = new AccountManger("Chaymae");
var aissame = new AccountManger("Aissame");

chatRoom.Register(ayoub);
chatRoom.Register(ali);
chatRoom.Register(asmae);
chatRoom.Register(chaymae);
chatRoom.Register(aissame);

ayoub.Send("Hello Guys!");
