namespace Otus.Hw._4.Reflection.Models;

[Serializable]
public class TestClass
{
    public int I1 { get; set; }
    public int I2 { get; set; }
    public int I3 { get; set; }
    public int I4 { get; set; }
    public int I5 { get; set; }

    public static TestClass Get()
    {
        return new TestClass {I1 = 1, I2 = 2, I3 = 3, I4 = 4, I5 = 5};
    }
}