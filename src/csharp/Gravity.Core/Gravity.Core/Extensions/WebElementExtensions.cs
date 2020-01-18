/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;

namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// A collection of <see cref="IWebElement" /> extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Provides a mechanism for building advanced interactions with the browser.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement" /> instance.</param>
        /// <returns>A self-reference to this <see cref="Interactions.Actions" />.</returns>
        public static Actions Actions(this IWebElement element)
        {
            return GetActionsFromElement(element).MoveToElement(element);
        }

        /// <summary>
        /// Clicks and holds the mouse button down on the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> on which to click and hold.</param>
        /// <returns>A self-reference to this <see cref="Interactions.Actions" />.</returns>
        public static Actions ClickAndHold(this IWebElement element)
        {
            // create new actions instance
            var actions = GetActionsFromElement(element);

            // execute action
            actions.ClickAndHold(element).Build().Perform();

            // keep the fluent
            return actions;
        }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML
        /// select element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> from which to create <see cref="SelectElement" />.</param>
        /// <returns>New instance of <see cref="SelectElement" />.</returns>
        /// <exception cref="UnexpectedTagNameException">Thrown when the element wrapped is not a <select> element.</exception>
        public static SelectElement AsComboBox(this IWebElement element)
        {
            return new SelectElement(element);
        }

        /// <summary>
        /// Right-click the mouse at the last known mouse coordinates.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> on which to click.</param>
        /// <returns>A self-reference to this <see cref="Interactions.Actions" />.</returns>
        public static Actions ContextClick(this IWebElement element)
        {
            // create new actions instance
            var actions = GetActionsFromElement(element);

            // execute action
            actions.MoveToElement(element).ContextClick().Build().Perform();

            // keep the fluent
            return actions;
        }

        /// <summary>
        /// Double-clicks the mouse on the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> on which to double-click.</param>
        /// <returns>A self-reference to this <see cref="Actions" />.</returns>
        public static Actions DoubleClick(this IWebElement element)
        {
            // create new actions instance
            var actions = GetActionsFromElement(element);

            // execute action
            actions.MoveToElement(element).DoubleClick().Build().Perform();

            // keep the fluent
            return actions;
        }

        #region *** Download Resource ***
        /// <summary>
        /// Download a resource based on the given <see cref="IWebElement" />.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement" /> to use when downloading a resource.</param>
        /// <param name="path">The path on which the resource will be saved.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static IWebElement DownloadResource(this IWebElement element, string path)
        {
            return DoDownloadResource(element, path, "");
        }

        /// <summary>
        /// Download a resource based on the given <see cref="IWebElement" />.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement" /> to use when downloading a resource.</param>
        /// <param name="path">The path on which the resource will be saved.</param>
        /// <param name="attribute">The element attribute from which to extract resource URL (if needed).</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static IWebElement DownloadResource(this IWebElement element, string path, string attribute)
        {
            return DoDownloadResource(element, path, attribute);
        }

        // execute action routine
        private static IWebElement DoDownloadResource(this IWebElement element, string path, string attribute)
        {
            // get resource address
            var resource = (string.IsNullOrEmpty(attribute))
                ? element.Text
                : element.GetAttribute(attribute);

            // download resource
            using (var client = new HttpClient())
            {
                // get response for the current resource
                var httpResponseMessage = client.GetAsync(resource).GetAwaiter().GetResult();

                // exit condition
                if (!httpResponseMessage.IsSuccessStatusCode) return element;

                // create directories path
                Directory.CreateDirectory(path);

                // get absolute file name
                var fileName = Regex.Match(resource, @"[^/\\&\?]+\.\w{3,4}(?=([\?&].*$|$))").Value;
                path = (path.LastIndexOf(@"\") == path.Length - 1)
                    ? path + fileName
                    : path + $@"\{fileName}";

                // write the file
                File.WriteAllBytes(path, httpResponseMessage.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult());
            }

            // keep the fluent
            return element;
        }
        #endregion

        /// <summary>
        /// Get the element's HTML and all it's content, including the start tag, it's attributes, and the end tag.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> from which to get the outer HTML.</param>
        /// <returns>The HTML element and all it's content, including the start tag, it's attributes, and the end tag.</returns>
        public static string GetSource(this IWebElement element)
        {
            // extract the driver to which the current element belongs to
            var driver = (IJavaScriptExecutor)(IWrapsDriver)element;

            // get this element outer HTML
            return driver.ExecuteScript("return arguments[0].outerHTML;", element) as string;
        }

        #region *** Move to Element   ***
        /// <summary>
        /// Moves the mouse to the specified offset of the top-left corner of the specified element.
        /// </summary>
        /// <param name="toElement">The <see cref="IWebElement"/> to which to move the mouse.</param>
        /// <param name="offsetX">The horizontal offset to which to move the mouse.</param>
        /// <param name="offsetY">The vertical offset to which to move the mouse.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static IWebElement MoveToElement(this IWebElement toElement, int offsetX, int offsetY)
        {
            // setup
            var actions = new Actions(((IWrapsDriver)toElement).WrappedDriver);

            // execute actions
            actions.MoveToElement(toElement, offsetX, offsetY).Build().Perform();

            // keep the fluent
            return toElement;
        }

        /// <summary>
        /// <summary>
        /// Moves the mouse to the specified offset of the top-left corner of the specified element.
        /// </summary>
        /// <param name="toElement">The <see cref="IWebElement"/> to which to move the mouse.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static IWebElement MoveToElement(this IWebElement toElement)
        {
            // setup
            var actions = new Actions(((IWrapsDriver)toElement).WrappedDriver);

            // execute actions
            actions.MoveToElement(toElement).Build().Perform();

            // keep the fluent
            return toElement;
        }
        #endregion

        #region *** Delayed Send Keys ***
        /// <summary>
        /// Sends keys to a given Text-Container object with delay between keys. Used
        /// for slow typing in order to trigger JS events.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to which send keys.</param>
        /// <param name="text">The keys to send.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>If not provided, the default delay is 100 milliseconds.</remarks>
        public static IWebElement DelayedSendKeys(this IWebElement element, string text)
        {
            return DoDelayedSendKeys(element, text, 100, false);
        }

        /// <summary>
        /// Sends keys to a given Text-Container object with delay between keys. Used
        /// for slow typing in order to trigger JS events.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to which send keys.</param>
        /// <param name="text">The keys to send.</param>
        /// <param name="clear">If set to <see cref="true"/> will clear the text before sending new text.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>If not provided, the default delay is 100 milliseconds.</remarks>
        public static IWebElement DelayedSendKeys(this IWebElement element, string text, bool clear)
        {
            return DoDelayedSendKeys(element, text, 100, clear);
        }

        /// <summary>
        /// Sends keys to a given Text-Container object with delay between keys. Used
        /// for slow typing in order to trigger JS events.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to which send keys.</param>
        /// <param name="text">The keys to send.</param>
        /// <param name="delay">The delay time between each key.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>If not provided, the default delay is 100 milliseconds.</remarks>
        public static IWebElement DelayedSendKeys(this IWebElement element, string text, int delay)
        {
            return DoDelayedSendKeys(element, text, delay, false);
        }

        /// <summary>
        /// Sends keys to a given Text-Container object with delay between keys. Used
        /// for slow typing in order to trigger JS events.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to which send keys.</param>
        /// <param name="text">The keys to send.</param>
        /// <param name="delay">The delay time between each key.</param>
        /// <param name="clear">If set to <see cref="true"/> will clear the text before sending new text.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>If not provided, the default delay is 100 milliseconds.</remarks>
        public static IWebElement DelayedSendKeys(this IWebElement element, string text, int delay, bool clear)
        {
            return DoDelayedSendKeys(element, text, delay, clear);
        }

        // execute action routine
        private static IWebElement DoDelayedSendKeys(IWebElement element, string text, int delay, bool clear)
        {
            // clear conditions
            if (clear)
            {
                element.Clear();
            }

            // iterate keys
            for (int i = 0; i < text.Length; i++)
            {
                element.SendKeys($"{text[i]}");
                Thread.Sleep(delay);
            }

            // keep the fluent
            return element;
        }
        #endregion

        #region *** Utilities         ***
        // gets and actions instance from IWebElement
        private static Actions GetActionsFromElement(IWebElement element)
        {
            // extract the driver to which the current element belongs to
            var driver = ((IWrapsDriver)element).WrappedDriver;

            // create new actions instance
            return new Actions(driver);
        }
        #endregion
    }
}