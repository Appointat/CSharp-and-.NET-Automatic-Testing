# C#/.NET

[] = crochets, {} = accolades

语法和C++相似。

[Youtube Video 20:13](https://www.youtube.com/watch?v=q_F4PyW8GTg)

### Encapsulation

- In the C#, A class is a blueprint for an object, and defines the properties and behaviors that the object will have. **Access modifiers**访问修饰符, such as **private, protected, internal, and public**, are used to control the accessibility of class members, and determine which code can access a particular property or method of the class.

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/e9d07845-c49d-4d39-b631-1d5869041933/Untitled.png)

### Heritage:

```csharp
using System;

namespace App
{
    interface ITradable
    {
        void SellToMerchant() // public
        {

        }
        void SellToAuctionHouse()
        {

        }
        void SellToPlayer()
        {

        }

    }

    class Mount : ITradable
    {

    }

    interface ITrableBetweenServers : ITradable
    {
        void SellToNeighbour();
    }

    abstract class Consumable // abstract
    {
        public abstract void Print();        
    }

    class MagicalBook : Consumable, ITradable
    {
        public override void Print()
        {

        }

        void SellTomerchant()
        {

        }

        
    }

    class Weapon : ITradable
    {
        void SellToMerchant()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ITradable items = new Mount();
        }
    }
}
```

### Abstration

- DRY: pylosophy of the program, Don’t Repeat Yourself.
- A great benefit of abstraction is having single classes that do something specific really well, that **many classes can call them**. This means they get the info they want, but **not the specifics**. Then if the specifics change, we change it in a single place, and all the classes utilising it, get updated.

### Polygone 多态:

sealed - override - virtual 

```csharp
using System;
using System.Security.Cryptography.X509Certificates;

namespace App
{
    class Fighter
    {
        public virtual void Fight()
        {
            Console.WriteLine("Fighter : Je combats, mais je ne sais pas ou.");
        }
    }

    class Tauren : Fighter
    {
        public override void Fight()
        {
            Console.WriteLine("Tauren!");
        }
    }
    class Human : Fighter
    {
        public override void Fight()
        {
            base.Fight(); // parent
            Console.WriteLine("Human!");
        }
        new public int lifePoints = 200;
    }

    class Orc : Fighter
    {
        //public override void Fight()
        //{
        //    Console.WriteLine("orc!");
        //}

        public override void Fight()
        {
            Console.WriteLine("orc!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human();
            Human h2 = new Human();
            Orc o1 = new Orc();
            Orc o2 = new Orc();
            Fighter t1 = new Tauren();
            Fighter[] fighters = new Fighter[] { h1, h2, o1, o2, t1 };

            foreach(var f in fighters) {
                f.Fight();
                /*
                 * Je combats, mais je ne sais pas ou.
                 * Human!
                 * Je combats, mais je ne sais pas ou.
                 * Human!
                 * Orc!
                 * Orc!
                 * Tauren!
                */
            }
            var h = new Human();
            Console.WriteLine(h.lifePoints); 
        }
    }
}
```

Gestion d’erreurs

- Debug.Assert(true)
- Trace.Assert(true)

```csharp
using System;
using System.Diagnostics;
namespace App
{
    class Program
    {
        static void PrintPositivement (int n)
        {
            //Debug.Assert(n>0, "1. n doit positif", "2. n > 0"); // valide (true)
            Trace.Assert(n > 0, "1. n doit positif", "2. n > 0"); // true
            Console.WriteLine(n);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour.");
            PrintPositivement(-4);
        }
    }
}
```

déclencheur de programme, trigger program程序触发

- Exception - try - catch

```csharp
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace App
{
    class ProgramException : Exception
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saisir un entier :");
            int number = 0;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Le nombre saisi est {number}");
                // throw new MyException("Erreur.");

            }
            catch (FormatException e)
            {
                Console.WriteLine("Saisi incrorrecte.");
                //throw;
            }
            catch(OverflowException)
            {
                //
            }
            catch(Exception) { } // tous les autres exceptions

            finally { 
                Console.WriteLine("Stop, finally."); // affiche dans tous les cas (true ou exceptions)
            }

        }
    }
}
```

### Shortcut

- "prop" + Tab 键：生成一个属性的声明
- "ctor" + Tab 键：生成一个默认的构造函数
- "for" + Tab 键：生成一个 for 循环
- "if" + Tab 键：生成一个 if 语句
- "try" + Tab 键：生成一个 try-catch 语句
- "using" + Tab 键：生成一个 using 语句
- "switch" + Tab 键：生成一个 switch 语句
- "class" + Tab 键：生成一个类的声明

### foreach (var i in tab)

### Lambda Expression

> (input-parameters) ⇒ {<sequence-of-statement>}
> 

