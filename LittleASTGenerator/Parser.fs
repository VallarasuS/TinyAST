module Parser

open System
open System.IO
open Lexer

type Expression =
    | Integer of int
    | Float of float
    | Addition of Expression * Expression
    | Subtraction of Expression * Expression
    | Multiplication of Expression * Expression
    | Division of Expression * Expression
    | Modulo of Expression * Expression
    | Power of Expression * Expression

type Parser(path:string) =
    let code = File.ReadAllText path
    let tokens = Tokenizer(code).GetTokens()