/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenQA.Selenium.Common
{
    /// <summary>
    /// Supplies a set of common conditions that can be waited when using <see cref="WebDriverWait"/>.
    /// </summary>
    /// <example>
    ///     <code>
    ///         IWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
    ///         IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("element_id")));
    ///     </code>
    /// </example>
    public static class ExpectedConditions
    {
        /// <summary>
        /// An expectation for checking that all elements present on the web page that
        /// match the locator.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located.</returns>
        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator) => (driver) =>
        {
            try
            {
                var elements = driver.FindElements(locator);
                return elements.Count > 0 ? elements : null;
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                return null;
            }
        };

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page.
        /// This does not necessarily mean that the element is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located.</returns>
        public static Func<IWebDriver, IWebElement> ElementExists(By locator) => (driver) => driver.FindElement(locator);

        /// <summary>
        /// An expectation for checking if alert is present on this session.
        /// </summary>
        /// <returns>An <see cref="IAlert"/> to manipulate JavaScrpt alerts.</returns>
        public static Func<IWebDriver, IAlert> AlertIsPresent() => (driver) =>
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (Exception e) when (e is NoAlertPresentException)
            {
                return null;
            }
        };

        /// <summary>
        /// An expectation for checking that all elements present on the web page that
        /// match the locator are visible and enabled. Visibility means that the elements are not
        /// only displayed but also have a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> EnabilityOfAllElementsLocatedBy(By locator) => (driver) =>
        {
            try
            {
                // find the elements
                var innerElements = driver.FindElements(locator);

                // retry conditions
                if (!innerElements.All(e => e.Enabled))
                {
                    return null;
                }

                // return if all elements in the collection are enabled
                return innerElements;
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                return null;
            }
        };

        /// <summary>
        /// An expectation for checking whether the given frame is available to switch to.
        /// If the frame is available it switches the given driver to the specified frame.
        /// </summary>
        /// <param name="locator">Locator for the Frame</param>
        /// <returns>An <see cref="IWebDriver"/> to manipulate the browser</returns>
        public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(By locator) => (driver) =>
        {
            try
            {
                var frameElement = driver.FindElement(locator);
                return driver.SwitchTo().Frame(frameElement);
            }
            catch (Exception e) when (e is NoSuchFrameException)
            {
                return null;
            }
        };

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page and visible.
        /// Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator) => (driver) =>
        {
            try
            {
                return ElementIfVisible(driver.FindElement(locator));
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                return null;
            }
        };

        /// <summary>
        /// An expectation for checking that all elements present on the web page that match the locator are visible.
        /// Visibility means that the elements are not only displayed but also have a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator) => (driver) =>
        {
            try
            {
                //! pipe: step #1 - find elements
                var elements = driver.FindElements(locator);

                // exit conditions
                if (elements.Any(element => !element.Displayed)) return null;

                // complete pipe
                return elements.Count > 0 ? elements : null;
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                return null;
            }
        };

        /// <summary>
        /// An expectation for checking that an element is either invisible or not present on the DOM.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns><see cref="true"/> if the element is not displayed; otherwise, <see cref="false"/>.</returns>
        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator) => (driver) =>
        {
            try
            {
                var element = driver.FindElement(locator);
                return !element.Displayed;
            }
            catch (Exception e) when (e is NoSuchElementException || e is StaleElementReferenceException)
            {
                // returns true because the element is not present in DOM. The
                // try block checks if the element is present but is invisible.
                return true;
            }
        };

        /// <summary>
        /// An expectation for checking if an element is visible and enabled such that you can click it.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and click-able (visible and enabled).</returns>
        public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator) => (driver) =>
        {
            try
            {
                var element = ElementIfVisible(driver.FindElement(locator));

                // exit conditions
                if (element == null)
                {
                    return null;
                }

                // expected conditions
                return (element.Enabled) ? element : null;
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                return null;
            }
        };

        /// <summary>
        /// An expectation for the URL of the current page to be a specific URL.
        /// </summary>
        /// <param name="regex">The regular expression that the URL should match.</param>
        /// <returns><see cref="true"/> if the URL matches the specified regular expression; otherwise, <see cref="false"/>.</returns>
        public static Func<IWebDriver, bool> UrlMatches(string regex)
            => (driver) => Regex.IsMatch(driver.Url, regex, RegexOptions.IgnoreCase);

        /// <summary>
        /// An expectation for checking that all elements are either invisible or not present on the DOM.
        /// </summary>
        /// <param name="locator">The locator used to find the elements.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static Func<IWebDriver, IWebDriver> InvisibilityOfAllElementsLocatedBy(By locator) => (driver) =>
        {
            try
            {
                var elements = driver.FindElements(locator);
                return elements.Any(element => element.Displayed) ? null : driver;
            }
            catch (Exception e) when (e is NoSuchElementException || e is StaleElementReferenceException)
            {
                return driver;
            }
        };

        #region *** Utilities ***
        // return if the given element is visible
        private static IWebElement ElementIfVisible(IWebElement element) => element.Displayed ? element : null;
        #endregion
    }
}