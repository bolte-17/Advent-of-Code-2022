namespace Extensions
  open System
  module String =
    let split (sep:string) (s: string) = 
      s.Split(sep, StringSplitOptions.None) |> Array.toList

  module List =
    let toPair<'a> = List.pairwise<'a> >> List.exactlyOne
    let ofPair (x:'a,y:'a) = [x;y]
  