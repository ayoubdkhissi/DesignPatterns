namespace Mediator;


public interface IChatroom
{
    void Register(TeamMember teamMember);
    void Send(string from, string message);
}

public abstract class TeamMember
{
    private IChatroom? _chatroom;
    public string Name { get; set; }

    public TeamMember(string name)
    {
        Name = name;
    } 
    internal void SetChatRoom(IChatroom chatroom)
    {
        _chatroom = chatroom;
    }
    
    public void Send(string message)
    {
        _chatroom?.Send(this.Name, message);
    }
    
    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"Message received {from} to {Name}: {message}");
    }
}

public class Lawyer : TeamMember
{
    public Lawyer(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"Lawyer {Name} received: ");
        base.Receive(from, message);
    }
}

public class AccountManger : TeamMember
{
    public AccountManger(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"Account Manager {Name} received: ");
        base.Receive(from, message);
    }
}

public class ChatRoom : IChatroom
{
    Dictionary<string, TeamMember> teamMembers = new();
    public void Register(TeamMember teamMember)
    {
        teamMember.SetChatRoom(this);
        if(!teamMembers.ContainsKey(teamMember.Name))
        {
            teamMembers.Add(teamMember.Name, teamMember);
        }
    }

    public void Send(string from, string message)
    {
        foreach (var teamMember in teamMembers.Values)
        {
            if(teamMember.Name != from)
                teamMember.Receive(from, message);
        }
    }
}

