Console.Title = "Composite";

// Creating the tree structure
var root = new Composite.Directory("root");
var topLevelDirectory1 = new Composite.Directory("topLevelDirectory1");
var topLevelDirectory2 = new Composite.Directory("topLevelDirectory2");
var subdir = new Composite.Directory("subdir1");

var file1 = new Composite.File("File1", 50);
var file2 = new Composite.File("File2", 150);
var file3 = new Composite.File("File3", 10);
var file4 = new Composite.File("File4", 10);

root.AddItem(topLevelDirectory1);
root.AddItem(file1);
root.AddItem(topLevelDirectory2);
topLevelDirectory1.AddItem(subdir);
topLevelDirectory1.AddItem(file2);
subdir.AddItem(file3);
subdir.AddItem(file4);

Console.WriteLine("The size of the root dir: " + root.GetSize());
Console.WriteLine("The size of the topLevelDir 1: " + topLevelDirectory1.GetSize());



