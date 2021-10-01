using Data.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Child
{
    public partial class ChildRepository : IChildRepository
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
            if (IsDemoData)
            {
                if (DemoData.TryGetValue(childId, out ChildModel model))
                {
                    return Map(model);
                }
                else
                {
                    return null;
                }
            }
            else
            {

                using (DbContextApp db = new DbContextApp())
                {
                    var model = db.Children.Find(childId);
                    if (model == null)
                        return null;
                    return Map(model);
                }
            }
        }

        /// <inheritdoc cref="IChildRepository.GetChild(string)"/>
        public ChildDto GetChild(string title)
        {
            if (IsDemoData)
            {
                ChildModel model = DemoData.Values.FirstOrDefault(rm => rm.Title == title);
                if (model != null)
                {
                    return Map(model);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                using (DbContextApp db = new DbContextApp())
                {
                    var model = db.Children.FirstOrDefault(c => c.Title == title);
                    if (model == null)
                        return null;
                    return Map(model);
                }
            }
        }

        /// <inheritdoc cref="IChildRepository.GetChildren(int)"/>
        public IEnumerable<ChildDto> GetChildren(int rootId)
        {
            if (IsDemoData)
            {
                return DemoData.Values.Where(cm => cm.ParentID == rootId).Select(Map).ToArray();
            }
            else
            {
                using (DbContextApp db = new DbContextApp())
                {
                    return db.Children.Where(c => c.ParentID == rootId).Select(Map).ToArray();
                }
            }
        }

        /// <inheritdoc cref="IChildRepository.UpdateRoot(ChildDto, ChildDto)"/>
        public ChildDto UpdateRoot(ChildDto oldChild, ChildDto newChild)
        {
            if (IsDemoData)
            {
                if (!DemoData.TryGetValue(oldChild.Id, out ChildModel model))
                    throw new Exception("Root с таким Id в базе нет. Возможно кто-то уже его удалил.");
                if (!ValuesEquals(model, oldChild))
                    throw new Exception("У этого Root другой Title. Возможно кто-то уже его изменил.");

                CopyFrom(model, newChild);

                return Map(model);
            }
            else
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

        /// <inheritdoc cref="IChildRepository.GetChildren()"/>
        public IEnumerable<ChildDto> GetChildren()
        {
            if (IsDemoData)
            {
                return DemoData.Values.Select(Map).ToArray();
            }
            else
            {
                using (DbContextApp db = new DbContextApp())
                {
                    return db.Children.Select(Map).ToArray();
                }
            }
        }

        protected readonly Random random = new Random();

        /// <inheritdoc cref="IChildRepository.AddRoot(ChildDto)"/>
        public ChildDto AddRoot(ChildDto dto)
        {
            var model = Map(dto);
            if (IsDemoData)
            {
                int id = 1;
                while (DemoData.ContainsKey(id))
                    id = random.Next(1000);
                model.ID = id;
                DemoData.Add(id, model);
                return Map(model);
            }
            else
            {
                using (DbContextApp db = new DbContextApp())
                {
                    db.Children.Add(model);
                    int change = db.SaveChanges();

                    // После сохранения Модели в ней данные могут быть изменены.
                    // Допустим, ID при добавлении игнорируется и после добавления
                    // в он будет перезаписан ID из БД.
                    // Поэтому надо создать новый DTO из той же Модели и вернуть его.

                    if (change != 1)
                        throw new Exception($"Должна была измениться одна запись, а изменилось {change} записей.");

                    return Map(model);
                }
            }
        }
    }
}
