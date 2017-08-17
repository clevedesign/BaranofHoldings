using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class TeamMemberRepository : GenericRepository<TeamMember>
    {
        public TeamMemberRepository(DbContext context)
            : base(context)
        {

        }
    }
}
