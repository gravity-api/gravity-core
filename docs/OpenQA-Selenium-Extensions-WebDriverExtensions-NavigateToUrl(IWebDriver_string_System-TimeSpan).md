#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.NavigateToUrl(IWebDriver, string, System.TimeSpan) Method
Calling the [NavigateToUrl(IWebDriver, string, System.TimeSpan)](./OpenQA-Selenium-Extensions-WebDriverExtensions-NavigateToUrl(IWebDriver_string_System-TimeSpan).md 'OpenQA.Selenium.Extensions.WebDriverExtensions.NavigateToUrl(IWebDriver, string, System.TimeSpan)') method will load a new web page  
in the current browser window. This is done using an HTTP GET operation, and the method  
will block until the load is complete.  
```csharp
public static IWebDriver NavigateToUrl(this IWebDriver driver, string url, System.TimeSpan timeout);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-NavigateToUrl(IWebDriver_string_System-TimeSpan)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-NavigateToUrl(IWebDriver_string_System-TimeSpan)-url'></a>
`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The URL to load. It is best to use a fully qualified URL.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-NavigateToUrl(IWebDriver_string_System-TimeSpan)-timeout'></a>
`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
  
  
#### Returns
[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
A self-reference to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver').  
