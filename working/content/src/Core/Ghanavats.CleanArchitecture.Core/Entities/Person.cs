namespace Ghanavats.CleanArchitecture.Core.Entities;

/// <summary>
/// A greatly simplified sample Person entity.
/// Replace with your own or remove if not needed.
/// </summary>
public class Person
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
}
