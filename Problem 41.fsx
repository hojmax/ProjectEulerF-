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

let mutable largest = 0
let endingDigits = [1;3;7]
// Jeg har udelukket 8- og 9-cifrede "pandigital" tal. Det viser sig at n = 7 er den øvre grænse for dette problem.
for g in endingDigits do
  for a in 7 .. -1 .. 1 do
    if a <> g then
      for b in 7 .. -1 .. 1 do
        if b <> g && b <> a then
          for c in 7 .. -1 .. 1 do
            if c <> g && c <> a && c <> b then
              for d in 7 .. -1 .. 1 do
                if d <> g && d <> a && d <> b && d <> c then
                  for e in 7 .. -1 .. 1 do
                    if e <> g && e <> a && e <> b && e <> c && e <> d then
                      for f in 7 .. -1 .. 1 do
                        if f <> g && f <> a && f <> b && f <> c && f <> d && f <> e then
                          let number = Array.sum (Array.mapi (fun i e -> pown 10 (6 - i) * e) [|a;b;c;d;e;f;g|])
                          if isPrime number && number > largest then
                            largest <- number

printfn "%A" largest
