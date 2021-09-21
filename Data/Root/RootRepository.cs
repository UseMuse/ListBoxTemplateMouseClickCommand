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
        /// <inheritdoc cref="IRootRepository.GetRoot(int)"/>
        public async Task<RootModel> GetRoot(int rootId)
        {
            using (DbContextApp db = new DbContextApp())
            {
                return await db.Roots.FindAsync(rootId);
            }
        }

        /// <inheritdoc cref="IRootRepository.GetRoot(string)"/>
        public async Task<RootModel> GetRoot(string title)
        {
            using (DbContextApp db = new DbContextApp())
            {
                return await db.Roots.FirstOrDefaultAsync(c => c.Title == title);
            }
        }

        /// <inheritdoc cref="IRootRepository.GetRoots()"/>
        public async Task<List<RootModel>> GetRoots()
        {
            using (DbContextApp db = new DbContextApp())
            {
                return await db.Roots.ToListAsync();
            }
        }

        /// <inheritdoc cref="IRootRepository.UpdateRoot(RootModel)"/>
        public async Task<bool> UpdateRoot(RootModel updated)
        {
            using (DbContextApp db = new DbContextApp())
            {
                RootModel current = await GetRoot(updated.ID);
                current.Title = updated.Title;
                return true;
            }
        }
    }
}
