using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace MatKinhShadyTest.Utilities.Report
{
  public class ExtentReporting
  {
    private static ExtentReports extent;
    private static ExtentHtmlReporter htmlReporter;
    private static ExtentTest test;

    public static void InitReport()
    {
      string path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", ".." + "\\ReportResults\\"));
      string fileName = path + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".html";
      //Console.WriteLine("FileName: " + fileName);
      extent = new ExtentReports();
      htmlReporter = new ExtentHtmlReporter(fileName);
      //htmlReporter.Configuration().Theme = Theme.Standard;
      extent.AttachReporter(htmlReporter);
    }
    public static void CreateTest(string testName)
    {
      if (extent == null) InitReport();
      test = extent.CreateTest(testName);
    }
    public static void FlushReport()
    {
      extent.Flush();
    }
    public static void LogInfo(string message)
    {
      test.Info(message);
    }
    public static void LogFail(string message)
    {
      test.Fail(message);
    }
    public static void LogPass(string message)
    {
      test.Pass(message);
    }
    public static void LogScreenShot(string message, string img)
    {
      test.Info(message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
    }
  }
}
