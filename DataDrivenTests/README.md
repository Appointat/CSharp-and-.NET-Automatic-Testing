# Data-Driven Test (DDT)

# Properties

## AssemblyInfo.cs

### namespace

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
```

### Assembly

An assembly is the compiled output of your code, typically a DLL, but your EXE is also an assembly. It's the smallest unit of deployment for any .NET project. 程序集是代码的编译输出，通常是 DLL，但 EXE 也是一个程序集。它是任何 .NET 项目的最小部署单元。

The assembly can also contain resources like icons, bitmaps, string tables, etc. Furthermore, the assembly also contains metadata in the assembly manifest - information like version number, strong name, culture, referenced assemblies and so forth. 程序集还可以包含图标、位图、字符串表等资源。此外，程序集还包含程序集清单中的元数据 - 版本号、强名称、区域性、引用的程序集等信息。

In 99% of your cases, one assembly equals a **physical file on disk** - the case of a multi-file assembly (one assembly, distributed across more than a single file) appears to be a rather odd-ball edge case. 在 99% 的情况下，一个程序集等于磁盘上的一个**物理文件**；多文件程序集（一个程序集，分布在多个文件中）的情况似乎是一个相当奇怪的边缘情况。

In a multifile assembly, there would still be only one assembly manifest in a DLL or EXE and the MSIL code in multiple netmodule files. 在多文件程序集中，DLL 或 EXE 中仍然只有一个程序集清单，多个网络模块文件中仍然只有一个 MSIL 代码。

- AssemblyTitle
    - This attribute is used to give a name to this particular assembly
    - It specifies a description for an assembly, and that the assembly title is a friendly name that can include spaces
- AssemblyDescription
    - Add notes/descriptions to the assembly
- AssemblyConfiguration
    - The assembly must have the configuration used to build the assembly
        
        ```csharp
        #if (DEBUG)
        [assembly: AssemblyConfiguration("Debug")]
        #else
        [assembly: AssemblyConfiguration("Release")]
        #endif
        ```
        
- AssemblyCompany
- AssemblyProduct
    - This attribute is used to describe the product that this particular assembly is for. Multiple assemblies can be components of the same product, in which case they can all share the same value for this attribute.
- AssemblyCopyright
- AssemblyTreademark
- AssemblyCulture

```csharp
// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("DataDrivenTests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("DataDrivenTests")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
```

### Version information

- AssemblyVersion
- AssemblyFileVersion
    - Version of the files

```csharp
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
```

### ComVisible

- COM visible (true) or not (false)

```csharp
// Setting ComVisible to false makes the types in this assembly not visible
// to COM components. If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
```

### Guid

- The following GUID is for the ID of the typelib, if this project is exposed to COM

```csharp
// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("fbbc6f15-e718-4080-832c-9d1f4b7a352a")]
```

# References

## DataDrivenTestFixture.cs

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/2c78c587-dc17-4438-89f2-7b2cc19f4458/Untitled.png)

## GenericTestFixture.cs

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/f46d7cfa-9450-4265-ab29-0f655eb6d84f/Untitled.png)

- keyword `[test]` is important.