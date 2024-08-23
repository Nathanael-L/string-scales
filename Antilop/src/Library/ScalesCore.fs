namespace Library

module ScalesCore =

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
    type Tuning = Note array

    let allNotes : Scale = [| C; Cs; D; Ds; E; F; Fs; G; Gs; A; Bb; B |]

    let mayorSchema : Schema = [| Key; Dis; Harm; Dis; Chor; Harm; Dis; Chor; Dis; Harm; Dis; Harm |]

    let violinStandardTuning : Tuning =
        [| G; D; A; E |]
    
    let permuteNotes (notes : Scale) (i: int) : Scale =
        let len = notes.Length

        notes
        |> Array.permute (fun x -> ((len + x - i) % len))

    let permuteSchema (schema : Schema) (i: int) : Schema =
        let len = schema.Length

        schema
        |> Array.permute (fun x -> ((len + x - i) % len))
        
    let filterScale (x : Role) =
        match x with
        | Key -> true
        | Chor -> true
        | Harm -> true
        | Dis -> false

    let getScale (note : Note) (schema : Schema) =
        let iNote =
            allNotes
            |> Array.findIndex (fun x -> x = note)

        (allNotes, iNote)
        ||> permuteNotes
        |> Array.zip schema
        |> Array.filter (fun n -> filterScale (fst n))
        |> Array.map snd
   
    let getMayorScale (note : Note) =
        getScale note mayorSchema

    let getStringSchema (scaleNote : Note) (schema : Schema) (stringNote : Note) : Schema =
        let iScale =
            allNotes
            |> Array.findIndex (fun x -> x = scaleNote)
        let iString = 
            (allNotes, iScale)
            ||> permuteNotes
            |> Array.findIndex (fun x -> x = stringNote)
        (schema, iString)
        ||> permuteSchema

    let getStringSchemas (tuning : Tuning) (schema : Schema) (scaleNote : Note) : (Note * Schema) array =
        tuning
        |> Array.map (fun x -> (x, (getStringSchema scaleNote schema x)))

    let nextFifthIndex (i : int) : int =
        (i + 7) % allNotes.Length

    let getFifth (note : Note) : Note =
        allNotes
        |> Array.findIndex (fun x -> x = note)
        |> fun x -> allNotes[nextFifthIndex x]

    let rec collectFifths (xs : Scale) (note : Note) : Scale =
        let isComplete = xs |> Array.contains note
        match isComplete with
        | true -> xs
        | false -> collectFifths (Array.append xs [|note|]) (getFifth note)

    let getFifths : Scale =
        collectFifths [||] C

    let getCircleOfFifths () : (Note * Scale) array =
        getFifths
        |> Array.map (fun x -> (x, getMayorScale x))
    
    let getCircleIfFifthsStringSchemas (tuning : Tuning) : array<Note * array<Note * Schema>> =
        getFifths
        |> Array.map (fun x -> (x, (getStringSchemas tuning mayorSchema x)))

    let getViolinCricleOfFifths () : array<Note * array<Note * Schema>> =
        getCircleIfFifthsStringSchemas violinStandardTuning
