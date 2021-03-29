#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebElementExtensions](./OpenQA-Selenium-Extensions-WebElementExtensions.md 'OpenQA.Selenium.Extensions.WebElementExtensions')
## WebElementExtensions.DelayedSendKeys(OpenQA.Selenium.IWebElement, string, bool) Method
Sends keys to a given Text-Container object with delay between keys. Used  
for slow typing in order to trigger JS events.  
```csharp
public static OpenQA.Selenium.IWebElement DelayedSendKeys(this OpenQA.Selenium.IWebElement element, string text, bool clear);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-DelayedSendKeys(OpenQA-Selenium-IWebElement_string_bool)-element'></a>
`element` [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
The [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') to which send keys.  
  
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-DelayedSendKeys(OpenQA-Selenium-IWebElement_string_bool)-text'></a>
`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The keys to send.  
  
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-DelayedSendKeys(OpenQA-Selenium-IWebElement_string_bool)-clear'></a>
`clear` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If set to True will clear the text before sending new text.  
  
#### Returns
[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
A self-reference to this [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement').  
### Remarks
If not provided, the default delay is 100 milliseconds.  
