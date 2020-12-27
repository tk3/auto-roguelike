namespace World1

type IPlace =
    abstract member Name: unit -> string
    abstract member LinkedPlaces: unit -> List<IPlace>

type Village(name: string, linkedPlaces: List<IPlace>) =
    let linkedPlaces = linkedPlaces

    interface IPlace with
        member _.Name() = name
        member _.LinkedPlaces() = linkedPlaces

type Dungeon(name: string, linkedPlaces: List<IPlace>) =
    let linkedPlaces = linkedPlaces

    interface IPlace with
        member _.Name() = name
        member _.LinkedPlaces() = linkedPlaces

type IOccupant =
    abstract member Action: unit -> unit

type Player() =
    interface IOccupant with
        member _.Action() =
            printfn "Player> action"

type TurnKeeper() =
    let mutable turn = 0

    member _.CurrentTrurn = turn

    member _.OrderOccupants(occupants: List<IOccupant>): unit =
        turn <- turn + 1
        printfn "TurnKeeper[%d]> order occupants" turn
        for occupant in occupants do
            occupant.Action()

type World(turnKeeper: TurnKeeper, player: Player) =
    let turnMaxValue = 5

    let turnKeeper = turnKeeper
    let occupants: List<IOccupant> = [player]

    member _.Start(): unit =
        printfn "start World ..."

        for i = 1 to turnMaxValue do
            turnKeeper.OrderOccupants(occupants)

