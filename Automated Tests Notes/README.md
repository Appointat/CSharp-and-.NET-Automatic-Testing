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

---

# Automated Tests for React application

---

# Automated Tests for React Electron Application

## Definition Electron

Electron is an open-source framework for building desktop applications using web technologies such as HTML, CSS, and JavaScript, which has since become a popular choice for building desktop applications across various industries.

## Definition React

React is an open-source JavaScript library for building user interfaces, which is now widely used by developers to build single-page applications, mobile applications, and complex web applications. React uses a **component-based architecture基于组件架构,** which means that developers can build complex user interfaces by composing smaller, reusable components.

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
    4. Configure the pipeline (Azure DevOps)
5. Monitor and Refactor

---

# Spectron Electron Automated Test

## Definition Spectron

Spectron is an open-source testing framework of Electron for **building desktop applications**. It is built on top of the **popular testing framework**, WebDriver, and provides a simple and consistent API for interacting with Electron applications and testing their user interface.

## Set up Spectron for automated testing (method 1) [[link](https://www.electronjs.org/docs/latest/tutorial/automated-testing)]

### Using the WebDriver interface

> WebDriver is an open-source tool for automated testing of web apps across many browsers. It provides capabilities for navigating to web pages, user input, JavaScript execution, and more. ChromeDriver is a standalone server which implements WebDriver's wire protocol for Chromium. It is being developed by members of the Chromium and WebDriver teams.
> 

> `npm` and `yarn` are available, but here we talk about `yarn` .
> 

There are a few ways that you can set up testing using WebDriver.

- **With WebdriverIO**
    1. **Install the test runner**. Run the WebdriverIO starter toolkit in your project root directory: `npx wido --yes` 
        - This installs all necessary packages for you and generates a `wdio.conf.js` configuration file.
    2. **Connect WDIO to your Electron app**. Update the capabilities in your configuration file `wdio.conf.js` to point to your Electron app binary:
        
        ```jsx
        export.config = {
          // ...
          capabilities: [{
            browserName: 'chrome',
            'goog:chromeOptions': {
              binary: '/path/to/your/electron/binary', // Path to your Electron binary.
              args: [/* cli arguments */] // Optional, perhaps 'app=' + /path/to/your/app/
            }
          }]
          // ...
        }
        ```
        
    3. **Run your test**: `npx wdio run wdio.conf.js`
