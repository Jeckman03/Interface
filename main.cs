using System;

class MainClass {

	// Maximum number of customers
	const int Max_Cust = 100;

  public static void Main (string[] args) {

		// Creating an array of Inerface IAccount to hold the max customers
		IAccount[] accounts = new IAccount[Max_Cust];

		// Creating a CustomerAccount object and assigning it to index 0 of the array
		accounts[0] = new CustomerAccount();
		accounts[0].PayInFunds(50);
		Console.WriteLine($"Balance: { accounts[0].GetBalance() }");

		// Creating a BabyAccount object and assigning it to index 1 of the array
		accounts[1] = new BabyAccount();
		accounts[1].PayInFunds(20);
		Console.WriteLine($"Balance: { accounts[1].GetBalance() }");

		// Since both objects implement the same interface they can both be stored 
		// in the same IAccount array

		if (accounts[0].WithdrawlFunds(20))
		{
			Console.WriteLine("Withdrawl OK");
		}

		if (accounts[1].WithdrawlFunds(20))
		{
			Console.WriteLine("Withdrawl OK");
		}


    Console.ReadLine();
  }
}

// Interface
public interface IAccount
{
	// int GetAccountNumber();
	void PayInFunds(decimal amount);
	bool WithdrawlFunds(decimal amount);
	decimal GetBalance();
}

public interface IPrintToPaper
{
	void DoPrint();
}

// Account class implementing an interface
public class CustomerAccount : IAccount
{
	private decimal balance = 0;

	public void PayInFunds(decimal amount)
	{
		balance += amount;
	}

	public virtual bool WithdrawlFunds(decimal amount)
	{
		if (amount > 10)
		{
			return false;
		}

		if (balance < amount)
		{
			return false;
		}

		balance -= amount;

		return true; 
	}

	public decimal GetBalance()
	{
		return balance;
	}
}

// This class is implementing two interfaces
// Also it is inheriting from partent class CustomerAccount
// Which means it gets everything from that class
// Sealed means this class cannot be used by annother class,
// you can also use sealed on override methods so they cant be changed
public sealed class BabyAccount : CustomerAccount, IAccount, IPrintToPaper
{
	public void DoPrint()
	{
		// Print Something
	}

	public override bool WithdrawlFunds(decimal amount)
	{
		if (amount > 10)
		{
			return false;
		}

		// Here we can use the word base to grab the base method and save us 
		// from having to write out the code again
		// Also it prevents the balance field from being visable in this class
		return base.WithdrawlFunds(amount);
	}

}