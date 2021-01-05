/*
 * Copyright (c) 2021 Víctor Vives - All rights reserved.
 * 
 * Licensed under the MIT License. 
 * See LICENSE file in the project root for full license information.
 */

using Microsoft.EntityFrameworkCore;
using TodoApi.Model;

namespace TodoApi.Context
{
    /// <summary>
    /// The todo context.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class TodoContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the todo items.
        /// </summary>
        /// <value>
        /// The todo items.
        /// </value>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
