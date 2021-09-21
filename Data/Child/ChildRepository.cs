using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Child
{
    public class ChildRepository : IChildRepository
    {
        /// <inheritdoc cref="IChildRepository.GetChild(int)"/>
        public async Task<ChildModel> GetChild(int childId)
        {
            using (DbContextApp db = new DbContextApp())
            {
                return await db.Children.FindAsync(childId);
            }
        }

        /// <inheritdoc cref="IChildRepository.GetChild(string)"/>
        public async Task<ChildModel> GetChild(string title)
        {
            using (DbContextApp db = new DbContextApp())
            {
                return await db.Children.FirstOrDefaultAsync(c => c.Title == title);
            }
        }

        /// <inheritdoc cref="IChildRepository.GetChildren()"/>
        public async Task<List<ChildModel>> GetChildren()
        {
            using (DbContextApp db = new DbContextApp())
            {
                return await db.Children.ToListAsync();
            }
        }

        /// <inheritdoc cref="IChildRepository.GetChildren(int)"/>
        public async Task<List<ChildModel>> GetChildren(int rootId)
        {
            using (DbContextApp db = new DbContextApp())
            {
                return await db.Children.Where(c => c.ParentID == rootId).ToListAsync();
            }
        }

        /// <inheritdoc cref="IChildRepository.UpdateChild(ChildModel)"/>
        public async Task<bool> UpdateChild(ChildModel updated)
        {
            using (DbContextApp db = new DbContextApp())
            {
                ChildModel current = await GetChild(updated.ID);
                current.Title = updated.Title;
                return true;
            }
        }
    }
}
