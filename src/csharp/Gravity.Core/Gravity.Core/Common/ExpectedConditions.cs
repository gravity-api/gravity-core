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
        /// <param name="by">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located.</returns>
        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By by) => (driver) =>
        {
            try
            {
                var elements = driver.FindElements(by);
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
        /// <param name="by">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located.</returns>
        public static Func<IWebDriver, IWebElement> ElementExists(By by) => (driver) => driver.FindElement(by);

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
        /// <param name="by">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> EnabilityOfAllElementsLocatedBy(By by) => (driver) =>
        {
            try
            {
                // find the elements
                var innerElements = driver.FindElements(by);

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
        /// <param name="by">Locator for the Frame</param>
        /// <returns>An <see cref="IWebDriver"/> to manipulate the browser</returns>
        public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(By by) => (driver) =>
        {
            try
            {
                var frameElement = driver.FindElement(by);
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
        /// <param name="by">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebDriver, IWebElement> ElementIsVisible(By by) => (driver) =>
        {
            try
            {
                return ElementIfVisible(driver.FindElement(by));
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
        /// <param name="by">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By by) => (driver) =>
        {
            try
            {
                //! pipe: step #1 - find elements
                var elements = driver.FindElements(by);

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
        /// <param name="by">The locator used to find the element.</param>
        /// <returns><see cref="true"/> if the element is not displayed; otherwise, <see cref="false"/>.</returns>
        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By by) => (driver) =>
        {
            try
            {
                var element = driver.FindElement(by);
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
        /// <param name="by">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and click-able (visible and enabled).</returns>
        public static Func<IWebDriver, IWebElement> ElementToBeClickable(By by) => (driver) =>
        {
            try
            {
                var element = ElementIfVisible(driver.FindElement(by));

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
        /// <param name="by">The locator used to find the elements.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static Func<IWebDriver, IWebDriver> InvisibilityOfAllElementsLocatedBy(By by) => (driver) =>
        {
            try
            {
                var elements = driver.FindElements(by);
                return elements.Any(element => element.Displayed) ? null : driver;
            }
            catch (Exception e) when (e is NoSuchElementException || e is StaleElementReferenceException)
            {
                return driver;
            }
        };

        /// <summary>
        /// An expectation for the given element's attribute to match a pattern.
        /// </summary>
        /// <param name="by">The locator used to find the element.</param>
        /// <param name="attribute">The attribute name to assert against the pattern.</param>
        /// <param name="regex">The regular expression that the attribute should match.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static Func<IWebDriver, IWebElement> AttributeMatches(By by, string attribute, string regex) => (driver) =>
        {
            // search for element
            var element = driver.FindElement(by);

            // return if condition met
            if (Regex.IsMatch(element.GetAttribute(attribute), regex))
            {
                return element;
            }

            // wait if condition yet to be met
            return null;
        };

        /// <summary>
        /// An expectation for the given element's text to match a pattern.
        /// </summary>
        /// <param name="by">The locator used to find the element.</param>
        /// <param name="regex">The regular expression that the attribute should match.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static Func<IWebDriver, IWebElement> TextMatches(By by, string regex) => (driver) =>
        {
            // search for element
            var element = driver.FindElement(by);

            // return if condition met
            if (Regex.IsMatch(element.Text, regex))
            {
                return element;
            }

            // wait if condition yet to be met
            return null;
        };

        /// <summary>
        /// An expectation for the current page status to be 'completed'.
        /// </summary>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static Func<IWebDriver, IWebDriver> PageHasBeenLoaded() => (driver) =>
        {
            // constants
            const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

            // handler: avoid invalid web driver implementations
            if (driver.GetType().Name.IndexOf("APPIUM", Compare) >= 0)
            {
                return driver;
            }

            // return the current web-driver state if document is loaded
            var isComplete = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState") as string;
            if (isComplete.Equals("complete", Compare))
            {
                return driver;
            }

            // continue waiting
            return null;
        };

        #region *** Utilities ***
        // return if the given element is visible
        private static IWebElement ElementIfVisible(IWebElement element) => element.Displayed ? element : null;
        #endregion
    }
}