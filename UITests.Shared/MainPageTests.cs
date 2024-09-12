using NUnit.Framework;

// You will have to make sure that all the namespaces match
// between the different platform specific projects and the shared
// code files. This has to do with how we initialize the AppiumDriver
// through the AppiumSetup.cs files and NUnit SetUpFixture attributes.
// Also see: https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html
namespace UITests;

// This is an example of tests that do not need anything platform specific
public class MainPageTests : BaseTest
{
	[Test]
	public void AppLaunches()
	{
		App.GetScreenshot().SaveAsFile($"{nameof(AppLaunches)}.png");
	}

	[Test]
	public void ClickCounterTest1()
	{
		
            // Arrange
            // Find elements with the value of the AutomationId property
            Task.Delay(2000).Wait(); // Wait for 2 seconds before clicking

            var element = FindUIElement("CounterBtn");

            // Act
            element.Click();
            Task.Delay(500).Wait(); // Wait for the click to register and show up on the screenshot

        // Assert
        string dateTimeNow = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        // Save the screenshot with DateTime included in the filename
        App.GetScreenshot().SaveAsFile($"{nameof(ClickCounterTest)}_{dateTimeNow}.png");


        Console.WriteLine("i m runinng 12");
        Assert.That(element.Text, Is.EqualTo("Clicked 1 time"));
    
	}


    [Test]
    public void ClickCounterWelcomeTest()
        {
     
            // Arrange
            Task.Delay(2000).Wait(); 

            var element = FindUIElement("Welcome");
        string dateTimeNow = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        // Save the screenshot with DateTime included in the filename
        App.GetScreenshot().SaveAsFile($"{nameof(ClickCounterTest)}_{dateTimeNow}.png");
        Assert.That(element.Text,Is.EqualTo("Welcome"));


        Console.WriteLine("i m runinng 566");


        }

    [Test]
    public void ClickCounterTest()
        {
        // Get the root path of the application dynamically
        string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        string logFilePath = Path.Combine(rootPath, "TestLogs", "TestLog.txt"); // Create the file in a 'TestLogs' directory

        // Ensure that the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

        string testName = nameof(ClickCounterTest);

            // Arrange
            Task.Delay(2000).Wait(); // Wait for 2 seconds before clicking
            var element = FindUIElement("CounterBtn");

            // Act
            element.Click();
            Task.Delay(500).Wait(); // Wait for the click to register and show up on the screenshot

            // Assert
            string dateTimeNow = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Save the screenshot with DateTime included in the filename
            App.GetScreenshot().SaveAsFile(Path.Combine(rootPath, $"{testName}_{dateTimeNow}.png"));

            // Assert element text
            Assert.That(element.Text, Is.EqualTo("Clicked 1 time"));

        // Log success to the text file

        Console.WriteLine("i m runinng 3333");
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                writer.WriteLine($"{DateTime.Now}: Test '{testName}' passed.");
                }
            
      
        }


    }
