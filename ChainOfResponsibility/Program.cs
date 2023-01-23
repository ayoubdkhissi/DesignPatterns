using ChainOfResponsibility;
using System.ComponentModel.DataAnnotations;

Console.Title = "Chain of Responsibility";

var validDocument = new Document("Java Sucks", DateTimeOffset.Now, true, true);
var invalidDocument = new Document("Java is good", DateTimeOffset.Now, false, true);

var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain.SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());

try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("valid document is valid!");
    documentHandlerChain.Handle(invalidDocument);
    Console.WriteLine("Invalid document is not valid");
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}