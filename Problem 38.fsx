// 10.000 er grænsen fordi: concat (1 * 10.000) (2 * 10.000) = 1000020000, som er 10 cifre. Det medsager gentagelse.
for i in 1..9999 do
  let mutable usedDigits = Set.empty
  let mutable isUnsure = true
  let mutable multiplier = 1
  while isUnsure && usedDigits.Count < 9 do
    let mutable currentValue = multiplier * i
    while isUnsure && currentValue >= 1 do
      if currentValue % 10 <> 0 && not (usedDigits.Contains(currentValue % 10)) then
        usedDigits <- usedDigits.Add(currentValue % 10)
        currentValue <- currentValue / 10
      else
        isUnsure <- false
    multiplier <- multiplier + 1
  if isUnsure && usedDigits.Count = 9 then
    for j in 1..multiplier-1 do
      printf "%A" (i * j)
    printfn ""
