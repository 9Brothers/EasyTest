using EasyTestDotNet.Enums;
using OpenQA.Selenium;
using System;

namespace EasyTestDotNet
{
  public class Configurations
  {
    public EDriver Driver { get; set; }
    public TimeSpan DefaultMaxTime { get; set; }
  }
}