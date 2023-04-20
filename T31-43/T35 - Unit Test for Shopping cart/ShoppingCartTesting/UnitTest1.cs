namespace ShoppingCartTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestZeroProducts()
        {
            var cart = new ShoppingCart();
            Assert.AreEqual(0, cart.products.Count);
        }

        [TestMethod]
        public void TestOneProduct()
        {
            var cart = new ShoppingCart();
            cart.AddProduct(new Product("Milk", 1.4));
            Assert.AreEqual(1, cart.products.Count);
        }

        [TestMethod]
        public void TestTwoProducts()
        {
            var cart = new ShoppingCart();
            cart.AddProduct(new Product("Milk", 1.4));
            cart.AddProduct(new Product("Bread", 2.2));
            Assert.AreEqual(2, cart.products.Count);
        }

        [TestMethod]
        public void TestFiveProducts()
        {
            var cart = new ShoppingCart();
            cart.AddProduct(new Product("Milk", 1.4));
            cart.AddProduct(new Product("Bread", 2.2));
            cart.AddProduct(new Product("Butter", 3.2));
            cart.AddProduct(new Product("Cheese", 4.2));
            cart.AddProduct(new Product("Eggs", 1.8));
            Assert.AreEqual(5, cart.products.Count);
        }
    }
}