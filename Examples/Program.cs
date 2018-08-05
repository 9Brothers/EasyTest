using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTestDotNet;
using EasyTestDotNet.Enums;
using OpenQA.Selenium;

namespace Examples
{
  class Program
  {
    static void Main(string[] args)
    {
      var configurations = new Configurations
      {
        DefaultMaxTime = TimeSpan.FromSeconds(20.0),
        Driver = EDriver.CHROME
      };

      new VisualizaProduto(configurations);
    }
  }
}
