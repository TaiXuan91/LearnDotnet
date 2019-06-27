# LearnDotnet
Just some study notes about dotnet.

## 目录

目录仅仅是拓扑排序，外加大的模块分类

每篇文章一开始，如果有前驱节点，需要先说明前驱章节名称

- [引言](Introduction.md)

- [.NET](./Dotnet/README.md)

- [命名空间](./Namespace/README.md)   （对于一个函数定义来说，函数名是外部名称，比如Main内部可以定义为`Main`的变量但是最好不要这么干。类的名称也类似，但是和类同名的函数名有特殊用途。）

- [类的成员](./ClassMembers/README.md)

- 

可能的专题：

- 命名空间，命名一般规范，名称作用域，类的访问修饰
- 类型系统，泛型
- 内存管理，垃圾回收，引用类型和值类型的内存管理，非托管类型的管理
- 异常处理
- 委托，lambda表达式



Type是typeof算符返回值的类型



默认成员访问修饰符是private

可以在类里定义类（或者其他类型）



  在讲操作符重载的时候要说一下自定义显示转换和隐式转换的问题

事件是值类成员，因为事件handler本身是个代理类的对象

  

Type类。表示类型的对象的类



常量字段和常量

- 类型推断（var，函数式的写法）

- 流程控制
- 委托
- 泛型，类型系统
- 算符重载（包括Cast和Indexer）

进一步拆分核心功能：

- 异常处理
- 事件机制
- 通用数据容器（包括Array，Span，List等）
- 字符串，正则表达式
- 反射机制（如类的附加信息声明，Type类）
- 引用C++库



类的成员，成员访问权限，类型说明符（类型说明符就是类或者接口）

类的实例化，is，as，类的静态类型

类的继承，接口（接口继承自特殊类），重载，虚函数

方法，只读，常量，readonly



副作用，赋值，只读，常量

泛型



先讲类的定义，

结构体，接口，枚举等也是继承自类

但是定义语法比较特殊





读书读到了 2 Core C#

已经介绍完：

- 

已经讲过名称绑定，但是在垃圾回收部分要重新讲变量作用域

讲类的时候要把涉及名称绑定的内容重新讲一遍

预设读者有编程知识

不是为了让初学者看懂





变量声明，初始化和赋值，

- 命名空间
- 类
- 方法和字段
- 实际上可以通过lambda 表达式和代理把所有方法都当作是字段，但是没有必要

### 命令式编程

- 主函数

- 变量和赋值 （输出变量的写法）
- 运算和函数调用（从+=开始讲，没有副作用的函数是没有意义的，+和有返回值的函数相当于用缓存传参）
- 流程控制
- 函数定义
- 名称绑定和变量作用域（垃圾回收机制，值类型和引用类型）





- [丘奇和图灵](./ChurchAndTuring/README.md)
- [HelloWorld](./HelloWorld/README.md) 修改helloworld的一些常识其他代码段先不要管

- 

### 命令式编程

- 变量和赋值（顺便说一下WriteLine）
- +=和运算（从=到+=再到+，相当于运算用了一个隐藏的缓存区，以后函数返回值也这么介绍）
- 类型基础 （布尔，字符串，整数，但是不要把运算和函数内容讲太多）
- 流程控制
- 变量作用域（以及内存的回收问题，垃圾回收问题，析构函数，非托管内存）
- 变量命名规范
- 
- 
- 



注释

异常处理

- 引用类型和值类型
- 装箱和拆箱

函数式编程

- 名称绑定

命令式编程中，没有改变状态，就相当于什么都没有做。例如加法，必须是加和之后保存，如果不保存只加和，相当于啥都没有。因为不强制有返回值。

赋值就是操作，例如单片机控制里就是通过变量赋值。读入就是从外向内赋值，输出就是从内向外赋值。

函数式就很不同。

- 主函数
- 函数调用（相当于动作序列）
- 变量传递和名称绑定



各种运算不作为单独的内容，而是算到相关的类型里介绍。

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

科学计算

字符串模型

图像处理模型



面向过程和函数式

面向过程，流程控制作为基础

面向对象整理数据结构，作为过度

函数式是最终的



然后F#从函数式开始从函数的角度重新分析这个问题

从函数引出单子和时序



编程功能库（异常，修饰，反射等），

业务功能库（科学计算，字符串处理等）



讲库的时候两个语言都要涉及



加入例程，注意改写一下.gitignore

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



《C# 高级编程》跳过部分：

第1章

第2章

- WORKING WITH VARIABLES
- USING PREDEFINED DATA TYPES
- CONTROLLING PROGRAM FLOW
- UNDERSTANDING THE MAIN METHOD
- USING COMMENTS
- UNDERSTANDING C# PREPROCESSOR
  DIRECTIVES
- 

第3章

第4章

第5章

第6章

第7章

第8章

第9章



通用数据结构：

- 泛型容器
- 泛型算法



科学计算（数值计算）：

- 浮点数，常规数学运算与常量
- span等
- 常用结构（四元数，二维，三维坐标等）
- 通用线性代数框架
- 通用线性代数框架的硬件加速
- 傅立叶变换



参考资料：

- C#高级编程（C#7， .NET Core 2.0）
- C#7.3 参考
- .NET Core 2.1， 2.2





- 类继承，实例化，类成员，接口
- 泛类型
- 其他类型定义，结构体，枚举，事件，委托，匿名类型等实际上都是语法糖化的类型
- 方法
- 引用类型和值类型，拆箱，装箱，超出可见性后的内存回收，using涉及的非托管内存放到内存管理里介绍

- 流程控制
- 命名空间和名称可见性





小专题：

- 事件
- 异常处理和异常类
- 注释和DocFX



附加大专题：

- 浮点数，数学库和科学数值计算
- 符号计算
- 字符，字符串，字符串处理



尽量使用英文术语

- 基本概念，主函数，程序集

- 名称，标示符，访问权限（类成员访问修饰符）
- 类型系统，类型继承，接口，泛型，实例化（一切都是对象，但是实际上函数不是对象，类型本身不是对象，命名空间不是对象。其他的接口，结构体，枚举，数组，委托等都是类。通过反射技术还有专门表示类的对象。所以如果把函数当作委托，不考虑命名空间的特殊性，一切都是类和对象。如果算上反射把类也能搞成对象，那么一切都是对象。）
- 委托，lambda表达式，local函数



关于程序集的解释https://docs.microsoft.com/zh-cn/dotnet/standard/glossary#assembly

https://docs.microsoft.com/en-us/dotnet/standard/glossary#assembly



命名空间和名称

- ~~标示符词法~~
- ~~防止冲突的命名空间~~
- ~~标示符的作用域，覆盖（其实还涉及到内存的动态绑定这里简单说一下）~~
- ~~类的成员访问控制~~

关于访问控制符还有250页的Other Modifiers
The modifiers没有说，但是最好拆解到类定义，静态类型等里边介绍。和const等一起。

静态类型和类的实例化一起介绍