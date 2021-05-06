/*
 * Copyright (c) 2021 Víctor Vives - All rights reserved.
 * 
 * Licensed under the MIT License. 
 * See LICENSE file in the project root for full license information.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApi.Model;
using TodoApi.Model.Requests;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    /// <summary>
    /// The todo controller class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("todo")]
    public class TodoController : ControllerBase
    {
        /// <summary>
        /// The todo service.
        /// </summary>
        private readonly ITodoService todoService;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<TodoItem> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController" /> class.
        /// </summary>
        /// <param name="todoService">The todo service.</param>
        /// <param name="logger">The logger.</param>
        public TodoController(ITodoService todoService, ILogger<TodoItem> logger)
        {
            this.todoService = todoService;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the specified todo item.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The created todo item.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(CreateTodoItemRequest request)
        {
            this.logger.LogInformation("Trying to create a new todo item.");

            TodoItem todoItem = new TodoItem
            {
                Description = request.Description,
                CreationDate = DateTime.Now,
                IsComplete = false,
            };

            todoItem = await this.todoService.Create(todoItem).ConfigureAwait(false);

            this.logger.LogInformation("The new todo item has been created successfully.");

            return todoItem;
        }

        /// <summary>
        /// Reads the todo item with the specified identifier.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        /// The item with the specified identifier.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Read(int id)
        {
            this.logger.LogInformation($"Trying to retrieve the todo item with identifier {id}.");

            TodoItem todoItem = await this.todoService.Read(id).ConfigureAwait(false);

            if (todoItem == null)
            {
                this.logger.LogError($"The todo item with identifier {id} has not been found.");

                return NotFound();
            }

            this.logger.LogInformation($"The todo item with identifier {id} has been retrieved successfully.");

            return todoItem;
        }

        /// <summary>
        /// Updates the todo item with the specified identifier.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        /// No content.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodoItemRequest request)
        {
            this.logger.LogInformation($"Trying to update the todo item with identifier {id}.");

            if (!this.todoService.Exists(id))
            {
                this.logger.LogError($"The todo item with identifier {id} has not been found.");

                return NotFound();
            }

            TodoItem todoItem = await this.todoService.Read(id).ConfigureAwait(false);
            todoItem.Description = request.Description;
            todoItem.IsComplete = request.IsComplete;

            await this.todoService.Update(todoItem);

            this.logger.LogInformation($"The todo item with identifier {id} has been updated successfully.");

            return NoContent();
        }

        /// <summary>
        /// Deletes the todo item.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        /// <returns>
        /// No content.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            this.logger.LogInformation($"Trying to remove the todo item with identifier {id}.");

            if (!this.todoService.Exists(id))
            {
                this.logger.LogError($"The todo item with identifier {id} has not been found.");

                return NotFound();
            }

            await this.todoService.Delete(id);

            this.logger.LogInformation($"The todo item with identifier {id} has been removed successfully.");

            return NoContent();
        }

        /// <summary>
        /// Gets all todo items.
        /// </summary>
        /// <returns>
        /// A list with all todo items.
        /// </returns>
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            this.logger.LogInformation("Trying to retrieve all todo items.");

            IEnumerable<TodoItem> todoItems = await this.todoService.GetAll().ConfigureAwait(false);

            this.logger.LogInformation("All todo items were retrieved successfully.");

            return todoItems;
        }
    }
}
