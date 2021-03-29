#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebDriverExtensions](./OpenQA-Selenium-Extensions-WebDriverExtensions.md 'OpenQA.Selenium.Extensions.WebDriverExtensions')
## WebDriverExtensions.SendPostCommand(OpenQA.Selenium.IWebDriver, string, System.Collections.Generic.IDictionary&lt;string,object&gt;) Method
Sends POST command directly to this [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
```csharp
public static string SendPostCommand(this OpenQA.Selenium.IWebDriver driver, string route, System.Collections.Generic.IDictionary<string,object> data);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SendPostCommand(OpenQA-Selenium-IWebDriver_string_System-Collections-Generic-IDictionary-string_object-)-driver'></a>
`driver` [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')  
This [OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver') instance.  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SendPostCommand(OpenQA-Selenium-IWebDriver_string_System-Collections-Generic-IDictionary-string_object-)-route'></a>
`route` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Command route starting with "/" (use the complete route which comes after session id).  
  
<a name='OpenQA-Selenium-Extensions-WebDriverExtensions-SendPostCommand(OpenQA-Selenium-IWebDriver_string_System-Collections-Generic-IDictionary-string_object-)-data'></a>
`data` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
Post data to send (parameters list).  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Command response as JSON (if available).  
