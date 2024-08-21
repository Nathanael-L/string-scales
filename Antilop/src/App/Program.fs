open System
open Library
open ScalerCore

let printMayorScale (noteName: string) =
    let note : Note = getNoteFromString noteName
    let scale = getMayorScale note
    printfn $"Scale: %0A{scale}"

let printGuitarMayorScale (noteName: string) =
    let note : Note = getNoteFromString noteName
    printfn $"E {drawStringScale E note mayorSchema}"
    printfn $"B {drawStringScale B note mayorSchema}"
    printfn $"G {drawStringScale G note mayorSchema}"
    printfn $"D {drawStringScale D note mayorSchema}"
    printfn $"A {drawStringScale A note mayorSchema}"
    printfn $"E {drawStringScale E note mayorSchema}"

[<EntryPoint>]
let main args =
    printfn "__+---SCALER---+__"
    printfn "1: Mayor Scale"
    printfn "2: Test Guitar Scale"
    printfn " Select: "
    let mode = Console.ReadLine()
    printfn " Note: "
    let note = Console.ReadLine()

    match mode with
        | "1" -> printMayorScale note
        | "2" -> printGuitarMayorScale note
        | _ -> printfn "unknown input"

    0 // return an integer exit code
