using api.Models;

namespace api.Tests.Models;

public class MarcasAutosTest
{
    [Fact]
    public void CreateTest()
    {
        var marcasAutos = new MarcasAutos {
            Nombre = "Toyota",
            Fundacion = 1933,
            Pais = "Japon"
        };
        Assert.Equal("Toyota", marcasAutos.Nombre);
        Assert.Equal(1933, marcasAutos.Fundacion);
        Assert.Equal("Japon", marcasAutos.Pais);
    }

    [Fact]
    public void EqualsTest()
    {
        var a = new MarcasAutos {
            Nombre = "Toyota",
            Fundacion = 1933,
            Pais = "Japon"
        };
        var b = new MarcasAutos {
            Nombre = "Toyota",
            Fundacion = 1933,
            Pais = "Japon"
        };
        Assert.Equal(a, b);
    }

    [Fact]
    public void GetHashCodeTest()
    {
        var nombre = "Toyota";
        var fundacion = 1933;
        var pais = "Japon";

        var a = new MarcasAutos {
            Nombre = nombre,
            Fundacion = fundacion,
            Pais = pais
        };

        var expected = HashCode.Combine(nombre, fundacion, pais);
        Assert.Equal(expected, a.GetHashCode());
    }
}
