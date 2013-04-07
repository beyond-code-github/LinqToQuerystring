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
	:	NOT^ SPACE booleanexpression
	|	booleanexpression;
		
booleanexpression
	:	atom (SPACE! filteroperator^ SPACE! atom | implicit);
	
implicit
	:	-> ^(EQUALS BOOL["true"]);
	
atom	:	'(' filterexpression ')'
	|	functioncall
	|	propertyname 
	|	constant;

functioncall
	:	function^ '(' (IDENTIFIER | constant) (',' (IDENTIFIER | constant))* ')';

function
	:	STARTSWITH | ENDSWITH | SUBSTRINGOF;
	
orderby
	:	ORDERBY^ orderbylist;
	
orderbylist
	:	orderpropertyname (','! orderpropertyname)*;

orderpropertyname
	:	propertyname -> ^(ASC propertyname)
	| 	propertyname (SPACE! (ASC | DESC)^);
	
constant:	(INT+ | BOOL | STRING | DATETIME);

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
		
INT	
	:	'0'..'9'+;
	
BOOL	:	('true' | 'false');

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
