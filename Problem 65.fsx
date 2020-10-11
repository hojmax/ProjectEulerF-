let cFrac = [|for i in 0I..99I ->
                if i = 0I then
                  2I 
                else if i = 1I then
                  1I
                else if (i - 2I) % 3I = 0I then
                  2I * (1I + (i - 2I) / 3I)
                else
                  1I
            |]

let mutable upper = 1I
let mutable lower = cFrac.[cFrac.Length - 1]
for i in cFrac.Length - 2 .. -1 .. 0 do
  let temp = lower
  lower <-  cFrac.[i] * lower + upper
  upper <- temp

let mutable sum = 0I
while lower >= 1I do
  sum <- sum + lower % 10I
  lower <- lower / 10I

printfn "%A" sum
