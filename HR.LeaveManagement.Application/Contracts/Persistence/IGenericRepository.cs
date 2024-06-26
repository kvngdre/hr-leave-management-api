﻿namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T?> FindByIdAsync(int id);

    Task<IReadOnlyList<T>> FindAllAsync();

    Task<T> InsertAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
