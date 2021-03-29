#### [Gravity.Core](./index.md 'index')
### [OpenQA.Selenium.Extensions](./OpenQA-Selenium-Extensions.md 'OpenQA.Selenium.Extensions').[WebElementExtensions](./OpenQA-Selenium-Extensions-WebElementExtensions.md 'OpenQA.Selenium.Extensions.WebElementExtensions')
## WebElementExtensions.GetSource(OpenQA.Selenium.IWebElement) Method
Get the element's HTML and all it's content, including the start tag, it's attributes, and the end tag.  
```csharp
public static string GetSource(this OpenQA.Selenium.IWebElement element);
```
#### Parameters
<a name='OpenQA-Selenium-Extensions-WebElementExtensions-GetSource(OpenQA-Selenium-IWebElement)-element'></a>
`element` [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement')  
The [OpenQA.Selenium.IWebElement](https://docs.microsoft.com/en-us/dotnet/api/OpenQA.Selenium.IWebElement 'OpenQA.Selenium.IWebElement') from which to get the outer HTML.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The HTML element and all it's content, including the start tag, it's attributes, and the end tag.  
### Remarks
Works only on Web/Mobile Web platforms.  
