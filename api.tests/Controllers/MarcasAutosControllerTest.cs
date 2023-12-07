using api.Controllers;
using api.Models;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace api.Tests.Controllers;

public class MarcasAutosControllerTest : IDisposable
{
    private DataContext _context;

    public MarcasAutosControllerTest()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase("test")
            .Options;
        _context = new DataContext(options);

        // it seems EF 7 does not support custom initializers
        // Database.SetInitializer(...);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        var list = Enumerable.Range(1, 3)
            .Select(index => new MarcasAutos
            {
                Nombre = "Name" + index,
                Fundacion = 1900 + index,
                Pais = "Country" + index
            })
            .ToList();
        list.ForEach(e  => _context.MarcasAutos.Add(e));
        _context.SaveChanges();

    }

    public void Dispose()
    {
        if (_context != null) {
            _context.Dispose();
        }
    }

    [Fact]
    public void ListTest()
    {
        var logger = new Mock<ILogger<MarcasAutosController>>().Object;
        var controller = new MarcasAutosController(_context, logger);

        var expected = _context.MarcasAutos;
        Assert.Equal(expected, controller.Index());
    }
}
