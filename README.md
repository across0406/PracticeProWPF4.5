# PracticeProWPF4.5
This project is to practice codes for "Pro WPF 4.5 in C#."

## 1. Solution Environment
- OS: Windows 10 64-bit
- Framework: .NET Framework 4.8

## 2. Chapter 2 XAML
### 2-1. InitialWindow
#### - This WPF window relies on the following:
##### => Window
##### => Page ( similar to Window, but used for navigable applications. )
##### => Application ( defines application resources and startup settings, but just being only one, there is nothing for application. )
#### - There are two XML namespaces:
##### => xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
* It is the core WPF namespace, and encompasses all the classes for WPF.
##### => xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
* It includes a variety of XAML utility features. These features allow you to influence how your document is interpreted. This namespace is pinpointed to the prefix x.
#### - Naming Elements
##### => <Grid x:Name="grid1>
* The XAML parser adds a field like upper code to the automatically generated portion of the InitialWindow: private System.Windows.Controls.Grid grid1;

### 2-2. EightBallWindow
#### - Special Characters and Whitespace
##### => Less than < -> &#38;lt&#59;
##### => Greater than > -> &#38;gt&#59;
##### => Ampersand & -> &#38;amp&#59;
##### => Quotation mark " -> &#38;quot&#59;
#### - To use a class not defined in one of the WPF namespaces, just write like to the following:
##### => xmlns:[Prefix]="clr-namespace:[Namespace];assembly=[AssemblyName]"
* e.g. xmlns:sys="clr-namespace:System;assembly=mscorlib"
#### - Use uncompiled XAML file
##### => Just use XamlReader.Load( [ FileStream from xamlFile path ] )
