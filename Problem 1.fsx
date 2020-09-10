let mutable result = 0
for i in 0..999 do
  if i % 3 = 0 then
    result <- result + i
  elif i % 5 = 0 then
    result <- result + i

printfn "%A" result
