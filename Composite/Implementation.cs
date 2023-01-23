namespace Composite;

/// <summary>
/// Component 
/// </summary>
public abstract class FileSystemItem
{
    public string Name { get; set; }

    public abstract long GetSize();

    protected FileSystemItem(string name)
    {
        Name = name;
    }
}

/// <summary>
/// Leaf
/// </summary>
public class File : FileSystemItem
{
    private long _size;
    public File(string name, long size) : base(name)
    {
        _size = size;
    }
    public override long GetSize()
    {
        return _size;
    }
}

/// <summary>
/// Composite
/// </summary>
public class Directory : FileSystemItem
{
    private long _size;
    public List<FileSystemItem> Items { get; set; } 
        = new List<FileSystemItem> ();

    public Directory(string name) : base(name) { }

    public override long GetSize()
    {
        long size = 0;
        foreach (FileSystemItem item in Items)
        {
            size += item.GetSize();
        }
        return size;
    }
    public void AddItem(FileSystemItem item)
    {
        Items.Add(item);
    }
    public void RemoveItem(FileSystemItem item)
    {
        Items.Remove(item);
    }    
}