namespace DiscriminatedUnions.Tests.Unit;

public class CanBe
{
	[Fact]
	public void ReturnsTrue_When_InputValueIsContainedInCurrentValue()
	{
		var  one    = CreditCard.PREMIUM;
		var  two    = CreditCard.PLATINUM;
		var  combo  = one | two;
		bool result = combo.CanBe(CreditCard.PREMIUM);
		Assert.True(result);
	}

	[Fact]
	public void ReturnsFalse_When_InputValueIsNotContainedInCurrentValue()
	{
		var  one    = CreditCard.PREMIUM;
		var  two    = CreditCard.PLATINUM;
		var  combo  = one | two;
		bool result = combo.CanBe(CreditCard.STANDARD);
		Assert.False(result);
	}
}