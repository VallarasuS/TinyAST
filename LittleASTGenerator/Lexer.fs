module Lexer

open System
open System.Text.RegularExpressions

type Class =
    | LParen
    | RParen
    | Add
    | Sub
    | Times
    | Div
    | Mod
    | Pow
    | Int
    | Float
    | WhiteSpace

type Token = {
    Class : Class;
    String : string }  

type Literal = {
    Class : Class;
    Pattern : string }

// symbols takes precedance in the order defined.
let Symbols = [
    { Class = LParen; Pattern = "^\(" };                     
    { Class = RParen; Pattern = "^\)" };                     
    { Class = Add; Pattern = "^\+" };                     
    { Class = Sub; Pattern = "^\-" };                     
    { Class = Times; Pattern = "^\*" };                     
    { Class = Div; Pattern = "^/" };                     
    { Class = Mod; Pattern = "^%" };                     
    { Class = Pow; Pattern = "^\^" };                     
    { Class = Int; Pattern = "^[+-]?(\d*[.])?\d+" };     
    { Class = Float; Pattern = "^[+-]?\d" };
    { Class = WhiteSpace; Pattern = "^\s"};]           

type Tokenizer(input:string) = 

    let rec getTokens (acc:Token list, part:string) =
        match part with
        | x when String.IsNullOrEmpty(x) -> acc
        | _ -> Symbols 
            |> List.find (fun s -> Regex.IsMatch(part,s.Pattern))
            |> fun l -> Regex.Match(part,l.Pattern), l.Class
            |> fun (m,c) -> { Class = c; String = m.Value } , m.Length
            |> fun (t,i) -> (t :: acc), part.Substring(i)
            |> fun (t,s) -> getTokens (t, s)

    member t.GetTokens() = getTokens([],input) |> List.rev

    // TODO : add lexical analysis, check for consistency with finite automata.
    // add error handling.