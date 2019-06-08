# Integer

我们都学过数数，所以什么是整数我就不在这里多说了。

> 不是没什么说的，而是详细讨论起来，我们要从集合以及Peano axioms说起。篇幅太长，实在放不下。

和逻辑值类似，编程中的整数类型，主要是借整数的概念来方便编程。而不是要完成对数学上整数概念的模拟。举个简单的例子，8位有符号整数127加1之后是-128。这在编程中不能算是一种错误，而是一种“特性”。因为按照计算机硬件层面的设计，加法器对于输入`127`和`1`就应该输出`-128`。但是数论上，127加1等于-128一般是说不通的。

如果你想在C#中重现这个例子，可以试试这段代码：

```C#
sbyte x = 127;
Console.WriteLine((sbyte)(x+1));
```

之所以要用在加法之后完成强制类型转换，是因为C#会在各种整型数和浮点数之间进行隐式转化。128是超出`sbyte`型表示范围的，因此默认会升级到表示范围更广的类型。这里我们就是要看看再保持类型不变的情况下会产生什么结果，所以要强制类型转换回来。

## 无符号整数

那么为什么8位有符号整数127加1后会变成-128呢？这就要从计算机对于整数的实现说起。

1个二进制位能表示两种状态，如果我们把它们对应到数字上就是0和1。而2个二进制位则可以组合出`00`，`01`，`10`，`11`，四种状态，对应十进制数的0，1，2，3。继续拓展位数就能表示更广的整数范围。但是整数本身是无穷的，以有限的计算机是不可能。在很多年前，计算机界统一以8位作为最短的表示整数单位。这样就有`00000000`到`11111111`一共256种状态，可以表示`0`到`255`的整数。

有了整数的表示方法，接下来我们讨论一下整数之间的加法。十进制数的加法实际上就是不断把两个数对应位相加，按照加法表处理加和和进位问题。在二进制加法中，依旧是查表进位的反复运用。但是由于二进制位的每一位只有两种状态，这个加法表就被简化为了一个简单的逻辑联词真值表。这样就可以通过逻辑运算来完成加法。

当两个加数对应位置都是`1`时，本位置`0`，然后进位`1`。如果仅有一个位为`1`，其他为`0`时，本位置`1`，进位为`0`。当两个位都为`0`时，本位为`0`，进位为`0`。如果考虑到从低位来的进位，就还有一种情况——三个位都为`1`，这时，本位置`1`同时进位为`1`。

按照这样的规则，当从低位加到高位，加到最高位时如果有两个位为`1`，应当进位`1`，并且本位置`0`。本位置`0`是可行的。而进位对于最高位是不可行的。这时，我们规定对于不可行的动作，就不执行（对，我写这句的时候想到了万智牌的规则……）。这样`11111111`加`00000001`就得到了`00000000`。因此对于8位无符号整数来说127加1等于0。

## 有符号整数

为了表示负数。我们可以从8位二进制数中选择一个位作为符号位。这样能表示绝对值位数仅剩7位。而符号位为`0`时表示这是一个正数，为`1`时表示这是一个负数（一般用最高位作为符号位）。这样有符号整数所能表示的数就是`00000001`到`01111111`。也就是1到127。这些正数对应的负数就是`10000001`到`11111111`，也就是-1到-127。

> 为了把减法运算转化为加法，顺便能够套用无符号整数的加法运算方法。计算机中使用补码来记录负数。在补码中-1保存为`11111111`，-127保存为`10000001`。

这样一来还剩两个状态`00000000`和`10000000`，看起来一个表示`+0`，一个表示`-0`。我们的算术中，一般正负零都等于零。用两个状态表示一个数实在是太奢侈了。于是约定用`00000000`表示0，用`10000000`表示别的数。而`10000000`按照规则正好可以是-128的补码。因此实际上8位有符号整数的表示范围是-128到+127。

8位有符号整数中最大的正整数`01111111`加`00000001`（127加1）就得到了`10000000`（-128）。

## 更长的数位

8位计算机肯定是无法满足人们的需求的。因此8位计算机之后，人们搞出了16位计算机。再之后又有了32位。现在比较普及的是64位。对应于每一个计算机的历史时期，就分别出现了16位，32位和64位的（无符号和有符号）整数。

dotnet中保留了这些数据类型。从短到长，有符号整数类有`System.SByte`，`System.Int16`，`System.Int32`，`System.Int64`，无符号整数类有`System.Byte`，`System.UInt16`,`System.UInt32`,`System.UInt64`。

严格来说，这些是不同的数据类型，一个`Int64`（别称为`long`）的1是不能直接和一个`Int32`（别称为`int`）的1相加的。完整的写法应该是这样：

```C#
int x = 1;
long y = 1;
y = y + (long)x;
```

不过为了让程序员的日子太难过，C#中对这些整数类型定义了隐式转换。当一个位数小的数，和一个位数大的数相加的时候会自动把结果类型变为和位数大的数一致的类型。但是从长数转化短数这种可能造成信息损失的操作仍然是必须通过显示转换来完成。

## 字面值

字面值就是源码中直接表示某个整数值的字符组合。

### 不同进制

十进制字面值的写法和一般的的写法一致——使用`0`到`9`的字符组合。十六进制写法则以`0X`或者`0x`开头由数字和字母`abcdef`（或者字母`ABCDEF`）组成。二进制写法以`0B`或者`0b`开头，由`0`和`1`组成。

### 分隔数位

为了方便数位数，我们还可以用`_`将数位隔开，例如`1_000_000`表示一百万。

### 后缀

一个整数字面值默认认为是`int`类型的。当超出`int`的表示范围时，dotnet会尝试把它解释为`uint`，`long`或`ulong`。

