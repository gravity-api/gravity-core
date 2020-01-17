/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// A collection of <see cref="IWebDriver" /> extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        #region *** Click Listener ***
        /// <summary>
        /// An <see cref="IWebDriver"/> extension method that listens to elements using the provided <see cref="By"/>
        /// mechanism. When found, the listener will <see cref="IWebElement.Click()"/> on all elements.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The mechanism by which to find elements within a document.</param>
        /// <remarks>The listener will stop when the driver is disposed or after 10min.</remarks>
        public static void ClickListener(this IWebDriver d, By by)
        {
            DoClickListener(d, by, interval: TimeSpan.FromSeconds(3), TimeSpan.FromMinutes(10));
        }

        /// <summary>
        /// An <see cref="IWebDriver"/> extension method that listens to elements using the provided <see cref="By"/>
        /// mechanism. When found, the listener will <see cref="IWebElement.Click()"/> on all elements.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The mechanism by which to find elements within a document.</param>
        /// <param name="interval">The interval between search ticks. Using a low interval time can reduce performance.</param>
        /// <remarks>The listener will stop when the driver is disposed or after 10min.</remarks>
        public static void ClickListener(this IWebDriver driver, By by, TimeSpan interval)
        {
            DoClickListener(driver, by, interval, TimeSpan.FromMinutes(10));
        }

        /// <summary>
        /// An <see cref="IWebDriver"/> extension method that listens to elements using the provided <see cref="By"/>
        /// mechanism. When found, the listener will <see cref="IWebElement.Click()"/> on all elements.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The mechanism by which to find elements within a document.</param>
        /// <param name="interval">The interval between search ticks. Using a low interval time can reduce performance.</param>
        /// <param name="timeout">Timeout of this listener expiration.</param>
        /// <remarks>The listener will stop when the driver is disposed or when timeout reached.</remarks>
        public static void ClickListener(this IWebDriver driver, By by, TimeSpan interval, TimeSpan timeout)
        {
            DoClickListener(driver, by, interval, timeout);
        }

        // execute action routine
        private static void DoClickListener(IWebDriver driver, By by, TimeSpan interval, TimeSpan timeout) => Task.Factory.StartNew(() =>
        {
            // setup
            TimeSpan expire = TimeSpan.FromTicks(0);

            while (driver != null || expire <= timeout)
            {
                // execute listener iteration
                Tick(driver, by, interval);

                // move expire time forward
                expire += interval;
            }
        }, TaskCreationOptions.LongRunning);

        // executes a single listener tick
        private static void Tick(IWebDriver driver, By by, TimeSpan interval)
        {
            try
            {
                var elements = driver.FindElements(by);

                if (elements.Count == 0)
                {
                    return;
                }

                foreach (var element in elements)
                {
                    element.Click();
                }
            }
            catch (Exception e) when (e != null)
            {
                // continue to iterate - silent error handling
            }
            finally
            {
                Thread.Sleep(interval);
            }
        }
        #endregion

        /// <summary>
        /// An <see cref="IWebDriver"/> extension method that closes all child windows of this session.
        /// </summary>
        /// <param name="webDriver">This <see cref="IWebDriver" /> instance.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver CloseAllChildWindows(this IWebDriver webDriver)
        {
            // exit conditions
            if (webDriver.WindowHandles.Count == 1)
            {
                return webDriver;
            }

            // action routine: close each > switch back to main window
            var mainWindow = webDriver.WindowHandles[0];

            foreach (var window in webDriver.WindowHandles)
            {
                if (window == mainWindow)
                {
                    continue;
                }
                webDriver.SwitchTo().Window(window).Close();
                Thread.Sleep(100);
            }

            // focus on main windows
            webDriver.SwitchTo().Window(mainWindow);

            // keep the fluent
            return webDriver;
        }

        /// <summary>
        /// An <see cref="IWebDriver"/> extension method that closes a window by the given window index.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="index">Zero-based index of the window.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver CloseWindow(this IWebDriver driver, int index)
        {
            // if index is out of bound, take last window
            if (index > (driver.WindowHandles.Count - 1))
            {
                index = driver.WindowHandles.Count - 1;
            }

            // setup
            var mainWindow = driver.WindowHandles[0];
            var window = driver.WindowHandles[index];

            // action routine: close > switch back to main window
            driver.SwitchTo().Window(window).Close();

            if (driver.WindowHandles?.Count > 0)
            {
                driver.SwitchTo().Window(mainWindow);
            }

            // keep the fluent
            return driver;
        }
    }
}
