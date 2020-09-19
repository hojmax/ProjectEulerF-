let sum n = n * (n + 1) / 2
let limit = 1000

printfn "%A" (sum ((limit - 1) / 3) * 3 + sum ((limit - 1) / 5) * 5 - sum ((limit - 1) / 15) * 15)
