using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.ApplicationCore;

[TestClass]
public class ServicioControllerTests
{
    private ServicioController _servicioController;

    [TestInitialize]
    public void Setup()
    {
        _servicioController = new ServicioController();
    }
    [TestMethod]
    public void AlquilarCoche_ValidData_ReturnsOkResult()
    {
        var cocheId = 1; 
        var usuario = new Usuario()
        {
            PuedeAlquilar = true,
            
        };

        var result = _servicioController.AlquilarCoche(cocheId, usuario) as OkObjectResult;

        Assert.IsNotNull(result);
        Assert.AreEqual("Coche alquilado correctamente.", result.Value);
    }

}
