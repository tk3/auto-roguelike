open System

type World() =
  member _.Start(): unit =
    printfn "start World ..."

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let world = new World()
    world.Start()
    0
