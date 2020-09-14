let mutable count = 0

for a in 0 .. 200 .. 200 do
  for b in 0 .. 100 .. 200 do
    if a + b <= 200 then
      for c in 0 .. 50 .. 200 do
        if a + b + c <= 200 then
          for d in 0 .. 20 .. 200 do
            if a + b + c + d <= 200 then
              for e in 0 .. 10 .. 200 do
                if a + b + c + d + e <= 200 then
                  for f in 0 .. 5 .. 200 do
                    if a + b + c + d + e + f <= 200 then
                      for g in 0 .. 2 .. 200 do
                        if a + b + c + d + e + f + g <= 200 then
                          count <- count + 1

printfn "%A" count
