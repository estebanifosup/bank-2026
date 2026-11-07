namespace Bank.Models;

public class SavingsAccount(string number, Person owner) : Account(number, owner)
{
    
    public DateTime DateLastWithdraw { get; set; }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Solde insuffisant.");
        }

        base.Withdraw(amount);
        DateLastWithdraw = DateTime.Now;
    }

    protected override double CalculInterets() => Balance * 0.045;

}