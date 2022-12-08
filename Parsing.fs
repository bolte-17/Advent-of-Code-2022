module Parsing
  open System
  open System.IO
  open System.Collections.Generic
  
  let private splitOn (predicate: 'a -> bool) (s: 'a seq) =
    let tryMoveNext (enumerator: IEnumerator<_>) = try enumerator.MoveNext() with _ -> false
    use en = s.GetEnumerator()
    seq {
      while tryMoveNext en do
        yield seq {
          let mutable loop = true
          while loop && not (predicate en.Current) do
            yield en.Current
            loop <- tryMoveNext en
        } |> Seq.toList
    }

  let readLineGroups lineParser file =
    File.ReadAllLines file
    |> splitOn String.IsNullOrEmpty
    |> Seq.map (List.map lineParser)
    |> Seq.toList
