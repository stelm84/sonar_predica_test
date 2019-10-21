using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PredicaTask.Objects;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;

namespace PredicaTask.Definitions
{
    [Binding]
    public class PredicaSteps
    {
        private GoogleSearchPage _search;
        private GoogleResultsPage _results;
        private IWebDriver _driver;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _search = new GoogleSearchPage(_driver);
        }

        [Given(@"I have Chrome browser opened")]
        public void GivenIHaveChromeBrowserOpened()
        {
            _search.ChromeBrowserOpen();
        }
        
        [When(@"I put (.*) into the address bar and hit Enter")]
        public void WhenIPutGoogleUrlIntoTheAddressBarAndHitEnter(string url)
        {
            _search.GoogleSearchPageOpen(url);
        }
        
        [Then(@"I will see the empty search input")]
        public void ThenIWillSeeTheEmptySearchInput()
        {
            _search.SearchInputPresent();
        }

        [When(@"I put (.*) into Google's search and hit Enter")]
        public void WhenIPutPredicaIntoGoogleSSearchAndHitEnter(string keyword)
        {
            _results = _search.PutTextInSearch(keyword);
        }

        [Then(@"I should see the (.*) as the first search result")]
        public void ThenIShouldSeeTheHttpsPredica_PlAsTheFirstSearchResult(string predica_site)
        {
            ReadOnlyCollection<IWebElement> list = _results.FindAllResults();
            _results.CheckFirstResultIsPredica(list, predica_site);
        }

        [Then(@"I should see the proper Predica (.*) within Predica google's details")]
        public void ThenIShouldSeeTheProperPredicaWithinPredicaGoogleSDetails(string warsaw_address)
        {
            _results.CheckWarsawContact(warsaw_address);
        }

        [Then(@"Within (.*) top search results I can see Predica's both (.*) and (.*) profiles")]
        public void ThenWithinTopSearchResultsICanSeePredicaSBothAndProfiles(int top, string linkedin, string facebook)
        {
            ReadOnlyCollection<IWebElement> list = _results.FindAllResults();
            _results.CheckLinkedInFacebookWithinTopResults(list, top, linkedin, facebook);
        }

        [AfterScenario]
        public void Teardown()
        {
            _driver.Close();
        }
    }
}
