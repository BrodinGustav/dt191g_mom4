using System.ComponentModel.DataAnnotations;    //Möjliggör för Required

namespace dt191g_mom4.Models;


public class Music {
    //Properties
    public int Id { get; set; }

    [Required (ErrorMessage = "Ange ett namn på artisten")]
    public string? ArtistName { get; set; }

    [Required  (ErrorMessage = "Ange låtlängd i sekunder")]
    public int Length   { get; set; }

    [Required (ErrorMessage = "Ange låttitel")]
    public string? Title { get; set; }

    [Required (ErrorMessage = "Ange kategori för låt")]
    public string? Category { get; set; }

    public DateTime DateRegister { get; set; } = DateTime.Now;  //Datum och klockslag när post lagras i DB
}

