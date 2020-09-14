let digitAmount n =
  let mutable i = n
  let mutable result = 1
  if i >= 100000000 then
    result <- result + 8
    i <- i / 100000000
  if i >= 10000 then
    result <- result + 4
    i <- i / 10000
  if i >= 100 then
    result <- result + 2
    i <- i / 100
  if i >= 10 then
    result <- result + 1
    i <- i / 10
  result


let validProduct a b =
  if digitAmount a + digitAmount b + digitAmount (a * b) = 9 then
    let mutable stillUnsure = true
    let mutable uniqueDigits = Set.empty
    let mutable parts = [|a; b; a * b|]
    for i in 0..parts.Length - 1 do
      while stillUnsure && parts.[i] >= 1 do
        if parts.[i] % 10 = 0 || uniqueDigits.Contains(parts.[i] % 10) then
          stillUnsure <- false
        else
          uniqueDigits <- uniqueDigits.Add(parts.[i] % 10)
          parts.[i] <- parts.[i] / 10
    stillUnsure
  else
    false

let mutable uniqueProducs = Set.empty
for a in 2..10000 do
  for b in 2..10000 do
    if validProduct a b then
      uniqueProducs <- uniqueProducs.Add(a * b)

printfn "%A" (Array.sum (Set.toArray uniqueProducs))
