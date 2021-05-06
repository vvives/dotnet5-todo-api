/*
 * Copyright (c) 2021 Víctor Vives - All rights reserved.
 * 
 * Licensed under the MIT License. 
 * See LICENSE file in the project root for full license information.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

using TodoApi.Model;

namespace TodoApi.Services
{
    /// <summary>
    /// The todo service interface.
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Creates the specified todo item.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <returns>
        /// The created todo item.
        /// </returns>
        Task<TodoItem> Create(TodoItem todoItem);

        /// <summary>
        /// Reads the todo item with the specified identifier.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        /// The item with the specified identifier.
        /// </returns>
        Task<TodoItem> Read(int id);

        /// <summary>
        /// Updates the todo item with specified identifier.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <returns>
        /// Nothing.
        /// </returns>
        Task<TodoItem> Update(TodoItem todoItem);

        /// <summary>
        /// Deletes the todo item with the specified identifier.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        /// Nothing.
        /// </returns>
        Task Delete(int id);

        /// <summary>
        /// Gets all todo items.
        /// </summary>
        /// <returns>
        /// A list with the todo items.
        /// </returns>
        Task<IList<TodoItem>> GetAll();

        /// <summary>
        /// Checks if the specified todo item exists.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        ///   <c>true</c> if this instance exists; otherwise, <c>false</c>.
        /// </returns>
        bool Exists(int id);
    }
}
