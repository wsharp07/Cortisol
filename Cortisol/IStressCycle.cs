namespace Cortisol
{
    public interface IStressCycle
    {
        IStressAction RunTimes(int times);
    }
}