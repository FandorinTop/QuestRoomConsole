﻿using QuestRoom.DataAccess.Repositories;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;
        private IDiscountRepository discountRepository;
        private IPersonalRepository personalRepository;
        private IPersonalTypeRepository personalTypeRepository;
        private IQuestActorRepository questActorRepository;
        private IQuestRepository questRepository;
        private IQuestSessionRepository questSessionRepository;
        private IQuestTypeNameRepository typeRepository;
        private IClientRepository clientRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IClientRepository ClientRepository
        {
            get
            {
                if (clientRepository is null)
                {
                    clientRepository  = new ClientRepository(_context);
                }

                return clientRepository ;
            }
        }

        public IDiscountRepository DiscountRepository
        {
            get
            {
                if(discountRepository is null)
                {
                    discountRepository = new DiscountRepository(_context);
                }

                return discountRepository;
            }
        }

        public IPersonalRepository PersonalRepository
        {
            get
            {
                if (personalRepository is null)
                {
                    personalRepository = new PersonalRepository(_context);
                }

                return personalRepository;
            }
        }

        public IPersonalTypeRepository PersonalTypeRepository
        {
            get
            {
                if (personalTypeRepository is null)
                {
                    personalTypeRepository = new PersonalTypeRepository(_context);
                }

                return personalTypeRepository;
            }
        }

        public IQuestActorRepository QuestActorRepository
        {
            get
            {
                if (questActorRepository is null)
                {
                    questActorRepository = new QuestActorRepository(_context);
                }

                return questActorRepository;
            }
        }

        public IQuestRepository QuestRepository
        {
            get
            {
                if (questRepository is null)
                {
                    questRepository = new QuestRepository(_context);
                }

                return questRepository;
            }
        }

        public IQuestSessionRepository QuestSessionRepository
        {
            get
            {
                if (questSessionRepository is null)
                {
                    questSessionRepository = new QuestSessionRepository(_context);
                }

                return questSessionRepository;
            }
        }

        public IQuestTypeNameRepository QuestTypeNameRepository
        {
            get
            {
                if (typeRepository is null)
                {
                    typeRepository = new QuestTypeNameRepository(_context);
                }

                return typeRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
