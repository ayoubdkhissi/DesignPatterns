namespace Command;

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Turning on the light");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turning off the light");
    }
}


public interface ICommand
{
    void Execute();
}

public class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}

public class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }
}

public class RemoteControl
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressButton()
    {
        command.Execute();
    }
}
