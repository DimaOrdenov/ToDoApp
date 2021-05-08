using System;
using LiteDB;
using ToDoApp.Definitions.Entities;

namespace ToDoApp.Services
{
    public class IssueRepository : BaseRepository<Issue>, IIssueRepository
    {
        public IssueRepository(Lazy<ILiteDatabase> db) 
            : base(db)
        {
        }
    }
}
