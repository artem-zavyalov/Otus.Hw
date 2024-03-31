namespace Otus.Hw._4.Reflection.Models;

[Serializable]
public class TestClass2
{
    public List<Line> Lines { get; set; } = null!;
    public List<int> I3 { get; set; } = null!;
    public int I1 { get; set; }
    public int I2 { get; set; }

    public static TestClass2 Get()
    {
        return new TestClass2
        {
            I1 = 1,
            I2 = 2,
            I3 = new List<int> {4, 5, 6},
            Lines = new List<Line>
            {
                new()
                {
                    Number = 1,
                    Type = 1,
                    Name = "abc",
                    Quantity = 3,
                    Price = new decimal(11.1)
                },
                new()
                {
                    Number = 2,
                    Type = 2,
                    Name = "bcd",
                    Quantity = 4,
                    Price = new decimal(0.123)
                }
            }
        };
    }
}