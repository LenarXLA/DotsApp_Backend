using System.ComponentModel.DataAnnotations.Schema;

namespace DotsAPI.Models;

public class Comment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? BackgroundColor { get; set; }
}