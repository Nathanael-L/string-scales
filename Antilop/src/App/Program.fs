open System
open Library
open ScalesCore
open InputOutput

let askNote () : Note=
    printf " Note: "
    Console.ReadLine()
    |> getNoteFromString

let askSchema () : Schema =
    printfn "1: Dur"
    printfn "2: Moll"
    printf " Select: "
    let i = Console.ReadLine()

    match i with
    | "1" -> mayorSchema
    | "2" -> minorSchema
    | _ -> mayorSchema

let askTuning () : Tuning =
    printfn "1: Gitarre"
    printfn "2: Geige"
    printf " Select: "
    let i = Console.ReadLine()

    match i with
    | "1" -> guitarStandardTuning
    | "2" -> violinStandardTuning
    | _ -> guitarStandardTuning


let printScale (note: Note) (schema : Schema) =
    let scale = getScale note schema
    printfn $"Scale: %0A{scale}"

let runSingleScale () =
    let note = askNote()
    let schema = askSchema()
    printScale note schema

let runInstrumentScale () =
    let note = askNote()
    let schema = askSchema()
    let tuning = askTuning()

    (tuning, schema, note)
    |||> getStringSchemas
    |> (fun x-> (note, x))
    |> printScaleStrings

let runFifths () =
    let tuning = askTuning()
    printCircleOfFifths tuning

let mainMenu () =
    let mutable mode = ""
    while mode <> "x" do
        printfn "1: Tonleiter"
        printfn "2: Tonleiter auf Instrument"
        printfn "3: Alle Tonarten auf Instrument"
        printfn "x: Exit"
        printf " Select: "
        mode <- Console.ReadLine()

        match mode with
            | "1" -> runSingleScale()
            | "2" -> runInstrumentScale()
            | "3" -> runFifths()
            | "x" -> printfn "exit"
            | _ -> printfn "unknown input"



let printGuitarMayorScale (noteName: string) =
    let note : Note = getNoteFromString noteName
    printfn $"E {drawStringScale E note mayorSchema}"
    printfn $"B {drawStringScale B note mayorSchema}"
    printfn $"G {drawStringScale G note mayorSchema}"
    printfn $"D {drawStringScale D note mayorSchema}"
    printfn $"A {drawStringScale A note mayorSchema}"
    printfn $"E {drawStringScale E note mayorSchema}"

let printFiths () =
    printfn $"Fifths: %0A{getFifths}"
    
[<EntryPoint>]
let main args =
    printfn "__+---STRING||SCALES---+__"
    printfn "  +---------||---------+  "
    printfn ""

    mainMenu()

    0 // return an integer exit code
