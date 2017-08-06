// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open ApplicativePhoneParser

[<EntryPoint>]
let main argv = 
    match argv with
        | [|phoneNumberStr|] -> 
            let phoneNumber = parsePhoneNumber phoneNumberStr
            printfn "%A" phoneNumber
            0
        | _ -> 
            printfn "Unknown args: %A" argv
            1
