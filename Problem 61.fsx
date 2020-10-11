let digitAmount n =
  let mutable i = n
  let mutable result = 1
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

let polygonal = [|
  (fun n -> n * (n + 1) / 2)
  (fun n -> n * n)
  (fun n -> n * (3 * n - 1) / 2)
  (fun n -> n * (2 * n - 1))
  (fun n -> n * (5 * n - 3) / 2)
  (fun n -> n * (3 * n - 2))
|]

let candidates: (int list) array = [|for i in 1 .. 6 -> []|]

for i in 0 .. polygonal.Length - 1 do
  let mutable shouldContinue = true
  let mutable j = 1
  while shouldContinue do
    let figurate = polygonal.[i] j
    let digits = digitAmount figurate
    if digits = 4 then
      candidates.[i] <- figurate :: candidates.[i]
    else
      shouldContinue <- digits < 4
    j <- j + 1

let getEnd number = number - (number / 100) * 100

let getStart number = number / 100

let getPossibleLinks (input: int list * int Set) =
  let mutable output = []
  let numberEnd = getEnd (fst input).[0]
  for i in 0..candidates.Length - 1 do
    if not ((snd input).Contains i) then
      for e in candidates.[i] do
        if numberEnd = getStart e then
          output <- (e :: fst input, (snd input).Add i) :: output
  output

let mutable current = [for e in candidates.[5] -> ([e], Set.empty.Add 5)]
let mutable next= []

for i in 0..4 do
  for e in current do
    next <- List.append (getPossibleLinks e) next
  current <- next
  next <- []

for e in current do
  if getEnd (fst e).[0] = getStart (fst e).[(fst e).Length - 1] then
    printfn "%A" (fst e)
