# LearnDotnet
Just some study notes about dotnet.

## 目录

- [引言](Introduction.md)
- [.NET](Dotnet.md)

语言C#和F#

总体的C#和F#语法

可变类型，不可变类型，引用类型，

流程控制语句，通过模式匹配，遍历和递归来替代

- [布尔代数](Boolean.md)
- [整数](Integer.md)
- 数值计算
  - [浮点数和算术](FloatAndArithmetic.md)
- 符号运算
- 字符和字符串
  - 正则表达式





科学计算用F#讲

变量和内存分配

引用类型和值类型，装箱和拆箱

命令式编程

常量和函数式编程

枚举和类型（枚举实际上是真正在定义元类型（结构体和函数都是组合类型））



F#也是描述式为主，命令式为辅助（do块中）。但是可以写非常函数式的。



条件跳转，命令式编程和时序，变量和状态存储机制

函数式编程和常量



函数式 ，用模式匹配替代了条件跳转

用列表处理替代了遍历循环

用递归替代了其他循环



数据库查询

XML

JSON

CSV

文件流

Nuget包管理

.NET CLI工具

跨包引用等

项目构件，csproj，fsproj等

## 构思中的专题

- 变量和变量作用域（变量的常量修饰，类型推断等）
- 函数不是类，但是有类型。函数的delegates，lambda，匿名函数等。void（实际上是System.Void，也是一个值类型）
- 可迭代对象和遍历
- 异常系统

在继承中介绍is，as和dynamic

继承中介绍类型转换和构造器，以及隐式类型转换



- 值类型和引用类型
- 可空类型



- 数值运算
- 符号运算
- 机器推理（先从实现形式系统的基本规则检测开始）



浮点数->浮点数运算->基本算术

​     ->线性代数现有一个可以计算的类-> 并行或者cuda加速

快速傅立叶变换

多媒体

计算机图形学

浮点数，浮点数运算，浮点数数学库，system.math numeric，第三方库（mathnet，numsharp等）

引入随机

字符（字符编码），字符串，字符串操作，字符搜索、替换、正则表达式

线性代数（数值计算）

复数

符号运算，解方程，微积分，分数，任意大整数

工程计算：浮点数，张量运算

关于数学计算的加速，nvidia的cuda，opencl，因特尔的mkl等。arrayfire



mathnet还有符号计算功能

工程算术

逻辑推导（暂时没有找到合适的库）

commandline （命令行解析）

xml，json，csv，excel

LINQ，

opentk，opengl，openal等3D虚拟

ffmpeg

opencv



is, as等放到object的介绍中，作为通用的算符





C#专题，流程控制语句，三元表达式