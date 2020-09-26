let getDigits number =
  [|number % 10; number / 10|]

for a in 11..99 do
  let aDigits = getDigits a
  if aDigits.[0] <> aDigits.[1] && aDigits.[0] <> 0 then
    for b in a + 1..99 do
      let bDigits = getDigits b
      if bDigits.[0] <> bDigits.[1] && bDigits.[0] <> 0 then
        for i in 0..1 do
          for j in 0..1 do
            if aDigits.[i] = bDigits.[j]
            && float aDigits.[1 - i] / float bDigits.[1 - j] = float a / float b then
              printfn "%A / %A" a b
