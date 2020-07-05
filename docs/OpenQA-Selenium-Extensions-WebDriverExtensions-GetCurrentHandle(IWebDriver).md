#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.GetCurrentHandle(IWebDriver) Method
Gets the current windows handle, if not implemented or not possible,  
returns [OpenQA.Selenium.Remote.SessionId](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Remote.SessionId 'OpenQA.Selenium.Remote.SessionId') or new [OpenQA.Selenium.Remote.SessionId](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Remote.SessionId 'OpenQA.Selenium.Remote.SessionId') if [OpenQA.Selenium.Remote.IHasSessionId](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Remote.IHasSessionId 'OpenQA.Selenium.Remote.IHasSessionId') is not implemented.  
```csharp
public static string GetCurrentHandle(this IWebDriver driver);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-GetCurrentHandle(IWebDriver)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Opaque handle to this window that uniquely identifies it within this driver instance.  
