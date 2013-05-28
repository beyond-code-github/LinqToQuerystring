grammar LinqToQuerystring;

options
{
    language=CSharp3;
    output=AST;
}

@parser::namespace { LinqToQuerystring }

@lexer::header {
using LinqToQuerystring.Exceptions;
}

@lexer::namespace { LinqToQuerystring }

@lexer::members {
public override void ReportError(RecognitionException e) {
    if (this.input.LT(1) == '\\')
    {
        //This will be an invalid escape sequence
        throw new InvalidEscapeSequenceException("\\" + (char)e.Character);
    }

    throw e;
}
}

public prog
	:	(param ('&'! param)*)*;

param	:	(orderby | top | skip | filter | select | inlinecount);

skip	
	:	SKIP^ INT+;

top	
	:	TOP^ INT+;

filter	
	:	FILTER^ filterexpression;
	
select
	:	SELECT^ propertyname (','! propertyname)*;
	
inlinecount
	:	INLINECOUNT^ ALLPAGES
	|	INLINECOUNT NONE ->;

filterexpression	
	:	orexpression (SPACE! OR^ SPACE! orexpression)*;
	
orexpression
	:	andexpression (SPACE! AND^ SPACE! andexpression)*;
	
andexpression
	:	NOT^ SPACE ('(' filterexpression ')' | booleanexpression)
	|	('(' filterexpression ')' | booleanexpression);
		
booleanexpression
	:	atom1=atom (
			SPACE (op=EQUALS | op=NOTEQUALS | op=GREATERTHAN | op=GREATERTHANOREQUAL | op=LESSTHAN | op=LESSTHANOREQUAL) SPACE atom2=atom 	
			-> ^($op $atom1 $atom2)
		|	-> ^(EQUALS["eq"] $atom1 BOOL["true"])
		);
		
atom	:	functioncall	
	|	constant
	|	propertyname;
	
functioncall
	:	function^ '(' atom (',' atom)* ')';

function
	:	STARTSWITH | ENDSWITH | SUBSTRINGOF | TOLOWER;
	
orderby
	:	ORDERBY^ orderbylist;
	
orderbylist
	:	orderpropertyname (','! orderpropertyname)*;

orderpropertyname
	:	propertyname -> ^(ASC propertyname)
	| 	propertyname (SPACE! (ASC | DESC)^);
	
constant:	(INT+ | BOOL | STRING | DATETIME);

propertyname
	:	(IDENTIFIER|DYNAMICIDENTIFIER) ('/' (IDENTIFIER|DYNAMICIDENTIFIER))*;

filteroperator
	:	EQUALS | NOTEQUALS | GREATERTHAN | GREATERTHANOREQUAL | LESSTHAN | LESSTHANOREQUAL;
	
ASSIGN
	: 	'=';

EQUALS	
	:	'eq';	
	
NOTEQUALS	
	:	'ne';	
	
GREATERTHAN	
	:	'gt';	
	
GREATERTHANOREQUAL
	:	'ge';	
	
LESSTHAN	
	:	'lt';	
	
LESSTHANOREQUAL
	:	'le';	

NOT		
	:	'not';

OR	
	:	'or';

AND	
	: 	'and';

ASC	
	:	'asc';
	
DESC	
	:	'desc';	
	
ALLPAGES
	: 	'allpages';
	
NONE
	:	'none';

SKIP
	:	'$skip=';

TOP
	:	'$top=';

FILTER
	:	'$filter=';

ORDERBY
	:	'$orderby=';
	
SELECT
	:	'$select=';
	
INLINECOUNT
	:	'$inlinecount=';
	
STARTSWITH
	:	'startswith';
	
ENDSWITH
	:	'endswith';
	
SUBSTRINGOF
	:	'substringof';

TOLOWER
	:	'tolower';
		
INT	
	:	'0'..'9'+;
	
BOOL	:	('true' | 'false');

DATETIME
	:	'datetime\'' '0'..'9'+ '-' '0'..'9'+ '-' + '0'..'9'+ 'T' '0'..'9'+ ':' '0'..'9'+ (':' '0'..'9'+ ('.' '0'..'9'+)*)* '\'';

SPACE	
	:	(' '|'\t')+;

NEWLINE 
	:	('\r'|'\n')+;
	
DYNAMICIDENTIFIER
	:	'[' ('a'..'z'|'A'..'Z'|'0'..'9'|'_')+ ']';	
	
IDENTIFIER
	:	('a'..'z'|'A'..'Z'|'0'..'9'|'_')+;

STRING
    	: '\'' (ESC_SEQ| ~('\\'|'\''))* '\'';

fragment
HEX_DIGIT : ('0'..'9'|'a'..'f'|'A'..'F') ;

fragment
ESC_SEQ
  	: '\'\''
    	| '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
    	| UNICODE_ESC
    	| OCTAL_ESC
    	;

fragment
OCTAL_ESC
    	:   '\\' ('0'..'3') ('0'..'7') ('0'..'7')
    	|   '\\' ('0'..'7') ('0'..'7')
    	|   '\\' ('0'..'7')
    	;

fragment
UNICODE_ESC
    	:   '\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT
    	;