```csharp
Func<int, int, bool> Eaqul = x, y => x==y;
Eaqul(1,2);
```

### Action

### async, await （处理异步lambda）

例如，下面的 Windows 窗体示例包含一个调用和等待异步方法 `ExampleMethodAsync`
的事件处理程序。

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        button1.Click += button1_Click;
    }

    private **async** void button1_Click(object sender, EventArgs e)
	  {
        await ExampleMethodAsync();
        textBox1.Text += "\r\nControl returned to Click event handler.\n";
    }

    private **async** Task ExampleMethodAsync()
    {
        // The following line simulates a task-returning asynchronous process.
        await Task.Delay(1000);
    }
}
```

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        button1.Click += async (sender, e) =>
        {
            await ExampleMethodAsync();
            textBox1.Text += "\r\nControl returned to Click event handler.\n";
        };
    }

    private **async** Task ExampleMethodAsync()
    {
        // The following line simulates a task-returning asynchronous process.
        await Task.Delay(1000);
    }
}
```

### Extension Properties 更复杂的属性

```csharp
using System;
class MyClass
{
    private int hight;
    private int aera;
    public int Hight { get { return hight;  } set { hight = value; } }
    public int width { get; set; }
    public int Aera { get { return hight * width; } }
}
internal class Program
{
    static void Main(string[] args)
    {
        MyClass class1 = new MyClass();
        class1.Hight= 3;
        class1.width = 2;
        Console.WriteLine(class1.Hight+"\n"+class1.width+"\n"+class1.Aera);
    }   
}
```

### Internal - keyword

- It is used to mark a class, interface, field, property, method, or event **as being visible only within the current assembly** (a unit of code that can be compiled and executed, the main function)
- Overall, the internal keyword is primarily used to **control the accessibility** of classes and class members, and to help maintain the integrity and encapsulation of a class.

### Jagged Array

```csharp
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[5];
jaggedArray[1] = new int[3];
jaggedArray[2] = new int[2];
```

### ArrayList()

```csharp
ArrayList list = new ArrayList();
list.Add(10);
list.Add("hello");
list.Remove(1);
list.RemoveAt(1);
```

### NotImplementedException class

- It is a class that is thrown to indicate that the method or operation being called **has not been implemented**. This can be useful when you are developing a class hierarchy and want to specify that certain methods must be implemented by derived classes.

## Automatic Testing（[点此返回Ansys自动测试岗位业务问](https://www.notion.so/Eng-SDE-Ansys-Compressed-Sensing-951e248a9ea74734b5f668956de71375)）

