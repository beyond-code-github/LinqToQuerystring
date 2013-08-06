// $ANTLR 3.1.1 D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g 2013-08-01 14:24:36

var LinqToQuerystringLexer = function(input, state) {
// alternate constructor @todo
// public LinqToQuerystringLexer(CharStream input)
// public LinqToQuerystringLexer(CharStream input, RecognizerSharedState state) {
    if (!state) {
        state = new org.antlr.runtime.RecognizerSharedState();
    }

    (function(){
    }).call(this);

    this.dfa29 = new LinqToQuerystringLexer.DFA29(this);
    LinqToQuerystringLexer.superclass.constructor.call(this, input, state);


};

org.antlr.lang.augmentObject(LinqToQuerystringLexer, {
    OCTAL_ESC: 54,
    MAX: 27,
    COUNT: 26,
    EQUALS: 18,
    ORDERBY: 36,
    NOT: 17,
    SUM: 29,
    AND: 16,
    INLINECOUNT: 11,
    SPACE: 14,
    T__60: 60,
    EXPAND: 10,
    EOF: -1,
    T__55: 55,
    ENDSWITH: 33,
    T__56: 56,
    T__57: 57,
    T__58: 58,
    ESC_SEQ: 52,
    IDENTIFIER: 31,
    T__59: 59,
    ALL: 25,
    LESSTHANOREQUAL: 23,
    DOUBLE: 44,
    SELECT: 9,
    GREATERTHANOREQUAL: 21,
    HEX_PAIR: 49,
    GREATERTHAN: 20,
    BYTE: 46,
    LESSTHAN: 22,
    GUID: 45,
    SUBSTRINGOF: 34,
    ASC: 37,
    DATETIME: 41,
    UNICODE_ESC: 53,
    BOOL: 39,
    HEX_DIGIT: 51,
    NOTEQUALS: 19,
    INT: 6,
    MIN: 28,
    DYNAMICIDENTIFIER: 47,
    SKIP: 5,
    TOLOWER: 35,
    ANY: 24,
    SINGLE: 43,
    NEWLINE: 50,
    ALLPAGES: 12,
    AVERAGE: 30,
    NONE: 13,
    STARTSWITH: 32,
    OR: 15,
    ALIAS: 4,
    FILTER: 8,
    ASSIGN: 48,
    DESC: 38,
    TOP: 7,
    LONG: 42,
    STRING: 40
});

