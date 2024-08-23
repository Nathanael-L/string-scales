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
