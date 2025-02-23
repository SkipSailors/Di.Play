namespace DI.Play.Test
{
    using Di.Play.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class ServiceTest
    {
        private IService? ThisService { get; set; }
        private IService? ThatService { get; set; }

        [TestInitialize]
        public void Start()
        {
            ThisService = new Service("this");
            ThatService = new Service("that");
        }
        
        [TestMethod]
        public void TestCtorNotExceptional()
        {
            Assert.IsNotNull(ThisService);
            Assert.IsNotNull(ThatService);
        }
        
        [TestMethod]
        public void TestDoSomethingNotExceptional()
        {
            string actualThis = ThisService!.DoSomething();
            Console.WriteLine(actualThis);
            string actualThat = ThatService!.DoSomething();
            Console.WriteLine(actualThat);
        }
        
        [TestMethod]
        public void TestBadServiceExceptional()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { new Service(null); });
        }
    }
}
