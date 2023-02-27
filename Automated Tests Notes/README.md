# Automated Tests

# Introduction

They are designed to be executed automatically by software rather than manually by a human tester. As for applications, they are widely used in software development and quality assurance (QA) to improve the efficiency and accuracy of testing.

1. `Unit tests`: These tests are used to test individual units of code, such as functions or methods, to ensure they behave as expected. 
2. `Integration tests`: These tests are used to verify the interaction between different units of code or systems, and to ensure they integrate correctly.
3. `Functional tests`: These tests are used to test the functionality of the software from the perspective of the end user, to ensure the software meets the specified requirements.
4. `Performance tests`: These tests are used to evaluate the performance of the software under different conditions, such as varying workloads or network conditions.
5. `Regression tests`: These tests are used to ensure that changes made to the software do not break existing functionality.

# Importance

## **Why Do Automated Tests Matter?**

Automated tests enable **fast error feedback** on the code developed, making the **development process more reliable**. In other words, developers can see errors quickly and fix them before software goes into production.

Automated testing is also useful when integrating new features into your software. 

- When the integration of features is being done, the written tests can ascertain探明 which parts of the software will break after the integration.
- Otherwise, if the tests are done manually, the team would need to test the integration at least three times: in a new feature created, in an old feature integrated, and in between both parts.

Testing manually is not only **time-consuming耗时的**, but it's also **error-prone易错的**. 

So, developing an application driven by automated tests can provide many benefits, including:

1. Quality control: we know what to expect from the software’s behavior.
2. Clear documentation: well-written tests are a good way to document software features.
3. Long-term value: even if you have to expend more effort up front to develop automated tests, you'll gain long-term dividends.
4. Time back: the more the tests are run, the more time they save you.
5. Energy back: the longer the lifecycle of a project, the more important automated tests become.

# Example - AT

```csharp
// Import the necessary libraries for unit testing
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Define a class for testing the Calculator class
[TestClass]
public class CalculatorTests
{
    // Define a test method for the Add functionality of the Calculator
    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange - set up the test by defining variables and expected results
        int num1 = 5;
        int num2 = 7;
        int expectedSum = 12; // Define the expected result of adding num1 and num2

        // Act - execute the code being tested
        Calculator calculator = new Calculator(); // Create a new instance of the Calculator class
        int actualSum = calculator.Add(num1, num2); // Call the Add method of the Calculator instance to get the actual result

        // Assert - check that the expected result and actual result are the same
        Assert.AreEqual(expectedSum, actualSum); // Compare the expected result with the actual result to ensure that the Add method is working correctly
    }
}

// Define the Calculator class that contains the Add method
public class Calculator
{
    // Add method adds two numbers and returns their sum
    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }
}
```

# Automated Tests for React application 针对React的自动化测试

# Automated Tests for React Electron Application 基于React Electron的自动化测试

## Definition Electron

Electron is an open-source framework for building desktop applications using web technologies such as HTML, CSS, and JavaScript, which has since become a popular choice for building desktop applications across various industries.

## Definition React

React is an open-source JavaScript library for building user interfaces, which is now widely used by developers to build single-page applications, mobile applications, and complex web applications. React uses a **component-based architecture基于组件架构,** which means that developers can build complex user interfaces by composing smaller, reusable components.

## Role of React

## Set up with React

> Definition: CI system (Continuous Integration) is the practice of merging all developers' working locals to a shared mainline, which triggers automated build and test before the merger/integration.
> 

> CD system (Continuous Delivery) can automatically deploy the built application to a production environment. This can involve deploying to a single server or multiple servers, depending on the architecture of the application. CD system depends on CI system.
>

1. Identify the components
2. Using the Jest Library
3. Write user stories and test cases
4. Run the application
    1. Choose a CI system
    2. Configure it
    3. Connect the repository
    4. Configure the pipeline
5. Monitor and Refactor

# Spectron Electron Automated Test 基于Spectron Electron的自动化测试

## Definition Spectron

Spectron is an open-source testing framework for **Electron applications**. It is built on top of the **popular testing framework**, WebDriverIO, and provides a simple and consistent API for interacting with Electron applications and testing their user interface.

## Set up Spectron for automated tests

1. Install Spectron as a dependency in your project. 
2. Set up the test framework/test runner, such as Mocha, and an assertion library, such as Chai.
3. Write your tests, using Spectron’s Application object, which represents your Electron app.
    
    ```jsx
    const Application = require('spectron').Application;
    const assert = require('assert');
    const path = require('path');
    
    // Path to your Electron application's executable file
    const appPath = path.join(__dirname, '..', 'dist', 'electron', 'MyApp.app', 'Contents', 'MacOS', 'MyApp');
    
    // Options object to configure Spectron Application instance
    const appOptions = {
      path: appPath
    };
    
    // Initialize a new Spectron Application instance
    const app = new Application(appOptions);
    
    // Wait for the application to be ready before running any tests
    before(function () {
      return app.start().then(function () {
        return app.client.waitUntilWindowLoaded();
      });
    });
    
    // Close the application after all tests are finished
    after(function () {
      if (app && app.isRunning()) {
        return app.stop();
      }
    });
    
    // Define a test suite using Mocha
    describe('MyApp', function () {
    
      // Define a test case within the suite 套件（大括号之内的）
      it('should display the correct window title', function () {
        // Use Spectron's built-in `browserWindow` method to access the application's window
        return app.client.browserWindow.getTitle().then(function (title) {
          // Assert that the window title is correct
          assert.strictEqual(title, 'MyApp');
        });
      });
    
      // Define another test case within the same suite
      it('should display a button that can be clicked', function () {
        // Use Spectron's built-in `element` and `click` methods to interact with the application's UI
        return app.client.element('#my-button').click().then(function () {
          // Use Spectron's built-in `isVisible` method to assert that the button was clicked and is now visible
          return app.client.isVisible('#my-button');
        }).then(function (isVisible) {
          // Assert that the button is visible after being clicked
          assert.strictEqual(isVisible, true);
        });
      });
    
    });
    ```
    
    - 关于代码结构的总结：定义app的路径，configuration，在test之前要确保Spectron已经准备好了，在suite里定义test
4. Run tests
    1. `npm test`. This will execute the tests defined in the **`describe`** and **`it`** blocks in your test script.
5. Debug and refine tests