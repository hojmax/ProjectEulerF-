let mutable count = 0

// Den her er lidt grim... Vil gerne finde ud af hvordan man kunne eksekverer det mere elegant.
for a in 0..9 do
  for b in 0..9 do
    if a <> b then
      for c in 0..9 do
        if a <> c && b <> c then
          for d in 0..9 do
            if a <> d && b <> d && c <> d then
              for e in 0..9 do
                if a <> e && b <> e && c <> e && d <> e then
                  for f in 0..9 do
                    if a <> f && b <> f && c <> f && d <> f && e <> f then
                      for g in 0..9 do
                        if a <> g && b <> g && c <> g && d <> g && e <> g && f <> g then
                          for h in 0..9 do
                            if a <> h && b <> h && c <> h && d <> h && e <> h && f <> h && g <> h then
                              for i in 0..9 do
                                if a <> i && b <> i && c <> i && d <> i && e <> i && f <> i && g <> i && h <> i then
                                  for j in 0..9 do
                                    if a <> j && b <> j && c <> j && d <> j && e <> j && f <> j && g <> j && h <> j && i <> j then
                                      count <- count + 1
                                      if count = int 1e6 then
                                        printfn "%A%A%A%A%A%A%A%A%A%A" a b c d e f g h i j