1. Manual testing
2. Automatic testing
3. Type of the test
    1. **Unit test**
        1. As the name suggests顾名思义， test a unit without its external dependencies: databases, message queues, web services, and so on.
        2. **为什么使用Unit Test? Why do we need to have automated unit testing? How effective is it?**
            1. 优点：Automated unit testing is precious first and foremost, because it is automatable
            2. As the size of an application grows, manual testing is no more enough, because it takes too much time and is **error-prone易错的**（not 100% correct）
            3. In addition, in **Agile development敏捷开发**, we have to operate with the concept of Rapid Feedback: the sooner we can get feedback about what we did was right or wrong, the more **effective** we can be.
            4. 采用 **Test-Driven Development** (TDD)的方式开发程序
        3. **如何开始Unit Test？**
            1. 选择framework, usually we could choose the NUnit framework (MSTest framework based on the VS, [xUnit.Net](http://xUnit.Net) is a modern framework)
    2. **Integration**
        1. test with its external dependencies
            
            ![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/d5c4dc13-620e-4bd1-8a87-9e7e352f5314/Untitled.png)
            
    3. End-to-end
        1. drives an application through its UI
    4. Test pyramid金字塔
        
        ![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/28780734-bfec-4d44-989d-58ad14b3ba90/Untitled.png)
        
        1. favor unit tests to e2e tests 使用unit test
        2. cover unit test gaps with integration tests 用集成测试弥补单元测试的差距
        3. use end-to-end tests sparingly谨慎使用e2e test
4. The tooling: Focus on the fundamentals, not the tooling
    1. Rider + ReSharper (fast) / Visual Studio + ReSharper
5. 存在哪些测试方向的案例？

### Unit Test - [Youtube-33:09](https://www.youtube.com/watch?v=GSTVFx0KOzI)

```csharp
namespace TestNinja.UnitTests
{   
    public class Reservation
    {
        public User MadeBy { get; set; }
        public bool CanbeCancelledBy(User user)
        {
            return (user.IsAdmin || MadeBy == user);
            // if (MadeBy == user) return true;
            // return false;
        }
    }

    public class User
    {
        public bool IsAdmin { get; set;}
    }
}

// using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using NUnit.Framework;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            // Arrange 安排
            var reservation = new Reservation();

            // Act
            var resualt = reservation.CanbeCancelledBy(new User { IsAdmin = true });

            // Assert 断言
            // Assert.IsTrue(result);
            Assert.That(result, Is.True);
            // Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_RetureTrue()
        {
            // Arrange 安排
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var resualt = reservation.CanbeCancelledBy(user);

            // Assert
            Assert.IsTrue(resualt);
        }
        
        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnFlase()
        {
            var reservation = new Reservation();
            var resualt = reservation.CanbeCancelledBy(new User());
            Assert.IsFalse(resualt);
        }
    }
}
```

运行：Test - Run All Tests - 弹出Test Explorer 

### NUnit - test framework

- NUnit is an **open-source test framework**. It could be a **unit**, an **API** or some code that uses a **UI library** to drive a UI.
- It allows us to realize and develop the methods as the tests in C#. And then we design those methods to exercise/train our application.
- It then also provides a **test runner**. A test runner is a tool that is able to find the methods marked as **tests in the source code** and **execute those blocks of code**.
    - NUnit offers a sample method to do the unit test, it is Assert() method in the *asserting library*,  which allows us to compare objects we are expecting and the actual, so in this case, we can determine whether to pass or fail this test.
    - Finally, it will return us a rapport and the result of the unit test.

### Test-Driven Development (TDD)

Write your tests before writing the production code.

1. Write a failing test
2. Write the simplest code to make the test pass
3. Refactor if necessary

Benefit of TDD

1. Testable source code
2. Full coverage by tests (could be refactored and deployed) déploiement 
3. Simpler Implementation
4. Test first or code first, it depends on the situation, if the test is complex, we prefer the code first.

### ASP.NET Web API

- Web APIs are software programming interfaces that allow applications to communicate with each other over the Web.
- They use the HTTP protocol to send and receive data
- Web APIs are often used to expose the functionality of an application to **third-party developers**, who can then create their own applications using these features. **In C#**, ****an API can be thought of as **a collection of classes, methods, and properties** that a programmer can use to perform specific tasks or access specific data within a system or service.
    - inherit继承
- 一般使用**ASP.NET**工具：翻译One of the most common ways is to use the "**ASP.NET Web API**" tool
- 

## [ASP.NET](http://ASP.NET) Core - [Youtube Vedio 32:57](https://www.youtube.com/watch?v=BfEjDD8mWYg)

- ASP.NET is a web development framework that allows developers to create dynamic web applications using the C# programming language.
- ~~SAP.NET Core - C# tool to build web applications~~
- ~~A competitor to Java Spring, PHP Laravel, Python Flask, Node.js Express (for enterprises’ projects)~~
- .NET - 微软，Development Platform (similar to Java Virtual Machine)
- ASP - **Active Server Pages**, dynamic web pages, connected to a database
- Conception of design method: Models Views and COntrollers (MVC)
    - Structure
        - Router: forwards [data packets](https://en.wikipedia.org/wiki/Data_packet)
        
        ![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/2e7f3728-2e49-42da-ad6e-774710718d29/Untitled.png)
        
    
    ### View
    
    - HTML CSS code
    - Usually gets a list of data from the controller
    - Dynamically combines data with HTML in a template
    - Razor (ASP.NET)
    
    ### Introduction of Model
    
    - Data Related
        - Object Relation Mapper (ORM)
        - 2 ways to manage the data access
            - Data Access Object (DAO): traditional, visible
                - they are tables
                - SQL statements
                - Database managers in companies (DAB’s) prefer DAOs
            - Object Relationnal Mapper (ORM)
                - Coders prefer ORMs, because ORM is built according to the classes
                - Database is updated using migrations
                - Simple for basic applications
    - Consists of classes/objects
    - Uses SQL statements
    - Supplies the controller

### Selenium (Tool)

- **我知道这个软件，但是我了解地不够深刻**。I know this software for automation C#, but I don't know it well enough.
- Selenium is a tool that **automates web browsers**, allowing developers to write tests that can interact with websites in the same way that a user would. It is commonly used for testing the functionality of web applications. To use Selenium, the developer writes a script that inst

## Protobuf - proto3

声明一个Java类，实例化的方式：

Advantages of JSON:

- Readable
- self-contained
- Extensible in data type

Shortages of JSON:

- Expensive (unclear types, allocation)
- Massive in URL

Protobuf

- 通过预先声明来节省空间和消耗
- 需要创建协议文件
- 适合小数据small volume， need to inspect， messages are varied（因此适用于servers传递RPC framework消息， used by Google）
- 工作流程（以JAVA为例）：
    - Automated Generation of Code by creating objects in all languages
    - serialized data 连载数据 can be interpreted译释 by any language
    - 通过Java Project，生成java类
    - 也可以通过Ruby Project，生成Ruby代码
- Google Protobuf