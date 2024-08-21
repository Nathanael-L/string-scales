namespace Library

module ScalerCore =

    type Note =
        | C
        | Cs
        | D
        | Ds
        | E
        | F
        | Fs
        | G
        | Gs
        | A
        | Bb
        | B

    // keynote, harmonic, chordal or disharmonious
    type Role =
        | Key
        | Harm
        | Chor
        | Dis

    type Scale = Note array
    type Schema = Role array
    
    let allNotes : Scale = [| C; Cs; D; Ds; E; F; Fs; G; Gs; A; Bb; B |]

    let mayorSchema : Schema = [| Key; Dis; Harm; Dis; Chor; Harm; Dis; Chor; Dis; Harm; Dis; Harm |]

    let permuteNotes (note : Note) (notes : Scale) =
        let i = notes |> Array.findIndex (fun x -> x = note)
        let len = notes.Length

        notes
        |> Array.permute (fun x -> ((len + x - i) % len))
        
    let filterScale (x : Role) =
        match x with
        | Key -> true
        | Chor -> true
        | Harm -> true
        | Dis -> false

    let getScale (note : Note) (schema : Schema) =
        allNotes
        |> permuteNotes note
        |> Array.zip schema
        |> Array.filter (fun n -> filterScale (fst n))
        |> Array.map snd
   
    let getMayorScale (note : Note) =
        getScale note mayorSchema

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
