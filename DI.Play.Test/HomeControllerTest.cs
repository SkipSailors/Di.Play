namespace DI.Play.Test;

using Di.Play.Controllers;
using Di.Play.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

[TestClass]
public class HomeControllerTest
{
    private HomeController? Service { get; set; }
    private IService? ThisService { get; set; }
    private IService? ThatService { get; set; }
    
    [TestInitialize]
    public void Initialize()
    {
        ThisService = Substitute.For<IService>();
        ThatService = Substitute.For<IService>();
        LoggerFactory factory = new();
        Logger<HomeController> logger = new(factory);
        Service = new HomeController(logger, ThisService, ThatService);
    }

    [TestMethod]
    public void TestCtorNotExceptional()
    {
        Assert.IsNotNull(Service);
    }

    [TestMethod]
    public void TestIndexNotExceptional()
    {
        Service!.Index();
    }

    [TestMethod]
    public void TestIndexUsesThis()
    {
        Service!.Index();
        ThisService!.Received(1).DoSomething();
    }

    [TestMethod]
    public void TestIndexUsesThat()
    {
        Service!.Index();
        ThatService!.Received(1).DoSomething();
    }
}