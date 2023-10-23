using DotsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotsAPI.Data;

public class DotRepository : IDotRepository
{
    private static bool isDataSeeded = false;
    
    public DotRepository()
    {
        
        if (!isDataSeeded)
        {
            using (var context = new ApiContext())
            {
                var dots = new List<Dot>()
                {
                    new Dot()
                    {
                        X = 200,
                        Y = 100,
                        Radius = 50,
                        Color = "green",
                        Comments = new List<Comment>()
                        {
                            new Comment() { Text = "Выпить воды", BackgroundColor = "Blue" },
                            new Comment() { Text = "Сделать зарядку", BackgroundColor = "Pink" },
                        }
                    },
                    new Dot()
                    {
                        X = 350,
                        Y = 150,
                        Radius = 20,
                        Color = "black",
                        Comments = new List<Comment>()
                        {
                            new Comment() { Text = "Побегать", BackgroundColor = "Green" },
                            new Comment() { Text = "Поплавать", BackgroundColor = "White" },
                            new Comment() { Text = "Отдохнуть", BackgroundColor = "Red" },
                        }
                    },
                    new Dot()
                    {
                        X = 450,
                        Y = 450,
                        Radius = 60,
                        Color = "pink",
                        Comments = new List<Comment>()
                        {
                            new Comment() { Text = "Тестим тестим", BackgroundColor = "Green" },
                        }
                    },
                };
                context.Dots.AddRange(dots);
                context.SaveChanges();
                
                isDataSeeded = true;
            }
        }

    }
    
    public async Task<IEnumerable<Dot>> GetDots()
    {
        await using (var context = new ApiContext())
        {
            return await context.Dots
                .Include(a => a.Comments)
                .ToListAsync();
        }
    }
}