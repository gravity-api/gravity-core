#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebElementExtensions](./OpenQA-Selenium-Extensions-WebElementExtensions.md 'OpenQA.Selenium.Extensions.WebElementExtensions')
## WebElementExtensions.SendGetCommand(IWebElement, string) Method
Sends GET command directly to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
```csharp
public static string SendGetCommand(this IWebElement element, string route);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-SendGetCommand(IWebElement_string)-element'></a>
`element` [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
This [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-SendGetCommand(IWebElement_string)-route'></a>
`route` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Command route starting with "/" (use the complete route which comes after session id).  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Command response as JSON (if available).  
