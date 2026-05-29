using Random = System.Random;

namespace CodeBase.Infrastructure.Services
{
    public class UnityRandomService : IRandomService
    {
        private Random _random;
        public UnityRandomService()
        {
            _random = new Random();
        }

        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}