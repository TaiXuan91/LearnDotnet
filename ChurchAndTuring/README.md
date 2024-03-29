# 丘奇和图灵

在各种各样的网络科普故事中，人们总是树立起一个富有魅力的天才形象然后忘掉与之同时代的同样做出过杰出贡献的其他科学家们。人们记住了牛顿，但是忘掉了莱布尼茨和胡克。人们记住了爱因斯坦，但是忘掉了薛定谔和普朗克。人们记住了一生经历富有戏剧色彩的伽罗瓦，同样青年才俊的阿贝尔就显得暗淡了许多。在计算机领域，几乎人人都知道图灵但是与之同时期的丘奇名气就小很多。图灵提出的图灵机为很多人所津津乐道。包括我在内的很多人为了装逼，即使不懂图灵机也要装懂。但是丘奇提出的与图灵机等价的λ演算，就很少有人装懂。因为你装了，别人也看不懂。

## 命令式和函数式

图灵机关注状态和状态的改变。λ演算则关注输入输出以及输入输出之间的映射。实际上它们是同一个东西的两种表述，但是具体到工程实现中，两者还是有很大差别的。

图灵机的思路更加直观，也更容易在工程上实现。现在的计算机硬件实现基本上都是按照图灵机的路数来的。关注状态，就导致需要保存状态，于是现在的计算机都有变量机制。要使状态改变，就要操作变量，这就需要赋值命令。在变量和赋值的基础上，就发展出了一种编程范式，叫做“命令式编程”。这个范式，为现在绝大多数编程语言所共有。以至于很多人以为编程必然需要变量和赋值。

实际上，我们可以跳出思维的局限。舍弃变量和赋值。仅仅采用常量和符号绑定。通过函数的嵌套和递归来完成程序。这就是λ演算的思路。这种思路上发展出来的编程范式叫做“函数式编程”。命令式编程关注状态，这使得它和时序绑定得很死。这是优势，也是劣势。如果你要做一个底层的硬件控制程序，能直接定义动作序列，当然是一个优势。但是如果你要处理并发问题，就容易掉进深渊。而函数式编程和命令式编程恰恰相反，从编程语言的层面，你想控制动作顺序是非常费劲的。但是你可以下放执行顺序的决定权，让程序自动决定执行顺序。在这个基础上，很多难以处理的并发问题，可以交给程序自己解决。更多关于函数式编程的细节，我不打算在这里介绍。以后会有很多机会详细聊。

## 面向对象？

面向对象也是一种编程范式。但是这种编程范式的关注点和命令式，函数式不同。面向对象是一种数据组织方式上的范式，它实际上可以和命令式编程组合，也可以和函数式编程组合。用比较数学化的说法是面向对象“正交”于命令式编程和函数式编程。

## C#和F#

.NET平台支持多种编程语言。我主要关注其中的C#和F#两种。虽然C#和F#实际上都是多范式编程语言，但是一般认为C#更倾向于命令式编程，F#更倾向于函数式编程。（看过C# 8.0新增功能后，我觉得C#吸收了不少Haskell的语法，反而可以写出比F#更函数式的程序。）同时这两种语言都支持面向对象。

在后续的章节中，我将首先从C#的命令式编程说起，聊到通过面向对象方式组织C#程序。再补充上用C#写函数式程序，简化代码的方法。然后聊一聊函数式的F#，以及F#中的命令式编程。

当然了，出于介绍内容完整的考虑，我会在这个大框架里穿插其他相对较小的语言特性的介绍。比如异常处理，反射机制等。

在完成对语法的基本介绍之后，我们会讨论.NET的类库。.NET的类库是基于面向对象设计的，因此受语言的范式的影响不大。

