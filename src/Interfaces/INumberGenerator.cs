namespace BullsAndCows.Interfaces
{
    public interface INumberGenerator
    {
        string GenerateNumber(int digits);

        int Next(int minValue, int maxValue);
    }
}
