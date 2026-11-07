using Bank.Models;

internal class Program
{
    
    private static void Main(string[] args)
    {
        Person alice = new("Alice", "Dupont", new DateTime(1995, 4, 12));
        Person bob = new("Bob", "Martin", new DateTime(1988, 11, 3));

        Bank.Models.Bank bank = new("Banque 2026");

        CurrentAccount aliceCurrent = new("BE01 0001", alice, creditLine: 500);
        SavingsAccount aliceSavings = new("BE01 0002", alice);
        CurrentAccount bobCurrent = new("BE01 0003", bob, creditLine: 200);

        bank.AddAccount(aliceCurrent);
        bank.AddAccount(aliceSavings);
        bank.AddAccount(bobCurrent);

        aliceCurrent.Deposit(1000);
        aliceCurrent.Withdraw(1300);
        aliceSavings.Deposit(2000);
        aliceSavings.Withdraw(500);
        bobCurrent.Deposit(150);

        Console.WriteLine($"=== {bank.Name} ===");
        foreach (Account account in bank.Accounts.Values)
        {
            Console.WriteLine(account);
        }

        Console.WriteLine();
        Console.WriteLine($"Solde de BE01 0001 : {bank.GetBalance("BE01 0001"):F2} €");
        Console.WriteLine($"Dernier retrait épargne : {aliceSavings.DateLastWithdraw:g}");
        Console.WriteLine($"Total des comptes d'{alice} : {bank.GetTotalBalance(alice):F2} €");

        try
        {
            bobCurrent.Withdraw(400);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Retrait refusé pour {bob} : {ex.Message}");
        }

        try
        {
            aliceSavings.Withdraw(5000);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Retrait refusé sur l'épargne : {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Après application des intérêts ===");
        foreach (Account account in bank.Accounts.Values)
        {
            account.ApplyInterest();
            Console.WriteLine(account);
        }

        bank.DeleteAccount("BE01 0003");
        Console.WriteLine();
        Console.WriteLine($"Comptes restants : {bank.Accounts.Count}");
    }

}