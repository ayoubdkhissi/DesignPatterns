using Command;

Console.Title = "Command";

Light light = new Light();
LightOnCommand lightOnCommand = new LightOnCommand(light);
LightOffCommand lightOffCommand = new LightOffCommand(light);

RemoteControl remoteControl = new RemoteControl();
remoteControl.SetCommand(lightOnCommand);
remoteControl.PressButton();

remoteControl.SetCommand(lightOffCommand);
remoteControl.PressButton();

