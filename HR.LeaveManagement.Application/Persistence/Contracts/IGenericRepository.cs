﻿namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> FindByIdAsync(int id);

    Task<IReadOnlyList<T>> FindAllAsync();

    Task<T> InsertAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<T> DeleteAsync(T entity);
}