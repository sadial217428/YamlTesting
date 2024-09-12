using NUnit.Framework;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace UITests;

[SetUpFixture]
public class AppiumSetup
{
	private static AppiumDriver? driver;

	public static AppiumDriver App => driver ?? throw new NullReferenceException("AppiumDriver is null");

	[OneTimeSetUp]
	public void RunBeforeAnyTests()
	{
		// If you started an Appium server manually, make sure to comment out the next line
		// This line starts a local Appium server for you as part of the test run
		AppiumServerHelper.StartAppiumLocalServer();

        //var windowsOptions = new AppiumOptions
        //{
        //	// Specify windows as the driver, typically don't need to change this
        //	AutomationName = "windows",
        //	// Always Windows for Windows
        //	PlatformName = "Windows",
        //          // The identifier of the deployed application to test
        //          //App = "com.companyname.basicappiumsample_9zz4h110yvjzm!App",
        //          App = @"F:\YamlsTestingProject\YamlTesting\Yaml\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\Yaml.exe"

        //          };
        //var currentDir = AppDomain.CurrentDomain.BaseDirectory;

        //// Use relative path based on the current directory
        //var appPath = Path.Combine(currentDir, @"..\..\..\Yaml\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\Yaml.exe");

        //var windowsOptions = new AppiumOptions
        //    {
        //    AutomationName = "windows",
        //    PlatformName = "Windows",
        //    App = appPath  // Use dynamically calculated path
        //    };
        //string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Yaml\\bin\\Debug\\net8.0-windows10.0.19041.0\\win10-x64\\Yaml.exe"));
        /// string appPath ="https://github.com/sadial217428/YamlTesting/blob/main/Yaml/bin/Debug/net8.0-windows10.0.19041.0/win10-x64/Yaml.exe";


        /// string projectRoot = @"Yaml\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\Yaml.exe";

        //string appPath =Path.Combine(projectRoot, @"YamlsTestingProject\YamlTesting\Yaml\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\Yaml.exe");

        // Log the path for debugging purposes

        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", ".."));

        // Combine the root directory with the relative path to the executable
        string appPath = Path.Combine(projectRoot, "Yaml", "bin", "Debug", "net8.0-windows10.0.19041.0", "win10-x64", "Yaml.exe");


        Console.WriteLine($"Application Path: {appPath}");

        var windowsOptions = new AppiumOptions
            {
            AutomationName = "windows",
            PlatformName = "Windows",
            App = appPath  // Use dynamically calculated path
            };

        // Note there are many more options that you can use to influence the app under test according to your needs

        driver = new WindowsDriver(windowsOptions);
	}

	[OneTimeTearDown]
	public void RunAfterAnyTests()
	{
		driver?.Quit();

		// If an Appium server was started locally above, make sure we clean it up here
		AppiumServerHelper.DisposeAppiumLocalServer();
	}
}
