using DesignPatterns.ChainOfResponsibility.BasicImplementation;
using DesignPatterns.ChainOfResponsibility.ExampleImplementation;

ConcreteHandler1 handler1 = new();
ConcreteHandler2 handler2 = new();
ConcreteHandler3 handler3 = new();
handler1.SetSuccessor(handler2);
handler2.SetSuccessor(handler3);

// handler1 is the entry point of the chain
handler1.Handle("1");
handler1.Handle("2");
handler1.Handle("3");
handler1.Handle("4");

Console.WriteLine();

// ---

SpamDetectionSystem spamDetector = new();
Email email = new("asdfu@jinsfv.net", "Nigerian Prince needs help", "Some text");
bool isSpam = spamDetector.IsSpam(email);
Console.WriteLine($"Email {(isSpam ? "is" : "is not")} spam");
Console.WriteLine();

email = new("spam@shop.com", "Safe link to checkout", "Some text");
isSpam = spamDetector.IsSpam(email);
Console.WriteLine($"Email {(isSpam ? "is" : "is not")} spam");
Console.WriteLine();

email = new("account@site.com", "Password reset", "Change your password");
isSpam = spamDetector.IsSpam(email);
Console.WriteLine($"Email {(isSpam ? "is" : "is not")} spam");
Console.WriteLine();

email = new("friend@social.com", "Greetings", "Hi, hope you're well");
isSpam = spamDetector.IsSpam(email);
Console.WriteLine($"Email {(isSpam ? "is" : "is not")} spam");
Console.WriteLine();