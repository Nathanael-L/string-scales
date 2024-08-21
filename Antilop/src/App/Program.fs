open System
open Library
open ScalerCore

let printMayorScale (noteName: string) =
    let note : Note = getNoteFromString noteName
    let scale = getMayorScale note
    printfn $"Scale: %0A{scale}"

[<EntryPoint>]
let main args =
    printfn "__+---SCALER---+__"
    printfn "1: Mayor Scale"
    printfn " Select: "
    let mode = Console.ReadLine()
    printfn " Tone: "
    let note = Console.ReadLine()

    match mode with
        | "1" -> printMayorScale note
        | _ -> printfn "unknown input"

    0 // return an integer exit code
