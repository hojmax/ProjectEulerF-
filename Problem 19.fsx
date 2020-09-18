let mutable sundayCount = 0
let monthLength = [|31; 28; 31; 30; 31; 30; 31; 31; 30; 31; 30; 31|]
let mutable year = 1901
let mutable month = 0
let mutable date = 0
// Den 1. januar 1901 var en tirsdag
let mutable weekday = 1
while year <= 2000 do
    date <- date + 1
    weekday <- (weekday + 1) % 7
    if date >= monthLength.[month] then
        date <- 0
        month <- month + 1
        if weekday = 6 then
          sundayCount <- sundayCount + 1
        if month >= 12 then
            month <- 0
            year <- year + 1
            if year % 400 = 0 || (year % 4 = 0 && year % 100 <> 0) then
                monthLength.[1] <- 29
            else
                monthLength.[1] <- 28

printfn "%A" sundayCount
