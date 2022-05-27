using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories.Base;

namespace QuestRoom.Interfaces.Repositories
{
    public interface IQuestTypeNameRepository : IBaseRepository<QuestTypeName>
    {
        public Task<QuestTypeName> FindByName(string name);
    }
}
