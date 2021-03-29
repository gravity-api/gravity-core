#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExpectedConditions](./OpenQA-Selenium-Common-ExpectedConditions.md 'OpenQA.Selenium.Common.ExpectedConditions')
## ExpectedConditions.ElementExists(OpenQA.Selenium.By) Method
An expectation for checking that an element is present on the DOM of a page.  
This does not necessarily mean that the element is visible.  
```csharp
public static System.Func<OpenQA.Selenium.IWebDriver,OpenQA.Selenium.IWebElement> ElementExists(OpenQA.Selenium.By by);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExpectedConditions-ElementExists(OpenQA-Selenium-By)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locator used to find the element.  
  
#### Returns
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
The [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') once it is located.  
