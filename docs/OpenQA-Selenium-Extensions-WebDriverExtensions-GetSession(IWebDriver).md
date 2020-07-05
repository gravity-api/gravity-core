#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.GetSession(IWebDriver) Method
Gets this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance [OpenQA.Selenium.Remote.SessionId](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Remote.SessionId 'OpenQA.Selenium.Remote.SessionId'). If there is no  
[OpenQA.Selenium.Remote.SessionId](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Remote.SessionId 'OpenQA.Selenium.Remote.SessionId') for this driver, a new one will be created.  
```csharp
public static SessionId GetSession(this IWebDriver driver);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-GetSession(IWebDriver)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
#### Returns
[OpenQA.Selenium.Remote.SessionId](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.Remote.SessionId 'OpenQA.Selenium.Remote.SessionId')  
Opaque handle to this window that uniquely identifies it within this driver instance.  
