﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer.Entities;

namespace Business.Domain_Layer.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        /// <summary>
        ///     Composition: TRepository holds all classes of type T
        /// </summary>
        /// <remarks>static: There can only be one list of type T aka no new ones.</remarks>
        internal static List<T> Items;

        /// <summary>
        ///     Adds a new value to the list of type T
        /// </summary>
        /// <param name="entity">The entity you're trying to add to the list</param>
        internal abstract void AddItem(T entity);

        /// <summary>
        ///     Gets value of type T using it's unique Id from inheritance with Entity class
        /// </summary>
        /// <param name="id">The id of the entity you're trying to find</param>
        internal abstract T GetItem(int id);

        /// <summary>
        ///     Returns all classes of type T in the list Items
        /// </summary>
        internal abstract List<T> GetAll();

        /// <summary>
        ///     Removes item of type T based of Id
        /// </summary>
        /// <param name="id">The id of the entity you're trying to find</param>
        internal abstract void RemoveItem(int id);

        /// <summary>
        /// Loads list of T to the Items paramater
        /// </summary>
        /// <param name="list">The gathered list of T </param>
        internal abstract void Load(List<T> list);

        /// <summary>
        /// Update T
        /// </summary>
        /// <param name="entity">The T you want to update</param>
        /// <returns>After updating it returns the new T that's directly gathered from the repository</returns>
        internal abstract T UpdateItem(T entity);

        /// <summary>
        ///     Calculates new Id based on index of previous entities ( BaseID = 1 )
        /// </summary>
        internal int GetNextId()
        {
            var maxId = 0;
            foreach (Entity e in Items)
                if (e.Id > maxId)
                    maxId = e.Id;
            return maxId + 1;
        }
    }
}