- **With Selenium :** [Selenium](https://www.selenium.dev/) is a web automation framework that exposes bindings to WebDriver APIs in many languages. Their Node.js bindings are available under the `selenium-webdriver` package on NPM. [[link](https://www.electronjs.org/docs/latest/tutorial/automated-testing#with-selenium)]

### **Using Playwright**

> [Microsoft Playwright](https://playwright.dev/) is an end-to-end testing framework built using browser-specific remote debugging protocols, similar to the [**Puppeteer**](https://github.com/puppeteer/puppeteer) headless Node.js API but geared towards end-to-end testing. Playwright has experimental Electron support via Electron's support for the [Chrome DevTools Protocol](https://chromedevtools.github.io/devtools-protocol/) (CDP).
> 
1. **Install dependencies**
    - You can install Playwright through your preferred Node.js package manager. The Playwright team recommends using the `PLAYWRIGHT_SKIP_BROWSER_DOWNLOAD` environment variable to avoid unnecessary browser downloads when testing an Electron app.
        
        ```jsx
        PLAYWRIGHT_SKIP_BROWSER_DOWNLOAD=1 yarn add --dev playwright
        ```
        
    - Playwright also comes with its own test runner, Playwright Test, which is built for end-to-end testing. You can also install it as a dev dependency in your project:
        
        ```jsx
        yarn add --dev @playwright/test
        ```
        
    
    > If you're interested in using an alternative test runner (e.g. `Jest` or `Mocha` ), check out Playwright's [Third-Party Test Runner](https://playwright.dev/docs/test-runners/) guide.
    > 
2. **Write your tests [[link](https://www.electronjs.org/docs/latest/tutorial/automated-testing#write-your-tests)]**

### **Using a custom test driver [[link](https://www.electronjs.org/docs/latest/tutorial/automated-testing#using-a-custom-test-driver)]**

## Set up Spectron for automated testing (method 2) [ChatGPT]

To use Yarn to generate automated tests for a project in Rider, you can follow these general steps:

1. Install Yarn: If you haven't installed Yarn already, you can download it from the official website: **[https://classic.yarnpkg.com/en/docs/install](https://classic.yarnpkg.com/en/docs/install)**.
2. Install testing dependencies: Depending on the testing framework you want to use (e.g. Jest, Mocha, etc.), you need to install the necessary dependencies. For example, if you want to use Jest, you can run the following command in the terminal:
    
    ```css
    yarn add --dev jest @types/jest
    ```
    
    This installs the Jest testing framework and its TypeScript typings as a development dependency.
    
3. Create test files: Once you have installed the testing dependencies, you can create test files for your project. For example, if you have a TypeScript project with source files in a **`src`** directory, you can create a test file **`src/index.test.ts`** that tests the code in **`src/index.ts`**.
4. Configure Jest: Depending on your project's setup, you may need to configure Jest to work with your project. This can include configuring Jest to recognize TypeScript files or setting up Jest to use specific testing libraries or mock functions. You can configure Jest by adding a **`jest.config.js`** file to the root of your project or by adding a **`jest`** section to your **`package.json`** file.
5. Run tests: Once you have created test files and configured Jest, you can run the tests using the **`yarn test`** command. This command runs the tests using the configuration specified in the **`jest.config.js`** or **`package.json`** file.

In Rider, you can use the built-in test runner to run your Yarn tests. To do this, you need to configure the test runner to use the **`yarn test`** command. You can do this by opening the "Run" menu, selecting "Edit Configurations...", and then creating a new "Yarn" configuration. In the "Yarn" configuration, set the "Script" field to "test" and the "Arguments" field to any additional arguments you want to pass to the **`yarn test`** command. Then, you can run the tests by selecting the "Yarn" configuration from the "Run" menu.

## Set up Spectron for automated testing (method 3) [not recommend]

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

---

# Actual Problems

## Statement

> This might be helpful too, for a better understanding of what went wrong previously.
> 

As we are currently facing plenty of problems with automated tests, I will try to summarize everything quickly:

1. The first problem we faced is the randomness of failing tests, although we found a machine that was able to run all the tests without any failure and we are trying to move the automated tests there, I think it was a little bit of luck that it passed all the tests without any random failings, although I tested the machine a lot of time. and the reason is that on my local machine, it was 100% passing, and then I was surprised that it is not always like that, and what proves my theory is that the QA is trying to run the test and they literally said that it is failing randomly. 我们面临的第一个问题是测试失败的随机性。尽管我们找到了一台机器可以在不出现任何失败的情况下运行所有的测试，我们正在尝试将自动化测试迁移到该机器上。我认为，该机器可以在没有随机失败的情况下通过所有测试，这有点幸运，尽管我已经多次测试了该机器。原因是在我的本地机器上，测试是百分百通过的，然后我惊讶地发现情况并不总是如此。证明我的理论的是，QA正在尝试运行测试，他们明确表示测试会随机失败。
2. The second problem is that the QA requires a lot of changes in the structure of the files, not only the location, which will require changes in all the JS files and the pipelines. 第二个问题是QA需要对文件结构进行大量更改，不仅是位置，还需要对所有JS文件和管道进行更改。
3. The third problem is the log reporting for an error is not clear at all for the QA (and sometimes for us) 日志报告不够清晰（对于我们和QA来说）
4. The fourth problem and the most important one is that the version of Spectron and puppeteer are outdated, we are currently using Spectron V14.0.0 and puppeteer V2.1.2 although we should and must use **Spectron V19.0.0** and **puppeteer V15.1.1**, especially after the 3rd parties upgrades. 第四个问题也是最重要的问题是Spectron和Puppeteer的版本过时。我们目前使用的是Spectron V14.0.0和Puppeteer V2.1.2，尽管我们应该和必须使用Spectron V19.0.0和Puppeteer V15.1.1，尤其是在第三方更新之后。

**Proposition**/**Solutions:** What I propose is that either we change the versions and then dedicate a suitable time to fix everything I talked about, or to start from scratch (which may be way easier), otherwise if we continue what we are currently doing (trying to fix the problems that the QA are facing) I think it is waste of their and our time. 我建议我们要么更改版本，然后花适当的时间修复我提到的所有问题，要么从头开始（可能更容易），否则，如果我们继续当前的做法（试图解决QA所面临的问题），我认为这是浪费他们和我们的时间。