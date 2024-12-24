using DesignPatterns.Visitor.BasicImplementation;
using DesignPatterns.Visitor.ExampleImplementation;

Element element1 = new ConcreteElement1();
Element element2 = new ConcreteElement2();

Visitor visitor1 = new ConcreteVisitor1();
Visitor visitor2 = new ConcreteVisitor2();

element1.Accept(visitor1);
element1.Accept(visitor2);

element2.Accept(visitor1);
element2.Accept(visitor2);

Console.WriteLine();

// ---

List<IDocumentElement> documentElements = [
    new TitleElement("Design Patterns"),
    new SubtitleElement("Visitor Design Pattern"),
    new ContentElement("blah blah blah")
];

Console.WriteLine("Text format:");
TextDocumentVisitor textDocumentVisitor = new();
foreach (IDocumentElement element in documentElements)
    element.Accept(textDocumentVisitor);

Console.WriteLine();

Console.WriteLine("Markdown format:");
MarkdownDocumentVisitor markdownDocumentVisitor = new();
foreach (IDocumentElement element in documentElements)
    element.Accept(markdownDocumentVisitor);
