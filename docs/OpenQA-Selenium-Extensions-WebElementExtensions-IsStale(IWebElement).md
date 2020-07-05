#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebElementExtensions](./OpenQA-Selenium-Extensions-WebElementExtensions.md 'OpenQA.Selenium.Extensions.WebElementExtensions')
## WebElementExtensions.IsStale(IWebElement) Method
Gets a value indicating if this [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') is stale (not attached to the DOM).  
```csharp
public static bool IsStale(this IWebElement element);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-IsStale(IWebElement)-element'></a>
`element` [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
The element.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/api/true 'true') if element is stale; [false](https://docs.microsoft.com/en-us/dotnet/api/false 'false') if not.  