(function(){
var HIDDEN = org.antlr.runtime.Token.HIDDEN_CHANNEL,
    EOF = org.antlr.runtime.Token.EOF;
org.antlr.lang.extend(LinqToQuerystringLexer, org.antlr.runtime.Lexer, {
    OCTAL_ESC : 54,
    MAX : 27,
    COUNT : 26,
    EQUALS : 18,
    ORDERBY : 36,
    NOT : 17,
    SUM : 29,
    AND : 16,
    INLINECOUNT : 11,
    SPACE : 14,
    T__60 : 60,
    EXPAND : 10,
    EOF : -1,
    T__55 : 55,
    ENDSWITH : 33,
    T__56 : 56,
    T__57 : 57,
    T__58 : 58,
    ESC_SEQ : 52,
    IDENTIFIER : 31,
    T__59 : 59,
    ALL : 25,
    LESSTHANOREQUAL : 23,
    DOUBLE : 44,
    SELECT : 9,
    GREATERTHANOREQUAL : 21,
    HEX_PAIR : 49,
    GREATERTHAN : 20,
    BYTE : 46,
    LESSTHAN : 22,
    GUID : 45,
    SUBSTRINGOF : 34,
    ASC : 37,
    DATETIME : 41,
    UNICODE_ESC : 53,
    BOOL : 39,
    HEX_DIGIT : 51,
    NOTEQUALS : 19,
    INT : 6,
    MIN : 28,
    DYNAMICIDENTIFIER : 47,
    SKIP : 5,
    TOLOWER : 35,
    ANY : 24,
    SINGLE : 43,
    NEWLINE : 50,
    ALLPAGES : 12,
    AVERAGE : 30,
    NONE : 13,
    STARTSWITH : 32,
    OR : 15,
    ALIAS : 4,
    FILTER : 8,
    ASSIGN : 48,
    DESC : 38,
    TOP : 7,
    LONG : 42,
    STRING : 40,
    getGrammarFileName: function() { return "D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g"; }
});
org.antlr.lang.augmentObject(LinqToQuerystringLexer.prototype, {
    // $ANTLR start T__55
    mT__55: function()  {
        try {
            var _type = this.T__55;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:7:7: ( '&' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:7:9: '&'
            this.match('&'); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "T__55",

    // $ANTLR start T__56
    mT__56: function()  {
        try {
            var _type = this.T__56;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:8:7: ( ',' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:8:9: ','
            this.match(','); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "T__56",

    // $ANTLR start T__57
    mT__57: function()  {
        try {
            var _type = this.T__57;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:9:7: ( '(' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:9:9: '('
            this.match('('); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "T__57",

    // $ANTLR start T__58
    mT__58: function()  {
        try {
            var _type = this.T__58;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:10:7: ( ')' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:10:9: ')'
            this.match(')'); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "T__58",

    // $ANTLR start T__59
    mT__59: function()  {
        try {
            var _type = this.T__59;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:11:7: ( '/' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:11:9: '/'
            this.match('/'); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "T__59",

    // $ANTLR start T__60
    mT__60: function()  {
        try {
            var _type = this.T__60;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:12:7: ( ':' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:12:9: ':'
            this.match(':'); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "T__60",

    // $ANTLR start ASSIGN
    mASSIGN: function()  {
        try {
            var _type = this.ASSIGN;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:114:2: ( '=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:114:5: '='
            this.match('='); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "ASSIGN",

    // $ANTLR start EQUALS
    mEQUALS: function()  {
        try {
            var _type = this.EQUALS;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:117:2: ( 'eq' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:117:4: 'eq'
            this.match("eq"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "EQUALS",

    // $ANTLR start NOTEQUALS
    mNOTEQUALS: function()  {
        try {
            var _type = this.NOTEQUALS;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:120:2: ( 'ne' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:120:4: 'ne'
            this.match("ne"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "NOTEQUALS",

    // $ANTLR start GREATERTHAN
    mGREATERTHAN: function()  {
        try {
            var _type = this.GREATERTHAN;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:123:2: ( 'gt' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:123:4: 'gt'
            this.match("gt"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "GREATERTHAN",

    // $ANTLR start GREATERTHANOREQUAL
    mGREATERTHANOREQUAL: function()  {
        try {
            var _type = this.GREATERTHANOREQUAL;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:126:2: ( 'ge' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:126:4: 'ge'
            this.match("ge"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "GREATERTHANOREQUAL",

    // $ANTLR start LESSTHAN
    mLESSTHAN: function()  {
        try {
            var _type = this.LESSTHAN;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:129:2: ( 'lt' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:129:4: 'lt'
            this.match("lt"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "LESSTHAN",

    // $ANTLR start LESSTHANOREQUAL
    mLESSTHANOREQUAL: function()  {
        try {
            var _type = this.LESSTHANOREQUAL;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:132:2: ( 'le' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:132:4: 'le'
            this.match("le"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "LESSTHANOREQUAL",

    // $ANTLR start NOT
    mNOT: function()  {
        try {
            var _type = this.NOT;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:135:2: ( 'not' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:135:4: 'not'
            this.match("not"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "NOT",

    // $ANTLR start OR
    mOR: function()  {
        try {
            var _type = this.OR;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:138:2: ( 'or' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:138:4: 'or'
            this.match("or"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "OR",

    // $ANTLR start AND
    mAND: function()  {
        try {
            var _type = this.AND;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:141:2: ( 'and' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:141:5: 'and'
            this.match("and"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "AND",

    // $ANTLR start ASC
    mASC: function()  {
        try {
            var _type = this.ASC;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:144:2: ( 'asc' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:144:4: 'asc'
            this.match("asc"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "ASC",

    // $ANTLR start DESC
    mDESC: function()  {
        try {
            var _type = this.DESC;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:147:2: ( 'desc' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:147:4: 'desc'
            this.match("desc"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "DESC",

    // $ANTLR start ALLPAGES
    mALLPAGES: function()  {
        try {
            var _type = this.ALLPAGES;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:150:2: ( 'allpages' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:150:5: 'allpages'
            this.match("allpages"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "ALLPAGES",

    // $ANTLR start NONE
    mNONE: function()  {
        try {
            var _type = this.NONE;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:153:2: ( 'none' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:153:4: 'none'
            this.match("none"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "NONE",

    // $ANTLR start SKIP
    mSKIP: function()  {
        try {
            var _type = this.SKIP;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:156:2: ( '$skip=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:156:4: '$skip='
            this.match("$skip="); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "SKIP",

    // $ANTLR start TOP
    mTOP: function()  {
        try {
            var _type = this.TOP;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:159:2: ( '$top=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:159:4: '$top='
            this.match("$top="); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "TOP",

    // $ANTLR start FILTER
    mFILTER: function()  {
        try {
            var _type = this.FILTER;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:162:2: ( '$filter=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:162:4: '$filter='
            this.match("$filter="); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "FILTER",

    // $ANTLR start ORDERBY
    mORDERBY: function()  {
        try {
            var _type = this.ORDERBY;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:165:2: ( '$orderby=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:165:4: '$orderby='
            this.match("$orderby="); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "ORDERBY",

    // $ANTLR start SELECT
    mSELECT: function()  {
        try {
            var _type = this.SELECT;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:168:2: ( '$select=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:168:4: '$select='
            this.match("$select="); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "SELECT",

    // $ANTLR start INLINECOUNT
    mINLINECOUNT: function()  {
        try {
            var _type = this.INLINECOUNT;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:171:2: ( '$inlinecount=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:171:4: '$inlinecount='
            this.match("$inlinecount="); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "INLINECOUNT",

    // $ANTLR start EXPAND
    mEXPAND: function()  {
        try {
            var _type = this.EXPAND;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:173:8: ( '$expand=' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:173:10: '$expand='
            this.match("$expand="); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "EXPAND",

    // $ANTLR start STARTSWITH
    mSTARTSWITH: function()  {
        try {
            var _type = this.STARTSWITH;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:176:2: ( 'startswith' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:176:4: 'startswith'
            this.match("startswith"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "STARTSWITH",

    // $ANTLR start ENDSWITH
    mENDSWITH: function()  {
        try {
            var _type = this.ENDSWITH;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:179:2: ( 'endswith' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:179:4: 'endswith'
            this.match("endswith"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "ENDSWITH",

    // $ANTLR start SUBSTRINGOF
    mSUBSTRINGOF: function()  {
        try {
            var _type = this.SUBSTRINGOF;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:182:2: ( 'substringof' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:182:4: 'substringof'
            this.match("substringof"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "SUBSTRINGOF",

    // $ANTLR start TOLOWER
    mTOLOWER: function()  {
        try {
            var _type = this.TOLOWER;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:185:2: ( 'tolower' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:185:4: 'tolower'
            this.match("tolower"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "TOLOWER",

    // $ANTLR start ANY
    mANY: function()  {
        try {
            var _type = this.ANY;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:187:5: ( 'any' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:187:8: 'any'
            this.match("any"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "ANY",

    // $ANTLR start ALL
    mALL: function()  {
        try {
            var _type = this.ALL;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:189:5: ( 'all' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:189:7: 'all'
            this.match("all"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "ALL",

    // $ANTLR start COUNT
    mCOUNT: function()  {
        try {
            var _type = this.COUNT;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:191:7: ( 'count' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:191:9: 'count'
            this.match("count"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "COUNT",

    // $ANTLR start MIN
    mMIN: function()  {
        try {
            var _type = this.MIN;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:193:5: ( 'min' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:193:7: 'min'
            this.match("min"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "MIN",

    // $ANTLR start MAX
    mMAX: function()  {
        try {
            var _type = this.MAX;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:195:5: ( 'max' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:195:7: 'max'
            this.match("max"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "MAX",

    // $ANTLR start SUM
    mSUM: function()  {
        try {
            var _type = this.SUM;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:197:5: ( 'sum' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:197:7: 'sum'
            this.match("sum"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "SUM",

    // $ANTLR start AVERAGE
    mAVERAGE: function()  {
        try {
            var _type = this.AVERAGE;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:199:9: ( 'average' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:199:11: 'average'
            this.match("average"); 




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "AVERAGE",

    // $ANTLR start INT
    mINT: function()  {
        try {
            var _type = this.INT;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:201:5: ( ( '-' )? ( '0' .. '9' )+ )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:201:7: ( '-' )? ( '0' .. '9' )+
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:201:7: ( '-' )?
            var alt1=2;
            var LA1_0 = this.input.LA(1);

            if ( (LA1_0=='-') ) {
                alt1=1;
            }
            switch (alt1) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:201:8: '-'
                    this.match('-'); 


                    break;

            }

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:201:14: ( '0' .. '9' )+
            var cnt2=0;
            loop2:
            do {
                var alt2=2;
                var LA2_0 = this.input.LA(1);

                if ( ((LA2_0>='0' && LA2_0<='9')) ) {
                    alt2=1;
                }


                switch (alt2) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:201:14: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt2 >= 1 ) {
                        break loop2;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(2, this.input);
                        throw eee;
                }
                cnt2++;
            } while (true);




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "INT",

    // $ANTLR start LONG
    mLONG: function()  {
        try {
            var _type = this.LONG;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:203:6: ( ( '-' )? ( '0' .. '9' )+ 'L' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:203:8: ( '-' )? ( '0' .. '9' )+ 'L'
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:203:8: ( '-' )?
            var alt3=2;
            var LA3_0 = this.input.LA(1);

            if ( (LA3_0=='-') ) {
                alt3=1;
            }
            switch (alt3) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:203:9: '-'
                    this.match('-'); 


                    break;

            }

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:203:15: ( '0' .. '9' )+
            var cnt4=0;
            loop4:
            do {
                var alt4=2;
                var LA4_0 = this.input.LA(1);

                if ( ((LA4_0>='0' && LA4_0<='9')) ) {
                    alt4=1;
                }


                switch (alt4) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:203:16: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt4 >= 1 ) {
                        break loop4;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(4, this.input);
                        throw eee;
                }
                cnt4++;
            } while (true);

            this.match('L'); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "LONG",

    // $ANTLR start DOUBLE
    mDOUBLE: function()  {
        try {
            var _type = this.DOUBLE;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:8: ( ( '-' )? ( '0' .. '9' )+ '.' ( '0' .. '9' )+ )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:10: ( '-' )? ( '0' .. '9' )+ '.' ( '0' .. '9' )+
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:10: ( '-' )?
            var alt5=2;
            var LA5_0 = this.input.LA(1);

            if ( (LA5_0=='-') ) {
                alt5=1;
            }
            switch (alt5) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:11: '-'
                    this.match('-'); 


                    break;

            }

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:17: ( '0' .. '9' )+
            var cnt6=0;
            loop6:
            do {
                var alt6=2;
                var LA6_0 = this.input.LA(1);

                if ( ((LA6_0>='0' && LA6_0<='9')) ) {
                    alt6=1;
                }


                switch (alt6) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:18: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt6 >= 1 ) {
                        break loop6;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(6, this.input);
                        throw eee;
                }
                cnt6++;
            } while (true);

            this.match('.'); 
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:33: ( '0' .. '9' )+
            var cnt7=0;
            loop7:
            do {
                var alt7=2;
                var LA7_0 = this.input.LA(1);

                if ( ((LA7_0>='0' && LA7_0<='9')) ) {
                    alt7=1;
                }


                switch (alt7) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:205:34: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt7 >= 1 ) {
                        break loop7;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(7, this.input);
                        throw eee;
                }
                cnt7++;
            } while (true);




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "DOUBLE",

    // $ANTLR start SINGLE
    mSINGLE: function()  {
        try {
            var _type = this.SINGLE;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:8: ( ( '-' )? ( '0' .. '9' )+ '.' ( '0' .. '9' )+ 'f' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:10: ( '-' )? ( '0' .. '9' )+ '.' ( '0' .. '9' )+ 'f'
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:10: ( '-' )?
            var alt8=2;
            var LA8_0 = this.input.LA(1);

            if ( (LA8_0=='-') ) {
                alt8=1;
            }
            switch (alt8) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:11: '-'
                    this.match('-'); 


                    break;

            }

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:17: ( '0' .. '9' )+
            var cnt9=0;
            loop9:
            do {
                var alt9=2;
                var LA9_0 = this.input.LA(1);

                if ( ((LA9_0>='0' && LA9_0<='9')) ) {
                    alt9=1;
                }


                switch (alt9) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:18: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt9 >= 1 ) {
                        break loop9;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(9, this.input);
                        throw eee;
                }
                cnt9++;
            } while (true);

            this.match('.'); 
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:33: ( '0' .. '9' )+
            var cnt10=0;
            loop10:
            do {
                var alt10=2;
                var LA10_0 = this.input.LA(1);

                if ( ((LA10_0>='0' && LA10_0<='9')) ) {
                    alt10=1;
                }


                switch (alt10) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:207:34: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt10 >= 1 ) {
                        break loop10;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(10, this.input);
                        throw eee;
                }
                cnt10++;
            } while (true);

            this.match('f'); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "SINGLE",

    // $ANTLR start BOOL
    mBOOL: function()  {
        try {
            var _type = this.BOOL;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:209:6: ( ( 'true' | 'false' ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:209:8: ( 'true' | 'false' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:209:8: ( 'true' | 'false' )
            var alt11=2;
            var LA11_0 = this.input.LA(1);

            if ( (LA11_0=='t') ) {
                alt11=1;
            }
            else if ( (LA11_0=='f') ) {
                alt11=2;
            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 11, 0, this.input);

                throw nvae;
            }
            switch (alt11) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:209:9: 'true'
                    this.match("true"); 



                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:209:18: 'false'
                    this.match("false"); 



                    break;

            }




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "BOOL",

    // $ANTLR start DATETIME
    mDATETIME: function()  {
        try {
            var _type = this.DATETIME;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:2: ( 'datetime\\'' ( '0' .. '9' )+ '-' ( '0' .. '9' )+ ( '-' )+ ( '0' .. '9' )+ 'T' ( '0' .. '9' )+ ':' ( '0' .. '9' )+ ( ':' ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )* )* '\\'' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:4: 'datetime\\'' ( '0' .. '9' )+ '-' ( '0' .. '9' )+ ( '-' )+ ( '0' .. '9' )+ 'T' ( '0' .. '9' )+ ':' ( '0' .. '9' )+ ( ':' ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )* )* '\\''
            this.match("datetime\'"); 

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:17: ( '0' .. '9' )+
            var cnt12=0;
            loop12:
            do {
                var alt12=2;
                var LA12_0 = this.input.LA(1);

                if ( ((LA12_0>='0' && LA12_0<='9')) ) {
                    alt12=1;
                }


                switch (alt12) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:17: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt12 >= 1 ) {
                        break loop12;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(12, this.input);
                        throw eee;
                }
                cnt12++;
            } while (true);

            this.match('-'); 
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:31: ( '0' .. '9' )+
            var cnt13=0;
            loop13:
            do {
                var alt13=2;
                var LA13_0 = this.input.LA(1);

                if ( ((LA13_0>='0' && LA13_0<='9')) ) {
                    alt13=1;
                }


                switch (alt13) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:31: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt13 >= 1 ) {
                        break loop13;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(13, this.input);
                        throw eee;
                }
                cnt13++;
            } while (true);

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:41: ( '-' )+
            var cnt14=0;
            loop14:
            do {
                var alt14=2;
                var LA14_0 = this.input.LA(1);

                if ( (LA14_0=='-') ) {
                    alt14=1;
                }


                switch (alt14) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:41: '-'
                    this.match('-'); 


                    break;

                default :
                    if ( cnt14 >= 1 ) {
                        break loop14;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(14, this.input);
                        throw eee;
                }
                cnt14++;
            } while (true);

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:47: ( '0' .. '9' )+
            var cnt15=0;
            loop15:
            do {
                var alt15=2;
                var LA15_0 = this.input.LA(1);

                if ( ((LA15_0>='0' && LA15_0<='9')) ) {
                    alt15=1;
                }


                switch (alt15) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:47: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt15 >= 1 ) {
                        break loop15;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(15, this.input);
                        throw eee;
                }
                cnt15++;
            } while (true);

            this.match('T'); 
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:61: ( '0' .. '9' )+
            var cnt16=0;
            loop16:
            do {
                var alt16=2;
                var LA16_0 = this.input.LA(1);

                if ( ((LA16_0>='0' && LA16_0<='9')) ) {
                    alt16=1;
                }


                switch (alt16) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:61: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt16 >= 1 ) {
                        break loop16;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(16, this.input);
                        throw eee;
                }
                cnt16++;
            } while (true);

            this.match(':'); 
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:75: ( '0' .. '9' )+
            var cnt17=0;
            loop17:
            do {
                var alt17=2;
                var LA17_0 = this.input.LA(1);

                if ( ((LA17_0>='0' && LA17_0<='9')) ) {
                    alt17=1;
                }


                switch (alt17) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:75: '0' .. '9'
                    this.matchRange('0','9'); 


                    break;

                default :
                    if ( cnt17 >= 1 ) {
                        break loop17;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(17, this.input);
                        throw eee;
                }
                cnt17++;
            } while (true);

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:85: ( ':' ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )* )*
            loop21:
            do {
                var alt21=2;
                var LA21_0 = this.input.LA(1);

                if ( (LA21_0==':') ) {
                    alt21=1;
                }


                switch (alt21) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:86: ':' ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )*
                    this.match(':'); 
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:90: ( '0' .. '9' )+
                    var cnt18=0;
                    loop18:
                    do {
                        var alt18=2;
                        var LA18_0 = this.input.LA(1);

                        if ( ((LA18_0>='0' && LA18_0<='9')) ) {
                            alt18=1;
                        }


                        switch (alt18) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:90: '0' .. '9'
                            this.matchRange('0','9'); 


                            break;

                        default :
                            if ( cnt18 >= 1 ) {
                                break loop18;
                            }
                                var eee = new org.antlr.runtime.EarlyExitException(18, this.input);
                                throw eee;
                        }
                        cnt18++;
                    } while (true);

                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:100: ( '.' ( '0' .. '9' )+ )*
                    loop20:
                    do {
                        var alt20=2;
                        var LA20_0 = this.input.LA(1);

                        if ( (LA20_0=='.') ) {
                            alt20=1;
                        }


                        switch (alt20) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:101: '.' ( '0' .. '9' )+
                            this.match('.'); 
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:105: ( '0' .. '9' )+
                            var cnt19=0;
                            loop19:
                            do {
                                var alt19=2;
                                var LA19_0 = this.input.LA(1);

                                if ( ((LA19_0>='0' && LA19_0<='9')) ) {
                                    alt19=1;
                                }


                                switch (alt19) {
                                case 1 :
                                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:212:105: '0' .. '9'
                                    this.matchRange('0','9'); 


                                    break;

                                default :
                                    if ( cnt19 >= 1 ) {
                                        break loop19;
                                    }
                                        var eee = new org.antlr.runtime.EarlyExitException(19, this.input);
                                        throw eee;
                                }
                                cnt19++;
                            } while (true);



                            break;

                        default :
                            break loop20;
                        }
                    } while (true);



                    break;

                default :
                    break loop21;
                }
            } while (true);

            this.match('\''); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "DATETIME",

    // $ANTLR start GUID
    mGUID: function()  {
        try {
            var _type = this.GUID;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:214:6: ( 'guid\\'' HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR '\\'' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:214:8: 'guid\\'' HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR '-' HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR HEX_PAIR '\\''
            this.match("guid\'"); 

            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.match('-'); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.match('-'); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.match('-'); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.match('-'); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.mHEX_PAIR(); 
            this.match('\''); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "GUID",

    // $ANTLR start BYTE
    mBYTE: function()  {
        try {
            var _type = this.BYTE;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:216:6: ( '0x' HEX_PAIR )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:216:8: '0x' HEX_PAIR
            this.match("0x"); 

            this.mHEX_PAIR(); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "BYTE",

    // $ANTLR start SPACE
    mSPACE: function()  {
        try {
            var _type = this.SPACE;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:218:7: ( ( ' ' | '\\t' )+ )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:218:9: ( ' ' | '\\t' )+
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:218:9: ( ' ' | '\\t' )+
            var cnt22=0;
            loop22:
            do {
                var alt22=2;
                var LA22_0 = this.input.LA(1);

                if ( (LA22_0=='\t'||LA22_0==' ') ) {
                    alt22=1;
                }


                switch (alt22) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:
                    if ( this.input.LA(1)=='\t'||this.input.LA(1)==' ' ) {
                        this.input.consume();

                    }
                    else {
                        var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                        this.recover(mse);
                        throw mse;}



                    break;

                default :
                    if ( cnt22 >= 1 ) {
                        break loop22;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(22, this.input);
                        throw eee;
                }
                cnt22++;
            } while (true);




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "SPACE",

    // $ANTLR start NEWLINE
    mNEWLINE: function()  {
        try {
            var _type = this.NEWLINE;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:220:9: ( ( '\\r' | '\\n' )+ )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:220:11: ( '\\r' | '\\n' )+
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:220:11: ( '\\r' | '\\n' )+
            var cnt23=0;
            loop23:
            do {
                var alt23=2;
                var LA23_0 = this.input.LA(1);

                if ( (LA23_0=='\n'||LA23_0=='\r') ) {
                    alt23=1;
                }


                switch (alt23) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:
                    if ( this.input.LA(1)=='\n'||this.input.LA(1)=='\r' ) {
                        this.input.consume();

                    }
                    else {
                        var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                        this.recover(mse);
                        throw mse;}



                    break;

                default :
                    if ( cnt23 >= 1 ) {
                        break loop23;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(23, this.input);
                        throw eee;
                }
                cnt23++;
            } while (true);




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "NEWLINE",

    // $ANTLR start DYNAMICIDENTIFIER
    mDYNAMICIDENTIFIER: function()  {
        try {
            var _type = this.DYNAMICIDENTIFIER;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:223:2: ( '[' ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )+ ']' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:223:4: '[' ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )+ ']'
            this.match('['); 
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:223:8: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )+
            var cnt24=0;
            loop24:
            do {
                var alt24=2;
                var LA24_0 = this.input.LA(1);

                if ( ((LA24_0>='0' && LA24_0<='9')||(LA24_0>='A' && LA24_0<='Z')||LA24_0=='_'||(LA24_0>='a' && LA24_0<='z')) ) {
                    alt24=1;
                }


                switch (alt24) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:
                    if ( (this.input.LA(1)>='0' && this.input.LA(1)<='9')||(this.input.LA(1)>='A' && this.input.LA(1)<='Z')||this.input.LA(1)=='_'||(this.input.LA(1)>='a' && this.input.LA(1)<='z') ) {
                        this.input.consume();

                    }
                    else {
                        var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                        this.recover(mse);
                        throw mse;}



                    break;

                default :
                    if ( cnt24 >= 1 ) {
                        break loop24;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(24, this.input);
                        throw eee;
                }
                cnt24++;
            } while (true);

            this.match(']'); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "DYNAMICIDENTIFIER",

    // $ANTLR start HEX_PAIR
    mHEX_PAIR: function()  {
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:227:2: ( HEX_DIGIT HEX_DIGIT )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:227:4: HEX_DIGIT HEX_DIGIT
            this.mHEX_DIGIT(); 
            this.mHEX_DIGIT(); 



        }
        finally {
        }
    },
    // $ANTLR end "HEX_PAIR",

    // $ANTLR start IDENTIFIER
    mIDENTIFIER: function()  {
        try {
            var _type = this.IDENTIFIER;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:230:2: ( ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )+ )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:230:4: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )+
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:230:4: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )+
            var cnt25=0;
            loop25:
            do {
                var alt25=2;
                var LA25_0 = this.input.LA(1);

                if ( ((LA25_0>='0' && LA25_0<='9')||(LA25_0>='A' && LA25_0<='Z')||LA25_0=='_'||(LA25_0>='a' && LA25_0<='z')) ) {
                    alt25=1;
                }


                switch (alt25) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:
                    if ( (this.input.LA(1)>='0' && this.input.LA(1)<='9')||(this.input.LA(1)>='A' && this.input.LA(1)<='Z')||this.input.LA(1)=='_'||(this.input.LA(1)>='a' && this.input.LA(1)<='z') ) {
                        this.input.consume();

                    }
                    else {
                        var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                        this.recover(mse);
                        throw mse;}



                    break;

                default :
                    if ( cnt25 >= 1 ) {
                        break loop25;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(25, this.input);
                        throw eee;
                }
                cnt25++;
            } while (true);




            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "IDENTIFIER",

    // $ANTLR start STRING
    mSTRING: function()  {
        try {
            var _type = this.STRING;
            var _channel = org.antlr.runtime.BaseRecognizer.DEFAULT_TOKEN_CHANNEL;
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:232:9: ( '\\'' ( ESC_SEQ | ~ ( '\\\\' | '\\'' ) )* '\\'' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:232:12: '\\'' ( ESC_SEQ | ~ ( '\\\\' | '\\'' ) )* '\\''
            this.match('\''); 
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:232:17: ( ESC_SEQ | ~ ( '\\\\' | '\\'' ) )*
            loop26:
            do {
                var alt26=3;
                var LA26_0 = this.input.LA(1);

                if ( (LA26_0=='\'') ) {
                    var LA26_1 = this.input.LA(2);

                    if ( (LA26_1=='\'') ) {
                        alt26=1;
                    }


                }
                else if ( (LA26_0=='\\') ) {
                    alt26=1;
                }
                else if ( ((LA26_0>='\u0000' && LA26_0<='&')||(LA26_0>='(' && LA26_0<='[')||(LA26_0>=']' && LA26_0<='\uFFFF')) ) {
                    alt26=2;
                }


                switch (alt26) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:232:18: ESC_SEQ
                    this.mESC_SEQ(); 


                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:232:27: ~ ( '\\\\' | '\\'' )
                    if ( (this.input.LA(1)>='\u0000' && this.input.LA(1)<='&')||(this.input.LA(1)>='(' && this.input.LA(1)<='[')||(this.input.LA(1)>=']' && this.input.LA(1)<='\uFFFF') ) {
                        this.input.consume();

                    }
                    else {
                        var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                        this.recover(mse);
                        throw mse;}



                    break;

                default :
                    break loop26;
                }
            } while (true);

            this.match('\''); 



            this.state.type = _type;
            this.state.channel = _channel;
        }
        finally {
        }
    },
    // $ANTLR end "STRING",

    // $ANTLR start HEX_DIGIT
    mHEX_DIGIT: function()  {
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:235:11: ( ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:235:13: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )
            if ( (this.input.LA(1)>='0' && this.input.LA(1)<='9')||(this.input.LA(1)>='A' && this.input.LA(1)<='F')||(this.input.LA(1)>='a' && this.input.LA(1)<='f') ) {
                this.input.consume();

            }
            else {
                var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                this.recover(mse);
                throw mse;}




        }
        finally {
        }
    },
    // $ANTLR end "HEX_DIGIT",

    // $ANTLR start ESC_SEQ
    mESC_SEQ: function()  {
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:239:2: ( '\\'\\'' | '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) | UNICODE_ESC | OCTAL_ESC )
            var alt27=4;
            var LA27_0 = this.input.LA(1);

            if ( (LA27_0=='\'') ) {
                alt27=1;
            }
            else if ( (LA27_0=='\\') ) {
                switch ( this.input.LA(2) ) {
                case '\"':
                case '\'':
                case '\\':
                case 'b':
                case 'f':
                case 'n':
                case 'r':
                case 't':
                    alt27=2;
                    break;
                case 'u':
                    alt27=3;
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                    alt27=4;
                    break;
                default:
                    var nvae =
                        new org.antlr.runtime.NoViableAltException("", 27, 2, this.input);

                    throw nvae;
                }

            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 27, 0, this.input);

                throw nvae;
            }
            switch (alt27) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:239:4: '\\'\\''
                    this.match("\'\'"); 



                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:240:5: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
                    this.match('\\'); 
                    if ( this.input.LA(1)=='\"'||this.input.LA(1)=='\''||this.input.LA(1)=='\\'||this.input.LA(1)=='b'||this.input.LA(1)=='f'||this.input.LA(1)=='n'||this.input.LA(1)=='r'||this.input.LA(1)=='t' ) {
                        this.input.consume();

                    }
                    else {
                        var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                        this.recover(mse);
                        throw mse;}



                    break;
                case 3 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:241:5: UNICODE_ESC
                    this.mUNICODE_ESC(); 


                    break;
                case 4 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:242:5: OCTAL_ESC
                    this.mOCTAL_ESC(); 


                    break;

            }
        }
        finally {
        }
    },
    // $ANTLR end "ESC_SEQ",

    // $ANTLR start OCTAL_ESC
    mOCTAL_ESC: function()  {
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:3: ( '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) )
            var alt28=3;
            var LA28_0 = this.input.LA(1);

            if ( (LA28_0=='\\') ) {
                var LA28_1 = this.input.LA(2);

                if ( ((LA28_1>='0' && LA28_1<='3')) ) {
                    var LA28_2 = this.input.LA(3);

                    if ( ((LA28_2>='0' && LA28_2<='7')) ) {
                        var LA28_5 = this.input.LA(4);

                        if ( ((LA28_5>='0' && LA28_5<='7')) ) {
                            alt28=1;
                        }
                        else {
                            alt28=2;}
                    }
                    else {
                        alt28=3;}
                }
                else if ( ((LA28_1>='4' && LA28_1<='7')) ) {
                    var LA28_3 = this.input.LA(3);

                    if ( ((LA28_3>='0' && LA28_3<='7')) ) {
                        alt28=2;
                    }
                    else {
                        alt28=3;}
                }
                else {
                    var nvae =
                        new org.antlr.runtime.NoViableAltException("", 28, 1, this.input);

                    throw nvae;
                }
            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 28, 0, this.input);

                throw nvae;
            }
            switch (alt28) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:7: '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' )
                    this.match('\\'); 
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:12: ( '0' .. '3' )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:13: '0' .. '3'
                    this.matchRange('0','3'); 



                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:23: ( '0' .. '7' )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:24: '0' .. '7'
                    this.matchRange('0','7'); 



                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:34: ( '0' .. '7' )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:247:35: '0' .. '7'
                    this.matchRange('0','7'); 





                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:248:7: '\\\\' ( '0' .. '7' ) ( '0' .. '7' )
                    this.match('\\'); 
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:248:12: ( '0' .. '7' )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:248:13: '0' .. '7'
                    this.matchRange('0','7'); 



                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:248:23: ( '0' .. '7' )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:248:24: '0' .. '7'
                    this.matchRange('0','7'); 





                    break;
                case 3 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:249:7: '\\\\' ( '0' .. '7' )
                    this.match('\\'); 
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:249:12: ( '0' .. '7' )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:249:13: '0' .. '7'
                    this.matchRange('0','7'); 





                    break;

            }
        }
        finally {
        }
    },
    // $ANTLR end "OCTAL_ESC",

    // $ANTLR start UNICODE_ESC
    mUNICODE_ESC: function()  {
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:254:3: ( '\\\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:254:7: '\\\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT
            this.match('\\'); 
            this.match('u'); 
            this.mHEX_DIGIT(); 
            this.mHEX_DIGIT(); 
            this.mHEX_DIGIT(); 
            this.mHEX_DIGIT(); 



        }
        finally {
        }
    },
    // $ANTLR end "UNICODE_ESC",

    mTokens: function() {
        // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:8: ( T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | ASSIGN | EQUALS | NOTEQUALS | GREATERTHAN | GREATERTHANOREQUAL | LESSTHAN | LESSTHANOREQUAL | NOT | OR | AND | ASC | DESC | ALLPAGES | NONE | SKIP | TOP | FILTER | ORDERBY | SELECT | INLINECOUNT | EXPAND | STARTSWITH | ENDSWITH | SUBSTRINGOF | TOLOWER | ANY | ALL | COUNT | MIN | MAX | SUM | AVERAGE | INT | LONG | DOUBLE | SINGLE | BOOL | DATETIME | GUID | BYTE | SPACE | NEWLINE | DYNAMICIDENTIFIER | IDENTIFIER | STRING )
        var alt29=51;
        alt29 = this.dfa29.predict(this.input);
        switch (alt29) {
            case 1 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:10: T__55
                this.mT__55(); 


                break;
            case 2 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:16: T__56
                this.mT__56(); 


                break;
            case 3 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:22: T__57
                this.mT__57(); 


                break;
            case 4 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:28: T__58
                this.mT__58(); 


                break;
            case 5 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:34: T__59
                this.mT__59(); 


                break;
            case 6 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:40: T__60
                this.mT__60(); 


                break;
            case 7 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:46: ASSIGN
                this.mASSIGN(); 


                break;
            case 8 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:53: EQUALS
                this.mEQUALS(); 


                break;
            case 9 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:60: NOTEQUALS
                this.mNOTEQUALS(); 


                break;
            case 10 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:70: GREATERTHAN
                this.mGREATERTHAN(); 


                break;
            case 11 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:82: GREATERTHANOREQUAL
                this.mGREATERTHANOREQUAL(); 


                break;
            case 12 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:101: LESSTHAN
                this.mLESSTHAN(); 


                break;
            case 13 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:110: LESSTHANOREQUAL
                this.mLESSTHANOREQUAL(); 


                break;
            case 14 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:126: NOT
                this.mNOT(); 


                break;
            case 15 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:130: OR
                this.mOR(); 


                break;
            case 16 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:133: AND
                this.mAND(); 


                break;
            case 17 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:137: ASC
                this.mASC(); 


                break;
            case 18 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:141: DESC
                this.mDESC(); 


                break;
            case 19 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:146: ALLPAGES
                this.mALLPAGES(); 


                break;
            case 20 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:155: NONE
                this.mNONE(); 


                break;
            case 21 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:160: SKIP
                this.mSKIP(); 


                break;
            case 22 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:165: TOP
                this.mTOP(); 


                break;
            case 23 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:169: FILTER
                this.mFILTER(); 


                break;
            case 24 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:176: ORDERBY
                this.mORDERBY(); 


                break;
            case 25 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:184: SELECT
                this.mSELECT(); 


                break;
            case 26 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:191: INLINECOUNT
                this.mINLINECOUNT(); 


                break;
            case 27 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:203: EXPAND
                this.mEXPAND(); 


                break;
            case 28 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:210: STARTSWITH
                this.mSTARTSWITH(); 


                break;
            case 29 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:221: ENDSWITH
                this.mENDSWITH(); 


                break;
            case 30 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:230: SUBSTRINGOF
                this.mSUBSTRINGOF(); 


                break;
            case 31 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:242: TOLOWER
                this.mTOLOWER(); 


                break;
            case 32 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:250: ANY
                this.mANY(); 


                break;
            case 33 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:254: ALL
                this.mALL(); 


                break;
            case 34 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:258: COUNT
                this.mCOUNT(); 


                break;
            case 35 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:264: MIN
                this.mMIN(); 


                break;
            case 36 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:268: MAX
                this.mMAX(); 


                break;
            case 37 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:272: SUM
                this.mSUM(); 


                break;
            case 38 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:276: AVERAGE
                this.mAVERAGE(); 


                break;
            case 39 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:284: INT
                this.mINT(); 


                break;
            case 40 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:288: LONG
                this.mLONG(); 


                break;
            case 41 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:293: DOUBLE
                this.mDOUBLE(); 


                break;
            case 42 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:300: SINGLE
                this.mSINGLE(); 


                break;
            case 43 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:307: BOOL
                this.mBOOL(); 


                break;
            case 44 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:312: DATETIME
                this.mDATETIME(); 


                break;
            case 45 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:321: GUID
                this.mGUID(); 


                break;
            case 46 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:326: BYTE
                this.mBYTE(); 


                break;
            case 47 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:331: SPACE
                this.mSPACE(); 


                break;
            case 48 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:337: NEWLINE
                this.mNEWLINE(); 


                break;
            case 49 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:345: DYNAMICIDENTIFIER
                this.mDYNAMICIDENTIFIER(); 


                break;
            case 50 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:363: IDENTIFIER
                this.mIDENTIFIER(); 


                break;
            case 51 :
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:1:374: STRING
                this.mSTRING(); 


                break;

        }

    }

}, true); // important to pass true to overwrite default implementations

org.antlr.lang.augmentObject(LinqToQuerystringLexer, {
    DFA29_eotS:
        "\u0008\uffff\u0007\u001b\u0001\uffff\u0004\u001b\u0001\uffff\u0001"+
    "\u003c\u0001\u001b\u0001\u003c\u0005\uffff\u0001\u0040\u0001\u001b\u0001"+
    "\u0042\u0001\u001b\u0001\u0045\u0001\u0046\u0001\u001b\u0001\u0048\u0001"+
    "\u0049\u0001\u004a\u0006\u001b\u0006\uffff\u0007\u001b\u0001\u003c\u0001"+
    "\u001b\u0001\uffff\u0001\u005c\u0001\uffff\u0001\u001b\u0001\uffff\u0001"+
    "\u001b\u0001\uffff\u0001\u0061\u0001\u001b\u0002\uffff\u0001\u001b\u0003"+
    "\uffff\u0001\u0064\u0001\u0065\u0001\u0066\u0001\u0068\u0003\u001b\u0002"+
    "\uffff\u0002\u001b\u0001\u006e\u0003\u001b\u0001\u0072\u0001\u0073\u0001"+
    "\uffff\u0001\u001b\u0001\u0075\u0002\u001b\u0001\uffff\u0001\u0079\u0001"+
    "\u001b\u0003\uffff\u0001\u001b\u0001\uffff\u0001\u001b\u0001\u007d\u0003"+
    "\u001b\u0001\uffff\u0001\u001b\u0001\u0082\u0001\u001b\u0002\uffff\u0001"+
    "\u0084\u0002\uffff\u0002\u001b\u0002\uffff\u0002\u001b\u0001\uffff\u0004"+
    "\u001b\u0001\uffff\u0001\u008d\u0001\uffff\u0001\u0082\u0007\u001b\u0001"+
    "\uffff\u0002\u001b\u0001\u0097\u0003\u001b\u0001\u009b\u0001\u009c\u0001"+
    "\u009d\u0001\uffff\u0003\u001b\u0004\uffff\u0002\u001b\u0001\u00a3\u0001"+
    "\u001b\u0001\uffff\u0001\u00a5\u0001\uffff",
    DFA29_eofS:
        "\u00a6\uffff",
    DFA29_minS:
        "\u0001\u0009\u0007\uffff\u0001\u006e\u0003\u0065\u0001\u0072\u0001"+
    "\u006c\u0001\u0061\u0001\u0065\u0001\u0074\u0002\u006f\u0001\u0061\u0001"+
    "\u0030\u0001\u002e\u0001\u0061\u0001\u002e\u0005\uffff\u0001\u0030\u0001"+
    "\u0064\u0001\u0030\u0001\u006e\u0002\u0030\u0001\u0069\u0003\u0030\u0001"+
    "\u0064\u0001\u0063\u0001\u006c\u0001\u0065\u0001\u0073\u0001\u0074\u0001"+
    "\u0065\u0005\uffff\u0001\u0061\u0001\u0062\u0001\u006c\u0002\u0075\u0001"+
    "\u006e\u0001\u0078\u0001\u002e\u0001\u0030\u0001\uffff\u0002\u0030\u0001"+
    "\u006c\u0001\uffff\u0001\u0073\u0001\uffff\u0001\u0030\u0001\u0065\u0002"+
    "\uffff\u0001\u0064\u0003\uffff\u0004\u0030\u0001\u0072\u0001\u0063\u0001"+
    "\u0065\u0002\uffff\u0001\u0072\u0001\u0073\u0001\u0030\u0001\u006f\u0001"+
    "\u0065\u0001\u006e\u0002\u0030\u0001\uffff\u0002\u0030\u0001\u0073\u0001"+
    "\u0077\u0001\uffff\u0001\u0030\u0001\u0027\u0003\uffff\u0001\u0061\u0001"+
    "\uffff\u0001\u0061\u0001\u0030\u0003\u0074\u0001\uffff\u0001\u0077\u0001"+
    "\u0030\u0001\u0074\u0002\uffff\u0001\u0030\u0002\uffff\u0001\u0065\u0001"+
    "\u0069\u0002\uffff\u0002\u0067\u0001\uffff\u0001\u0069\u0001\u0073\u0001"+
    "\u0072\u0001\u0065\u0001\uffff\u0001\u0030\u0001\uffff\u0001\u0030\u0001"+
    "\u0074\u0002\u0065\u0001\u006d\u0001\u0077\u0001\u0069\u0001\u0072\u0001"+
    "\uffff\u0001\u0068\u0001\u0073\u0001\u0030\u0001\u0065\u0001\u0069\u0001"+
    "\u006e\u0003\u0030\u0001\uffff\u0001\u0027\u0001\u0074\u0001\u0067\u0004"+
    "\uffff\u0001\u0068\u0001\u006f\u0001\u0030\u0001\u0066\u0001\uffff\u0001"+
    "\u0030\u0001\uffff",
    DFA29_maxS:
        "\u0001\u007a\u0007\uffff\u0001\u0071\u0001\u006f\u0001\u0075\u0001"+
    "\u0074\u0001\u0072\u0001\u0076\u0001\u0065\u0001\u0074\u0001\u0075\u0001"+
    "\u0072\u0001\u006f\u0001\u0069\u0001\u0039\u0001\u007a\u0001\u0061\u0001"+
    "\u007a\u0005\uffff\u0001\u007a\u0001\u0064\u0001\u007a\u0001\u0074\u0002"+
    "\u007a\u0001\u0069\u0003\u007a\u0001\u0079\u0001\u0063\u0001\u006c\u0001"+
    "\u0065\u0001\u0073\u0001\u0074\u0001\u006b\u0005\uffff\u0001\u0061\u0001"+
    "\u006d\u0001\u006c\u0002\u0075\u0001\u006e\u0001\u0078\u0001\u004c\u0001"+
    "\u0066\u0001\uffff\u0001\u007a\u0001\u0039\u0001\u006c\u0001\uffff\u0001"+
    "\u0073\u0001\uffff\u0001\u007a\u0001\u0065\u0002\uffff\u0001\u0064\u0003"+
    "\uffff\u0004\u007a\u0001\u0072\u0001\u0063\u0001\u0065\u0002\uffff\u0001"+
    "\u0072\u0001\u0073\u0001\u007a\u0001\u006f\u0001\u0065\u0001\u006e\u0002"+
    "\u007a\u0001\uffff\u0002\u0066\u0001\u0073\u0001\u0077\u0001\uffff\u0001"+
    "\u007a\u0001\u0027\u0003\uffff\u0001\u0061\u0001\uffff\u0001\u0061\u0001"+
    "\u007a\u0003\u0074\u0001\uffff\u0001\u0077\u0001\u007a\u0001\u0074\u0002"+
    "\uffff\u0001\u007a\u0002\uffff\u0001\u0065\u0001\u0069\u0002\uffff\u0002"+
    "\u0067\u0001\uffff\u0001\u0069\u0001\u0073\u0001\u0072\u0001\u0065\u0001"+
    "\uffff\u0001\u007a\u0001\uffff\u0001\u007a\u0001\u0074\u0002\u0065\u0001"+
    "\u006d\u0001\u0077\u0001\u0069\u0001\u0072\u0001\uffff\u0001\u0068\u0001"+
    "\u0073\u0001\u007a\u0001\u0065\u0001\u0069\u0001\u006e\u0003\u007a\u0001"+
    "\uffff\u0001\u0027\u0001\u0074\u0001\u0067\u0004\uffff\u0001\u0068\u0001"+
    "\u006f\u0001\u007a\u0001\u0066\u0001\uffff\u0001\u007a\u0001\uffff",
    DFA29_acceptS:
        "\u0001\uffff\u0001\u0001\u0001\u0002\u0001\u0003\u0001\u0004\u0001"+
    "\u0005\u0001\u0006\u0001\u0007\u0010\uffff\u0001\u002f\u0001\u0030\u0001"+
    "\u0031\u0001\u0032\u0001\u0033\u0011\uffff\u0001\u0016\u0001\u0017\u0001"+
    "\u0018\u0001\u001a\u0001\u001b\u0009\uffff\u0001\u0027\u0003\uffff\u0001"+
    "\u0008\u0001\uffff\u0001\u0009\u0002\uffff\u0001\u000a\u0001\u000b\u0001"+
    "\uffff\u0001\u000c\u0001\u000d\u0001\u000f\u0007\uffff\u0001\u0015\u0001"+
    "\u0019\u0008\uffff\u0001\u0028\u0004\uffff\u0001\u000e\u0002\uffff\u0001"+
    "\u0010\u0001\u0020\u0001\u0011\u0001\uffff\u0001\u0021\u0005\uffff\u0001"+
    "\u0025\u0003\uffff\u0001\u0023\u0001\u0024\u0001\uffff\u0001\u0029\u0001"+
    "\u002a\u0002\uffff\u0001\u0014\u0001\u002d\u0002\uffff\u0001\u0012\u0004"+
    "\uffff\u0001\u002b\u0001\uffff\u0001\u002e\u0008\uffff\u0001\u0022\u0009"+
    "\uffff\u0001\u0026\u0003\uffff\u0001\u001f\u0001\u001d\u0001\u0013\u0001"+
    "\u002c\u0004\uffff\u0001\u001c\u0001\uffff\u0001\u001e",
    DFA29_specialS:
        "\u00a6\uffff}>",
    DFA29_transitionS: [
            "\u0001\u0018\u0001\u0019\u0002\uffff\u0001\u0019\u0012\uffff"+
            "\u0001\u0018\u0003\uffff\u0001\u000f\u0001\uffff\u0001\u0001"+
            "\u0001\u001c\u0001\u0003\u0001\u0004\u0002\uffff\u0001\u0002"+
            "\u0001\u0014\u0001\uffff\u0001\u0005\u0001\u0015\u0009\u0017"+
            "\u0001\u0006\u0002\uffff\u0001\u0007\u0003\uffff\u001a\u001b"+
            "\u0001\u001a\u0003\uffff\u0001\u001b\u0001\uffff\u0001\u000d"+
            "\u0001\u001b\u0001\u0012\u0001\u000e\u0001\u0008\u0001\u0016"+
            "\u0001\u000a\u0004\u001b\u0001\u000b\u0001\u0013\u0001\u0009"+
            "\u0001\u000c\u0003\u001b\u0001\u0010\u0001\u0011\u0006\u001b",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\u0001\u001e\u0002\uffff\u0001\u001d",
            "\u0001\u001f\u0009\uffff\u0001\u0020",
            "\u0001\u0022\u000e\uffff\u0001\u0021\u0001\u0023",
            "\u0001\u0025\u000e\uffff\u0001\u0024",
            "\u0001\u0026",
            "\u0001\u0029\u0001\uffff\u0001\u0027\u0004\uffff\u0001\u0028"+
            "\u0002\uffff\u0001\u002a",
            "\u0001\u002c\u0003\uffff\u0001\u002b",
            "\u0001\u0032\u0001\u002f\u0002\uffff\u0001\u0031\u0005\uffff"+
            "\u0001\u0030\u0003\uffff\u0001\u002d\u0001\u002e",
            "\u0001\u0033\u0001\u0034",
            "\u0001\u0035\u0002\uffff\u0001\u0036",
            "\u0001\u0037",
            "\u0001\u0039\u0007\uffff\u0001\u0038",
            "\u000a\u003a",
            "\u0001\u003e\u0001\uffff\u000a\u0017\u0007\uffff\u000b\u001b"+
            "\u0001\u003d\u000e\u001b\u0004\uffff\u0001\u001b\u0001\uffff"+
            "\u0017\u001b\u0001\u003b\u0002\u001b",
            "\u0001\u003f",
            "\u0001\u003e\u0001\uffff\u000a\u0017\u0007\uffff\u000b\u001b"+
            "\u0001\u003d\u000e\u001b\u0004\uffff\u0001\u001b\u0001\uffff"+
            "\u001a\u001b",
            "",
            "",
            "",
            "",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u0041",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u0044\u0005\uffff\u0001\u0043",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u0047",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u004b\u0014\uffff\u0001\u004c",
            "\u0001\u004d",
            "\u0001\u004e",
            "\u0001\u004f",
            "\u0001\u0050",
            "\u0001\u0051",
            "\u0001\u0053\u0005\uffff\u0001\u0052",
            "",
            "",
            "",
            "",
            "",
            "\u0001\u0054",
            "\u0001\u0055\u000a\uffff\u0001\u0056",
            "\u0001\u0057",
            "\u0001\u0058",
            "\u0001\u0059",
            "\u0001\u005a",
            "\u0001\u005b",
            "\u0001\u003e\u0001\uffff\u000a\u003a\u0012\uffff\u0001\u005c",
            "\u000a\u005d\u0007\uffff\u0006\u005d\u001a\uffff\u0006\u005d",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u005e",
            "\u0001\u005f",
            "",
            "\u0001\u0060",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u0062",
            "",
            "",
            "\u0001\u0063",
            "",
            "",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u000f\u001b\u0001\u0067\u000a\u001b",
            "\u0001\u0069",
            "\u0001\u006a",
            "\u0001\u006b",
            "",
            "",
            "\u0001\u006c",
            "\u0001\u006d",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u006f",
            "\u0001\u0070",
            "\u0001\u0071",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "",
            "\u000a\u0074\u0007\uffff\u0006\u0074\u001a\uffff\u0006\u0074",
            "\u000a\u005e\u002c\uffff\u0001\u0076",
            "\u0001\u0077",
            "\u0001\u0078",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u007a",
            "",
            "",
            "",
            "\u0001\u007b",
            "",
            "\u0001\u007c",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u007e",
            "\u0001\u007f",
            "\u0001\u0080",
            "",
            "\u0001\u0081",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u0083",
            "",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "",
            "",
            "\u0001\u0085",
            "\u0001\u0086",
            "",
            "",
            "\u0001\u0087",
            "\u0001\u0088",
            "",
            "\u0001\u0089",
            "\u0001\u008a",
            "\u0001\u008b",
            "\u0001\u008c",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u008e",
            "\u0001\u008f",
            "\u0001\u0090",
            "\u0001\u0091",
            "\u0001\u0092",
            "\u0001\u0093",
            "\u0001\u0094",
            "",
            "\u0001\u0095",
            "\u0001\u0096",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u0098",
            "\u0001\u0099",
            "\u0001\u009a",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "",
            "\u0001\u009e",
            "\u0001\u009f",
            "\u0001\u00a0",
            "",
            "",
            "",
            "",
            "\u0001\u00a1",
            "\u0001\u00a2",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            "\u0001\u00a4",
            "",
            "\u000a\u001b\u0007\uffff\u001a\u001b\u0004\uffff\u0001\u001b"+
            "\u0001\uffff\u001a\u001b",
            ""
    ]
});

org.antlr.lang.augmentObject(LinqToQuerystringLexer, {
    DFA29_eot:
        org.antlr.runtime.DFA.unpackEncodedString(LinqToQuerystringLexer.DFA29_eotS),
    DFA29_eof:
        org.antlr.runtime.DFA.unpackEncodedString(LinqToQuerystringLexer.DFA29_eofS),
    DFA29_min:
        org.antlr.runtime.DFA.unpackEncodedStringToUnsignedChars(LinqToQuerystringLexer.DFA29_minS),
    DFA29_max:
        org.antlr.runtime.DFA.unpackEncodedStringToUnsignedChars(LinqToQuerystringLexer.DFA29_maxS),
    DFA29_accept:
        org.antlr.runtime.DFA.unpackEncodedString(LinqToQuerystringLexer.DFA29_acceptS),
    DFA29_special:
        org.antlr.runtime.DFA.unpackEncodedString(LinqToQuerystringLexer.DFA29_specialS),
    DFA29_transition: (function() {
        var a = [],
            i,
            numStates = LinqToQuerystringLexer.DFA29_transitionS.length;
        for (i=0; i<numStates; i++) {
            a.push(org.antlr.runtime.DFA.unpackEncodedString(LinqToQuerystringLexer.DFA29_transitionS[i]));
        }
        return a;
    })()
});

LinqToQuerystringLexer.DFA29 = function(recognizer) {
    this.recognizer = recognizer;
    this.decisionNumber = 29;
    this.eot = LinqToQuerystringLexer.DFA29_eot;
    this.eof = LinqToQuerystringLexer.DFA29_eof;
    this.min = LinqToQuerystringLexer.DFA29_min;
    this.max = LinqToQuerystringLexer.DFA29_max;
    this.accept = LinqToQuerystringLexer.DFA29_accept;
    this.special = LinqToQuerystringLexer.DFA29_special;
    this.transition = LinqToQuerystringLexer.DFA29_transition;
};

org.antlr.lang.extend(LinqToQuerystringLexer.DFA29, org.antlr.runtime.DFA, {
    getDescription: function() {
        return "1:1: Tokens : ( T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | ASSIGN | EQUALS | NOTEQUALS | GREATERTHAN | GREATERTHANOREQUAL | LESSTHAN | LESSTHANOREQUAL | NOT | OR | AND | ASC | DESC | ALLPAGES | NONE | SKIP | TOP | FILTER | ORDERBY | SELECT | INLINECOUNT | EXPAND | STARTSWITH | ENDSWITH | SUBSTRINGOF | TOLOWER | ANY | ALL | COUNT | MIN | MAX | SUM | AVERAGE | INT | LONG | DOUBLE | SINGLE | BOOL | DATETIME | GUID | BYTE | SPACE | NEWLINE | DYNAMICIDENTIFIER | IDENTIFIER | STRING );";
    },
    dummy: null
});
 
})();