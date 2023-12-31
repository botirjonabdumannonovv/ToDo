﻿using System.Linq.Expressions;
using ToDo.Domain.Common.Exceptions;
using ToDo.Domain.Entities;

namespace ToDo.Application.Todos.Services;

public interface ITodoService
{
    IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNotracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<TodoItem> UpdateAsync(TodoItem todoItem, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<TodoItem?> DeleteByIdAsync(Guid todoId, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}