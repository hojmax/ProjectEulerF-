let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
  result

let digitBoundaries = [|for i in 0I..8I -> iPown 10I (iPown 2I i)|]
let correspondingDigits = [|for i in 0..8 -> pown 2 i|]

let bigIntDigitCount number =
  let mutable digits = 1
  let mutable n = number
  for i in digitBoundaries.Length - 1 .. -1 .. 0 do
    if n >= digitBoundaries.[i] then
      n <- n / digitBoundaries.[i]
      digits <- digits + correspondingDigits.[i]
  digits

let mutable a = 1I
let mutable b = 2I
let mutable fractionCount = 0

for i in 1..999 do
  let temp = a + 2I * b
  a <- b
  b <- temp
  if bigIntDigitCount (a + b) > bigIntDigitCount b then
    fractionCount <- fractionCount + 1

printfn "%A" fractionCount
