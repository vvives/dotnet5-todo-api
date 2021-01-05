/*
 * Copyright (c) 2021 Víctor Vives - All rights reserved.
 * 
 * Licensed under the MIT License. 
 * See LICENSE file in the project root for full license information.
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TodoApi.Context;
using TodoApi.Model;

namespace TodoApi.Repositories
{
    /// <summary>
    /// The todo repository class.
    /// </summary>
    /// <seealso cref="TodoApi.Repositories.ITodoRepository" />
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TodoContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TodoRepository(TodoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates the specified todo item.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <returns>
        /// The created todo item.
        /// </returns>
        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            return todoItem;
        }

        /// <summary>
        /// Reads the todo item with the specified identifier.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        /// The item with the specified identifier.
        /// </returns>
        public async Task<TodoItem> Read(int id)
        {
            return await context.TodoItems.FindAsync(id);
        }

        /// <summary>
        /// Updates the todo item with specified identifier.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <returns>
        /// Nothing.
        /// </returns>
        public async Task<TodoItem> Update(TodoItem todoItem)
        {
            context.Entry(todoItem).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return todoItem;
        }

        /// <summary>
        /// Deletes the specified todo item.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        public async Task Delete(int id)
        {
            TodoItem todoItem = await context.TodoItems.FindAsync(id);
            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all todo items.
        /// </summary>
        /// <returns>
        /// A list with the todo items.
        /// </returns>
        public async Task<IList<TodoItem>> GetAll()
        {
            return await context.Set<TodoItem>().ToListAsync();
        }

        /// <summary>
        /// Checks if the specified todo item exists.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        ///   <c>true</c> if this instance exists; otherwise, <c>false</c>.
        /// </returns>
        public bool Exists(int id) =>
            context.TodoItems.Any(todoItem => todoItem.Id == id);
    }
}
