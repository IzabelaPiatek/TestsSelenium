

using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace TestsSelenium
{
    public class Tests //: IDisposable
    {
        IWebDriver driver;  //zmienna dost�pna w ka�dej metodzie

        [SetUp]
        public void Setup()  //metoda wykonuj�ca si� przed ka�dym testem
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Position = new System.Drawing.Point(8, 30); // ustawienie pozycji otwarcia okna przegl�darki
            driver.Manage().Window.Size = new System.Drawing.Size(1290, 730); //ustawienie rozmiaru okna przegl�darki

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(7);
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(7);
        }

        [Test]
        public void TestGoogle() //metoda
        {
            driver.Navigate().GoToUrl("http://google.pl/"); //przejd� do strony
            driver.FindElement(By.XPath("//*[text()='Zaakceptuj wszystko']")).Click(); //akceptuje warunki googla (u�ytkownik niezalogowany)
            IWebElement searchField = driver.FindElement(By.CssSelector("[title='Szukaj']")); // namierzanie pola szukaj
            string searchEntry = "Borrusia Dortmund";
            searchField.SendKeys(searchEntry); // wysy�amy do pola szukaj znaki "Wszech�wiaty r�wnoleg�e"
            searchField.Submit(); // wyszukuje

            driver.FindElement(By.XPath("//*[text()='Borussia Dortmund � Wikipedia, wolna encyklopedia']")).Click(); // szukamy takiego wyniku w googlu


            string entryUrl = "https://pl.wikipedia.org/wiki/Borussia_Dortmund";
            ClassicAssert.AreEqual(entryUrl, driver.Url, "URL is not correct"); // sprawdzamy czy to chcieli�my sprawdzi� dzia�a. Pierwszy parametr to czego my si� spodziewamy, a drugi to co rzeczywi�cie si� znajduje na stronie

        }
        [Test]
        public void TestAndroidAssets()
        {
            driver.Navigate().GoToUrl("http://google.pl/"); //przejd� do strony
            driver.FindElement(By.XPath("//*[text()='Zaakceptuj wszystko']")).Click(); //akceptuje warunki googla (u�ytkownik niezalogowany)
            IWebElement searchField = driver.FindElement(By.CssSelector("[title='Szukaj']")); // namierzanie pola szukaj
            string searchEntry = "Android Assets";
            searchField.SendKeys(searchEntry); // wysy�amy do pola szukaj znaki "Wszech�wiaty r�wnoleg�e"
            searchField.Submit(); // wyszukuje

            driver.FindElement(By.XPath("//*[text()='Android Asset Studio']")).Click(); // szukamy takiego wyniku w googlu

            driver.FindElement(By.XPath("//*[text()='Launcher icon generator']")).Click();

            driver.FindElement(By.XPath("//*[text()='Clipart']")).Click();

            IWebElement findClipart = driver.FindElement(By.XPath("//input[@placeholder='Find clipart']"));
            string searchClipartName = "computer";
            findClipart.SendKeys(searchClipartName);
            driver.FindElement(By.XPath("//div[@title='computer']")).Click();
           
            driver.FindElement(By.XPath("//*[text()='Trim']")).Click();

            driver.FindElement(By.XPath("//button[@class='form-field-color-widget']")).Click();
            string color = "FFF700";
            string backgroundColor = "000000";
            IWebElement findHexColor = driver.FindElement(By.XPath("//input[@value='607D8B']"));
            
            for (int i = 0; i < 7; i++)
            {
                findHexColor.SendKeys(Keys.Backspace);
            }
            
            findHexColor.Click();
            findHexColor.SendKeys(color);
            findHexColor.SendKeys(Keys.Escape);

            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[3]/div/div/div/button")).Click();
            IWebElement findHexBackgroundColor = driver.FindElement(By.XPath("//input[@value='448AFF']"));

            for (int i = 0; i < 7; i++)
            {
                findHexBackgroundColor.SendKeys(Keys.Backspace);
            }
            
            findHexBackgroundColor.Click();
            findHexBackgroundColor.SendKeys(backgroundColor);
            findHexBackgroundColor.SendKeys(Keys.Escape);

            driver.FindElement(By.XPath("//*[text()='Center']")).Click();

            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[5]/div/div/select")).Click();
            IWebElement shapePicker = driver.FindElement(By.XPath("//option[@value='circle']"));
            shapePicker.Click();


            driver.FindElement(By.XPath("//*[text()='Elevate']")).Click();
            
            IWebElement nameField = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[7]/div/input"));
            string iconName = "black_yellow_computer";

            for (int i = 0; i < 12; i++)
            {
                nameField.SendKeys(Keys.Backspace);
            }
            nameField.SendKeys(iconName);

            driver.FindElement(By.Id("download-zip-button")).Click();

            string entryUrl = "https://romannurik.github.io/AndroidAssetStudio/";

        }

        [TearDown]
        public void QuitDriver() //metoda odpala si� po ka�dym te�cie -> wychodzi z drivera
        {
            driver.Quit(); // zamyka przegl�dark�, i ubij proces ChromeDriver �eby nie wisia�
            //driver.Close(); // zamyka przegl�dark�, ale nie ubije procesu ChromeDriver
        }


    }
}

