using EasyTestDotNet;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
  public class VisualizaProduto : EasyTest
  {
    public VisualizaProduto(Configurations configurations) : base(configurations)
    {
      Visit("https://www.vvatacado.com.br");

      Find(By.Id("ctl00_TopBar_PaginaSistemaArea1_ctl15_txtBusca")).SendKeys("geladeira");

      ClickButton("Buscar");

      Find(By.CssSelector("#ctl00_Conteudo_ctl03_geladeira-consul-frost-free-275-l-branca-crm35nb-9600910 a")).Click();

      //test.ClickLinkByLinkText("Geladeira Consul Frost Free 275 L Branca CRM35NB");
      //test.ClickLinkById("ctl00_Conteudo_ctl03_geladeira-consul-frost-free-275-l-branca-crm35nb-9600910");

      Quit();
    }
  }
}
