module Utils
  let memoize f =
    let cache = new System.Collections.Generic.Dictionary<_, _>()
    fun x -> 
      match cache.TryGetValue(x) with 
      | true, v -> v
      | false, _ -> 
          let v = f x
          cache.Add(x, v)
          v
  
  let rec generate f s =
    seq {
      yield s
      yield! generate f (f s)
    }
