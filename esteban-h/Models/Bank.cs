namespace Bank.Models;

public class Bank(string name)
{

    public string Name { get; set; } = name;

    public Dictionary<string, Account> Accounts { get; } = [];

    public void AddAccount(Account account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            throw new InvalidOperationException($"Le compte {account.Number} existe déjà.");
        }

        Accounts.Add(account.Number, account);
    }

    public void DeleteAccount(string number)
    {
        if (!Accounts.Remove(number))
        {
            throw new KeyNotFoundException($"Le compte {number} n'existe pas.");
        }
    }

    public double GetBalance(string number)
    {
        if (!Accounts.TryGetValue(number, out Account? account))
        {
            throw new KeyNotFoundException($"Le compte {number} n'existe pas.");
        }

        return account.Balance;
    }

    public double GetTotalBalance(Person owner)
    {
        double total = 0;
        foreach (Account account in Accounts.Values)
        {
            if (account.Owner == owner)
            {
                total += account.Balance;
            }
        }
        return total;
    }

}