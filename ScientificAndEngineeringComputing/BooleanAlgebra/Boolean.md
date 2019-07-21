# Boolean Algebra

这一节主要围绕`System.Boolean`这一类型展开。`Boolean`类型是对数学中布尔代数的模拟。

## 数学背景

### 布尔代数

布尔代数是一种数学上的结构。由一个集合和两种基本运算组成。这个集合中我们不妨称之为$B$，它有两个值。这两个值叫做$0$和$1$还是$false$和$true$其实没有什么关系。但是它们能彼此区分很重要。同样的，这两个运算叫什么也不重要，但是它们之间能产生什么样的关系很重要。这里我们叫这两个运算“非”和“或”。

> 一般为了表示方便，除了非和或这两个运算，还会基于它们定义一个叫“与”的运算。当然了，定义更多的运算也是可以的。

运算本质上就是函数。其中$\neg$是一元函数，称为“非”，定义域和值域都在$B$上。它的输入输出关系是这样的：
$$
\neg x = \begin{cases}
false & \text{x=true}\\
true & \text{x=false}
\end{cases}
\tag{1}
$$
$\or$是二元函数，称为“或”，定义于$B\times B$上，值域为$B$。它的输入输出关系是这样的：
$$
x \or y = \begin{cases}
false & \text{x=false and y=false} \\
true & \text{x=true or y= true}
\end{cases}
\tag{2}
$$
更多关于布尔代数的内容可以参见资料[^1]。

## 机制

dotnet中的`System.Boolean`是用于表示真假的类型。它有两个值：`true`和`false`。`Boolean`值之间的运算，就就是布尔代数中的运算。

C#中使用`&&`，`||`，`!`三个算符表示与、或、非这三个联结词。F#中则分别使用`&&`，`||`，`not`。

### 异或

除了与、或、非这三个操作。布尔代数中还有一个比较常用的叫“异或”的操作。异或操作也可以由非或两个联结词组合。不过，C#中也用了专门的算符来表示它。这就是`^`。这个算符实际上有重载。除了处理逻辑异或，它还表示二进制异或运算。

> `x^y`实际上等价于`(!x&&y)||(x&&!y)`。

$$
x \oplus y = (\neg x \and y) \or (x \and \neg y) \tag{4}
$$

### 相等

逻辑值也可以判断是否相等。如果两个逻辑变量的值一样就返回`true`，不一样就返回`false`。C#中用`==`进行判断，而F#中使用`=`进行判断。

作为相等关系的反面，还有不等关系。在两个变量一样的时候返回`false`，在不一样的时候返回`true`。C#中不等关系用`!=`表示，F#中用`<>`表示。

这两种关系判断实际上也是两种逻辑联结词。`A==B`等价于`!(A^B)`。而对于逻辑值来说，`A!=B`和`A^B`具有相同的返回结果。

### 条件逻辑

对于“与”联结词来说，当知道第一个参数是`false`的时候，就没有必要得知第二个参数的真假。最终结果肯定是`false`。类似的情况“或”联结词也有。因此，`&&`和`||`并不会完整计算前后两个表达式。如果第一个表达式的结果能够确定最终结果，第二个表达式就不会被求值。也就是说，第二个表达式是否被执行、求值，取决于第一个表达式的值。因此这种运算被称为“条件逻辑”。这种条件逻辑虽然看起来像是一种简单的运算，实际上能起到类似条件语句的效果。例如：

```C#
bool outputValue = y&&Print()
```

其中`y`是一个逻辑变量，`Print`是一个返回值为`bool`的函数。仅当`y`为`true`才会执行`Print`函数。当然了，出于可读性考虑，个人非常不建议这样使用逻辑算符。

如果你需要不论什么情况，都完全计算前后两个表达式的逻辑运算。可以使用C#的`|`和`&`。这两个算符也是重载了（C语言中）本来用于按位运算的算符。这两个算符分别对应`||`和`&&`。

C#中有保证两个表达式都运算的算符，主要是要使用函数的副作用。而函数式编程中，一般不允许函数副作用。因此，如果一个函数的返回值没有用，这个函数根本就不需要被执行。因此，你根本不会需要这种功能。如果你认为很需要，只能说明你的程序不够函数式。

### 可空逻辑

三值逻辑被引入C#中，主要是因为基于现在的计算机系统，编程时经常要处理空指针或者未初始化变量等问题。把一个逻辑值看作一个对象的话，如果它被赋予空值，那么它自然不是$true$也不是$false$。用三值逻辑运算来解决这类问题，比冗长的空值检查写起来要简单不少。

## 主要参考

dotnet：

- [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=netcore-2.2#definition)

C#：

- [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/bool)
- [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/true-literal)
- [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/false-literal)
- [Boolean logical operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators)
- [true and false operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/true-false-operators)

F#：

- [bool, true, false](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types)
- [Boolean Operators](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/boolean-operators)

Boolean是一个值类型类，仅有`true`和`false`两个值。外加与或非三种常用运算。此类型经常用于各种条件表达式，条件语句或者循环结构中。

需要注意C#和F#中的`||`和`&&`都是short-circuit操作。当算符右边表达式的值就能确定表达式结果的时候，就不会计算算符左边表达式的值。

此外Boolean相关的可空类型，也是一个比较独特的点。这是C和C++没有的特性。当可空Boolean参与逻辑运算的时候遵循三值逻辑的运算法则。简单来说你把为`null`的变量当作未知变量，然后按照二值逻辑的标准做判断。如果一定要知道这个未知变量是`true`还是`false`之后才能确定整个表达式的结果，这个表达式的三值逻辑结果就是`null`。其他情况下三值逻辑的输出和二值逻辑一致。

[^1]: https://en.wikipedia.org/wiki/Boolean_algebra

