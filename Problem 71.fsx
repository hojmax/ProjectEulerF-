let target = 3.0/7.0
let mutable distance = 1.0
let mutable answer = (0.0,0.0)
for d in 1.0..1e6 do
  let numerator = floor (target * d)
  let denominator = d
  let currentDistance = target - numerator / denominator
  if currentDistance <> 0.0 && currentDistance < distance then
    answer <- (numerator, denominator)
    distance <- currentDistance

printfn "%A" answer
