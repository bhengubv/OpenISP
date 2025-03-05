public class CreditService
{
    public int Credits { get; private set; }
    public void AddCredits(int amount) => Credits += amount;
}
