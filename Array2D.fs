module Array2D
  let inBounds array (x,y) = 
    x >= Array2D.base1 array && y >= Array2D.base2 array
    && x < Array2D.length1 array && y < Array2D.length2 array

  let item (array: int[,]) (x,y) = array[x,y]

  let neighbors array (x,y) = 
    [(x+1,y);(x,y+1);(x-1,y);(x,y-1)]
    |> Seq.filter (inBounds array)
    |> Seq.map (fun pt -> (pt, item array pt))

  let toSeq (arr: 'T [,]) = arr |> Seq.cast<'T>

  let findIndex predicate array=
    array
    |> Array2D.mapi (fun x y v -> if predicate v then Some (x,y) else None)
    |> toSeq
    |> Seq.pick id