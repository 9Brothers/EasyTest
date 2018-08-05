using EasyTestDotNet.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EasyTestDotNet
{
  public class EasyTest
  {
    private Configurations configurations = null;
    private IWebDriver driver = null;
    private IJavaScriptExecutor jsDriver = null;

    public EasyTest(Configurations configurations)
    {
      this.configurations = configurations;

      if(configurations.Driver == EDriver.CHROME)
      {
        driver = new ChromeDriver();
      }
      else if (configurations.Driver == EDriver.FIREFOX)
      {
        driver = new FirefoxDriver();
      }

      jsDriver = (IJavaScriptExecutor)driver;
    }

    /// <summary>
    /// Visita uma página pela URL
    /// </summary>
    /// <param name="url">URL de acesso à página</param>
    protected void Visit(string url)
    {
      driver.Navigate().GoToUrl(url);
    }

    /// <summary>
    /// Clica em um link pelo Id
    /// </summary>
    /// <param name="id">Id do link</param>
    protected void ClickLinkById(string id)
    {
      Find(By.Id(id)).Click();
    }

    /// <summary>
    /// Clica em um link pelo texto 
    /// </summary>
    /// <param name="text">Texto do link</param>
    protected void ClickLinkByLinkText(string text)
    {
      Find(By.LinkText(text)).Click();      
    }

    /// <summary>
    /// Clica em um botão pelo texto  
    /// </summary>
    /// <param name="text">Texto do botão</param>
    protected void ClickButton(string text)
    {
      IReadOnlyCollection<IWebElement> elements = (IReadOnlyCollection<IWebElement>)jsDriver.ExecuteScript("return document.getElementsByTagName(\"button\")");

      var element = elements.FirstOrDefault(e => e.Text == text);

      if(element != null)
      {
        element.Click();
      }
      else
      {
        throw new NoSuchElementException();
      }
    }

    /// <summary>
    /// Preenche um campo pelo label
    /// </summary>
    /// <param name="labelText">Texto do label</param>
    /// <param name="with">Texto a ser preenchido</param>
    protected void FillIn(string labelText, string with)
    {
      var label = FindElementByText(labelText);
      var labelFor = label.GetAttribute("for");

      Find(By.Id(labelFor)).SendKeys(with);
    }

    /// <summary>
    /// Procura um elemento na página
    /// </summary>
    /// <param name="by">Class Name | CSS Selector | ID | Link Text | Name | Partial Link Text | Tag Name | XPath</param>
    /// <returns></returns>
    protected IWebElement Find(By by, double timeout = 20.0)
    {
      var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
      var result = wait.Until((e) =>
      {
        try
        {
          var element = e.FindElement(by);

          return element.Displayed && element.Enabled;
        }
        catch (NoSuchElementException ex)
        {
          throw ex;
        }
      });

      if (result)
      {
        return driver.FindElement(by);
      }

      throw new NoSuchElementException();
    }

    protected void Quit()
    {
      driver.Quit();
    }

    private IWebElement FindElementByText(string text)
    {
      var elements = FindElementsByText(text);

      return elements.FirstOrDefault(e => e.Text == text);
    }

    private IReadOnlyCollection<IWebElement> FindElementsByText(string text)
    {
      var elements = (IReadOnlyCollection<IWebElement>)jsDriver.ExecuteScript("return document.getElementByTagName('label')");

      return elements.Where(e => e.Text == text).ToList();
    }

    
  }
}
