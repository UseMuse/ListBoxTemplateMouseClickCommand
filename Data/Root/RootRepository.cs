using Data.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Root
{
    public partial class RootRepository : IRootRepository
    {
        /// <summary>Создаёт новый экземпляр <see cref="RootDto"/>.</summary>
        /// <param name="model">Данные для нового экземпляра.</param>
        /// <returns>Новый экземпляр <see cref="RootDto"/> с данными из <paramref name="model"/>.</returns>
        protected RootDto Map(RootModel model)
        {
            return new RootDto(model.ID, model.Title);
        }

        /// <summary>Создаёт новый экземпляр <see cref="RootDto"/>.</summary>
        /// <param name="dto">Данные для нового экземпляра.</param>
        /// <returns>Новый экземпляр <see cref="RootDto"/> с данными из <paramref name="dto"/>.</returns>
        protected RootModel Map(RootDto dto)
        {
            return new RootModel()
            {
                ID = dto.Id,
                Title = dto.Title
            };
        }

        /// <inheritdoc cref="IRootRepository.GetRoot(int)"/>
        public RootDto GetRoot(int rootId)
        {
            if (IsDemoData)
            {
                if (DemoData.TryGetValue(rootId, out RootModel model))
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
                    var model = db.Roots.Find(rootId);
                    if (model == null)
                        return null;
                    return Map(model);
                }
            }
        }

        /// <inheritdoc cref="IRootRepository.GetRoot(string)"/>
        public RootDto GetRoot(string title)
        {
            if (IsDemoData)
            {
                RootModel model = DemoData.Values.FirstOrDefault(rm => rm.Title == title);
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
                    var model = db.Roots.FirstOrDefault(c => c.Title == title);
                    if (model == null)
                        return null;
                    return Map(model);

                }
            }
        }

        /// <inheritdoc cref="IRootRepository.GetRoots()"/>
        public IEnumerable<RootDto> GetRoots()
        {
            if (IsDemoData)
            {
                return DemoData.Values.Select(Map).ToArray();
            }
            else
            {
                using (DbContextApp db = new DbContextApp())
                {
                    return db.Roots.ToArray().Select(Map).ToArray();
                }
            }
        }

        /// <inheritdoc cref="IRootRepository.UpdateRoot(RootModel)"/>
        public RootDto UpdateRoot(RootDto oldRoot, RootDto newRoot)
        {
            if (IsDemoData)
            {
                if (!DemoData.TryGetValue(oldRoot.Id, out RootModel model))
                    throw new Exception("Root с таким Id в базе нет. Возможно кто-то уже его удалил.");
                if (!ValuesEquals(model, oldRoot))
                    throw new Exception("У этого Root другой Title. Возможно кто-то уже его изменил.");

                CopyFrom(model, newRoot);

                return Map(model);
            }
            else
            {
                using (DbContextApp db = new DbContextApp())
                {
                    RootModel model = db.Roots.Find(oldRoot.Id);
                    if (model?.ID != oldRoot.Id)
                        throw new Exception("Root с таким Id в базе нет. Возможно кто-то уже его удалил.");
                    if (!ValuesEquals(model, oldRoot))
                        throw new Exception("У этого Root другой Title. Возможно кто-то уже его изменил.");

                    CopyFrom(model, newRoot);
                    int change = db.SaveChanges();
                    if (change != 1)
                        throw new Exception($"Должна была измениться одна запись, а изменилось {change} записей.");

                    return Map(model);
                }
            }
        }


        /// <summary>Копирует данные в <see cref="RootModel"/> из <see cref="RootDto"/>.</summary>
        /// <param name="model">Экземпляр в который нужно скопировать данные.</param>
        /// <param name="dto">Экземпляр из которого копируются данные.</param>
        protected void CopyFrom(RootModel model, RootDto dto)
        {
            if (model.ID != dto.Id)
                throw new Exception("Данные не для этого Id.");
            model.Title = dto.Title;
        }

        /// <summary>Проверяет идентичность данных.</summary>
        /// <param name="model">Экземпляр <see cref="RootModel"/>.</param>
        /// <param name="dto">Экземпляр <see cref="RootDto"/>.</param>
        /// <returns>Возвращает <see langword="true"/>, если данные в обоих экземплярах идентичны.</returns>
        protected bool ValuesEquals(RootModel model, RootDto dto)
        {
            return
                model.ID == dto.Id &&
                model.Title == dto.Title;
        }

        protected readonly Random random = new Random();

        /// <inheritdoc cref="IRootRepository.AddRoot(RootDto)"/>
        public RootDto AddRoot(RootDto dto)
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
                    db.Roots.Add(model);
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
