module PhoneParser

open FParsec
open ApplicativePhoneParser

let phoneNumber = 
    let parensAreaCode = optional (pchar '(') >>. areaCode .>> optional (pchar ')')
    let mainNumberThenEof = mainNumber .>> eof
    let mkPhoneNumber (areaCode, numType) mainNumber = 
        { areaCode = areaCode; number = mainNumber; numberType = numType; }
    pipe2 parensAreaCode mainNumberThenEof mkPhoneNumber
    
let parsePhoneNumber str =
    run phoneNumber str