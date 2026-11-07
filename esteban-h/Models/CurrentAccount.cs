namespace Bank.Models;

public class CurrentAccount(string number, Person owner, double creditLine = 0) : Account(number, owner)
{
    
    private double _creditLine = Validate(creditLine);

    public double CreditLine
    {
        get => _creditLine;
        set => _creditLine = Validate(value);
    }

    private static double Validate(double value) =>
        value >= 0
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit ne peut pas être négative.");

    public override void Withdraw(double amount)
    {
        if (Balance - amount < -CreditLine)
        {
            throw new InvalidOperationException("Ligne de crédit dépassée.");
        }

        base.Withdraw(amount);
    }

    protected override double CalculInterets() => Balance * (Balance >= 0 ? 0.03 : 0.0975);

}