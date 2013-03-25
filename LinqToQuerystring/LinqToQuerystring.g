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
	:	(NOT^)* comparisonexpression (SPACE! NOT^ SPACE! comparisonexpression)*;
		
comparisonexpression
	:	propertyname SPACE! EQUALS^ SPACE! (INT+ | BOOL | STRING);

orderby
	:	ORDERBY^ orderbylist;
	
orderbylist
	:	orderpropertyname (','! orderpropertyname)*;

orderpropertyname
	:	propertyname -> ^(ASC propertyname)
	| 	propertyname (SPACE! (ASC | DESC)^);

propertyname
	:	IDENTIFIER  ('/' IDENTIFIER)*;

ASSIGN
	: 	'=';

FILTEROPERATOR
	:	'ne' | 'gt' | 'ge' | 'lt' | 'le';

EQUALS	
	:	'eq';	

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
	:	('<'|'>'|'a'..'z'|'A'..'Z'|'0'..'9'|'_')+;

STRING	
	:	'\'' ('<'|'>'|'a'..'z'|'A'..'Z'|'0'..'9'|'_'|' '|'\t')+ '\'';

