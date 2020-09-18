let isPermutedMultiple number =
  let mutable originalDigits = [|for i in 0..9 -> 0|]
  let mutable n = number
  while n >= 1 do
    originalDigits.[n % 10] <- originalDigits.[n % 10] + 1
    n <- n / 10
  let mutable i = 2
  let mutable isUnsure = true
  while isUnsure && i <= 6 do
    let mutable digitCheck = Array.copy originalDigits
    let mutable m = i * number
    while isUnsure && m >= 1 do
      digitCheck.[m % 10] <- digitCheck.[m % 10] - 1
      isUnsure <- digitCheck.[m % 10] >= 0
      m <- m / 10
    i <- i + 1
  isUnsure

let digitLimit = 6
let mutable currentDigits = 2
while currentDigits <= digitLimit do
  let magnitude = pown 10 (currentDigits - 1)
  for delta in 0..4 * magnitude / 6 do
    let candidate = magnitude + delta
    if isPermutedMultiple candidate then
      printfn "%A" candidate
  currentDigits <- currentDigits + 1
