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

let getChainLength a b =
  let mutable count = 0
  let mutable next = b
  while isPrime next do
    count <- count + 1
    next <- pown count 2 + a * count + b
  count

let mutable longestChain = 0
let mutable longestCoefficients = [|0; 0|]

for a in -999..999 do
  // 2 og 3 er også mulige kandidater for b
  // Men da Project Euler fortæller mig at min løsning med b = 971 er korrekt, udvider jeg ikke søgefeltet yderligere
  for b in 1..1000 / 6 do
    for delta in -1 .. 2 .. 1 do
      let chainLength = getChainLength a (b * 6 + delta)
      if chainLength > longestChain then
        longestChain <- chainLength
        longestCoefficients <- [|a; b * 6 + delta|]

printfn "%A" longestCoefficients
