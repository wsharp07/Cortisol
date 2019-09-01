using System.Threading.Tasks;

namespace Cortisol
{
    public interface IStressResult
    {
        Task Induce();
    }
}