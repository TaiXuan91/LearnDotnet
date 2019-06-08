# Float and Arithmetic

计算机使用二进制数

dotnet:

- [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single?view=netcore-2.2)
- [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double?view=netcore-2.2)
- [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?view=netcore-2.2)
- [System.MathF](https://docs.microsoft.com/en-us/dotnet/api/system.mathf?view=netcore-2.2)
- [System.Math](https://docs.microsoft.com/en-us/dotnet/api/system.math?view=netcore-2.2)

C#:

- [float](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/float)
- [double](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/double)
- [decimal](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/decimal)
- [Arithmetic operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators)
- [Equality operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators)
- [Comparision operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators)

F#:

- [Float Types](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types)
- [Float Literals](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/literals)
- [Arithmetic operators](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/arithmetic-operators)

浮点数是通过有效数字，位移和符号位表示有理数的一种方案。为了配合完成基本的数学运算，这里推荐阅读Float相关的类之后了解一下`System.Math`。

浮点数方案和整数的编码方案类似，这种方案并不能保证表示所有有理数（哪怕是$(0,1)$区间上的所有有理数也不能完全表示）。

浮点数的主要用途就是工程和科学计算，用于解数值解。在很多情况下，数值解并不等于解析解。另外浮点数在运算的时候会产生舍入误差。所以浮点数计算的结果很可能不精确等于理论上的预期结果。因此尽量不对浮点数使用精确的等于操作，而应该比较大致的范围。

