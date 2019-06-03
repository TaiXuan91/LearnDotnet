# Predefined Types

我认为基础的预定义类型可以分为如下几类来介绍：

- 作为一切类型的父类型的`System.Object`
- 本质上是整数的各种整型，布尔型和字符型
- 字符串类型`System.String`
- 各种浮点数类型

## System.Object

追根究底`System.Object`是所有类的父类。dotnet中所有的类都继承自它。它最大的特性就是没有什么特性。也正因为它没有什么特性，它才能作为所有其他类的父类。

所有`System.Object`的方法和属性，都是dotnet中所有类共有的。例如`System.Object`有`GetType`方法，dotnet中所有的对象（包括字符串，逻辑值，整数，浮点数，结构体等）也都有这个方法。调用这个方法可以返回这个对象所属的类（返回最小的那个类，而不是返回各种父类）。例如：

```C#
int i = 5;
string str = "hello world";
Console.WriteLine(i.GetType());
Console.WriteLine(str.GetType());
Console.WriteLine(str.GetType().GetType()); // will show "System.RuntimType"
```

需要说明的是`GetType`方法的返回值是`System.Type`，这也是一个类，因此也继承自`System.Object`，因而也有`GetType`方法。

> 另有一个常用的`System.Object`的方法就是`ToString`，用于把对象转化为字符串。所有的对象都能生成一个对应的字符串，因而我们可以把任何对象对应的字符串从字符终端输出。这在调试的时候很好用。

## 整数类型

我这里所说的整数类型，其实是dotnet中的好几个类。

### 整数的长度

数学上的整数是可以无限增长下去的。但是计算机是不可能处理无限长的数据的。因此计算机实际上只能处理一部分整数。我们投入越多的二进制位，所能表示的整数范围就越大。例如1位二进制位只能表示0和1。但是2位二进制位就能表示0到3，4位二进制位表示0到15，8位二进制位能表示0到255。dotnet中内置了若干个非负整数类，其区别就是所占用的二进制位数量不同。现列表展示：

| 类        | 别称 | 二进制位数 | 最小值 | 最大值 |
| ----------- | --- | ---------- | ------ | ------ |
| System.Byte | byte | 8          | 0      | 255    |
| System.UInt16 | ushort | 16 | 0 | 65,535 |
| System.UInt32 | uint | 32 | 0 | 4,294,967,295 |
| System.UInt64 | long | 64 | 0 | 18,446,744,073,709,551,615 |

>  每个非负整数类都有`MaxValue`和`MinValue`这两个字段。用于表示这个类别所能表示的最大和最小整数。实际上有符号整数，浮点数等类中也有类似的字段。

### 无符号和有符号

之前我们介绍的`byte`，`uint`等属于无符号整数。也就是说只能表示大于等于0的整数。如果我们将一个二进制位用于表示正负号，那么就可以同时表示正数和负数。这种编码方式表示整数，就叫有符号整数。以下是有符号整数类型的简表：

| 类           | 别称  | 二进制位数 | 最小值                     | 最大值                    |
| ------------ | ----- | ---------- | -------------------------- | ------------------------- |
| System.SByte | sbyte | 8          | -128                       | 127                       |
| System.Int16 | short | 16         | -32,768                    | 32767                     |
| System.Int32 | int   | 32         | -2,147,483,648             | 2,147,483,647             |
| System.Int64 | long  | 64         | -9,223,372,036,854,775,808 | 9,223,372,036,854,775,807 |

>  由于使用一个位作为符号位，有符号整数相比于相同位数的无符号整数，所能表示整数的绝对值范围就少了一半。

### 整数的字面值

所有对象都是由构造函数构造的。而对于整数来说最基本的构造函数就是其字面值。十进制整数的字面值是用0到9的数字组成的。为了方便书写和阅读，我们可以用`_`对数字做分段。例如直接写`1234123417`我们就容易搞不清楚它到底几位。但是写成`1_234_123_417`就方便多了。

如果要写二进制数字，需要以`0B`开头，然后只能用`0`和`1`书写。十六进制数则以`0X`开头，由数字和`ABCDEF`组成。例如：`0B10110`，`0x4AB1F`。（整数字面值中的字母用小写字母也可以。）

以上介绍的都是无符号整数的写法。如果要表示有符号整数，只需要在绝对值的前面加上正负号表示正负数就可以。另外默认无符号整数相当于有符号整数中的非负数，所以一般省略正号。

### 整数的运算



### 布尔值

布尔值本质上也是用整数表示的。在比较古老的C语言中根本没有布尔值这个类型，而是使用整数`0`表示`false`，用非零整数表示`true`。

### 字符值

## 字符串

## 浮点数



System.RuntimeType也是一个类