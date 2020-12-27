open World1

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let player = new Player()
    let turnKeeper = new TurnKeeper()
    let world = new World(turnKeeper, player)
    world.Start()
    0
