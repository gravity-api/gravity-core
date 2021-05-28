/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Newtonsoft.Json;
using OpenQA.Selenium.Common;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ExpectedConditions = OpenQA.Selenium.Common.ExpectedConditions;

namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// A collection of <see cref="IWebDriver" /> extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        private static readonly HttpClient client = new();

        #region *** Click Listener    ***
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
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver CloseAllChildWindows(this IWebDriver driver)
        {
            // exit conditions
            if (driver.WindowHandles.Count == 1)
            {
                return driver;
            }

            // action routine: close each > switch back to main window
            var mainWindow = driver.WindowHandles[0];

            foreach (var window in driver.WindowHandles)
            {
                if (window == mainWindow)
                {
                    continue;
                }
                driver.SwitchTo().Window(window).Close();
                Thread.Sleep(100);
            }

            // focus on main windows
            driver.SwitchTo().Window(mainWindow);

            // keep the fluent
            return driver;
        }

        #region ***  Driver: Close     ***
        /// <summary>
        /// An <see cref="IWebDriver"/> extension method that closes a window by the given window index.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="index">Zero-based index of the window.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver Close(this IWebDriver driver, int index)
        {
            // if index is out of bound, take no action
            if (index > (driver.WindowHandles.Count - 1))
            {
                return driver;
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

        /// <summary>
        /// An <see cref="IWebDriver"/> extension method that closes a window by the given window index.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="windowName">The name of the window to select.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver Close(this IWebDriver driver, string windowName)
        {
            // if no window, take no action
            var isWindowName = driver
                .WindowHandles
                .Any(i => i.Equals(windowName, StringComparison.OrdinalIgnoreCase));
            if (!isWindowName)
            {
                return driver;
            }

            // setup
            var mainWindow = driver.WindowHandles[0];

            // action routine: close > switch back to main window
            driver.SwitchTo().Window(windowName).Close();
            if (driver.WindowHandles?.Count > 0)
            {
                driver.SwitchTo().Window(windowName: mainWindow);
            }

            // keep the fluent
            return driver;
        }
        #endregion

        #region *** Element: Displayed ***
        /// <summary>
        /// Finds the first visible <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not displayed.</exception>
        public static IWebElement GetDisplayedElement(this IWebDriver driver, By by)
        {
            return DoGetDisplayedElement(driver, by, timeout: TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds the first visible <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not displayed.</exception>
        public static IWebElement GetDisplayedElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetDisplayedElement(driver, by, timeout);
        }

        /// <summary>
        /// Finds all visible <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not displayed.</exception>
        public static IEnumerable<IWebElement> GetDisplayedElements(this IWebDriver driver, By by)
        {
            return DoGetDisplayedElements(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds all visible <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not displayed.</exception>
        public static IEnumerable<IWebElement> GetDisplayedElements(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetDisplayedElements(driver, by, timeout);
        }

        // execute action routine
        private static IWebElement DoGetDisplayedElement(IWebDriver driver, By by, TimeSpan timeout)
        {
            return ExtensionsUtilities
                .WebDriverWait(driver, timeout)
                .Until(d => ExpectedConditions.ElementIsVisible(by).Invoke(d));
        }

        private static IEnumerable<IWebElement> DoGetDisplayedElements(IWebDriver driver, By by, TimeSpan timeout)
        {
            try
            {
                return ExtensionsUtilities
                    .WebDriverWait(driver, timeout)
                    .Until(d => ExpectedConditions.VisibilityOfAllElementsLocatedBy(by).Invoke(d));
            }
            catch (Exception e) when (e != null)
            {
                return Array.Empty<IWebElement>();
            }
        }
        #endregion

        #region *** Element: Exists    ***
        /// <summary>
        /// Finds the first exists <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found.</exception>
        public static IWebElement GetElement(this IWebDriver driver, By by)
        {
            return DoGetElement(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds the first exists <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found.</exception>
        public static IWebElement GetElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetElement(driver, by, timeout);
        }

        /// <summary>
        /// Finds all exists <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found.</exception>
        public static IEnumerable<IWebElement> GetElements(this IWebDriver driver, By by)
        {
            return DoGetElements(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds all exists <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found.</exception>
        public static IEnumerable<IWebElement> GetElements(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetElements(driver, by, timeout);
        }

        // execute action routine
        private static IEnumerable<IWebElement> DoGetElements(IWebDriver driver, By by, TimeSpan timeout)
        {
            try
            {
                return ExtensionsUtilities
                    .WebDriverWait(driver, timeout)
                    .Until(d => ExpectedConditions.PresenceOfAllElementsLocatedBy(by).Invoke(d));
            }
            catch (Exception e) when (e != null)
            {
                return Array.Empty<IWebElement>();
            }
        }
        #endregion

        #region *** Element: Enabled   ***
        /// <summary>
        /// Finds the first enabled <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not clickable.</exception>
        public static IWebElement GetEnabledElement(this IWebDriver driver, By by)
        {
            return DoGetEnabledElement(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds the first enabled <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not clickable.</exception>
        public static IWebElement GetEnabledElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetEnabledElement(driver, by, timeout);
        }

        /// <summary>
        /// Finds all enabled <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not clickable.</exception>
        public static IEnumerable<IWebElement> GetEnabledElements(this IWebDriver driver, By by)
        {
            return DoGetEnabledElements(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds all enabled <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not clickable.</exception>
        public static IEnumerable<IWebElement> GetEnabledElements(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetEnabledElements(driver, by, timeout);
        }

        // execute action routine
        private static IWebElement DoGetEnabledElement(IWebDriver driver, By by, TimeSpan timeout)
        {
            return ExtensionsUtilities
                .WebDriverWait(driver, timeout)
                .Until(d => ExpectedConditions.ElementToBeClickable(by).Invoke(d));
        }

        private static IEnumerable<IWebElement> DoGetEnabledElements(IWebDriver driver, By by, TimeSpan timeout)
        {
            try
            {
                return ExtensionsUtilities
                    .WebDriverWait(driver, timeout)
                    .Until(d => ExpectedConditions.EnabilityOfAllElementsLocatedBy(by).Invoke(d));
            }
            catch (Exception e) when (e != null)
            {
                return Array.Empty<IWebElement>();
            }
        }
        #endregion

        #region *** Element: Selected  ***
        /// <summary>
        /// Finds the first enabled <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not selected.</exception>
        public static IWebElement GetSelectedElement(this IWebDriver driver, By by)
        {
            return DoGetSelectedElement(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds the first enabled <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not selected.</exception>
        public static IWebElement GetSelectedElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetSelectedElement(driver, by, timeout);
        }

        /// <summary>
        /// Finds all enabled <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not selected.</exception>
        public static IEnumerable<IWebElement> GetSelectedElements(this IWebDriver driver, By by)
        {
            return DoGetSelectedElements(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Finds all enabled <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>The first visible matching <see cref="IWebElement"/> on the current context.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        /// <exception cref="WebDriverTimeoutException">Thrown when element was not found or not selected.</exception>
        public static IEnumerable<IWebElement> GetSelectedElements(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoGetSelectedElements(driver, by, timeout);
        }

        // execute action routine
        private static IWebElement DoGetSelectedElement(IWebDriver driver, By by, TimeSpan timeout)
        {
            return ExtensionsUtilities
                .WebDriverWait(driver, timeout)
                .Until(d => ExpectedConditions.ElementToBeClickable(by).Invoke(d));
        }

        private static IEnumerable<IWebElement> DoGetSelectedElements(IWebDriver driver, By by, TimeSpan timeout)
        {
            try
            {
                return ExtensionsUtilities
                    .WebDriverWait(driver, timeout)
                    .Until(d => ExpectedConditions.EnabilityOfAllElementsLocatedBy(by).Invoke(d));
            }
            catch (Exception e) when (e != null)
            {
                return Array.Empty<IWebElement>();
            }
        }
        #endregion

        /// <summary>
        /// Gets the current windows handle, if not implemented or not possible,
        /// returns <see cref="SessionId"/> or new <see cref="SessionId"/> if <see cref="IHasSessionId"/> is not implemented.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <returns>Opaque handle to this window that uniquely identifies it within this driver instance.</returns>
        public static string GetCurrentHandle(this IWebDriver driver)
        {
            try
            {
                return driver.CurrentWindowHandle;
            }
            catch (Exception e) when (e is WebDriverException || e is NullReferenceException)
            {
                if (driver is IHasSessionId id)
                {
                    return id.ToString();
                }
            }
            return new SessionId($"gravity-{Guid.NewGuid()}").ToString();
        }

        #region *** Screenshot        ***
        /// <summary>
        /// Saves the screenshot to a file, overwriting the file if it already exists.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="fileName">The full path and file name to save the screenshot to.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver GetScreenshot(this IWebDriver driver, string fileName)
        {
            // normalize path
            fileName = fileName.TrimEnd('\\');

            // get image extension
            var extension = Path.GetExtension(fileName).Replace(".", string.Empty).ToUpper();

            // set format default
            var format = GetFormat(extension);

            // take screen-shot
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName, format);

            // keep the fluent
            return driver;
        }

        // gets the format enumerator based on file extension
        private static ScreenshotImageFormat GetFormat(string extension) => extension switch
        {
            "BMP" => ScreenshotImageFormat.Bmp,
            "GIF" => ScreenshotImageFormat.Gif,
            "JPEG" => ScreenshotImageFormat.Jpeg,
            "TIFF" => ScreenshotImageFormat.Tiff,
            _ => ScreenshotImageFormat.Png,
        };
        #endregion

        /// <summary>
        /// Gets this <see cref="IWebDriver"/> instance <see cref="SessionId"/>. If there is no
        /// <see cref="SessionId"/> for this driver, a new one will be created.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <returns>Opaque handle to this window that uniquely identifies it within this driver instance.</returns>
        public static SessionId GetSession(this IWebDriver driver)
        {
            return DoGetSession(driver);
        }

        /// <summary>
        /// Determines whether this <see cref="IWebDriver"/> instance has alert.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <returns><see cref="true"/> if the specified driver has alert; otherwise, <see cref="false"/>.</returns>
        public static bool HasAlert(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        #region *** Navigate to URL   ***
        /// <summary>
        /// Calling the <see cref="NavigateToUrl(IWebDriver, string)"/> method will load a new web page
        /// in the current browser window. This is done using an HTTP GET operation, and the method
        /// will block until the load is complete.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="url">The URL to load. It is best to use a fully qualified URL.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver NavigateToUrl(this IWebDriver driver, string url)
        {
            return DoNavigateToUrl(driver, url, TimeSpan.FromSeconds(60));
        }

        /// <summary>
        /// Calling the <see cref="NavigateToUrl(IWebDriver, string, TimeSpan)"/> method will load a new web page
        /// in the current browser window. This is done using an HTTP GET operation, and the method
        /// will block until the load is complete.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="url">The URL to load. It is best to use a fully qualified URL.</param>
        /// <param name="timeout"></param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver NavigateToUrl(this IWebDriver driver, string url, TimeSpan timeout)
        {
            return DoNavigateToUrl(driver, url, timeout);
        }

        // execute action routine
        private static IWebDriver DoNavigateToUrl(this IWebDriver driver, string url, TimeSpan timeout)
        {
            try
            {
                // set timeout
                driver.Manage().Timeouts().PageLoad = timeout;

                // navigate to URL
                driver.Url = url;

                // mobile OS handler; invalid maximize action
                if (IsMobileDriver(driver))
                {
                    return driver;
                }

                // maximize the window - this will verify page is fully loaded (sync only)
                var isMax = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return screen.availWidth - window.innerWidth === 0;");
                if (!isMax)
                {
                    driver.Manage().Window.Maximize();
                }

                // keep the fluent
                return driver;
            }
            catch (Exception)
            {
                driver?.Close();
                driver?.Dispose();
                throw;
            }
        }

        private static bool IsMobileDriver(IWebDriver driver)
        {
            // get base web-driver
            if (driver is not RemoteWebDriver remoteWebDriver)
            {
                return false;
            }

            // check if capability exists
            if (!remoteWebDriver.Capabilities.HasCapability(CapabilityType.PlatformName))
            {
                return false;
            }

            // check capabilities
            if (remoteWebDriver.Capabilities[CapabilityType.PlatformName] is not string platformName)
            {
                return false;
            }

            // normalize
            platformName = platformName.ToUpper();

            // assert if mobile
            return platformName == "IOS" || platformName == "ANDROID" || platformName == "FIREFOXOS";
        }
        #endregion

        /// <summary>
        /// Scrolls the current browser window by the given scroll amount.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="scrollLength">Length of the scroll.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver ScrollBrowserWindow(this IWebDriver driver, int scrollLength)
        {
            // scroll browser-window
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scroll(0, {scrollLength});");

            // keep the fluent
            return driver;
        }

        #region *** Persistent Click  ***
        /// <summary>
        /// Persistently attempts to find and click on the given element, until successful
        /// or until no exceptions has been thrown.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver PersistentClick(this IWebDriver driver, By by)
        {
            return DoPersistentClick(driver, by, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Persistently attempts to find and click on the given element, until successful
        /// or until no exceptions has been thrown.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver PersistentClick(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoPersistentClick(driver, by, timeout);
        }

        // execute action routine
        private static IWebDriver DoPersistentClick(IWebDriver driver, By by, TimeSpan timeout)
        {
            // initialize web-driver waiter
            var webDriverWait = new WebDriverWait(driver, timeout);

            // persist click
            return webDriverWait.Until(d =>
            {
                try
                {
                    d.FindElement(by).Click();
                }
                catch (Exception e) when (e != null && !(e is StaleElementReferenceException))
                {
                    return null;
                }
                return d;
            });
        }
        #endregion

        #region *** Persistent Keys   ***
        /// <summary>
        /// Persistently attempts to find and send keys to the given element, until successful
        /// or until no exceptions has been thrown.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="text">The keys to send.</param>
        /// <param name="clear">If set to <see cref="true"/> will clear the text before sending new text.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver PersistentSendKeys(this IWebDriver driver, By by, string text, bool clear)
        {
            return DoPersistentSendKeys(driver, by, text, clear, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Persistently attempts to find and send keys to the given element, until successful
        /// or until no exceptions has been thrown.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="text">The keys to send.</param>
        /// <param name="clear">If set to <see cref="true"/> will clear the text before sending new text.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver PersistentSendKeys(this IWebDriver driver, By by, string text, bool clear, TimeSpan timeout)
        {
            return DoPersistentSendKeys(driver, by, text, clear, timeout);
        }

        /// <summary>
        /// Persistently attempts to find and send keys to the given element, until successful
        /// or until no exceptions has been thrown.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="text">The keys to send.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver PersistentSendKeys(this IWebDriver driver, By by, string text)
        {
            return DoPersistentSendKeys(driver, by, text, false, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Persistently attempts to find and send keys to the given element, until successful
        /// or until no exceptions has been thrown.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver" /> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="text">The keys to send.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver PersistentSendKeys(this IWebDriver driver, By by, string text, TimeSpan timeout)
        {
            return DoPersistentSendKeys(driver, by, text, false, timeout);
        }

        // execute action routine
        private static IWebDriver DoPersistentSendKeys(IWebDriver driver, By by, string text, bool clear, TimeSpan timeout)
        {
            // initialize web-driver waiter
            var webDriverWait = new WebDriverWait(driver, timeout);

            // persist click
            return webDriverWait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(by);
                    if (clear)
                    {
                        element.Clear();
                    }
                    element.SendKeys(text);
                }
                catch (Exception e) when (e != null && !(e is StaleElementReferenceException))
                {
                    return null;
                }
                return d;
            });
        }
        #endregion

        #region *** Submit Form       ***
        /// <summary>
        /// Submits a web form (everything under <form></form> tag).
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="id">The form identifier ('id' attribute).</param>
        /// <returns>A self-reference to this <see cref="IWebDriver"/>.</returns>
        public static IWebDriver SubmitForm(this IWebDriver driver, string id)
        {
            // submit the form
            ((IJavaScriptExecutor)(driver)).ExecuteScript($"document.forms['{id}'].submit();");

            // keep the fluent
            return driver;
        }

        /// <summary>
        /// Submits a web form (everything under <form></form> tag).
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="index">Zero-based index of the form in the page DOM.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver"/>.</returns>
        public static IWebDriver SubmitForm(this IWebDriver driver, int index)
        {
            // submit the form
            ((IJavaScriptExecutor)(driver)).ExecuteScript($"document.forms[{index}].submit();");

            // keep the fluent
            return driver;
        }

        /// <summary>
        /// Submits a web form (everything under <form></form> tag).
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver"/>.</returns>
        public static IWebDriver SubmitForm(this IWebDriver driver, By by)
        {
            return SubmitFormBy(driver, by, timeout: TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Submits a web form (everything under <form></form> tag).
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver"/>.</returns>
        public static IWebDriver SubmitForm(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return SubmitFormBy(driver, by, timeout);
        }

        public static IWebDriver SubmitFormBy(IWebDriver driver, By by, TimeSpan timeout)
        {
            // setup
            var element = DoGetElement(driver, by, timeout);

            // submit the form
            ((IJavaScriptExecutor)(driver)).ExecuteScript($"arguments[0].submit();", element);

            // keep the fluent
            return driver;
        }
        #endregion

        #region *** Switch to Frame   ***
        /// <summary>
        /// If the frame is available it switches the given driver to the specified frame.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="by">A mechanism by which to find elements within a document.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver SwitchToFrame(this IWebDriver driver, By by)
        {
            return DoSwitchToFrame(driver, by, timeout: TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// If the frame is available it switches the given driver to the specified frame.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="by">A mechanism by which to find elements within a document.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        /// <remarks>If not provided, the default timeout is 10 seconds.</remarks>
        public static IWebDriver SwitchToFrame(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return DoSwitchToFrame(driver, by, timeout: timeout);
        }

        // execute action routine
        private static IWebDriver DoSwitchToFrame(IWebDriver driver, By by, TimeSpan timeout)
        {
            // wait and switch to frame
            var frame = ExtensionsUtilities
                .WebDriverWait(driver, timeout)
                .Until(d =>
                {
                    try
                    {
                        var frameElement = d.FindElement(by);
                        return d.SwitchTo().Frame(frameElement);
                    }
                    catch (Exception e) when (e is NoSuchFrameException)
                    {
                        return null;
                    }
                });

            // keep the fluent
            return frame ?? driver;
        }
        #endregion

        /// <summary>
        /// Switches the focus of future commands for this driver to the window with the given index.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="index">The window index.</param>
        /// <returns>A self-reference to this <see cref="IWebDriver" />.</returns>
        public static IWebDriver SwitchToWindow(this IWebDriver driver, int index)
        {
            // exit condition
            if (driver.WindowHandles.Count == 0)
            {
                return driver;
            }

            // switch to the given window (by index)
            driver.SwitchTo().Window(driver.WindowHandles[index]);

            // keep the fluent
            return driver;
        }

        /// <summary>
        /// Gets this <see cref="IWebDriver"/> endpoint.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <returns><see cref="IWebDriver"/> endpoint.</returns>
        public static Uri GetEndpoint(this IWebDriver driver)
        {
            return DoGetEndpoint(driver);
        }

        #region *** Send Command      ***
        /// <summary>
        /// Sends POST command directly to this <see cref="IWebDriver"/> instance.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="route">Command route starting with "/" (use the complete route which comes after session id).</param>
        /// <param name="data">Post data to send (parameters list).</param>
        /// <returns>Command response as JSON (if available).</returns>
        public static string SendPostCommand(this IWebDriver driver, string route, IDictionary<string, object> data)
        {
            // setup
            var content = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(content, Encoding.UTF8, mediaType: "application/json");
            var command = GetCommandApi(driver, route);

            // command
            var response = client
                .PostAsync(requestUri: command, content: stringContent)
                .GetAwaiter()
                .GetResult();

            // results
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends GET command directly to this <see cref="IWebDriver"/> instance.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="route">Command route starting with "/" (use the complete route which comes after session id).</param>
        /// <returns>Command response as JSON (if available).</returns>
        public static string SendGetCommand(this IWebDriver driver, string route)
        {
            // setup
            var command = GetCommandApi(driver, route);

            // command
            var response = client
                .GetAsync(requestUri: command)
                .GetAwaiter()
                .GetResult();

            // results
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends DELETE command directly to this <see cref="IWebDriver"/> instance.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="route">Command route starting with "/" (use the complete route which comes after session id).</param>
        /// <returns>Command response as JSON (if available).</returns>
        public static string SendDeleteCommand(this IWebDriver driver, string route)
        {
            // setup
            var command = GetCommandApi(driver, route);

            // command
            var response = client
                .DeleteAsync(requestUri: command)
                .GetAwaiter()
                .GetResult();

            // results
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        private static string GetCommandApi(IWebDriver driver, string route)
        {
            var endpoint = DoGetEndpoint(driver).AbsoluteUri;
            var session = DoGetSession(driver);
            route = route.StartsWith("/") ? route : $"/{route}";
            return $"{endpoint}session/{session}{route}";
        }
        #endregion

        #region *** Utilities         ***
        private static Uri DoGetEndpoint(IWebDriver driver)
        {
            // local
            static Type GetRemoteWebDriver(Type type)
            {
                if (!typeof(RemoteWebDriver).IsAssignableFrom(type))
                {
                    return type;
                }

                while (type != typeof(RemoteWebDriver))
                {
                    type = type.BaseType;
                }

                return type;
            }

            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;

            // get RemoteWebDriver type
            var remoteWebDriver = GetRemoteWebDriver(driver.GetType());

            // get this instance executor > get this instance internalExecutor
            var executor = remoteWebDriver.GetField("executor", Flags).GetValue(driver) as ICommandExecutor;

            // get URL
            var endpoint = executor.GetType().GetField("remoteServerUri", Flags).GetValue(executor) as Uri;

            // result
            return endpoint ?? executor.GetType().GetField("URL", Flags).GetValue(executor) as Uri;
        }

        private static SessionId DoGetSession(IWebDriver driver)
        {
            if (driver is IHasSessionId id)
            {
                return id.SessionId;
            }
            return new SessionId($"gravity-{Guid.NewGuid()}");
        }

        private static IWebElement DoGetElement(IWebDriver driver, By by, TimeSpan timeout)
        {
            return ExtensionsUtilities
                .WebDriverWait(driver, timeout)
                .Until(d => ExpectedConditions.ElementExists(by).Invoke(d));
        }
        #endregion
    }
}