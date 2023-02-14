// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var one   = CreditCard.PREMIUM;
var two   = CreditCard.PLATINUM;
var combo = (one | two) & CreditCard.STANDARD;
bool diff  = combo.Equals((CreditCard.PREMIUM | CreditCard.PLATINUM) & CreditCard.STANDARD);
Console.WriteLine(combo.Name);
Console.WriteLine(diff);