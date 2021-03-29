#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExpectedConditions](./OpenQA-Selenium-Common-ExpectedConditions.md 'OpenQA.Selenium.Common.ExpectedConditions')
## ExpectedConditions.TextMatches(OpenQA.Selenium.By, string) Method
An expectation for the given element's text to match a pattern.  
```csharp
public static System.Func<OpenQA.Selenium.IWebDriver,OpenQA.Selenium.IWebElement> TextMatches(OpenQA.Selenium.By by, string regex);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExpectedConditions-TextMatches(OpenQA-Selenium-By_string)-by'></a>
`by` [OpenQA.Selenium.By](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.By 'OpenQA.Selenium.By')  
The locator used to find the element.  
  
<a name='OpenQA-Selenium-Common-ExpectedConditions-TextMatches(OpenQA-Selenium-By_string)-regex'></a>
`regex` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The regular expression that the attribute should match.  
  
#### Returns
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
A self-reference to this [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement').  
