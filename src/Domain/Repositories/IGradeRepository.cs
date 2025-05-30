using Domain.Entities;

namespace Domain.Repositories;

public interface IGradeRepository
{
    Task<List<Grade>> GetAllAsync();
    Task<Grade> GetByIdAsync(int id);
    Task<Grade> AddAsync(Grade grade);
    Task<bool> UpdateAsync(int id, Grade grade);
    Task<bool> DeleteAsync(int id);
}