let limit = 999
let sum n = n * (n + 1) / 2
printfn "%A" (sum (limit / 3) * 3 + sum (limit / 5) * 5 - sum (limit / 15) * 15)
