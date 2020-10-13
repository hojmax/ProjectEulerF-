let printClockwise (parts: int array array) =
  let mutable lowest = 11
  let mutable lowestIndex = 0
  for i in 0 .. parts.Length - 1 do
    if parts.[i].[0] < lowest then
      lowest <- parts.[i].[0]
      lowestIndex <- i
  let mutable toConsole = ""
  for i in 0..4 do
    for e in parts.[(lowestIndex + i) % 5] do
      toConsole <- toConsole + string e
  printfn "%s" toConsole

let isValid numbers =
  if (Array.exists (fun e -> e <= 0 || e >= 11) numbers) then
    false
  else
    let mutable isCandidate = true
    let digits = [|0;0;0;0;0;0;0;0;0;0|]
    let mutable index = 0
    while isCandidate && index < numbers.Length do
      digits.[numbers.[index] - 1] <- digits.[numbers.[index] - 1] + 1
      isCandidate <- digits.[numbers.[index] - 1] <= 1
      index <- index + 1
    isCandidate

let a = 10

for n in 14 .. 2 .. 16 do
  for d in 1..9 do
    for f in 1..9 do
      if f <> d then
        for h in 1..9 do
          if h <> d && h <> f then
            for j in 1..9 do
              if j <> d && j <> f && j <> h then
                for b in 1..9 do
                  if b <> d && b <> f && b <> h && b <> j && 
                     a + 2 * b - d + f - h + j = n then
                    let i = n - j - b
                    let g = n - h - i
                    let e = n - f - g
                    let c = n - d - e
                    let numbers = [|a;b;c;d;e;f;g;h;i;j|]
                    if isValid numbers then
                      printClockwise [|[|a;b;c|];[|d;c;e|];[|f;e;g|];[|h;g;i|];[|j;i;b|]|]
