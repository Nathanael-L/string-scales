namespace Library

open System
open ScalesCore

module InputOutput =

    let getNoteFromString (name : string) : Note =
        match name with
        | "C" -> C
        | "Cs" -> Cs
        | "C#" -> Cs
        | "D" -> D
        | "Ds" -> Ds
        | "D#" -> Ds
        | "E" -> E
        | "F" -> F
        | "Fs" -> Fs
        | "F#" -> Fs
        | "G" -> G
        | "Gs" -> Gs
        | "G#" -> Gs
        | "A" -> A
        | "Bb" -> Bb
        | "B" -> B
        | _ -> C

    let getStringFromNote (x : Note) : string =
        match x with
        | C -> "C"
        | Cs -> "C#"
        | D -> "D"
        | Ds -> "D#"
        | E -> "E"
        | F -> "F"
        | Fs -> "F#"
        | G -> "G"
        | Gs -> "G#"
        | A -> "A"
        | Bb -> "Bb"
        | B -> "B"

    let roleToString (x : Role) : string =
        match x with
        | Key -> "∆---"
        | Harm -> "o---"
        | Chor -> "O---"
        | Dis -> " ---"

    let schemaToString (x : Schema) : string =
        x
        |> Array.map roleToString
        |> String.Concat

    let drawStringScale (stringNote : Note) (scaleNote : Note) (schema : Schema) : string =
        getStringSchema scaleNote schema stringNote
        |> schemaToString

    let printStringSchema (x : (Note * Schema)) =
        let name = x |> fst |> getStringFromNote
        let schemaString = x |> snd |> schemaToString
        printfn $"{name.PadRight(3, ' ')}{schemaString}"
    let printScaleStrings (x : (Note * array<Note * Schema>)) =
        x
        |> fst
        |> getStringFromNote
        |> printfn "%s"

        x
        |> snd
        |> Array.iter (printStringSchema)

        printfn ""

    let printMayorScaleStrings (x : (Note * array<Note * Schema>)) =
        x
        |> fst
        |> getStringFromNote
        |> printfn "%s-Dur"

        x
        |> snd
        |> Array.iter (printStringSchema)

        printfn ""

    let printCircleOfFifths (tuning : Tuning) =
        getCircleOfFifthsStringSchemas tuning
        |> Array.iter (fun x -> (printMayorScaleStrings x))
