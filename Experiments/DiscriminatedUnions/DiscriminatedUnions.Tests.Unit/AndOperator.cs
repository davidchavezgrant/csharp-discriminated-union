namespace DiscriminatedUnions.Tests.Unit;

public class AndOperator
{
	[Fact]
	public void AndOperator_CombinesTwoCards_ReturnsCombinedValue()
	{
		var card1 = CreditCard.PREMIUM;
		var card2 = CreditCard.PLATINUM;
		var card3 = CreditCard.STANDARD;

		// Combine two cards using '&' operator
		var cardCombo1 = card1 & card2;
		var cardCombo2 = card2 & card3;

		// Assert that the combined value is correct
		Assert.Equal("(Premium) and (Platinum)",  cardCombo1.ToString());
		Assert.Equal("(Platinum) and (Standard)", cardCombo2.ToString());
	}

	[Fact]
	public void AndOperator_CombinesSameCards_ReturnsSameValue()
	{
		var card1 = CreditCard.PREMIUM;
		var card2 = CreditCard.PREMIUM;

		// Combine same cards using '&' operator
		var cardCombo = card1 & card2;

		// Assert that the combined value is the same as the original value
		Assert.Equal(CreditCard.PREMIUM.Value, cardCombo.Value);
	}
	
	[Fact]
	public void AndOperator_CombinesSameCards_ReturnsSameName()
	{
		var card1 = CreditCard.PREMIUM;
		var card2 = CreditCard.PREMIUM;

		// Combine same cards using '&' operator
		var cardCombo = card1 & card2;

		// Assert that the combined value is the same as the original value
		Assert.Equal(CreditCard.PREMIUM.Name, cardCombo.Name);
	}

	[Fact]
	public void AndOperator_CombinesAllCards_ReturnsCombinedValue()
	{
		var card1 = CreditCard.PREMIUM;
		var card2 = CreditCard.PLATINUM;
		var card3 = CreditCard.STANDARD;

		// Combine all cards using '&' operator
		var cardCombo = card1 & card2 & card3;

		// Assert that the combined value is correct
		Assert.Equal("((Premium) and (Platinum)) and (Standard)", cardCombo.ToString());
	}
}
