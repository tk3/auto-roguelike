open System

type IOccupant =
    abstract member Action: unit -> unit

type Player() =
    interface IOccupant with
        member _.Action() =
            printfn "Player> action"

type TurnKeeper() =
    let mutable turn = 0

    member _.CurrentTrurn = turn

    member _.OrderOccupants(occupants: List<'IOccupant>): unit =
        turn <- turn + 1
        printfn "TurnKeeper[%d]> order occupants" turn
        for occupant in occupants do
            (occupant :> IOccupant).Action()

type World(turnKeeper: TurnKeeper, player: Player) =
    let turnKeeper = turnKeeper
    // let _occupants = List.empty<'IOccupant>
    let _occupants = [player]

    member _.Start(): unit =
        printfn "start World ..."
        turnKeeper.OrderOccupants(_occupants)

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let player = new Player()
    let turnKeeper = new TurnKeeper()
    let world = new World(turnKeeper, player)
    world.Start()
    0
