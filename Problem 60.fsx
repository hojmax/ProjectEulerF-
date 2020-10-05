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

let modifiedPrimeSieve n =
  let sieve = [|for i in 1..n / 2 -> 1|]
  let limit = int (sqrt (float n))
  for i in 1..(limit - 1) / 2 do
    if sieve.[i] = 1 then
      let value = 2 * i + 1
      for j in ((pown value 2) - 1) / 2 .. value .. sieve.Length - 1 do
        sieve.[j] <- 0
  let mutable result = []
  for i in sieve.Length - 1.. -1 .. 1 do
    if sieve.[i] = 1 && i <> 2 then
      result <- (2 * i + 1) :: result
  result

let isPrime n =
  if n = 2 || n = 3 then
    true
  else
    if n < 2 || n % 2 = 0 || n % 3 = 0 then
      false
    else
      let mutable prime = true
      let limit = (int (sqrt (float n)) + 1) / 6
      let mutable i = 1
      while i <= limit && prime do
        if n % (6 * i + 1) = 0 || n % (6 * i - 1) = 0 then
          prime <- false
        i <- i + 1
      prime

let concatenate n m = n * pown 10 (digitAmount m) + m

let removeElement (list: int list) element = List.filter (fun e -> e <> element) list

let inCommonCount (list1: int list) (list2: int list) =
  let mutable count = 0
  for e in list2 do
    if List.exists (fun x -> x = e) list1 then
      count <- count + 1
  count

let primes = modifiedPrimeSieve 10000
// Kunne ikke helt finde måden at lave type deklaration på maps, hvilket grunder (-1,[-1]) elementet.
let mutable connected = Map.empty.Add(-1,[-1]).Remove(-1)
for i in 0..primes.Length - 1 do
  for j in i + 1..primes.Length - 1 do
    if isPrime (concatenate primes.[i] primes.[j]) &&
       isPrime (concatenate primes.[j] primes.[i]) then
      if connected.ContainsKey(i) then
        connected <- connected.Add(i, j :: connected.[i])
      else
        connected <- connected.Add(i, [j])
      if connected.ContainsKey(j) then
        connected <- connected.Add(j, i :: connected.[j])
      else
        connected <- connected.Add(j, [i])

let setSize = 5

for i in 0..37 do
  for e in connected do
    for n in e.Value do
      if inCommonCount e.Value connected.[n] < setSize - 2 then
        connected <- connected.Add(e.Key,removeElement e.Value n).Add(n, removeElement connected.[n] e.Key)

for e in connected do
  if e.Value.Length <> 0 then
    printfn "%A %A" primes.[e.Key] (List.map (fun e -> primes.[e]) e.Value)
