let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
  result

let digitBoundaries = [|for i in 0I..5I -> iPown 10I (iPown 2I i)|]
let correspondingDigits = [|for i in 0..5 -> pown 2 i|]

let bigIntDigitCount number =
  let mutable digits = 1
  let mutable n = number
  for i in digitBoundaries.Length - 1 .. -1 .. 0 do
    if n >= digitBoundaries.[i] then
      n <- n / digitBoundaries.[i]
      digits <- digits + correspondingDigits.[i]
  System.Numerics.BigInteger digits

let mutable count = 0

// Ved at plotte "plot([floor(log10(10^x)) + 1, x], discont = true)" i maple, kan man se at 9 er det maximale tal der kan være opløftet til n med n decimaler
for n in 1I..21I do
  let mutable i = 1I
  let mutable innerContinue = true
  while innerContinue do
    let magnitude = bigIntDigitCount (iPown i n)
    if magnitude = n then
      printfn "%A ** %A = %A" i n (iPown i n)
      count <- count + 1
    else if magnitude > n then
      innerContinue <- false
    i <- i + 1I

printfn "%A" count
