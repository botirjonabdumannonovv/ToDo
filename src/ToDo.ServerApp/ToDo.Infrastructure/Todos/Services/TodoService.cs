using System.Linq.Expressions;
using FluentValidation;
using ToDo.Application.Todos.Services;
using ToDo.Domain.Entities;
using ToDo.Persistence.Repositories.Interfaces;

namespace ToDo.Infrastructure.Todos.Services;

public class TodoService(ITodoRepository repository, IValidator<TodoItem> todoValidator) : ITodoService
{
    public IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>>? predicate = default, bool asNoTracking = false)
    {
        return repository.Get(predicate, asNoTracking);
    }

    public ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNotracking = false, CancellationToken cancellationToken = default)
    {
        return repository.GetByIdAsync(todoId, asNotracking, cancellationToken);
    }

    public ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(todoItem);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        return repository.CreateAsync(todoItem, saveChanges, cancellationToken);
    }

    public ValueTask<TodoItem> UpdateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(todoItem);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        return repository.UpdateAsync(todoItem, saveChanges, cancellationToken);
    }

    public ValueTask<TodoItem?> DeleteByIdAsync(Guid todoId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return repository.DeleteByIdAsync(todoId, saveChanges, cancellationToken);
    }
}