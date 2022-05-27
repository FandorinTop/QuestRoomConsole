﻿using Microsoft.EntityFrameworkCore;
using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestTypeNameRepository : GenericRepository<QuestTypeName>, IQuestTypeNameRepository
    {
        public QuestTypeNameRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<QuestTypeName> FindByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(item => item.NormalizedName == name.ToUpperInvariant());
        }
    }
}
