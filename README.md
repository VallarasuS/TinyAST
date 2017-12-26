# TinyAST

Tiny AST is a baby step in building a lisp compiler that's why the name tiny.

# Language

Only a subset of Lisp scheme is accounted in this program and uses prefix notation.

Here is an example statement

(operator operand operand)

(+ 5 3)

# What does Tiny AST do?

It is a lexer for a subset of Lisp called Lispy Calculator, it understands the language syntax produces an Abstract Syntax Tree with language tokens, which can used for parsing or direct intrepretation.

for the above example the AST will look like

	            +

	         /      \

	       5          3


