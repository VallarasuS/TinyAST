// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System
open Lexer

[<EntryPoint>]
let main argv = 
    let tokens = Tokenizer("(+ (+ 2 3) (* 2 5))").GetTokens()

    tokens |> List.iter (fun l -> printfn "%s" l.String)

    Console.ReadKey() |> ignore

    0 // return an integer exit code
