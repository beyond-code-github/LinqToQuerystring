grammar LinqToQuerystring;

options
{
    language=CSharp3;
    output=AST;
}

@parser::namespace { LinqToQuerystring }

@lexer::namespace { LinqToQuerystring }

public prog
	:	(param ('&'! param)*)*;

param	:	(orderby | top | skip | filter);

skip	
	:	SKIP^ INT+;

top	
	:	TOP^ INT+;

filter	
	:	FILTER^ filterexpression;

filterexpression	
	:	orexpression (SPACE! OR^ SPACE! orexpression)*;
	
orexpression
	:	andexpression (SPACE! AND^ SPACE! andexpression)*;
	
andexpression
	:	NOT^ SPACE comparisonexpression
	|	comparisonexpression;
		
comparisonexpression
	:	propertyname SPACE! filteroperator^ SPACE! (INT+ | BOOL | STRING | DATETIME)
	|	'(' filterexpression ')';

orderby
	:	ORDERBY^ orderbylist;
	
orderbylist
	:	orderpropertyname (','! orderpropertyname)*;

orderpropertyname
	:	propertyname -> ^(ASC propertyname)
	| 	propertyname (SPACE! (ASC | DESC)^);

propertyname
	:	IDENTIFIER  ('/' IDENTIFIER)*;

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

SKIP
	:	'$skip=';

TOP
	:	'$top=';

FILTER
	:	'$filter=';

ORDERBY
	:	'$orderby=';
		
INT	
	:	'0'..'9'+;
	
BOOL	
	:	('true' | 'false');

SPACE	
	:	(' '|'\t')+;

NEWLINE 
	:	('\r'|'\n')+;
	
IDENTIFIER
	:	('a'..'z'|'A'..'Z'|'0'..'9'|'_')+;

STRING	
	:	'\'' ('<'|'>'|'a'..'z'|'A'..'Z'|'0'..'9'|'_'|' '|'\t')+ '\'';

DATETIME
	:	'datetime\'' '0'..'9'+ '-' '0'..'9'+ '-' + '0'..'9'+ 'T' '0'..'9'+ ':' '0'..'9'+ (':' '0'..'9'+ ('.' '0'..'9'+)*)* '\'';
