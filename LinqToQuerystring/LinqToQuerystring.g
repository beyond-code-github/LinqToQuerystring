grammar LinqToQuerystring;

options
{
	language=CSharp3;
	output=AST;
}

tokens {
	ALIAS;
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

param	:	(orderby | top | skip | filter | select | inlinecount | expand | ignored);

skip	
	:	SKIP^ INT+;

top	
	:	TOP^ INT+;

filter	
	:	FILTER^ filterexpression[false];
	
select
	:	SELECT^ propertyname[false] (','! propertyname[false])*;
			
expand
	:	EXPAND^ propertyname[false] (','! propertyname[false])*;

inlinecount
	:	INLINECOUNT^ ALLPAGES
	|	INLINECOUNT NONE ->;

ignored	:	IGNORED IDENTIFIER -> IGNORED;

filterexpression[bool subquery]
	:	orexpression[subquery] (SPACE! OR^ SPACE! orexpression[subquery])*;
	
orexpression[bool subquery]
	:	andexpression[subquery] (SPACE! AND^ SPACE! andexpression[subquery])*;
	
andexpression[bool subquery]
	:	NOT^ SPACE ('(' filterexpression[subquery] ')' | booleanexpression[subquery])
	|	('(' filterexpression[subquery] ')' | booleanexpression[subquery]);
		
booleanexpression[bool subquery]
	:	atom1=atom[subquery] (
			SPACE (op=EQUALS | op=NOTEQUALS | op=GREATERTHAN | op=GREATERTHANOREQUAL | op=LESSTHAN | op=LESSTHANOREQUAL) SPACE atom2=atom[subquery] 	
			-> ^($op $atom1 $atom2)
		|	-> ^(EQUALS["eq"] $atom1 BOOL["true"])
		);
		
atom[bool subquery]
	:	functioncall[subquery]
	|	constant
	|	accessor[subquery];
	
functioncall[bool subquery]
	:	function^ '(' atom[subquery] (',' atom[subquery])* ')';
	
accessor[bool subquery]:
		(propertyname[subquery] -> propertyname) (
			'/' (func=ANY | func=ALL | func=COUNT | func=MAX | func=MIN | func=SUM | func=AVERAGE) 
			'(' (
				(id=IDENTIFIER ':' SPACE filterexpression[true]) -> ^($func $accessor ALIAS[$id] filterexpression)
				| -> ^($func $accessor) )
			')' 
		)?;
	
function
	:	STARTSWITH | ENDSWITH | SUBSTRINGOF | TOLOWER | TOUPPER | YEAR | YEARS | MONTH | DAY | DAYS | HOUR | HOURS | MINUTE | MINUTES | SECOND | SECONDS;
		
orderby
	:	ORDERBY^ orderbylist;
	
orderbylist
	:	orderpropertyname (','! orderpropertyname)*;

orderpropertyname
	:	propertyname[false] (
			-> ^(ASC["asc"] propertyname)
			| (SPACE (op=ASC | op=DESC)) -> ^($op propertyname)
		);
	
constant:	(INT^ | BOOL^ | STRING^ | DATETIME^ | LONG^ | SINGLE^ | DECIMAL^ | DOUBLE^ | GUID^ | BYTE^ | NULL^);

propertyname[bool subquery]
	:	(identifierpart[subquery] -> identifierpart) ('/' next=subpropertyname[false] -> ^($propertyname $next))?;

subpropertyname[bool subquery]
	:	propertyname[false];
	
identifierpart[bool subquery]
	:	(id=IDENTIFIER -> {subquery}? ALIAS[$id]
				-> IDENTIFIER[$id]
		| DYNAMICIDENTIFIER -> DYNAMICIDENTIFIER);

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
	
EXPAND	:	'$expand=';
	
IGNORED :	'$' IDENTIFIER '=';
	
STARTSWITH
	:	'startswith';
	
ENDSWITH
	:	'endswith';
	
SUBSTRINGOF
	:	'substringof';
	
TOLOWER
	:	'tolower';

TOUPPER
	:	'toupper';
	
YEAR
	:	'year';
	
YEARS
	:	'years';
	
MONTH
	:	'month';
	
DAY
	:	'day';
	
DAYS
	:	'days';
	
HOUR
	:	'hour';
	
HOURS
	:	'hours';
	
MINUTE
	:	'minute';
	
MINUTES
	:	'minutes';
	
SECOND
	:	'second';
	
SECONDS
	:	'seconds';

ANY	: 	'any';
	
ALL	:	'all';

COUNT	:	'count';

MIN	:	'min';

MAX	:	'max';

SUM	:	'sum';

AVERAGE	:	'average';
		
INT	:	('-')? '0'..'9'+;
	
LONG	:	('-')? ('0'..'9')+ 'L';
	
DOUBLE	:	('-')? ('0'..'9')+ '.' ('0'..'9')+ 'd'?;
	
SINGLE	:	('-')? ('0'..'9')+ '.' ('0'..'9')+ 'f';

DECIMAL	:	('-')? ('0'..'9')+ '.' ('0'..'9')+ 'm';
	
BOOL	:	('true' | 'false');

NULL	:	'null';

DATETIME
	:	'datetime\'' '0'..'9'+ '-' '0'..'9'+ '-' + '0'..'9'+ 'T' '0'..'9'+ ':' '0'..'9'+ (':' '0'..'9'+ ('.' '0'..'9'+)*)* ('Z')? '\'';
	
GUID	:	'guid\'' HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR '\'';

BYTE	:	'0x' HEX_PAIR;

SPACE	:	(' '|'\t')+;

NEWLINE :	('\r'|'\n')+;
	
DYNAMICIDENTIFIER
	:	'[' ('a'..'z'|'A'..'Z'|'0'..'9'|'_')+ ']';	
	
fragment
HEX_PAIR
	: HEX_DIGIT HEX_DIGIT;
	
IDENTIFIER
	:	('a'..'z'|'A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*;
	
STRING 	: 	'\'' (ESC_SEQ| ~('\\'|'\''))* '\'';

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
