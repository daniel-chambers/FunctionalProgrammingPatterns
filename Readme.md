# Functional Programming Patterns for Mere Mortals

This repository contains the presentation materials and sample code for the Functional Programming Patterns presentation. Here's the abstract:

> Have you ever peeked over the fence into functional programming land and gazed into a seemingly alien landscape of weird symbols and crazily named concepts? Has your curiosity about functional programming been stymied by complicated words and abstractions? If so, this talk is for you.

> We’re going to take a practical, example-based journey through complex-sounding but deceptively simple functional patterns such as functors, applicatives and the big bad monad. We’ll see how these patterns work, what they’re for and how they are used to make clean, composable code. We’ll also identify the places where functional patterns are quietly being used in our mainstream day to day languages. By the end of the talk, you will be better equipped to take further steps down the functional programming path of enlightenment.

There are two versions of the slides, one done for NDC Sydney 2017, which was a one hour talk, and a cut down 45 minute version for DDD Melbourne 2017.

Video: [NDC Sydney 2017](https://www.youtube.com/watch?v=v9QGWbGppis)

## args-example
To get the `args-example` sample code up and running, you will need:
* [Haskell Stack][1] - to compile the code
* [Atom][2] (optional) - to browse the Haskell code
* [IDE-Haskell][3] (optional) - Atom plugin to support Haskell (make sure to read the Requirements section of their readme). To install GHC-Mod with Stack, use `stack build ghc-mod` inside the `args-example` directory.

To build the example, run `stack install`. `args-example-exe` will then be on your path to execute.

## fparsec-example
To get the `fparsec-example` sample code up and running, you will need:
* Visual Studio 2015 (with Visual F# Tools)

You can then build and run the project as normal.

## Recommended Reading
Scott Wlashin's [FSharp for Fun and Profit][5] website contains many useful articles. Two specifically to look at are:
* [Map and Bind and Apply, Oh my!][6]
* [Railway Oriented Programming][7]

The [Haskell Programming from First Principles][4] book is highly recommended as a comprehensive introduction to functional programming in Haskell, and has very complete chapters that walk you through functors, applicatives and monads.

[1]: https://www.haskellstack.org/
[2]: https://atom.io/
[3]: https://github.com/atom-haskell/ide-haskell
[4]: https://haskellbook.com
[5]: https://fsharpforfunandprofit.com/
[6]: https://fsharpforfunandprofit.com/series/map-and-bind-and-apply-oh-my.html
[7]: https://fsharpforfunandprofit.com/rop/
