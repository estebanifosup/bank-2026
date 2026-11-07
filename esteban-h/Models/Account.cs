namespace Bank.Models;

public abstract class Account(string number, Person owner)
{

    public string Number { get; set; } = number;
    public Person Owner { get; set; } = owner;

    public double Balance { get; private set; }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être positif.");
        }

        Balance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être positif.");
        }

        Balance -= amount;
    }

    protected abstract double CalculInterets();

    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }

    public override string ToString() => $"{Number} ({Owner}) : {Balance:F2} €";
    
}