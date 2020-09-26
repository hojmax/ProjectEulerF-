let primes = [|2;3;5;7;11;13;17|]
let mutable totalSum = 0I

let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
  result

(*
Begrænsninger:
1. ciffer kan ikke være 0
4. ciffer skal være 2, 4, 6, 8 eller 0
6. ciffer er 5 eller 0
8-10 skal kunne divideres med 17
*)

// Den her løsning er ikke særlig elegant. Har et meget lignende problem i opgave 31, og er ikke sikker på hvordan det kan løses bedre.
for a in 6..58 do
  let mutable a123 = [|-1;-1;-1|]
  let mutable n = 17 * a
  let mutable aValid = true
  let mutable i = 0
  while aValid && n >= 1 do
    let current = n % 10
    if current = a123.[0] || current = a123.[1] || current = a123.[2] then
      aValid <- false
    else
      a123.[i] <- current
      n <- n / 10
      i <- i + 1
  if aValid then
    for b in 0..5..5 do
      if b <> a123.[0] && b <> a123.[1] && b <> a123.[2] then
        for c in 0..2..8 do
          if c <> a123.[0] && c <> a123.[1] && c <> a123.[2] && c <> b then
            for d in 1..9 do
              if d <> a123.[0] && d <> a123.[1] && d <> a123.[2] && d <> b && d <> c then
                for e in 0..9 do
                  if e <> a123.[0] && e <> a123.[1] && e <> a123.[2] && e <> b && e <> c && e <> d then
                    for f in 0..9 do
                      if f <> a123.[0] && f <> a123.[1] && f <> a123.[2] && f <> b && f <> c && f <> d && f <> e then
                        for g in 0..9 do
                          if g <> a123.[0] && g <> a123.[1] && g <> a123.[2] && g <> b && g <> c && g <> d && g <> e && g <> f then
                            for h in 0..9 do
                              if h <> a123.[0] && h <> a123.[1] && h <> a123.[2] && h <> b && h <> c && h <> d && h <> e && h <> f && h <> g then
                                let digits = [|d;e;f;c;g;b;h;a123.[2];a123.[1];a123.[0]|]
                                let mutable i = 1
                                let mutable isDivisible = true
                                while isDivisible && i <= 7 do
                                  isDivisible <- (digits.[i] * 100 + digits.[i + 1] * 10 + digits.[i + 2]) % primes.[i - 1] = 0
                                  i <- i + 1
                                if isDivisible then
                                  for j in 0..digits.Length - 1 do
                                    totalSum <- totalSum + System.Numerics.BigInteger digits.[j] * iPown 10I (9I - System.Numerics.BigInteger j)

printfn "%A" totalSum
