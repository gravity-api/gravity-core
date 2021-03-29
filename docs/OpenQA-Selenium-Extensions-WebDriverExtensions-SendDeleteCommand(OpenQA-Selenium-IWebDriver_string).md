#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.SendDeleteCommand(OpenQA.Selenium.IWebDriver, string) Method
Sends DELETE command directly to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
```csharp
public static string SendDeleteCommand(this OpenQA.Selenium.IWebDriver driver, string route);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SendDeleteCommand(OpenQA-Selenium-IWebDriver_string)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SendDeleteCommand(OpenQA-Selenium-IWebDriver_string)-route'></a>
`route` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Command route starting with "/" (use the complete route which comes after session id).  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Command response as JSON (if available).  
