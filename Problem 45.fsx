let mutable n = 144.0
let mutable hasFound = false
while not hasFound do
  if (sqrt (48.0 * n ** 2.0 - 24.0 * n + 1.0) + 1.0) % 6.0 = 0.0 then
    printfn "%A" (n * (2.0 * n - 1.0))
    hasFound <- true
  n <- n + 1.0
