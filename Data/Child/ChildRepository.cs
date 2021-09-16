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
        public async Task<ChildModel> GetChild(int childId)
        {
            using (var db = new DbContextApp())
            {
                return await db.Children.FindAsync(childId);
            }
        }

        public async Task<ChildModel> GetChild(string title)
        {
            using (var db = new DbContextApp())
            {
                return await db.Children.FirstOrDefaultAsync(c => c.Title == title);
            }
        }

        public async Task<List<ChildModel>> GetChildren()
        {
            using (var db = new DbContextApp())
            {
                return await db.Children.ToListAsync();
            }
        }

        public async Task<List<ChildModel>> GetChildren(int rootId)
        {
            using (var db = new DbContextApp())
            {
                return await db.Children.Where(c => c.ParentID == rootId).ToListAsync();
            }
        }
    }
}
