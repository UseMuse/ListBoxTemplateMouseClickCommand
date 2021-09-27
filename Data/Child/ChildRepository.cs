using Data;
using Data.Model;
using DTO;
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
        /// <summary>Создаёт новый экземпляр <see cref="ChildDto"/>.</summary>
        /// <param name="model">Данные для нового экземпляра.</param>
        /// <returns>Новый экземпляр <see cref="ChildDto"/> с данными из <paramref name="model"/>.</returns>
        protected ChildDto Map(ChildModel model)
        {
            return new ChildDto(model.ID, model.Title, model.ParentID);
        }

        /// <summary>Создаёт новый экземпляр <see cref="ChildDto"/>.</summary>
        /// <param name="dto">Данные для нового экземпляра.</param>
        /// <returns>Новый экземпляр <see cref="ChildDto"/> с данными из <paramref name="dto"/>.</returns>
        protected ChildModel Map(ChildDto dto)
        {
            return new ChildModel()
            {
                ID = dto.Id,
                Title = dto.Title,
                ParentID = dto.ParentID
            };
        }

        /// <summary>Копирует данные в <see cref="ChildModel"/> из <see cref="ChildDto"/>.</summary>
        /// <param name="model">Экземпляр в который нужно скопировать данные.</param>
        /// <param name="dto">Экземпляр из которого копируются данные.</param>
        protected void CopyFrom(ChildModel model, ChildDto dto)
        {
            if (model.ID != dto.Id)
                throw new Exception("Данные не для этого Id.");
            model.Title = dto.Title;
        }

        /// <summary>Проверяет идентичность данных.</summary>
        /// <param name="model">Экземпляр <see cref="ChildModel"/>.</param>
        /// <param name="dto">Экземпляр <see cref="ChildDto"/>.</param>
        /// <returns>Возвращает <see langword="true"/>, если данные в обоих экземплярах идентичны.</returns>
        protected bool ValuesEquals(ChildModel model, ChildDto dto)
        {
            return
                model.ID == dto.Id &&
                model.Title == dto.Title;
        }

        /// <inheritdoc cref="IChildRepository.GetChild(int)"/>
        public ChildDto GetChild(int childId)
        {
            using (DbContextApp db = new DbContextApp())
            {
                var model = db.Children.Find(childId);
                if (model == null)
                    return null;
                return Map(model);
            }
        }

        public ChildDto GetChild(string title)
        {
            using (DbContextApp db = new DbContextApp())
            {
                var model = db.Children.FirstOrDefault(c => c.Title == title);
                if (model == null)
                    return null;
                return Map(model);

            }
        }

        public IEnumerable<ChildDto> GetChildren(int rootId)
        {
            using (DbContextApp db = new DbContextApp())
            {
                return db.Children.Where(c => c.ParentID == rootId).Select(Map).ToArray();
            }
        }

        public ChildDto UpdateRoot(ChildDto oldChild, ChildDto newChild)
        {
            using (DbContextApp db = new DbContextApp())
            {
                ChildModel model = db.Children.Find(oldChild.Id);
                if (model?.ID != oldChild.Id)
                    throw new Exception("Child с таким Id в базе нет. Возможно кто-то уже его удалил.");
                if (!ValuesEquals(model, oldChild))
                    throw new Exception("У этого Child другой Title. Возможно кто-то уже его изменил.");

                CopyFrom(model, newChild);
                int change = db.SaveChanges();
                if (change != 1)
                    throw new Exception($"Должна была измениться одна запись, а изменилось {change} записей.");

                return Map(model);
            }
        }
    }
}
