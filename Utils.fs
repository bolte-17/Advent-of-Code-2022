module Utils
  open System.Collections.Generic
  let memoize f =
    let cache = new Dictionary<_, _>()
    fun x -> 
      match cache.TryGetValue(x) with 
      | true, v -> v
      | false, _ -> 
          let v = f x
          cache.Add(x, v)
          v
  
  let memoY f =
    let cache = Dictionary<_,_>()
    let rec fn x =
      match cache.TryGetValue(x) with
      | true,y -> y
      | _ -> 
        let v = f fn x
        cache.Add(x,v)
        v
    fn
  
  let rec generate f s =
    seq {
      yield s
      yield! generate f (f s)
    }
