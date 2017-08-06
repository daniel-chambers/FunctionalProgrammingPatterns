module ApplicativePhoneParser

open FParsec

// Map
let (<!>) fn f = f |>> fn

// Apply
let (<*>) (fn : Parser<('a -> 'b),'u>) (a : Parser<'a,'u>) : Parser<'b,'u> = 
    fn >>= (fun fn' -> a >>= (fn' >> preturn))

type PhoneNumberType =
    | Victoria
    | NewSouthWales
    | Mobile

type PhoneNumber = 
    { areaCode   : string
      number     : string
      numberType : PhoneNumberType }

let determineType areaCode = 
    match areaCode with
        | "03" -> Some Victoria
        | "02" -> Some NewSouthWales
        | "04" -> Some Mobile
        | _    -> None

let areaCode = 
    manyMinMaxSatisfy 2 2 isDigit <?> "2 digit area code"
    >>= fun areaCode -> 
        match determineType areaCode with
            | Some numType -> preturn (areaCode, numType)
            | None -> fail <| sprintf "Invalid area code: %s" areaCode


let areaCodeWithParens =
    (pchar '(') >>. areaCode .>> (pchar ')')

let mainNumber = manyMinMaxSatisfy 8 8 isDigit <?> "8 digit phone number"

let phoneNumber = 
    let parensAreaCode = attempt areaCodeWithParens <|> areaCode
    let mainNumberThenEof = mainNumber .>> eof
    let mkPhoneNumber (areaCode, numType) mainNumber = 
        { areaCode = areaCode; number = mainNumber; numberType = numType; }
        
    //            map               apply
    mkPhoneNumber <!> parensAreaCode <*> mainNumberThenEof 

let parsePhoneNumber str =
    run phoneNumber str