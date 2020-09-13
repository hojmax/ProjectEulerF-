for b in 1..499 do
  let mutable c = b + 1
  while c + b < 1000 do
    if 2 * b * b + (2 * c - 2000) * b + pown (c - 1000) 2 = c * c then
      printfn "a = %A, b = %A, c = %A" (1000 - b - c) b c
    c <- c + 1
