/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenQA.Selenium.Common
{
    internal static class ExtensionsUtilities
    {
        /// <summary>
        /// Gets an instance of <see cref="IWait{T}"/> with default ignore list
        /// of <see cref="StaleElementReferenceException"/> and <see cref="NoSuchElementException"/>
        /// </summary>
        /// <param name="driver">The WebDriver instance used to wait.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns><see cref="IWait{T}"/> implementation which provides the ability to wait for an arbitrary condition during test execution.</returns>
        public static IWait<IWebDriver> WebDriverWait(IWebDriver driver, TimeSpan timeout)
        {
            // setup
            var ignore = new[]
            {
                typeof(StaleElementReferenceException),
                typeof(NoSuchElementException),
                typeof(WebDriverException),
                typeof(NullReferenceException)
            };

            // get waiter
            return GetWebDriverWait(driver, timeout, ignore);
        }

        /// <summary>
        /// Gets an instance of <see cref="IWait{T}"/> with default ignore list
        /// of <see cref="StaleElementReferenceException"/> and <see cref="NoSuchElementException"/>
        /// </summary>
        /// <param name="driver">The WebDriver instance used to wait.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <param name="exceptionTypes">The types of exceptions to ignore.</param>
        /// <returns><see cref="IWait{T}"/> implementation which provides the ability to wait for an arbitrary condition during test execution.</returns>
        public static IWait<IWebDriver> WebDriverWait(IWebDriver driver, TimeSpan timeout, params Type[] exceptionTypes)
        {
            return GetWebDriverWait(driver, timeout, exceptionTypes);
        }

        // execute action routine
        private static IWait<IWebDriver> GetWebDriverWait(IWebDriver driver, TimeSpan timeout, params Type[] exceptionTypes)
        {
            // setup
            const string Message =
                "Element(s) were not found within {0}sec. Consider changing element searching criteria or extending the timeout.";

            var webDriverWait = new WebDriverWait(driver, timeout)
            {
                Message = string.Format(Message, $"{timeout.TotalSeconds}")
            };

            // ignore list
            webDriverWait.IgnoreExceptionTypes(exceptionTypes);

            // get waiter
            return webDriverWait;
        }
    }
}
