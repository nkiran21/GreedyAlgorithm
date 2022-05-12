
using System;
using System.Linq;

/******************* Denomination Class *****************************/
public class DenominationClass
{
	// Decimal variable denomination containing denominations in the multiple of 100
	private int[] _denominations;
	/** Getter and Setter for variable denomination****/
    public int[] GetDenominations()
    {
        return _denominations;
    }
	public void SetDenominations(int[] value)
    {
		_denominations = value;
	}
	/**************************************************/

	// Place holder for each denomination. End placeholder will give us how many coins 
	// were needed for the corresponding denominations
	private int[] _tokens;
	/******* Getter and Setter for variable Tokens ****/
	public int[] GetTokens()
    {
		return _tokens;
    }
	public void SetTokens(int[] values)
    {
		_tokens = values;
    }
	/**************************************************/

	// Constructor to instantiate the class which takes the code specified denominations 
	// No need of default constructor so that the user is bound to pass his required denominations
	public DenominationClass(int[] denominationItems)
    {
		this._denominations = denominationItems;
		_tokens = new int[denominationItems.Length];
    }
	
	// Function that calculates and returns the minimum number of coins
	public int MinCoinsNeeded(decimal valuePassed)
    {

		int current = 0;    // placeholder for the denomination and tokens array
		int counter = 0;    // This variable yields total number of coins needed


		// In every loop from the given value(valuePassed) starting from maximum 
		// denominations(_denominations) is reduced until the given values reaches 0.
		// This loop also ensures the array index will not exceed the more than 
		// the array items. 
		while (valuePassed > 0 && current < _denominations.Count())
		{
			// Condition to check given value can still greater than denomination pointer
			if (valuePassed >= _denominations[current])		
			{
				valuePassed -= _denominations[current];		// on success denomination value is reduced
				_tokens[current] += 1;						// and value in the placde holder for the denominations is incremented
				counter++;									// total numbers of coins used is being tracked
			}
			// if the denominations is small the place holder pointer is moved to next place
			else
				current += 1;								
			
		}
		return counter;
	}
	
}
/*************** Denomination Class End ****************************/



/*********************** Main Class ********************************/
public class GeldwechselAutomaten
{
	public static void Main()
	{
		Console.WriteLine("***************  Geldwechsel-Automaten   **************************");
		// Hier wird der gewünschte Wechselgeldbetrag angegeben
		decimal givenValue = 0.30m;

		// Sie müssen hier angeben, welche Münzwerte Sie verwenden möchten
		int[] denominationParameter = new int[] { 200, 100, 50, 20, 10, 5, 2, 1 };
		// ihre Gegenwerte in Worten
		string[] currencyNotation = new string[] { "2 Euro", "1 Euro", "50 Cent", "20 Cent", "10 Cent", "5 Cent", "2 Cent", "1 Cent" };
		
		DenominationClass denominationObj = new DenominationClass(denominationParameter);

		// Converting the value given by user in integer format
		givenValue *= 100;

		// Call the function which calculates minimum number of coins required and returns the same in integer
		int minCoinsCalculated = denominationObj.MinCoinsNeeded(givenValue);
		Console.WriteLine("\nMindestanzahl von Münzen benötigt: " + minCoinsCalculated + "\n");
		
		// Resulting denomination and place array is fetched
		int[] resultTokens = denominationObj.GetTokens();
		int[] resultDenominations = denominationObj.GetDenominations();
		// Displaying the result
		for (int iterator=0;iterator<denominationParameter.Length;iterator++)
        {
			Console.WriteLine(resultTokens[iterator] + " * " + currencyNotation[iterator] + " Münzen wird benötigt");
        }

	}
}
/********************** Main Class Ende **********************************/
