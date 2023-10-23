using DotsAPI.Models;

namespace DotsAPI.Data;

public interface IDotRepository
{
    public Task<IEnumerable<Dot>> GetDots();
}