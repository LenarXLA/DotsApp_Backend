using System.ComponentModel.DataAnnotations.Schema;

namespace DotsAPI.Models;

public class Dot
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Radius { get; set; }
    public string? Color { get; set; }
    public List<Comment>? Comments { get; set; }
    
}