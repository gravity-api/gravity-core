/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Newtonsoft.Json;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// A collection of <see cref="IWebElement" /> extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        private static readonly HttpClient client = new HttpClient();

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
        /// <exception cref="UnexpectedTagNameException"/>
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

        /// <summary>
        /// Gets a value indicating if this <see cref="IWebElement"/> is stale (not attached to the DOM).
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>True if element is stale; False if not.</returns>
        public static bool IsStale(this IWebElement element)
        {
            try
            {
                return !(!element.Enabled || element.Enabled);
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the underline element id of this <see cref="IWebElement"/> instance.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement"/> instance.</param>
        /// <returns>The underline element id.</returns>
        public static string Id(this IWebElement element)
        {
            return GetElementId(element);
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
            using (var httpClient = new HttpClient())
            {
                // get response for the current resource
                var httpResponseMessage = httpClient.GetAsync(resource).GetAwaiter().GetResult();

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

        #region *** Java Script Get   ***
        /// <summary>
        /// Get the element's HTML and all it's content, including the start tag, it's attributes, and the end tag.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> from which to get the outer HTML.</param>
        /// <returns>The HTML element and all it's content, including the start tag, it's attributes, and the end tag.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static string GetSource(this IWebElement element)
        {
            return DoJavaScriptGet(element, "return arguments[0].outerHTML;");
        }

        /// <summary>
        /// Gets the value property of the value attribute of a text field.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> from which to get the outer HTML.</param>
        /// <returns>The value property of the value attribute of a text field.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static string GetValue(this IWebElement element)
        {
            return DoJavaScriptGet(element, "return arguments[0].value;");
        }

        // execute action routine
        private static string DoJavaScriptGet(IWebElement element, string script)
        {
            try
            {
                // extract driver
                var driver = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;

                // clear the element
                var result = driver.ExecuteScript(script, element) as string;
                return string.IsNullOrEmpty(result) ? string.Empty : result;
            }
            catch (Exception e) when (e != null)
            {
                // ignore exceptions
            }
            return string.Empty;
        }
        #endregion

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
        /// <param name="clear">If set to True will clear the text before sending new text.</param>
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
        /// <param name="clear">If set to True will clear the text before sending new text.</param>
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

        #region *** Java Script       ***
        /// <summary>
        /// Attempts to clear the given data from the text container. This method will not throw an exception.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement">IWebElement</see> instance.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static IWebElement JavaScriptClear(this IWebElement element)
        {
            return DoJavaScriptOnElement(element, "arguments[0].value='';");
        }

        /// <summary>
        /// Attempts to click on the given element. Use when element cannot be clicked otherwise.
        /// This method will not throw an exception.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement">IWebElement</see> instance.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static IWebElement JavaScriptClick(this IWebElement element)
        {
            return DoJavaScriptOnElement(element, "arguments[0].click();");
        }

        /// <summary>
        /// The <see cref="JavaScriptFocus(IWebElement)"/> method is used to give focus to an element (if it can be focused).
        /// This method will not throw an exception.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement">IWebElement</see> instance.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static IWebElement JavaScriptFocus(this IWebElement element)
        {
            return DoJavaScriptOnElement(element, "arguments[0].focus();");
        }

        /// <summary>
        /// The <see cref="JavaScriptBlur(IWebElement)"/> method is used to remove focus from an element.
        /// This method will not throw an exception.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement">IWebElement</see> instance.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static IWebElement JavaScriptBlur(this IWebElement element)
        {
            return DoJavaScriptOnElement(element, "arguments[0].blur();");
        }

        /// <summary>
        /// The <see cref="JavaScriptScrollTop(IWebElement, int)"/> property sets the number of pixels
        /// an element's content is scrolled vertically.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement">IWebElement</see> instance.</param>
        /// <param name="scrollTop">The number of pixels an element's content is scrolled vertically.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static IWebElement JavaScriptScrollTop(this IWebElement element, int scrollTop)
        {
            return DoJavaScriptOnElement(element, $"arguments[0].scrollTop={scrollTop}");
        }

        /// <summary>
        /// The <see cref="JavaScriptScrollLeft(IWebElement, int)"/> property sets the number of pixels
        /// an element's content is scrolled horizontally.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement">IWebElement</see> instance.</param>
        /// <param name="scrollLeft">The number of pixels an element's content is scrolled horizontally.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        /// <remarks>Works only on Web/Mobile Web platforms.</remarks>
        public static IWebElement JavaScriptScrollLeft(this IWebElement element, int scrollLeft)
        {
            return DoJavaScriptOnElement(element, $"arguments[0].scrollLeft={scrollLeft}");
        }

        // executes action routine
        private static IWebElement DoJavaScriptOnElement(IWebElement element, string script)
        {
            try
            {
                // extract driver
                var driver = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;

                // clear the element
                driver.ExecuteScript(script, element);
            }
            catch (Exception e) when (e != null)
            {
                // ignore exceptions
            }
            return element;
        }
        #endregion

        #region *** Upload File       ***
        /// <summary>
        /// Allows to set input of file type element with file to upload (bypass all native windows).
        /// </summary>
        /// <param name="element">This <see cref="IWebElement">IWebElement</see> instance.</param>
        /// <param name="path">The file to upload.</param>
        /// <returns>A self-reference to this <see cref="IWebElement" />.</returns>
        public static IWebElement UploadFile(this IWebElement element, string path)
        {
            if (!IsFileInput(element))
            {
                throw new ArgumentException
                    ($"The element <{element.TagName}></{element.TagName}> is not of type '<input type=\"file\"></input>'.", nameof(element));
            }

            // execute script
            const string script = "arguments[0].setAttribute('style','visibility: visible; display: block;');";
            var onDriver = ((IWrapsDriver)element).WrappedDriver;
            ((IJavaScriptExecutor)onDriver).ExecuteScript(script, element);

            // send key to trigger files upload
            element.SendKeys(path);

            // keep the fluent
            return element;
        }

        // validate if the current element is valid input-file element
        private static bool IsFileInput(IWebElement element)
        {
            // constants
            const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

            // setup conditions
            var isValidTag = element.TagName.Equals("input", Compare);
            var isValidTyp = element.GetAttribute("type").Equals("file", Compare);

            // exit condition
            return isValidTag && isValidTyp;
        }
        #endregion

        #region *** Send Command      ***
        /// <summary>
        /// Sends POST command directly to this <see cref="IWebDriver"/> instance.
        /// </summary>
        /// <param name="element">This <see cref="IWebElement"/> instance.</param>
        /// <param name="route">Command route starting with "/" (use the complete route which comes after session id).</param>
        /// <param name="data">Post data to send (parameters list).</param>
        /// <returns>Command response as JSON (if available).</returns>
        public static string SendPostCommand(this IWebElement element, string route, IDictionary<string, object> data)
        {
            // setup
            var content = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(content, Encoding.UTF8, mediaType: "application/json");
            var command = GetCommandApi(element, route);

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
        /// <param name="element">This <see cref="IWebElement"/> instance.</param>
        /// <param name="route">Command route starting with "/" (use the complete route which comes after session id).</param>
        /// <returns>Command response as JSON (if available).</returns>
        public static string SendGetCommand(this IWebElement element, string route)
        {
            // setup
            var command = GetCommandApi(element, route);

            // command
            var response = client
                .GetAsync(requestUri: command)
                .GetAwaiter()
                .GetResult();

            // results
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        private static string GetCommandApi(IWebElement element, string route)
        {
            // setup: get driver
            var driver = ((IWrapsDriver)element).WrappedDriver;

            // setup: command
            var endpoint = driver.GetEndpoint().AbsoluteUri;
            var session = driver.GetSession();
            var elementId = GetElementId(element);
            route = route.StartsWith("/") ? route : $"/{route}";

            // result
            return $"{endpoint}session/{session}/element/{elementId}{route}";
        }
        #endregion

        #region *** Select Element    ***
        /// <summary>
        /// Select the option by the index, as determined by the "index" attribute of the
        /// element.
        /// </summary>
        /// <param name="selectElement">This <see cref="SelectElement"/>.</param>
        /// <param name="index">The value of the index attribute of the option to be selected.</param>
        public static void JsSelectByIndex(this SelectElement selectElement, int index)
        {
            // constants
            var script = $"options[{index}].selected = true;";

            // web element to act on
            var onElement = selectElement.WrappedElement;
            var onDriver = (IWrapsDriver)onElement;

            // execute
            ((IJavaScriptExecutor)onDriver).ExecuteScript(script, onElement);
        }

        /// <summary>
        /// Select all options by the text displayed.
        /// </summary>
        /// <param name="selectElement">This <see cref="SelectElement"/>.</param>
        /// <param name="text">The text of the option to be selected.</param>
        public static void JsSelectByText(this SelectElement selectElement, string text)
        {
            // constants
            var script =
                "var options = arguments[0].getElementsByTagName(\"option\");" +
                "" +
                "for(i = 0; i < options.length; i++) {" +
                $"   if(options[i].innerText !== \"{text}\") {{" +
                "       continue;" +
                "    }" +
                "    options[i].selected = true;" +
                "    break;" +
                "}";

            // web element to act on
            var onElement = selectElement.WrappedElement;
            var onDriver = (IWrapsDriver)onElement;

            // execute
            ((IJavaScriptExecutor)onDriver).ExecuteScript(script, onElement);
        }

        /// <summary>
        /// Select an option by the value.
        /// </summary>
        /// <param name="selectElement"></param>
        /// <param name="value">The value of the option to be selected.</param>
        public static void JsSelectByValue(this SelectElement selectElement, string value)
        {
            // constants
            var script =
                "var options = arguments[0].getElementsByTagName(\"option\");" +
                "" +
                "for(i = 0; i < options.length; i++) {" +
                $"   if(options[i].getAttribute(\"value\") !== \"{value}\") {{" +
                "       continue;" +
                "    }" +
                "    options[i].selected = true;" +
                "    break;" +
                "}";

            // web element to act on
            var onElement = selectElement.WrappedElement;
            var onDriver = (IWrapsDriver)onElement;

            // execute
            ((IJavaScriptExecutor)onDriver).ExecuteScript(script, onElement);
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

        // gets the underline element id
        [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Designed to increase accessibility")]
        private static string GetElementId(IWebElement element)
        {
            // local
            static Type GetRemoteWebElement(Type type)
            {
                if (!typeof(RemoteWebElement).IsAssignableFrom(type))
                {
                    return type;
                }

                while (type != typeof(RemoteWebElement))
                {
                    type = type.BaseType;
                }

                return type;
            }

            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;

            // get RemoteWebElement type
            var remoteWebElement = GetRemoteWebElement(element.GetType());

            // get element id
            return remoteWebElement.GetProperty(name: "Id", Flags).GetValue(element).ToString();
        }
        #endregion
    }
}