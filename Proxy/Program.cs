using Proxy;

Console.Title = "Proxy";


//var document = new DocumentProxy("doc1.pdf");

//// getting the file name (the real document is not constructed yet)
//Console.WriteLine($"File name: {document.FileName}");

//// Now the real document is constructed
//document.DisplayDucument();

// with read rights
var document = new ProtectedDocumentProxy("doc1.pdf", "read");
document.DisplayDucument();

Console.WriteLine();

// without read rights
var document2 = new ProtectedDocumentProxy("doc2.pdf", "none");
document2.DisplayDucument();

