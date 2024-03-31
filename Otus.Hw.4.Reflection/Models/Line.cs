namespace Otus.Hw._4.Reflection.Models;

[Serializable]
public class Line
{
    public int Number { get; set; }
    public int Type { get; set; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}