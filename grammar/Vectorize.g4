grammar Vectorize;

program
    :   function+ ;

function
    :   'fn' ID '(' (funcparam (',' funcparam)*)? ')' ('->' type (array='[' ']')?)? statement ;

funcparam
    : ID ':' type (array='[' ']')? ;

funccall
    :   ID '(' (expression ( ',' expression)*)? ')' ;

vardef
    : 'let' ID ':' type (array='[' size=expression? ']')? ('=' initial=expression)?
    ;

type
    :   'int'
    |   'float'
    |   'bool'
    |   'string'
    ;

statement
    :   blockstmt
    |   vardefstmt
    |   varassignstmt
    |   funccall ';'
    |   ifstmt
    |   forstmt
    |   whilestmt
    |   returnstmt
    |   expressionstmt
    ;

blockstmt
    :  '{' statement* '}' ;

vardefstmt
    :   vardef ';' ;

varassignstmt
    :   ID ('[' index=expression ']')? '=' value=expression ';' ;

expressionstmt
    :   expression ';' ;

forstmt
    :   'for' '(' vardef ';' expression ';' expression ')' statement
    ;

ifstmt
    :   'if' '(' expression ')' statement
            ('else' 'if' '(' expression ')' statement)*
            ('else' statement)?
    ;

whilestmt
    :   'while' '(' expression ')' statement
    ;

returnstmt
    :   'return' expression ';'
    ;


expression
    :   '(' expression ')'                                      #Para
    |   ID '[' expression ']'                                   #ArrayAccess
    |   expression op=('++'|'--')                               #Unary
    |   '!' expression                                          #LogNot
    |   lhs=expression op=('*'|'/'|'%') rhs=expression          #BinaryMulDivMod
    |   lhs=expression op=('+'|'-') rhs=expression              #BinaryAddSub
    |   lhs=expression op=('<'|'<='|'>'|'>=') rhs=expression    #LogRel
    |   lhs=expression op=('=='|'!=') rhs=expression            #LogEqual
    |   lhs=expression '&&' rhs=expression                      #LogAnd
    |   lhs=expression '||' rhs=expression                      #LogOr
    |   INT                                                     #LiteralInt
    |   FLOAT                                                   #LiteralFloat
    |   STRING                                                  #LiteralString
    |   BOOL                                                    #LiteralBool
    |   ID                                                      #Var
    |   funccall                                                #FuncCall
    ;

WS      : [ \r\n\t]+ -> skip ;
INT     : '-'? [0-9]+ ;
FLOAT   : '-'? [0-9]+ '.' [0-9]+ ;
STRING  : '"' ~["]* '"' ;
BOOL    : ('true' | 'false') ;
ID      : [a-zA-Z_] [a-zA-Z0-9_]* ;
LINECMT : '#' ~[\r\n]* -> skip ;