namespace Lab9
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RemoveFromCart()
        {
            IWebDriver driver = new ChromeDriver();

            //driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://nbalance.by/");

            Thread.Sleep(1000);

            var mansBootTab = driver.FindElement(By.XPath("//div[@class='offers__image']"));
            var actions = new Actions(driver);

            actions.Click(mansBootTab);
            actions.Perform();

            Thread.Sleep(1000);

            var boots = driver.FindElement(By.XPath("//h2[@class='woocommerce-loop-product__title'][1]"));

            var jsExecute = (IJavaScriptExecutor)driver;

            jsExecute.ExecuteScript("arguments[0].scrollIntoView();", boots);

            Thread.Sleep(1000);

            actions.Click(boots);
            actions.Perform();

            Thread.Sleep(1000);

            var addToCartButton = driver.FindElement(By.XPath("//button[contains(text(),'В корзину')]"));

            actions.Click(addToCartButton);
            actions.Perform();

            Thread.Sleep(1000);

            var viewCartLink = driver.FindElement(By.LinkText("Просмотр корзины"));

            actions.Click(viewCartLink);
            actions.Perform();

            Thread.Sleep(1000);

            var removeButton = driver.FindElement(By.XPath("//a[@class='remove']"));

            jsExecute.ExecuteScript("arguments[0].scrollIntoView();", removeButton);

            Thread.Sleep(1000);

            Assert.IsNotNull(removeButton, "Removed successfuly");

            actions.Click(removeButton);
            actions.Perform();

            Assert.Pass();
        }
    }
}