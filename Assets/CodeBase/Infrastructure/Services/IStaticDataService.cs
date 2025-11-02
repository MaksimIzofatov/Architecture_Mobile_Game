using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();
        MonsterStaticData ForMonsters(MonsterTypeId id);
    }
}