我们可以用后缀显式控制字面值类型。用`u`或`U`表示`uint`，用`l`或`L`表示`long`，用`ul`或者`UL`表示`ulong`。例如：

```C#
int x = 3;
uint y = 3U;
long z = 3L;
ulong w = 3LU;
```

> 整数字面值的各种字母的小写可能和数字混淆（例如`l`和`1`），因此推荐使用大写字母。
>
> 此外大写字母和数字高度一样，看起来更整齐（我是强迫症）。

## 运算

整数的运算，主要分为以下几类。

### 算术运算

算术运算主要包含加减乘除，取反，取余数，指数运算，关系运算等。其中前几种运算返回整数，关系运算返回逻辑值。

- `-` 取反运算，一元运算，返回输入值的相反数。
- `+` 加法运算，二元运算。
- `-` 减法运算，二元运算。和取反运算是同一个符号，但是操作数数量不同。
- `*` 乘法运算，二元运算。
- `/` 整除运算，二元运算，返回整除商。
- `%` 取余数运算，二元运算，返回整除余数。

- `==` 相等运算，二元运算。判断两个数是否相同。不同整数类型在比较时会自动转化为相同类型。
- `!=` （F#中是`<>`） 不等运算，二元运算。判断两个数是否不同。
- `>` 大于运算，二元运算。判断左侧操作数是否大于右侧操作数。
- `>=` 大于等于运算，二元运算。判断左侧操作数是否大于等于右侧操作数。
- `<` 小于运算，二元运算。判断左侧操作数是否小于右侧操作数。
- `<=` 小于等于运算，二元运算。判断左侧操作数是否小于等于右侧操作数。

> F#中虽然有`**`用于指数运算。但是不适用于整数。

### 溢出

虽然按照计算机的硬件设计，8位有符号数127加1得到-127这类情况不算错误。但是这毕竟和数学常识不太一样。很难确定一个程序员写的程序出现这种情况的时候是有意为之还是不经意的错误。就比如*Sid Meier's Civilization*中甘地好战性溢出究竟是个Bug，还是当年有人故意黑他。

因此C#提供checked和unchecked两个算符，用于设置检查是否溢出。例如：

```C#
y = checked(x+1); // through exception
y = unchecked(x+1); // don't through exception
```

在这两个算符都没有使用，那么是否抛出溢出异常根据编译时的选项确定。

### 除零

数学上没有定义0作为除数。C#和F#中的整型数也没有定义。因此使用0作为除数会引发异常。

### 赋值组合运算

C#中如果要让一个变量加（或者减去，乘以，取商，取余数）一个数之后仍赋予这个变量。就可以进行简写。例如：

```C#
int x=2;
x = x+2; // original
x += 2; // rewrite
```

如果是加1，减1这种操作。还有更精简的写法。主要是两种写法，`x += 1`简写为`x++`，`x -= 1`简写为`x--`。

> `++`和`--`还有优先级和结合性等问题。有兴趣可以了解一下。但是出于可读性考虑，千万不要故意用这种东西搞一些奇怪的写法。就一个自增当成一个语句单独使用就好了，不要和别的算符组合使用。

### 位运算

dotnet中的整型数本质上是有限位的二进制数。可以把它们当作一组逻辑值，然后进行所谓的按位运算。

- `~` （F#中是`~~~`） 按位非，一元运算。把一个二进制整数每一位都取反。
- `|` （F#中是`|||`） 按位或，二元运算。对两个二进制数逐位取或。
- `&` （F#中是`&&&`） 按位与，二元运算。对两个二进制数逐位取与。
- `^` （F#中是`^^^`） 按位异或，二元运算。对两个二进制数逐位取异或。
- `<<` （F#中是`<<<`） 左移运算。左侧参数为被操作整数，右侧为移动位数。把每个位都向左移，超出部分删除，不足部分补零。
- `>>` （F#中是`>>>`） 右移运算。左侧参数为被操作整数，右侧为移动位数。把每个位都向左移，超出部分删除，不足部分补足。对于无符号整数，用0补足。对于有符号整数，用符号位补足。

> C#中按位运算也能和赋值组成复合运算。

> 整数的相关操作也是基本类型中比较复杂的。一方面整数作为“数”有加减乘除，大小比较等算术操作。另一方面，从存储原理上讲所有数据类型归根结底都是以整数形式存储的，整数可以作为操作内存数据转换的一个媒介，因此整数还额外有按位操作和位移操作。

## 主要参考

dotnet:

- [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=netcore-2.2)
- [System.UInt16](https://docs.microsoft.com/en-us/dotnet/api/system.uint16?view=netcore-2.2)
- [System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/system.uint32?view=netcore-2.2)
- [System.UInt64](https://docs.microsoft.com/en-us/dotnet/api/system.uint64?view=netcore-2.2)
- [System.SByte](https://docs.microsoft.com/en-us/dotnet/api/system.sbyte?view=netcore-2.2)

- [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16?view=netcore-2.2)
- [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=netcore-2.2)
- [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=netcore-2.2)

C#:

- [byte](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/byte)
- [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort)
- [uint](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/uint)
- [ulong](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ulong)
- [sbyte](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sbyte)
- [short](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/short)
- [int](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int)
- [long](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/long)
- [Arithmetic operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators)
- [Bitwise and shift operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators)
- [Equality operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators)
- [Comparison operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators)
- [Checked and Unchecked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked-and-unchecked)

F#:

- [Integer Literals](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/true-false-operators)
- [Int Types](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types)
- [Arithmetic operators](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/arithmetic-operators)
- [Bitwise and shift operators](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/bitwise-operators)


