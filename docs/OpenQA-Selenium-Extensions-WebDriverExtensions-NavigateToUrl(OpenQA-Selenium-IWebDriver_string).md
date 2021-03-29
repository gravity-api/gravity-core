#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.NavigateToUrl(OpenQA.Selenium.IWebDriver, string) Method
Calling the [NavigateToUrl(OpenQA.Selenium.IWebDriver, string)](./OpenQA-Selenium-Extensions-WebDriverExtensions-NavigateToUrl(OpenQA-Selenium-IWebDriver_string).md 'OpenQA.Selenium.Extensions.WebDriverExtensions.NavigateToUrl(OpenQA.Selenium.IWebDriver, string)') method will load a new web page  
in the current browser window. This is done using an HTTP GET operation, and the method  
will block until the load is complete.  
```csharp
public static OpenQA.Selenium.IWebDriver NavigateToUrl(this OpenQA.Selenium.IWebDriver driver, string url);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-NavigateToUrl(OpenQA-Selenium-IWebDriver_string)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-NavigateToUrl(OpenQA-Selenium-IWebDriver_string)-url'></a>
`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The URL to load. It is best to use a fully qualified URL.  
  
#### Returns
[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
A self-reference to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver').  
