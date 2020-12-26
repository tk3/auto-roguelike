open System

type IOccupant =
    abstract Action: unit -> unit

type Player =
    interface IOccupant with
        override _.Action() =
            printfn "Player> action"

type TurnKeeper() =
    let mutable turn = 0

    member _.CurrentTrurn = turn

    member _.OrderOccupants(): unit =
        turn <- turn + 1
        printfn "TurnKeeper[%d]> order occupants" turn

type World(turnKeeper: TurnKeeper) =
    let turnKeeper = turnKeeper

    member _.Start(): unit =
        printfn "start World ..."
        turnKeeper.OrderOccupants()

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let turnKeeper = new TurnKeeper()
    let world = new World(turnKeeper)
    world.Start()
    0
