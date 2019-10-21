using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace PredicaTask.Objects
{
    class GoogleSearchPage
    {
        private readonly IWebDriver _driver;

        public GoogleSearchPage(IWebDriver driver) => _driver = driver;

        public IWebElement SearchInput => _driver.FindElement(By.Name("q"));

        public void ChromeBrowserOpen()
        {
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.AreEqual(1, _driver.WindowHandles.Count);
            Console.WriteLine("Chrome browser successfully opened");
        }
        public bool GoogleSearchPageOpen(String url)
        {
            _driver.Navigate().GoToUrl(url);
            StringAssert.AreEqualIgnoringCase("google", _driver.Title, "Page title expected to be 'Google'");
            if (_driver.Url.Equals("https://www.google.com/"))
            {
                Console.WriteLine("Page loaded is Google-Search");
                return true;
            }
            else
                return false;
        }
        public void SearchInputPresent()
        {
            Assert.True(SearchInput.Displayed);
            Console.WriteLine("Search input is visible");
            SearchInput.Click();
        }
        public GoogleResultsPage PutTextInSearch(string keyword)
        {
            SearchInput.SendKeys(keyword);
            SearchInput.SendKeys(Keys.Enter);
            Console.WriteLine("Successfully entered the text into the search input");
            return new GoogleResultsPage(_driver);
        }
    }
}