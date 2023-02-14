// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var  one   = CreditCard.PREMIUM;
var  two   = CreditCard.PLATINUM;
var  combo = (one & CreditCard.PLATINUM) | CreditCard.PLATINUM;
bool diff  = combo.CanBe(CreditCard.PLATINUM & CreditCard.PREMIUM);
Console.WriteLine(combo.Name);
Console.WriteLine(diff);