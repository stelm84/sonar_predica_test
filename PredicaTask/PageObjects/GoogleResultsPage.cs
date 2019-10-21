using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace PredicaTask.Objects
{
    class GoogleResultsPage
    {
        private readonly IWebDriver _driver;
        private IWebElement _link;

        public GoogleResultsPage(IWebDriver driver) => _driver = driver;

        public IWebElement WarsawContact => _driver.FindElement(By.ClassName("LrzXr"));

        public ReadOnlyCollection<IWebElement> FindAllResults()
        {
            ReadOnlyCollection<IWebElement> resultList = _driver.FindElements(By.ClassName("rc"));
            return resultList;
        }

        //Checking Predica's page is positioned on top of google results after searchin for 'Predica' keyword
        public void CheckFirstResultIsPredica(ReadOnlyCollection<IWebElement> list, string predica_site)
        {
            _link = list[0].FindElement(By.TagName("a"));
            StringAssert.AreEqualIgnoringCase(predica_site, _link.GetAttribute("href"));
            Console.WriteLine("First result is: " + _link.GetAttribute("href"));
        }

        //Checking the Predica's Warsaw contact details displayed in google's top search
        public void CheckWarsawContact(string warsaw_address)
        {
            if (WarsawContact.Displayed)
            {
                StringAssert.AreEqualIgnoringCase(warsaw_address, WarsawContact.Text);
                Console.WriteLine("Contact details found: " + WarsawContact.Text);
            }
        }

        //Checking that both Predica's 'linkedin' and 'facebook' profiles are within 5 top results
        public void CheckLinkedInFacebookWithinTopResults(ReadOnlyCollection<IWebElement> list, int top, string linkedin, string facebook)
        {
            bool li = false, fb = false;
            Console.WriteLine("Top 5 search results:");
            for (int i=0; i<top; i++)
            {
                Console.WriteLine("  " + (i+1) + " value found: " + list[i].FindElement(By.TagName("h3")).Text);
                if (list[i].FindElement(By.TagName("h3")).Text.Contains(linkedin))
                    li = true;
                if (list[i].FindElement(By.TagName("h3")).Text.Contains(facebook))
                    fb = true;
            }
            if (li && fb)
                Console.WriteLine("Both pages: linkedin and facebook found withing top 5 search results");
            else
                Assert.Fail("Unable to find linkedin and/or facebook profiles within top 5 search results");
        }

    }
}

