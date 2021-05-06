/*
 * Copyright (c) 2021 Víctor Vives - All rights reserved.
 * 
 * Licensed under the MIT License. 
 * See LICENSE file in the project root for full license information.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

using TodoApi.Model;
using TodoApi.Repositories;

namespace TodoApi.Services
{
    /// <summary>
    /// The todo service.
    /// </summary>
    /// <seealso cref="TodoApi.Services.ITodoService" />
    public class TodoService : ITodoService
    {
        /// <summary>
        /// The todo repository.
        /// </summary>
        private readonly ITodoRepository todoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoService"/> class.
        /// </summary>
        /// <param name="todoRepository">The todo repository.</param>
        public TodoService(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        /// <summary>
        /// Creates the specified todo item.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <returns>
        /// The created todo item.
        /// </returns>
        public Task<TodoItem> Create(TodoItem todoItem) =>
            this.todoRepository.Create(todoItem);

        /// <summary>
        /// Reads the todo item with the specified identifier.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        /// The item with the specified identifier.
        /// </returns>
        public Task<TodoItem> Read(int id) =>
            this.todoRepository.Read(id);

        /// <summary>
        /// Updates the todo item with specified identifier.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <returns>
        /// Nothing.
        /// </returns>
        public Task<TodoItem> Update(TodoItem todoItem) =>
            this.todoRepository.Update(todoItem);

        /// <summary>
        /// Deletes the todo item with the specified identifier.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        /// Nothing.
        /// </returns>
        public Task Delete(int id) =>
            this.todoRepository.Delete(id);

        /// <summary>
        /// Gets all todo items.
        /// </summary>
        /// <returns>
        /// A list with the todo items.
        /// </returns>
        public Task<IList<TodoItem>> GetAll() =>
            this.todoRepository.GetAll();

        /// <summary>
        /// Checks if the specified todo item exists.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        ///   <c>true</c> if this instance exists; otherwise, <c>false</c>.
        /// </returns>
        public bool Exists(int id) =>
            this.todoRepository.Exists(id);
    }
}
