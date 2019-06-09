# Boolean

很多人学过数学，但是对于逻辑缺乏基本的常识。因此我们需要先简单介绍逻辑。

## 数学背景

逻辑试图以简单且严谨的方式，解决言语上的纷争。大致上来说，我认为它基于两个基本假设：

- 非黑即白。一句话要么是真的，要么是假的。不存在第三种情况。
- 普遍相关。语句之间是有联系的。如果已知一些语句的真假，就可以推断出与之关联的其他语句的真假。而且在数学中，我们可以基于非常少的语句（几句或者几十句），推断出数学中绝大多数语句的真假。

在基本假设之下，语句的真假被分为两个层面研究。如果一个语句是由完整的其他语句通过联词联接组成的，那么这个语句的真假是各个组成部件确定的。研究这种关系的叫做命题逻辑。如果把语句进一步拆解为动词和名词等，然后把这些动词名词重新组合，就能得到另外的语句。研究重组前后语句真假值的联系的，就叫谓词逻辑。

> 一般来说，为了方便，人们认为“谓词逻辑”包含“命题逻辑”。也就是说，一般所说的“谓词逻辑”既研究名词和动词的重组，也研究句子通过联词的联接。

在确定了一些公理（公理就是假定为真的语句）之后，通过谓词逻辑，就能确定非常多语句的真假。一旦两个人承认相同的公理，并且都承认谓词逻辑。那么当两个人有分歧的时候，不必争吵，更不必打架，坐下来算一算就明了了。

当计算机出现以后，这套方法又有了新的用武之地。将一些实际中的问题抽象成逻辑问题，然后用计算机来计算，就能省下更多事情。为了把这一套方法搬到计算机中，就有了Boolean类型等机制。

## 机制

dotnet中的`System.Boolean`是用于表示真假的类型。它有两个值：`true`和`false`。`Boolean`值之间的运算，就能表示命题逻辑。

命题之间的联词有很多种，但是各种联词之间可以相互替代。最基本的联词是两个——“非”和“或”。其他联词可以通过这两个联词构造出来。一般为了使用方便，我们会把“非（（非A）或（非B））”简写为“A与B”。这样就得到了三个最常用的联结词——与或非。

F#中分别使用`&&`，`||`，`not`三个算符表示这三个联结词。C#中则使用`&&`，`||`，`!`。

### 异或

异或操作也可以由非或两个联结词组合。但是由于历史原因，C#中也用了专门的算符来表示它。这就是`^`。这个算符实际上有重载。除了处理逻辑异或，它还表示二进制异或运算。

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

### 作为算符的true和false

C#中有作为算符的`true`和`false`。但是我们并不像使用其他算符一样用它们。这两个算符存在的意义就是重载。如果我们给一个类定义了`true`和`false`的算符重载，那么这个类的对象就能像逻辑值一样用于作为跳转条件，条件表达式的条件等。

这两个算符如果要定义必须成对定义。它们接受一个类对象作为输入。当操作`true`的返回为`true`，这个对象在作为条件时就被转化为逻辑值`true`。当操作`false`的返回值为`true`时，这个对象在作为条件时就会被转化为逻辑值`false`。

来看一个例子：

```C#
class Test
{
    public int x;
    public static bool operator true(Test t)
    {
        return t.x > 5;
    }
    public static bool operator false(Test t)
    {
        return t.x <= 5;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var t = new Test();
        t.x = 20;
        if (t) // Use Text object as condition, not a logic value.
            Console.WriteLine("bigger than 5");
        else
            Console.WriteLine("equal to 5 or less than 5");
    }
}
```

> `true`和`false`两个算符是分别定义的。因此，有可能出现这两个算符都返回`true`或者都返回`false`的情况。都返回`true`时，认为这个对象为`true`，都返回`false`时认为这个对象为`false`。

### 谓词逻辑

`Boolean`类型看起来主要对应逻辑中的命题逻辑。只涉及组合语句层面的真假，而不能表示语句中的动词，量词，名词等更细致的结构。这是因为编程中，以函数调用作为不可进一步拆分为其他完整语句的原子语句。`Boolean`类型只需要处理命题逻辑层面的问题。而语句内部，谓词逻辑层面的事情，是函数定义内部决定的。

>  一个函数作用于某组参数的时候，返回值是`true`还是`false`是函数定义确定的。

顺便提一句，编程中的逻辑运算，旨在用逻辑方法让编程更方便。而不是通过程序完整模拟谓词推演。当然了用计算机模拟形式逻辑推演也是非常有意义的事情。只不过如果你想这么做，需要自己写程序或者调用别人写的逻辑推理程序。

> 有一些符号运算库，例如Python的sympy，中涉及了一些模拟逻辑推理的功能。但是似乎都不是很完善。因此有空的话，我计划用Haskell或者F#自己写一写试试。

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


