let primeFactors (n: byref<int64>) =
  let mutable result = []
  let mutable i = 2L
  while i <= int64 ((float n)**0.5) do
    while n % i = 0L do
      result <- i :: result
      n <- n / i
    i <- i + 1L
  if not (n = 1L) then
    result <- n :: result
  result

let mutable input = 600851475143L
printfn "%A" (primeFactors &input)
