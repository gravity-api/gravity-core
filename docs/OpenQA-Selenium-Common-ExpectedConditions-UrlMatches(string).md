#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Common](./OpenQA-Selenium-Common.md 'OpenQA.Selenium.Common').[ExpectedConditions](./OpenQA-Selenium-Common-ExpectedConditions.md 'OpenQA.Selenium.Common.ExpectedConditions')
## ExpectedConditions.UrlMatches(string) Method
An expectation for the URL of the current page to be a specific URL.  
```csharp
public static System.Func<OpenQA.Selenium.IWebDriver,bool> UrlMatches(string regex);
```
#### Parameters
<a name='OpenQA-Selenium-Common-ExpectedConditions-UrlMatches(string)-regex'></a>
`regex` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The regular expression that the URL should match.  
  
#### Returns
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[OpenQA.Selenium.IWebDriver](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebDriver 'OpenQA.Selenium.IWebDriver')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
True if the URL matches the specified regular expression; otherwise, False.  
