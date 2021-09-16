using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Root
{
    public class RootRepository : IRootRepository
    {
        public async Task<RootModel> GetRoot(int rootId)
        {
            using (var db = new DbContextApp())
            {
                return await db.Roots.FindAsync(rootId);
            }
        }

        public async Task<RootModel> GetRoot(string title)
        {
            using (var db = new DbContextApp())
            {
                return await db.Roots.FirstOrDefaultAsync(c => c.Title == title);
            }
        }

        public async Task<List<RootModel>> GetRoots()
        {
            using (var db = new DbContextApp())
            {
                return await db.Roots.ToListAsync();
            }
        }
    }
}
