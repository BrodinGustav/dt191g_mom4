using System.ComponentModel.DataAnnotations;    //Möjliggör för Required

namespace dt191g_mom4.Models;


public class Music {
    //Properties
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int Length   { get; set; }

    [Required]
    public string? Title { get; set; }

    public enum Category  {rock, blues, folk}

    public DateTime DateRegister { get; set; } = DateTime.Now;  //Datum och klockslag när post lagras i DB
}

