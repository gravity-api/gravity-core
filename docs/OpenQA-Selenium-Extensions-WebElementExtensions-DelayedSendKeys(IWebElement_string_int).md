#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebElementExtensions](./OpenQA-Selenium-Extensions-WebElementExtensions.md 'OpenQA.Selenium.Extensions.WebElementExtensions')
## WebElementExtensions.DelayedSendKeys(IWebElement, string, int) Method
Sends keys to a given Text-Container object with delay between keys. Used  
for slow typing in order to trigger JS events.  
```csharp
public static IWebElement DelayedSendKeys(this IWebElement element, string text, int delay);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-DelayedSendKeys(IWebElement_string_int)-element'></a>
`element` [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
The [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') to which send keys.  
  
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-DelayedSendKeys(IWebElement_string_int)-text'></a>
`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The keys to send.  
  
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-DelayedSendKeys(IWebElement_string_int)-delay'></a>
`delay` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The delay time between each key.  
  
#### Returns
[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
A self-reference to this [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement').  
### Remarks
If not provided, the default delay is 100 milliseconds.  
