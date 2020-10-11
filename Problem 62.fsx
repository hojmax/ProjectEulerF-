let getDigits number =
  let digits = [|0;0;0;0;0;0;0;0;0;0|]
  let mutable n = number
  while n >= 1I do
    digits.[int (n % 10I)] <- digits.[int (n % 10I)] + 1
    n <- n / 10I
  digits

let mutable firstAddition = Map.empty
let mutable cubesCount = Map.empty
let mutable shouldContinue = true
let mutable n = 1I

while shouldContinue do
  let cube = n * n * n
  let next = getDigits cube
  if cubesCount.ContainsKey next then
    let count = cubesCount.[next] + 1
    if count >= 5 then
      printfn "%A" firstAddition.[next]
      shouldContinue <- false
    else
      cubesCount <- cubesCount.Add(next, count)
  else
    firstAddition <- firstAddition.Add(next, cube)
    cubesCount <- cubesCount.Add(next, 1)
  n <- n + 1I
