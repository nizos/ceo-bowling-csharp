using Example;

namespace Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Greet()
    {
        Assert.That(MyClass.Greet(), Is.EqualTo("Hello World!"));
    }
}
