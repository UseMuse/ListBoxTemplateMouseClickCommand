﻿using Data.Model;
using Data.Root;
using Logic.Child;
using Logic.DTO;
using Logic.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public partial class MainLogic : IRootLogic
    {

        /// <summary>Метод возвращает <see cref="RootDTO"/> с данными из переданного <see cref="RootModel"/>.</summary>
        /// <param name="item">Экземпляр с данными.</param>
        /// <returns>Новый экземпляр <see cref="RootDTO"/> с данными из переданного <see cref="RootModel"/>.</returns>
        internal static RootDTO Mapper(RootModel item)
        {
            return new RootDTO(item.ID, item.Title);
        }

        /// <inheritdoc cref="IRootLogic.GetRoot(int)"/>
        public async Task<RootDTO> GetRoot(int rootId)
        {
            RootModel item = await rootRepository.GetRoot(rootId);
            if (item == null)
                throw new ArgumentException(nameof(rootId));
            RootDTO dto = Mapper(item);
            return dto;
        }

        /// <inheritdoc cref="IRootLogic.GetRoot(string)"/>
        public async Task<RootDTO> GetRoot(string title)
        {
            RootModel item = await rootRepository.GetRoot(title);
            if (item == null)
                throw new ArgumentException(nameof(title));
            RootDTO dto = Mapper(item);
            return dto;
        }

        /// <inheritdoc cref="IRootLogic.GetRoots()"/>
        public async Task<IEnumerable<RootDTO>> GetRoots()
        {
            IEnumerable<RootModel> items = await rootRepository.GetRoots();
            //List<RootDTO> dtos = new List<RootDTO>();
            //dtos.AddRange((from item in items select map(item)).ToList());
            //return dtos;
            return Array.AsReadOnly(items.Select(Mapper).ToArray());
        }
    }
}
