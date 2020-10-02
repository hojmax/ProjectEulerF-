let isPentagonal number = (1.0 + sqrt (1.0 + 24.0 * float number)) / 6.0 % 1.0 = 0.0

let pentagonal n = n * (3.0 * n - 1.0) / 2.0

let limit = 1020.0
let mutable minimumDelta = 1e7
for a in 1.0 .. limit do
  for b in 1.0 .. a - 1.0 do
    let index = (3.0 * a * a - 3.0 * b * b - a + b) / (6.0 * b)
    if index % 1.0 = 0.0 then
      let delta = pentagonal index - pentagonal a
      if isPentagonal delta && delta < minimumDelta then
        minimumDelta <- delta
        
printfn "%A" minimumDelta
