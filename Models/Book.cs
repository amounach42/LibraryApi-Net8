using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components.Web;
using Models;

namespace Models;
public class Book {
    public int Id { get; set; }
    public string? Title { get ; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int AuthorId { get; set; } 
    public Author Author { get; set; }
}