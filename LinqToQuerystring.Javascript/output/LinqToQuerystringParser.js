// $ANTLR 3.1.1 D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g 2013-08-01 14:24:35

var LinqToQuerystringParser = function(input, state) {
    if (!state) {
        state = new org.antlr.runtime.RecognizerSharedState();
    }

    (function(){
    }).call(this);

    LinqToQuerystringParser.superclass.constructor.call(this, input, state);


         

    /* @todo only create adaptor if output=AST */
    this.adaptor = new org.antlr.runtime.tree.CommonTreeAdaptor();

};

org.antlr.lang.augmentObject(LinqToQuerystringParser, {
    OCTAL_ESC: 54,
    MAX: 27,
    EQUALS: 18,
    COUNT: 26,
    ORDERBY: 36,
    NOT: 17,
    INLINECOUNT: 11,
    AND: 16,
    SUM: 29,
    EXPAND: 10,
    T__60: 60,
    EOF: -1,
    SPACE: 14,
    T__55: 55,
    T__56: 56,
    ENDSWITH: 33,
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
    ANY: 24,
    TOLOWER: 35,
    NEWLINE: 50,
    SINGLE: 43,
    ALLPAGES: 12,
    NONE: 13,
    AVERAGE: 30,
    OR: 15,
    STARTSWITH: 32,
    ASSIGN: 48,
    FILTER: 8,
    ALIAS: 4,
    DESC: 38,
    LONG: 42,
    TOP: 7,
    STRING: 40
});

(function(){
// public class variables
var OCTAL_ESC= 54,
    MAX= 27,
    EQUALS= 18,
    COUNT= 26,
    ORDERBY= 36,
    NOT= 17,
    INLINECOUNT= 11,
    AND= 16,
    SUM= 29,
    EXPAND= 10,
    T__60= 60,
    EOF= -1,
    SPACE= 14,
    T__55= 55,
    T__56= 56,
    ENDSWITH= 33,
    T__57= 57,
    T__58= 58,
    ESC_SEQ= 52,
    IDENTIFIER= 31,
    T__59= 59,
    ALL= 25,
    LESSTHANOREQUAL= 23,
    DOUBLE= 44,
    SELECT= 9,
    GREATERTHANOREQUAL= 21,
    HEX_PAIR= 49,
    GREATERTHAN= 20,
    BYTE= 46,
    LESSTHAN= 22,
    GUID= 45,
    SUBSTRINGOF= 34,
    ASC= 37,
    DATETIME= 41,
    UNICODE_ESC= 53,
    BOOL= 39,
    HEX_DIGIT= 51,
    NOTEQUALS= 19,
    INT= 6,
    MIN= 28,
    DYNAMICIDENTIFIER= 47,
    SKIP= 5,
    ANY= 24,
    TOLOWER= 35,
    NEWLINE= 50,
    SINGLE= 43,
    ALLPAGES= 12,
    NONE= 13,
    AVERAGE= 30,
    OR= 15,
    STARTSWITH= 32,
    ASSIGN= 48,
    FILTER= 8,
    ALIAS= 4,
    DESC= 38,
    LONG= 42,
    TOP= 7,
    STRING= 40;

// public instance methods/vars
org.antlr.lang.extend(LinqToQuerystringParser, org.antlr.runtime.Parser, {
        
    setTreeAdaptor: function(adaptor) {
        this.adaptor = adaptor;
    },
    getTreeAdaptor: function() {
        return this.adaptor;
    },

    getTokenNames: function() { return LinqToQuerystringParser.tokenNames; },
    getGrammarFileName: function() { return "D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g"; }
});
org.antlr.lang.augmentObject(LinqToQuerystringParser.prototype, {

    // inline static return class
    prog_return: (function() {
        LinqToQuerystringParser.prog_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.prog_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:13:8: public prog : ( param ( '&' param )* )* ;
    // $ANTLR start "prog"
    prog: function() {
        var retval = new LinqToQuerystringParser.prog_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var char_literal2 = null;
         var param1 = null;
         var param3 = null;

        var char_literal2_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:14:2: ( ( param ( '&' param )* )* )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:14:4: ( param ( '&' param )* )*
            root_0 = this.adaptor.nil();

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:14:4: ( param ( '&' param )* )*
            loop2:
            do {
                var alt2=2;
                var LA2_0 = this.input.LA(1);

                if ( (LA2_0==SKIP||(LA2_0>=TOP && LA2_0<=INLINECOUNT)||LA2_0==ORDERBY) ) {
                    alt2=1;
                }


                switch (alt2) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:14:5: param ( '&' param )*
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_param_in_prog40);
                    param1=this.param();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, param1.getTree());
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:14:11: ( '&' param )*
                    loop1:
                    do {
                        var alt1=2;
                        var LA1_0 = this.input.LA(1);

                        if ( (LA1_0==55) ) {
                            alt1=1;
                        }


                        switch (alt1) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:14:12: '&' param
                            char_literal2=this.match(this.input,55,LinqToQuerystringParser.FOLLOW_55_in_prog43); 
                            this.pushFollow(LinqToQuerystringParser.FOLLOW_param_in_prog46);
                            param3=this.param();

                            this.state._fsp--;

                            this.adaptor.addChild(root_0, param3.getTree());


                            break;

                        default :
                            break loop1;
                        }
                    } while (true);



                    break;

                default :
                    break loop2;
                }
            } while (true);




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    param_return: (function() {
        LinqToQuerystringParser.param_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.param_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:1: param : ( orderby | top | skip | filter | select | inlinecount | expand ) ;
    // $ANTLR start "param"
    param: function() {
        var retval = new LinqToQuerystringParser.param_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

         var orderby4 = null;
         var top5 = null;
         var skip6 = null;
         var filter7 = null;
         var select8 = null;
         var inlinecount9 = null;
         var expand10 = null;


        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:7: ( ( orderby | top | skip | filter | select | inlinecount | expand ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:9: ( orderby | top | skip | filter | select | inlinecount | expand )
            root_0 = this.adaptor.nil();

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:9: ( orderby | top | skip | filter | select | inlinecount | expand )
            var alt3=7;
            switch ( this.input.LA(1) ) {
            case ORDERBY:
                alt3=1;
                break;
            case TOP:
                alt3=2;
                break;
            case SKIP:
                alt3=3;
                break;
            case FILTER:
                alt3=4;
                break;
            case SELECT:
                alt3=5;
                break;
            case INLINECOUNT:
                alt3=6;
                break;
            case EXPAND:
                alt3=7;
                break;
            default:
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 3, 0, this.input);

                throw nvae;
            }

            switch (alt3) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:10: orderby
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_orderby_in_param59);
                    orderby4=this.orderby();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, orderby4.getTree());


                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:20: top
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_top_in_param63);
                    top5=this.top();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, top5.getTree());


                    break;
                case 3 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:26: skip
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_skip_in_param67);
                    skip6=this.skip();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, skip6.getTree());


                    break;
                case 4 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:33: filter
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_filter_in_param71);
                    filter7=this.filter();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, filter7.getTree());


                    break;
                case 5 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:42: select
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_select_in_param75);
                    select8=this.select();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, select8.getTree());


                    break;
                case 6 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:51: inlinecount
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_inlinecount_in_param79);
                    inlinecount9=this.inlinecount();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, inlinecount9.getTree());


                    break;
                case 7 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:16:65: expand
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_expand_in_param83);
                    expand10=this.expand();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, expand10.getTree());


                    break;

            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    skip_return: (function() {
        LinqToQuerystringParser.skip_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.skip_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:18:1: skip : SKIP (int= INT )+ -> ^( SKIP INT[int] ) ;
    // $ANTLR start "skip"
    skip: function() {
        var retval = new LinqToQuerystringParser.skip_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var int = null;
        var SKIP11 = null;

        var int_tree=null;
        var SKIP11_tree=null;
        var stream_INT=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token INT");
        var stream_SKIP=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token SKIP");

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:19:2: ( SKIP (int= INT )+ -> ^( SKIP INT[int] ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:19:4: SKIP (int= INT )+
            SKIP11=this.match(this.input,SKIP,LinqToQuerystringParser.FOLLOW_SKIP_in_skip94);  
            stream_SKIP.add(SKIP11);

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:19:12: (int= INT )+
            var cnt4=0;
            loop4:
            do {
                var alt4=2;
                var LA4_0 = this.input.LA(1);

                if ( (LA4_0==INT) ) {
                    alt4=1;
                }


                switch (alt4) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:19:12: int= INT
                    int=this.match(this.input,INT,LinqToQuerystringParser.FOLLOW_INT_in_skip98);  
                    stream_INT.add(int);



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



            // AST REWRITE
            // elements: INT, SKIP
            // token labels: 
            // rule labels: retval
            // token list labels: 
            // rule list labels: 
            retval.tree = root_0;
            var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

            root_0 = this.adaptor.nil();
            // 19:18: -> ^( SKIP INT[int] )
            {
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:19:21: ^( SKIP INT[int] )
                {
                var root_1 = this.adaptor.nil();
                root_1 = this.adaptor.becomeRoot(stream_SKIP.nextNode(), root_1);

                this.adaptor.addChild(root_1, this.adaptor.create(INT, int));

                this.adaptor.addChild(root_0, root_1);
                }

            }

            retval.tree = root_0;


            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    top_return: (function() {
        LinqToQuerystringParser.top_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.top_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:21:1: top : TOP (int= INT )+ -> ^( TOP INT[int] ) ;
    // $ANTLR start "top"
    top: function() {
        var retval = new LinqToQuerystringParser.top_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var int = null;
        var TOP12 = null;

        var int_tree=null;
        var TOP12_tree=null;
        var stream_INT=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token INT");
        var stream_TOP=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token TOP");

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:22:2: ( TOP (int= INT )+ -> ^( TOP INT[int] ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:22:4: TOP (int= INT )+
            TOP12=this.match(this.input,TOP,LinqToQuerystringParser.FOLLOW_TOP_in_top118);  
            stream_TOP.add(TOP12);

            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:22:11: (int= INT )+
            var cnt5=0;
            loop5:
            do {
                var alt5=2;
                var LA5_0 = this.input.LA(1);

                if ( (LA5_0==INT) ) {
                    alt5=1;
                }


                switch (alt5) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:22:11: int= INT
                    int=this.match(this.input,INT,LinqToQuerystringParser.FOLLOW_INT_in_top122);  
                    stream_INT.add(int);



                    break;

                default :
                    if ( cnt5 >= 1 ) {
                        break loop5;
                    }
                        var eee = new org.antlr.runtime.EarlyExitException(5, this.input);
                        throw eee;
                }
                cnt5++;
            } while (true);



            // AST REWRITE
            // elements: TOP, INT
            // token labels: 
            // rule labels: retval
            // token list labels: 
            // rule list labels: 
            retval.tree = root_0;
            var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

            root_0 = this.adaptor.nil();
            // 22:17: -> ^( TOP INT[int] )
            {
                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:22:20: ^( TOP INT[int] )
                {
                var root_1 = this.adaptor.nil();
                root_1 = this.adaptor.becomeRoot(stream_TOP.nextNode(), root_1);

                this.adaptor.addChild(root_1, this.adaptor.create(INT, int));

                this.adaptor.addChild(root_0, root_1);
                }

            }

            retval.tree = root_0;


            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    filter_return: (function() {
        LinqToQuerystringParser.filter_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.filter_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:24:1: filter : FILTER filterexpression[false] ;
    // $ANTLR start "filter"
    filter: function() {
        var retval = new LinqToQuerystringParser.filter_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var FILTER13 = null;
         var filterexpression14 = null;

        var FILTER13_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:25:2: ( FILTER filterexpression[false] )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:25:4: FILTER filterexpression[false]
            root_0 = this.adaptor.nil();

            FILTER13=this.match(this.input,FILTER,LinqToQuerystringParser.FOLLOW_FILTER_in_filter142); 
            FILTER13_tree = this.adaptor.create(FILTER13);
            root_0 = this.adaptor.becomeRoot(FILTER13_tree, root_0);

            this.pushFollow(LinqToQuerystringParser.FOLLOW_filterexpression_in_filter145);
            filterexpression14=this.filterexpression(false);

            this.state._fsp--;

            this.adaptor.addChild(root_0, filterexpression14.getTree());



            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    select_return: (function() {
        LinqToQuerystringParser.select_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.select_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:27:1: select : SELECT propertyname[false] ( ',' propertyname[false] )* ;
    // $ANTLR start "select"
    select: function() {
        var retval = new LinqToQuerystringParser.select_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var SELECT15 = null;
        var char_literal17 = null;
         var propertyname16 = null;
         var propertyname18 = null;

        var SELECT15_tree=null;
        var char_literal17_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:28:2: ( SELECT propertyname[false] ( ',' propertyname[false] )* )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:28:4: SELECT propertyname[false] ( ',' propertyname[false] )*
            root_0 = this.adaptor.nil();

            SELECT15=this.match(this.input,SELECT,LinqToQuerystringParser.FOLLOW_SELECT_in_select156); 
            SELECT15_tree = this.adaptor.create(SELECT15);
            root_0 = this.adaptor.becomeRoot(SELECT15_tree, root_0);

            this.pushFollow(LinqToQuerystringParser.FOLLOW_propertyname_in_select159);
            propertyname16=this.propertyname(false);

            this.state._fsp--;

            this.adaptor.addChild(root_0, propertyname16.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:28:32: ( ',' propertyname[false] )*
            loop6:
            do {
                var alt6=2;
                var LA6_0 = this.input.LA(1);

                if ( (LA6_0==56) ) {
                    alt6=1;
                }


                switch (alt6) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:28:33: ',' propertyname[false]
                    char_literal17=this.match(this.input,56,LinqToQuerystringParser.FOLLOW_56_in_select163); 
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_propertyname_in_select166);
                    propertyname18=this.propertyname(false);

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, propertyname18.getTree());


                    break;

                default :
                    break loop6;
                }
            } while (true);




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    expand_return: (function() {
        LinqToQuerystringParser.expand_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.expand_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:30:1: expand : EXPAND propertyname[false] ( ',' propertyname[false] )* ;
    // $ANTLR start "expand"
    expand: function() {
        var retval = new LinqToQuerystringParser.expand_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var EXPAND19 = null;
        var char_literal21 = null;
         var propertyname20 = null;
         var propertyname22 = null;

        var EXPAND19_tree=null;
        var char_literal21_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:31:2: ( EXPAND propertyname[false] ( ',' propertyname[false] )* )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:31:4: EXPAND propertyname[false] ( ',' propertyname[false] )*
            root_0 = this.adaptor.nil();

            EXPAND19=this.match(this.input,EXPAND,LinqToQuerystringParser.FOLLOW_EXPAND_in_expand181); 
            EXPAND19_tree = this.adaptor.create(EXPAND19);
            root_0 = this.adaptor.becomeRoot(EXPAND19_tree, root_0);

            this.pushFollow(LinqToQuerystringParser.FOLLOW_propertyname_in_expand184);
            propertyname20=this.propertyname(false);

            this.state._fsp--;

            this.adaptor.addChild(root_0, propertyname20.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:31:32: ( ',' propertyname[false] )*
            loop7:
            do {
                var alt7=2;
                var LA7_0 = this.input.LA(1);

                if ( (LA7_0==56) ) {
                    alt7=1;
                }


                switch (alt7) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:31:33: ',' propertyname[false]
                    char_literal21=this.match(this.input,56,LinqToQuerystringParser.FOLLOW_56_in_expand188); 
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_propertyname_in_expand191);
                    propertyname22=this.propertyname(false);

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, propertyname22.getTree());


                    break;

                default :
                    break loop7;
                }
            } while (true);




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    inlinecount_return: (function() {
        LinqToQuerystringParser.inlinecount_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.inlinecount_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:33:1: inlinecount : ( INLINECOUNT ALLPAGES | INLINECOUNT NONE ->);
    // $ANTLR start "inlinecount"
    inlinecount: function() {
        var retval = new LinqToQuerystringParser.inlinecount_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var INLINECOUNT23 = null;
        var ALLPAGES24 = null;
        var INLINECOUNT25 = null;
        var NONE26 = null;

        var INLINECOUNT23_tree=null;
        var ALLPAGES24_tree=null;
        var INLINECOUNT25_tree=null;
        var NONE26_tree=null;
        var stream_INLINECOUNT=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token INLINECOUNT");
        var stream_NONE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token NONE");

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:34:2: ( INLINECOUNT ALLPAGES | INLINECOUNT NONE ->)
            var alt8=2;
            var LA8_0 = this.input.LA(1);

            if ( (LA8_0==INLINECOUNT) ) {
                var LA8_1 = this.input.LA(2);

                if ( (LA8_1==ALLPAGES) ) {
                    alt8=1;
                }
                else if ( (LA8_1==NONE) ) {
                    alt8=2;
                }
                else {
                    var nvae =
                        new org.antlr.runtime.NoViableAltException("", 8, 1, this.input);

                    throw nvae;
                }
            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 8, 0, this.input);

                throw nvae;
            }
            switch (alt8) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:34:4: INLINECOUNT ALLPAGES
                    root_0 = this.adaptor.nil();

                    INLINECOUNT23=this.match(this.input,INLINECOUNT,LinqToQuerystringParser.FOLLOW_INLINECOUNT_in_inlinecount204); 
                    INLINECOUNT23_tree = this.adaptor.create(INLINECOUNT23);
                    root_0 = this.adaptor.becomeRoot(INLINECOUNT23_tree, root_0);

                    ALLPAGES24=this.match(this.input,ALLPAGES,LinqToQuerystringParser.FOLLOW_ALLPAGES_in_inlinecount207); 
                    ALLPAGES24_tree = this.adaptor.create(ALLPAGES24);
                    this.adaptor.addChild(root_0, ALLPAGES24_tree);



                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:35:4: INLINECOUNT NONE
                    INLINECOUNT25=this.match(this.input,INLINECOUNT,LinqToQuerystringParser.FOLLOW_INLINECOUNT_in_inlinecount212);  
                    stream_INLINECOUNT.add(INLINECOUNT25);

                    NONE26=this.match(this.input,NONE,LinqToQuerystringParser.FOLLOW_NONE_in_inlinecount214);  
                    stream_NONE.add(NONE26);



                    // AST REWRITE
                    // elements: 
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 35:21: ->
                    {
                        root_0 = null;
                    }

                    retval.tree = root_0;

                    break;

            }
            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    filterexpression_return: (function() {
        LinqToQuerystringParser.filterexpression_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.filterexpression_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:37:1: filterexpression[subquery] : orexpression[subquery] ( SPACE OR SPACE orexpression[subquery] )* ;
    // $ANTLR start "filterexpression"
    filterexpression: function(subquery) {
        var retval = new LinqToQuerystringParser.filterexpression_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var SPACE28 = null;
        var OR29 = null;
        var SPACE30 = null;
         var orexpression27 = null;
         var orexpression31 = null;

        var SPACE28_tree=null;
        var OR29_tree=null;
        var SPACE30_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:38:2: ( orexpression[subquery] ( SPACE OR SPACE orexpression[subquery] )* )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:38:4: orexpression[subquery] ( SPACE OR SPACE orexpression[subquery] )*
            root_0 = this.adaptor.nil();

            this.pushFollow(LinqToQuerystringParser.FOLLOW_orexpression_in_filterexpression226);
            orexpression27=this.orexpression(subquery);

            this.state._fsp--;

            this.adaptor.addChild(root_0, orexpression27.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:38:27: ( SPACE OR SPACE orexpression[subquery] )*
            loop9:
            do {
                var alt9=2;
                var LA9_0 = this.input.LA(1);

                if ( (LA9_0==SPACE) ) {
                    alt9=1;
                }


                switch (alt9) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:38:28: SPACE OR SPACE orexpression[subquery]
                    SPACE28=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_filterexpression230); 
                    OR29=this.match(this.input,OR,LinqToQuerystringParser.FOLLOW_OR_in_filterexpression233); 
                    OR29_tree = this.adaptor.create(OR29);
                    root_0 = this.adaptor.becomeRoot(OR29_tree, root_0);

                    SPACE30=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_filterexpression236); 
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_orexpression_in_filterexpression239);
                    orexpression31=this.orexpression(subquery);

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, orexpression31.getTree());


                    break;

                default :
                    break loop9;
                }
            } while (true);




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    orexpression_return: (function() {
        LinqToQuerystringParser.orexpression_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.orexpression_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:40:1: orexpression[subquery] : andexpression[subquery] ( SPACE AND SPACE andexpression[subquery] )* ;
    // $ANTLR start "orexpression"
    orexpression: function(subquery) {
        var retval = new LinqToQuerystringParser.orexpression_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var SPACE33 = null;
        var AND34 = null;
        var SPACE35 = null;
         var andexpression32 = null;
         var andexpression36 = null;

        var SPACE33_tree=null;
        var AND34_tree=null;
        var SPACE35_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:41:2: ( andexpression[subquery] ( SPACE AND SPACE andexpression[subquery] )* )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:41:4: andexpression[subquery] ( SPACE AND SPACE andexpression[subquery] )*
            root_0 = this.adaptor.nil();

            this.pushFollow(LinqToQuerystringParser.FOLLOW_andexpression_in_orexpression253);
            andexpression32=this.andexpression(subquery);

            this.state._fsp--;

            this.adaptor.addChild(root_0, andexpression32.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:41:28: ( SPACE AND SPACE andexpression[subquery] )*
            loop10:
            do {
                var alt10=2;
                var LA10_0 = this.input.LA(1);

                if ( (LA10_0==SPACE) ) {
                    var LA10_1 = this.input.LA(2);

                    if ( (LA10_1==AND) ) {
                        alt10=1;
                    }


                }


                switch (alt10) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:41:29: SPACE AND SPACE andexpression[subquery]
                    SPACE33=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_orexpression257); 
                    AND34=this.match(this.input,AND,LinqToQuerystringParser.FOLLOW_AND_in_orexpression260); 
                    AND34_tree = this.adaptor.create(AND34);
                    root_0 = this.adaptor.becomeRoot(AND34_tree, root_0);

                    SPACE35=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_orexpression263); 
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_andexpression_in_orexpression266);
                    andexpression36=this.andexpression(subquery);

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, andexpression36.getTree());


                    break;

                default :
                    break loop10;
                }
            } while (true);




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    andexpression_return: (function() {
        LinqToQuerystringParser.andexpression_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.andexpression_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:43:1: andexpression[subquery] : ( NOT SPACE ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] ) | ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] ) );
    // $ANTLR start "andexpression"
    andexpression: function(subquery) {
        var retval = new LinqToQuerystringParser.andexpression_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var NOT37 = null;
        var SPACE38 = null;
        var char_literal39 = null;
        var char_literal41 = null;
        var char_literal43 = null;
        var char_literal45 = null;
         var filterexpression40 = null;
         var booleanexpression42 = null;
         var filterexpression44 = null;
         var booleanexpression46 = null;

        var NOT37_tree=null;
        var SPACE38_tree=null;
        var char_literal39_tree=null;
        var char_literal41_tree=null;
        var char_literal43_tree=null;
        var char_literal45_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:44:2: ( NOT SPACE ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] ) | ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] ) )
            var alt13=2;
            var LA13_0 = this.input.LA(1);

            if ( (LA13_0==NOT) ) {
                alt13=1;
            }
            else if ( (LA13_0==INT||(LA13_0>=IDENTIFIER && LA13_0<=TOLOWER)||(LA13_0>=BOOL && LA13_0<=DYNAMICIDENTIFIER)||LA13_0==57) ) {
                alt13=2;
            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 13, 0, this.input);

                throw nvae;
            }
            switch (alt13) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:44:4: NOT SPACE ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] )
                    root_0 = this.adaptor.nil();

                    NOT37=this.match(this.input,NOT,LinqToQuerystringParser.FOLLOW_NOT_in_andexpression280); 
                    NOT37_tree = this.adaptor.create(NOT37);
                    root_0 = this.adaptor.becomeRoot(NOT37_tree, root_0);

                    SPACE38=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_andexpression283); 
                    SPACE38_tree = this.adaptor.create(SPACE38);
                    this.adaptor.addChild(root_0, SPACE38_tree);

                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:44:15: ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] )
                    var alt11=2;
                    var LA11_0 = this.input.LA(1);

                    if ( (LA11_0==57) ) {
                        alt11=1;
                    }
                    else if ( (LA11_0==INT||(LA11_0>=IDENTIFIER && LA11_0<=TOLOWER)||(LA11_0>=BOOL && LA11_0<=DYNAMICIDENTIFIER)) ) {
                        alt11=2;
                    }
                    else {
                        var nvae =
                            new org.antlr.runtime.NoViableAltException("", 11, 0, this.input);

                        throw nvae;
                    }
                    switch (alt11) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:44:16: '(' filterexpression[subquery] ')'
                            char_literal39=this.match(this.input,57,LinqToQuerystringParser.FOLLOW_57_in_andexpression286); 
                            char_literal39_tree = this.adaptor.create(char_literal39);
                            this.adaptor.addChild(root_0, char_literal39_tree);

                            this.pushFollow(LinqToQuerystringParser.FOLLOW_filterexpression_in_andexpression288);
                            filterexpression40=this.filterexpression(subquery);

                            this.state._fsp--;

                            this.adaptor.addChild(root_0, filterexpression40.getTree());
                            char_literal41=this.match(this.input,58,LinqToQuerystringParser.FOLLOW_58_in_andexpression291); 
                            char_literal41_tree = this.adaptor.create(char_literal41);
                            this.adaptor.addChild(root_0, char_literal41_tree);



                            break;
                        case 2 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:44:53: booleanexpression[subquery]
                            this.pushFollow(LinqToQuerystringParser.FOLLOW_booleanexpression_in_andexpression295);
                            booleanexpression42=this.booleanexpression(subquery);

                            this.state._fsp--;

                            this.adaptor.addChild(root_0, booleanexpression42.getTree());


                            break;

                    }



                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:45:4: ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] )
                    root_0 = this.adaptor.nil();

                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:45:4: ( '(' filterexpression[subquery] ')' | booleanexpression[subquery] )
                    var alt12=2;
                    var LA12_0 = this.input.LA(1);

                    if ( (LA12_0==57) ) {
                        alt12=1;
                    }
                    else if ( (LA12_0==INT||(LA12_0>=IDENTIFIER && LA12_0<=TOLOWER)||(LA12_0>=BOOL && LA12_0<=DYNAMICIDENTIFIER)) ) {
                        alt12=2;
                    }
                    else {
                        var nvae =
                            new org.antlr.runtime.NoViableAltException("", 12, 0, this.input);

                        throw nvae;
                    }
                    switch (alt12) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:45:5: '(' filterexpression[subquery] ')'
                            char_literal43=this.match(this.input,57,LinqToQuerystringParser.FOLLOW_57_in_andexpression303); 
                            char_literal43_tree = this.adaptor.create(char_literal43);
                            this.adaptor.addChild(root_0, char_literal43_tree);

                            this.pushFollow(LinqToQuerystringParser.FOLLOW_filterexpression_in_andexpression305);
                            filterexpression44=this.filterexpression(subquery);

                            this.state._fsp--;

                            this.adaptor.addChild(root_0, filterexpression44.getTree());
                            char_literal45=this.match(this.input,58,LinqToQuerystringParser.FOLLOW_58_in_andexpression308); 
                            char_literal45_tree = this.adaptor.create(char_literal45);
                            this.adaptor.addChild(root_0, char_literal45_tree);



                            break;
                        case 2 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:45:42: booleanexpression[subquery]
                            this.pushFollow(LinqToQuerystringParser.FOLLOW_booleanexpression_in_andexpression312);
                            booleanexpression46=this.booleanexpression(subquery);

                            this.state._fsp--;

                            this.adaptor.addChild(root_0, booleanexpression46.getTree());


                            break;

                    }



                    break;

            }
            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    booleanexpression_return: (function() {
        LinqToQuerystringParser.booleanexpression_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.booleanexpression_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:47:1: booleanexpression[subquery] : atom1= atom[subquery] ( SPACE (op= EQUALS | op= NOTEQUALS | op= GREATERTHAN | op= GREATERTHANOREQUAL | op= LESSTHAN | op= LESSTHANOREQUAL ) SPACE atom2= atom[subquery] -> ^( $op $atom1 $atom2) | -> ^( EQUALS[\"eq\"] $atom1 BOOL[\"true\"] ) ) ;
    // $ANTLR start "booleanexpression"
    booleanexpression: function(subquery) {
        var retval = new LinqToQuerystringParser.booleanexpression_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var op = null;
        var SPACE47 = null;
        var SPACE48 = null;
         var atom1 = null;
         var atom2 = null;

        var op_tree=null;
        var SPACE47_tree=null;
        var SPACE48_tree=null;
        var stream_NOTEQUALS=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token NOTEQUALS");
        var stream_LESSTHAN=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token LESSTHAN");
        var stream_EQUALS=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token EQUALS");
        var stream_SPACE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token SPACE");
        var stream_GREATERTHANOREQUAL=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token GREATERTHANOREQUAL");
        var stream_GREATERTHAN=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token GREATERTHAN");
        var stream_LESSTHANOREQUAL=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token LESSTHANOREQUAL");
        var stream_atom=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"rule atom");
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:48:2: (atom1= atom[subquery] ( SPACE (op= EQUALS | op= NOTEQUALS | op= GREATERTHAN | op= GREATERTHANOREQUAL | op= LESSTHAN | op= LESSTHANOREQUAL ) SPACE atom2= atom[subquery] -> ^( $op $atom1 $atom2) | -> ^( EQUALS[\"eq\"] $atom1 BOOL[\"true\"] ) ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:48:4: atom1= atom[subquery] ( SPACE (op= EQUALS | op= NOTEQUALS | op= GREATERTHAN | op= GREATERTHANOREQUAL | op= LESSTHAN | op= LESSTHANOREQUAL ) SPACE atom2= atom[subquery] -> ^( $op $atom1 $atom2) | -> ^( EQUALS[\"eq\"] $atom1 BOOL[\"true\"] ) )
            this.pushFollow(LinqToQuerystringParser.FOLLOW_atom_in_booleanexpression328);
            atom1=this.atom(subquery);

            this.state._fsp--;

            stream_atom.add(atom1.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:48:25: ( SPACE (op= EQUALS | op= NOTEQUALS | op= GREATERTHAN | op= GREATERTHANOREQUAL | op= LESSTHAN | op= LESSTHANOREQUAL ) SPACE atom2= atom[subquery] -> ^( $op $atom1 $atom2) | -> ^( EQUALS[\"eq\"] $atom1 BOOL[\"true\"] ) )
            var alt15=2;
            var LA15_0 = this.input.LA(1);

            if ( (LA15_0==SPACE) ) {
                var LA15_1 = this.input.LA(2);

                if ( ((LA15_1>=OR && LA15_1<=AND)) ) {
                    alt15=2;
                }
                else if ( ((LA15_1>=EQUALS && LA15_1<=LESSTHANOREQUAL)) ) {
                    alt15=1;
                }
                else {
                    var nvae =
                        new org.antlr.runtime.NoViableAltException("", 15, 1, this.input);

                    throw nvae;
                }
            }
            else if ( (LA15_0==EOF||LA15_0==SKIP||(LA15_0>=TOP && LA15_0<=INLINECOUNT)||LA15_0==ORDERBY||LA15_0==55||LA15_0==58) ) {
                alt15=2;
            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 15, 0, this.input);

                throw nvae;
            }
            switch (alt15) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:4: SPACE (op= EQUALS | op= NOTEQUALS | op= GREATERTHAN | op= GREATERTHANOREQUAL | op= LESSTHAN | op= LESSTHANOREQUAL ) SPACE atom2= atom[subquery]
                    SPACE47=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_booleanexpression336);  
                    stream_SPACE.add(SPACE47);

                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:10: (op= EQUALS | op= NOTEQUALS | op= GREATERTHAN | op= GREATERTHANOREQUAL | op= LESSTHAN | op= LESSTHANOREQUAL )
                    var alt14=6;
                    switch ( this.input.LA(1) ) {
                    case EQUALS:
                        alt14=1;
                        break;
                    case NOTEQUALS:
                        alt14=2;
                        break;
                    case GREATERTHAN:
                        alt14=3;
                        break;
                    case GREATERTHANOREQUAL:
                        alt14=4;
                        break;
                    case LESSTHAN:
                        alt14=5;
                        break;
                    case LESSTHANOREQUAL:
                        alt14=6;
                        break;
                    default:
                        var nvae =
                            new org.antlr.runtime.NoViableAltException("", 14, 0, this.input);

                        throw nvae;
                    }

                    switch (alt14) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:11: op= EQUALS
                            op=this.match(this.input,EQUALS,LinqToQuerystringParser.FOLLOW_EQUALS_in_booleanexpression341);  
                            stream_EQUALS.add(op);



                            break;
                        case 2 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:23: op= NOTEQUALS
                            op=this.match(this.input,NOTEQUALS,LinqToQuerystringParser.FOLLOW_NOTEQUALS_in_booleanexpression347);  
                            stream_NOTEQUALS.add(op);



                            break;
                        case 3 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:38: op= GREATERTHAN
                            op=this.match(this.input,GREATERTHAN,LinqToQuerystringParser.FOLLOW_GREATERTHAN_in_booleanexpression353);  
                            stream_GREATERTHAN.add(op);



                            break;
                        case 4 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:55: op= GREATERTHANOREQUAL
                            op=this.match(this.input,GREATERTHANOREQUAL,LinqToQuerystringParser.FOLLOW_GREATERTHANOREQUAL_in_booleanexpression359);  
                            stream_GREATERTHANOREQUAL.add(op);



                            break;
                        case 5 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:79: op= LESSTHAN
                            op=this.match(this.input,LESSTHAN,LinqToQuerystringParser.FOLLOW_LESSTHAN_in_booleanexpression365);  
                            stream_LESSTHAN.add(op);



                            break;
                        case 6 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:49:93: op= LESSTHANOREQUAL
                            op=this.match(this.input,LESSTHANOREQUAL,LinqToQuerystringParser.FOLLOW_LESSTHANOREQUAL_in_booleanexpression371);  
                            stream_LESSTHANOREQUAL.add(op);



                            break;

                    }

                    SPACE48=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_booleanexpression374);  
                    stream_SPACE.add(SPACE48);

                    this.pushFollow(LinqToQuerystringParser.FOLLOW_atom_in_booleanexpression378);
                    atom2=this.atom(subquery);

                    this.state._fsp--;

                    stream_atom.add(atom2.getTree());


                    // AST REWRITE
                    // elements: op, atom2, atom1
                    // token labels: op
                    // rule labels: retval, atom1, atom2
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_op=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token op",op);
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);
                    var stream_atom1=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token atom1",atom1!=null?atom1.tree:null);
                    var stream_atom2=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token atom2",atom2!=null?atom2.tree:null);

                    root_0 = this.adaptor.nil();
                    // 50:4: -> ^( $op $atom1 $atom2)
                    {
                        // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:50:7: ^( $op $atom1 $atom2)
                        {
                        var root_1 = this.adaptor.nil();
                        root_1 = this.adaptor.becomeRoot(stream_op.nextNode(), root_1);

                        this.adaptor.addChild(root_1, stream_atom1.nextTree());
                        this.adaptor.addChild(root_1, stream_atom2.nextTree());

                        this.adaptor.addChild(root_0, root_1);
                        }

                    }

                    retval.tree = root_0;

                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:51:5: 

                    // AST REWRITE
                    // elements: EQUALS, atom1
                    // token labels: 
                    // rule labels: retval, atom1
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);
                    var stream_atom1=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token atom1",atom1!=null?atom1.tree:null);

                    root_0 = this.adaptor.nil();
                    // 51:5: -> ^( EQUALS[\"eq\"] $atom1 BOOL[\"true\"] )
                    {
                        // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:51:8: ^( EQUALS[\"eq\"] $atom1 BOOL[\"true\"] )
                        {
                        var root_1 = this.adaptor.nil();
                        root_1 = this.adaptor.becomeRoot(this.adaptor.create(EQUALS, "eq"), root_1);

                        this.adaptor.addChild(root_1, stream_atom1.nextTree());
                        this.adaptor.addChild(root_1, this.adaptor.create(BOOL, "true"));

                        this.adaptor.addChild(root_0, root_1);
                        }

                    }

                    retval.tree = root_0;

                    break;

            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    atom_return: (function() {
        LinqToQuerystringParser.atom_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.atom_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:54:1: atom[subquery] : ( functioncall[subquery] | constant | accessor[subquery] );
    // $ANTLR start "atom"
    atom: function(subquery) {
        var retval = new LinqToQuerystringParser.atom_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

         var functioncall49 = null;
         var constant50 = null;
         var accessor51 = null;


        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:55:2: ( functioncall[subquery] | constant | accessor[subquery] )
            var alt16=3;
            switch ( this.input.LA(1) ) {
            case STARTSWITH:
            case ENDSWITH:
            case SUBSTRINGOF:
            case TOLOWER:
                alt16=1;
                break;
            case INT:
            case BOOL:
            case STRING:
            case DATETIME:
            case LONG:
            case SINGLE:
            case DOUBLE:
            case GUID:
            case BYTE:
                alt16=2;
                break;
            case IDENTIFIER:
            case DYNAMICIDENTIFIER:
                alt16=3;
                break;
            default:
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 16, 0, this.input);

                throw nvae;
            }

            switch (alt16) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:55:4: functioncall[subquery]
                    root_0 = this.adaptor.nil();

                    this.pushFollow(LinqToQuerystringParser.FOLLOW_functioncall_in_atom430);
                    functioncall49=this.functioncall(subquery);

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, functioncall49.getTree());


                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:56:4: constant
                    root_0 = this.adaptor.nil();

                    this.pushFollow(LinqToQuerystringParser.FOLLOW_constant_in_atom436);
                    constant50=this.constant();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, constant50.getTree());


                    break;
                case 3 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:57:4: accessor[subquery]
                    root_0 = this.adaptor.nil();

                    this.pushFollow(LinqToQuerystringParser.FOLLOW_accessor_in_atom441);
                    accessor51=this.accessor(subquery);

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, accessor51.getTree());


                    break;

            }
            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    functioncall_return: (function() {
        LinqToQuerystringParser.functioncall_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.functioncall_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:59:1: functioncall[subquery] : function '(' atom[subquery] ( ',' atom[subquery] )* ')' ;
    // $ANTLR start "functioncall"
    functioncall: function(subquery) {
        var retval = new LinqToQuerystringParser.functioncall_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var char_literal53 = null;
        var char_literal55 = null;
        var char_literal57 = null;
         var function52 = null;
         var atom54 = null;
         var atom56 = null;

        var char_literal53_tree=null;
        var char_literal55_tree=null;
        var char_literal57_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:60:2: ( function '(' atom[subquery] ( ',' atom[subquery] )* ')' )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:60:4: function '(' atom[subquery] ( ',' atom[subquery] )* ')'
            root_0 = this.adaptor.nil();

            this.pushFollow(LinqToQuerystringParser.FOLLOW_function_in_functioncall453);
            function52=this.function();

            this.state._fsp--;

            root_0 = this.adaptor.becomeRoot(function52.getTree(), root_0);
            char_literal53=this.match(this.input,57,LinqToQuerystringParser.FOLLOW_57_in_functioncall456); 
            char_literal53_tree = this.adaptor.create(char_literal53);
            this.adaptor.addChild(root_0, char_literal53_tree);

            this.pushFollow(LinqToQuerystringParser.FOLLOW_atom_in_functioncall458);
            atom54=this.atom(subquery);

            this.state._fsp--;

            this.adaptor.addChild(root_0, atom54.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:60:33: ( ',' atom[subquery] )*
            loop17:
            do {
                var alt17=2;
                var LA17_0 = this.input.LA(1);

                if ( (LA17_0==56) ) {
                    alt17=1;
                }


                switch (alt17) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:60:34: ',' atom[subquery]
                    char_literal55=this.match(this.input,56,LinqToQuerystringParser.FOLLOW_56_in_functioncall462); 
                    char_literal55_tree = this.adaptor.create(char_literal55);
                    this.adaptor.addChild(root_0, char_literal55_tree);

                    this.pushFollow(LinqToQuerystringParser.FOLLOW_atom_in_functioncall464);
                    atom56=this.atom(subquery);

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, atom56.getTree());


                    break;

                default :
                    break loop17;
                }
            } while (true);

            char_literal57=this.match(this.input,58,LinqToQuerystringParser.FOLLOW_58_in_functioncall469); 
            char_literal57_tree = this.adaptor.create(char_literal57);
            this.adaptor.addChild(root_0, char_literal57_tree);




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    accessor_return: (function() {
        LinqToQuerystringParser.accessor_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.accessor_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:62:1: accessor[subquery] : ( propertyname[subquery] -> propertyname ) ( '/' (func= ANY | func= ALL | func= COUNT | func= MAX | func= MIN | func= SUM | func= AVERAGE ) '(' ( (id= IDENTIFIER ':' SPACE filterexpression[true] ) -> ^( $func $accessor ALIAS[$id] filterexpression ) | -> ^( $func $accessor) ) ')' )? ;
    // $ANTLR start "accessor"
    accessor: function(subquery) {
        var retval = new LinqToQuerystringParser.accessor_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var func = null;
        var id = null;
        var char_literal59 = null;
        var char_literal60 = null;
        var char_literal61 = null;
        var SPACE62 = null;
        var char_literal64 = null;
         var propertyname58 = null;
         var filterexpression63 = null;

        var func_tree=null;
        var id_tree=null;
        var char_literal59_tree=null;
        var char_literal60_tree=null;
        var char_literal61_tree=null;
        var SPACE62_tree=null;
        var char_literal64_tree=null;
        var stream_59=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token 59");
        var stream_58=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token 58");
        var stream_ANY=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token ANY");
        var stream_57=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token 57");
        var stream_IDENTIFIER=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token IDENTIFIER");
        var stream_ALL=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token ALL");
        var stream_AVERAGE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token AVERAGE");
        var stream_MAX=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token MAX");
        var stream_COUNT=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token COUNT");
        var stream_MIN=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token MIN");
        var stream_SUM=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token SUM");
        var stream_SPACE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token SPACE");
        var stream_60=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token 60");
        var stream_filterexpression=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"rule filterexpression");
        var stream_propertyname=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"rule propertyname");
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:62:19: ( ( propertyname[subquery] -> propertyname ) ( '/' (func= ANY | func= ALL | func= COUNT | func= MAX | func= MIN | func= SUM | func= AVERAGE ) '(' ( (id= IDENTIFIER ':' SPACE filterexpression[true] ) -> ^( $func $accessor ALIAS[$id] filterexpression ) | -> ^( $func $accessor) ) ')' )? )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:63:3: ( propertyname[subquery] -> propertyname ) ( '/' (func= ANY | func= ALL | func= COUNT | func= MAX | func= MIN | func= SUM | func= AVERAGE ) '(' ( (id= IDENTIFIER ':' SPACE filterexpression[true] ) -> ^( $func $accessor ALIAS[$id] filterexpression ) | -> ^( $func $accessor) ) ')' )?
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:63:3: ( propertyname[subquery] -> propertyname )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:63:4: propertyname[subquery]
            this.pushFollow(LinqToQuerystringParser.FOLLOW_propertyname_in_accessor481);
            propertyname58=this.propertyname(subquery);

            this.state._fsp--;

            stream_propertyname.add(propertyname58.getTree());


            // AST REWRITE
            // elements: propertyname
            // token labels: 
            // rule labels: retval
            // token list labels: 
            // rule list labels: 
            retval.tree = root_0;
            var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

            root_0 = this.adaptor.nil();
            // 63:27: -> propertyname
            {
                this.adaptor.addChild(root_0, stream_propertyname.nextTree());

            }

            retval.tree = root_0;


            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:63:44: ( '/' (func= ANY | func= ALL | func= COUNT | func= MAX | func= MIN | func= SUM | func= AVERAGE ) '(' ( (id= IDENTIFIER ':' SPACE filterexpression[true] ) -> ^( $func $accessor ALIAS[$id] filterexpression ) | -> ^( $func $accessor) ) ')' )?
            var alt20=2;
            var LA20_0 = this.input.LA(1);

            if ( (LA20_0==59) ) {
                alt20=1;
            }
            switch (alt20) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:4: '/' (func= ANY | func= ALL | func= COUNT | func= MAX | func= MIN | func= SUM | func= AVERAGE ) '(' ( (id= IDENTIFIER ':' SPACE filterexpression[true] ) -> ^( $func $accessor ALIAS[$id] filterexpression ) | -> ^( $func $accessor) ) ')'
                    char_literal59=this.match(this.input,59,LinqToQuerystringParser.FOLLOW_59_in_accessor494);  
                    stream_59.add(char_literal59);

                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:8: (func= ANY | func= ALL | func= COUNT | func= MAX | func= MIN | func= SUM | func= AVERAGE )
                    var alt18=7;
                    switch ( this.input.LA(1) ) {
                    case ANY:
                        alt18=1;
                        break;
                    case ALL:
                        alt18=2;
                        break;
                    case COUNT:
                        alt18=3;
                        break;
                    case MAX:
                        alt18=4;
                        break;
                    case MIN:
                        alt18=5;
                        break;
                    case SUM:
                        alt18=6;
                        break;
                    case AVERAGE:
                        alt18=7;
                        break;
                    default:
                        var nvae =
                            new org.antlr.runtime.NoViableAltException("", 18, 0, this.input);

                        throw nvae;
                    }

                    switch (alt18) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:9: func= ANY
                            func=this.match(this.input,ANY,LinqToQuerystringParser.FOLLOW_ANY_in_accessor499);  
                            stream_ANY.add(func);



                            break;
                        case 2 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:20: func= ALL
                            func=this.match(this.input,ALL,LinqToQuerystringParser.FOLLOW_ALL_in_accessor505);  
                            stream_ALL.add(func);



                            break;
                        case 3 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:31: func= COUNT
                            func=this.match(this.input,COUNT,LinqToQuerystringParser.FOLLOW_COUNT_in_accessor511);  
                            stream_COUNT.add(func);



                            break;
                        case 4 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:44: func= MAX
                            func=this.match(this.input,MAX,LinqToQuerystringParser.FOLLOW_MAX_in_accessor517);  
                            stream_MAX.add(func);



                            break;
                        case 5 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:55: func= MIN
                            func=this.match(this.input,MIN,LinqToQuerystringParser.FOLLOW_MIN_in_accessor523);  
                            stream_MIN.add(func);



                            break;
                        case 6 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:66: func= SUM
                            func=this.match(this.input,SUM,LinqToQuerystringParser.FOLLOW_SUM_in_accessor529);  
                            stream_SUM.add(func);



                            break;
                        case 7 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:64:77: func= AVERAGE
                            func=this.match(this.input,AVERAGE,LinqToQuerystringParser.FOLLOW_AVERAGE_in_accessor535);  
                            stream_AVERAGE.add(func);



                            break;

                    }

                    char_literal60=this.match(this.input,57,LinqToQuerystringParser.FOLLOW_57_in_accessor542);  
                    stream_57.add(char_literal60);

                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:65:8: ( (id= IDENTIFIER ':' SPACE filterexpression[true] ) -> ^( $func $accessor ALIAS[$id] filterexpression ) | -> ^( $func $accessor) )
                    var alt19=2;
                    var LA19_0 = this.input.LA(1);

                    if ( (LA19_0==IDENTIFIER) ) {
                        alt19=1;
                    }
                    else if ( (LA19_0==58) ) {
                        alt19=2;
                    }
                    else {
                        var nvae =
                            new org.antlr.runtime.NoViableAltException("", 19, 0, this.input);

                        throw nvae;
                    }
                    switch (alt19) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:66:5: (id= IDENTIFIER ':' SPACE filterexpression[true] )
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:66:5: (id= IDENTIFIER ':' SPACE filterexpression[true] )
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:66:6: id= IDENTIFIER ':' SPACE filterexpression[true]
                            id=this.match(this.input,IDENTIFIER,LinqToQuerystringParser.FOLLOW_IDENTIFIER_in_accessor553);  
                            stream_IDENTIFIER.add(id);

                            char_literal61=this.match(this.input,60,LinqToQuerystringParser.FOLLOW_60_in_accessor555);  
                            stream_60.add(char_literal61);

                            SPACE62=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_accessor557);  
                            stream_SPACE.add(SPACE62);

                            this.pushFollow(LinqToQuerystringParser.FOLLOW_filterexpression_in_accessor559);
                            filterexpression63=this.filterexpression(true);

                            this.state._fsp--;

                            stream_filterexpression.add(filterexpression63.getTree());





                            // AST REWRITE
                            // elements: func, filterexpression, accessor
                            // token labels: func
                            // rule labels: retval
                            // token list labels: 
                            // rule list labels: 
                            retval.tree = root_0;
                            var stream_func=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token func",func);
                            var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                            root_0 = this.adaptor.nil();
                            // 66:54: -> ^( $func $accessor ALIAS[$id] filterexpression )
                            {
                                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:66:57: ^( $func $accessor ALIAS[$id] filterexpression )
                                {
                                var root_1 = this.adaptor.nil();
                                root_1 = this.adaptor.becomeRoot(stream_func.nextNode(), root_1);

                                this.adaptor.addChild(root_1, stream_retval.nextTree());
                                this.adaptor.addChild(root_1, this.adaptor.create(ALIAS, id));
                                this.adaptor.addChild(root_1, stream_filterexpression.nextTree());

                                this.adaptor.addChild(root_0, root_1);
                                }

                            }

                            retval.tree = root_0;

                            break;
                        case 2 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:67:7: 

                            // AST REWRITE
                            // elements: func, accessor
                            // token labels: func
                            // rule labels: retval
                            // token list labels: 
                            // rule list labels: 
                            retval.tree = root_0;
                            var stream_func=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token func",func);
                            var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                            root_0 = this.adaptor.nil();
                            // 67:7: -> ^( $func $accessor)
                            {
                                // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:67:10: ^( $func $accessor)
                                {
                                var root_1 = this.adaptor.nil();
                                root_1 = this.adaptor.becomeRoot(stream_func.nextNode(), root_1);

                                this.adaptor.addChild(root_1, stream_retval.nextTree());

                                this.adaptor.addChild(root_0, root_1);
                                }

                            }

                            retval.tree = root_0;

                            break;

                    }

                    char_literal64=this.match(this.input,58,LinqToQuerystringParser.FOLLOW_58_in_accessor599);  
                    stream_58.add(char_literal64);



                    break;

            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    function_return: (function() {
        LinqToQuerystringParser.function_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.function_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:71:1: function : ( STARTSWITH | ENDSWITH | SUBSTRINGOF | TOLOWER );
    // $ANTLR start "function"
    function: function() {
        var retval = new LinqToQuerystringParser.function_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var set65 = null;

        var set65_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:72:2: ( STARTSWITH | ENDSWITH | SUBSTRINGOF | TOLOWER )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:
            root_0 = this.adaptor.nil();

            set65=this.input.LT(1);
            if ( (this.input.LA(1)>=STARTSWITH && this.input.LA(1)<=TOLOWER) ) {
                this.input.consume();
                this.adaptor.addChild(root_0, this.adaptor.create(set65));
                this.state.errorRecovery=false;
            }
            else {
                var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                throw mse;
            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    orderby_return: (function() {
        LinqToQuerystringParser.orderby_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.orderby_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:74:1: orderby : ORDERBY orderbylist ;
    // $ANTLR start "orderby"
    orderby: function() {
        var retval = new LinqToQuerystringParser.orderby_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var ORDERBY66 = null;
         var orderbylist67 = null;

        var ORDERBY66_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:75:2: ( ORDERBY orderbylist )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:75:4: ORDERBY orderbylist
            root_0 = this.adaptor.nil();

            ORDERBY66=this.match(this.input,ORDERBY,LinqToQuerystringParser.FOLLOW_ORDERBY_in_orderby638); 
            ORDERBY66_tree = this.adaptor.create(ORDERBY66);
            root_0 = this.adaptor.becomeRoot(ORDERBY66_tree, root_0);

            this.pushFollow(LinqToQuerystringParser.FOLLOW_orderbylist_in_orderby641);
            orderbylist67=this.orderbylist();

            this.state._fsp--;

            this.adaptor.addChild(root_0, orderbylist67.getTree());



            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    orderbylist_return: (function() {
        LinqToQuerystringParser.orderbylist_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.orderbylist_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:77:1: orderbylist : orderpropertyname ( ',' orderpropertyname )* ;
    // $ANTLR start "orderbylist"
    orderbylist: function() {
        var retval = new LinqToQuerystringParser.orderbylist_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var char_literal69 = null;
         var orderpropertyname68 = null;
         var orderpropertyname70 = null;

        var char_literal69_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:78:2: ( orderpropertyname ( ',' orderpropertyname )* )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:78:4: orderpropertyname ( ',' orderpropertyname )*
            root_0 = this.adaptor.nil();

            this.pushFollow(LinqToQuerystringParser.FOLLOW_orderpropertyname_in_orderbylist651);
            orderpropertyname68=this.orderpropertyname();

            this.state._fsp--;

            this.adaptor.addChild(root_0, orderpropertyname68.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:78:22: ( ',' orderpropertyname )*
            loop21:
            do {
                var alt21=2;
                var LA21_0 = this.input.LA(1);

                if ( (LA21_0==56) ) {
                    alt21=1;
                }


                switch (alt21) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:78:23: ',' orderpropertyname
                    char_literal69=this.match(this.input,56,LinqToQuerystringParser.FOLLOW_56_in_orderbylist654); 
                    this.pushFollow(LinqToQuerystringParser.FOLLOW_orderpropertyname_in_orderbylist657);
                    orderpropertyname70=this.orderpropertyname();

                    this.state._fsp--;

                    this.adaptor.addChild(root_0, orderpropertyname70.getTree());


                    break;

                default :
                    break loop21;
                }
            } while (true);




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    orderpropertyname_return: (function() {
        LinqToQuerystringParser.orderpropertyname_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.orderpropertyname_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:80:1: orderpropertyname : propertyname[false] ( -> ^( ASC[\"asc\"] propertyname ) | ( SPACE (op= ASC | op= DESC ) ) -> ^( $op propertyname ) ) ;
    // $ANTLR start "orderpropertyname"
    orderpropertyname: function() {
        var retval = new LinqToQuerystringParser.orderpropertyname_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var op = null;
        var SPACE72 = null;
         var propertyname71 = null;

        var op_tree=null;
        var SPACE72_tree=null;
        var stream_ASC=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token ASC");
        var stream_DESC=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token DESC");
        var stream_SPACE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token SPACE");
        var stream_propertyname=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"rule propertyname");
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:81:2: ( propertyname[false] ( -> ^( ASC[\"asc\"] propertyname ) | ( SPACE (op= ASC | op= DESC ) ) -> ^( $op propertyname ) ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:81:4: propertyname[false] ( -> ^( ASC[\"asc\"] propertyname ) | ( SPACE (op= ASC | op= DESC ) ) -> ^( $op propertyname ) )
            this.pushFollow(LinqToQuerystringParser.FOLLOW_propertyname_in_orderpropertyname668);
            propertyname71=this.propertyname(false);

            this.state._fsp--;

            stream_propertyname.add(propertyname71.getTree());
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:81:24: ( -> ^( ASC[\"asc\"] propertyname ) | ( SPACE (op= ASC | op= DESC ) ) -> ^( $op propertyname ) )
            var alt23=2;
            var LA23_0 = this.input.LA(1);

            if ( (LA23_0==EOF||LA23_0==SKIP||(LA23_0>=TOP && LA23_0<=INLINECOUNT)||LA23_0==ORDERBY||(LA23_0>=55 && LA23_0<=56)) ) {
                alt23=1;
            }
            else if ( (LA23_0==SPACE) ) {
                alt23=2;
            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 23, 0, this.input);

                throw nvae;
            }
            switch (alt23) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:82:4: 

                    // AST REWRITE
                    // elements: propertyname
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 82:4: -> ^( ASC[\"asc\"] propertyname )
                    {
                        // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:82:7: ^( ASC[\"asc\"] propertyname )
                        {
                        var root_1 = this.adaptor.nil();
                        root_1 = this.adaptor.becomeRoot(this.adaptor.create(ASC, "asc"), root_1);

                        this.adaptor.addChild(root_1, stream_propertyname.nextTree());

                        this.adaptor.addChild(root_0, root_1);
                        }

                    }

                    retval.tree = root_0;

                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:83:6: ( SPACE (op= ASC | op= DESC ) )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:83:6: ( SPACE (op= ASC | op= DESC ) )
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:83:7: SPACE (op= ASC | op= DESC )
                    SPACE72=this.match(this.input,SPACE,LinqToQuerystringParser.FOLLOW_SPACE_in_orderpropertyname691);  
                    stream_SPACE.add(SPACE72);

                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:83:13: (op= ASC | op= DESC )
                    var alt22=2;
                    var LA22_0 = this.input.LA(1);

                    if ( (LA22_0==ASC) ) {
                        alt22=1;
                    }
                    else if ( (LA22_0==DESC) ) {
                        alt22=2;
                    }
                    else {
                        var nvae =
                            new org.antlr.runtime.NoViableAltException("", 22, 0, this.input);

                        throw nvae;
                    }
                    switch (alt22) {
                        case 1 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:83:14: op= ASC
                            op=this.match(this.input,ASC,LinqToQuerystringParser.FOLLOW_ASC_in_orderpropertyname696);  
                            stream_ASC.add(op);



                            break;
                        case 2 :
                            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:83:23: op= DESC
                            op=this.match(this.input,DESC,LinqToQuerystringParser.FOLLOW_DESC_in_orderpropertyname702);  
                            stream_DESC.add(op);



                            break;

                    }






                    // AST REWRITE
                    // elements: op, propertyname
                    // token labels: op
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_op=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token op",op);
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 83:33: -> ^( $op propertyname )
                    {
                        // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:83:36: ^( $op propertyname )
                        {
                        var root_1 = this.adaptor.nil();
                        root_1 = this.adaptor.becomeRoot(stream_op.nextNode(), root_1);

                        this.adaptor.addChild(root_1, stream_propertyname.nextTree());

                        this.adaptor.addChild(root_0, root_1);
                        }

                    }

                    retval.tree = root_0;

                    break;

            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    constant_return: (function() {
        LinqToQuerystringParser.constant_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.constant_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:86:1: constant : (int= INT -> INT[int] | bool= BOOL -> BOOL[bool] | str= STRING -> STRING[str] | date= DATETIME -> DATETIME[date] | long= LONG -> LONG[long] | sing= SINGLE -> SINGLE[sing] | dbl= DOUBLE -> DOUBLE[dbl] | guid= GUID -> GUID[guid] | byte= BYTE -> BYTE[byte] ) ;
    // $ANTLR start "constant"
    constant: function() {
        var retval = new LinqToQuerystringParser.constant_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var int = null;
        var bool = null;
        var str = null;
        var date = null;
        var long = null;
        var sing = null;
        var dbl = null;
        var guid = null;
        var byte = null;

        var int_tree=null;
        var bool_tree=null;
        var str_tree=null;
        var date_tree=null;
        var long_tree=null;
        var sing_tree=null;
        var dbl_tree=null;
        var guid_tree=null;
        var byte_tree=null;
        var stream_DOUBLE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token DOUBLE");
        var stream_BYTE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token BYTE");
        var stream_GUID=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token GUID");
        var stream_INT=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token INT");
        var stream_SINGLE=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token SINGLE");
        var stream_LONG=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token LONG");
        var stream_DATETIME=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token DATETIME");
        var stream_STRING=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token STRING");
        var stream_BOOL=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token BOOL");

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:87:2: ( (int= INT -> INT[int] | bool= BOOL -> BOOL[bool] | str= STRING -> STRING[str] | date= DATETIME -> DATETIME[date] | long= LONG -> LONG[long] | sing= SINGLE -> SINGLE[sing] | dbl= DOUBLE -> DOUBLE[dbl] | guid= GUID -> GUID[guid] | byte= BYTE -> BYTE[byte] ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:87:4: (int= INT -> INT[int] | bool= BOOL -> BOOL[bool] | str= STRING -> STRING[str] | date= DATETIME -> DATETIME[date] | long= LONG -> LONG[long] | sing= SINGLE -> SINGLE[sing] | dbl= DOUBLE -> DOUBLE[dbl] | guid= GUID -> GUID[guid] | byte= BYTE -> BYTE[byte] )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:87:4: (int= INT -> INT[int] | bool= BOOL -> BOOL[bool] | str= STRING -> STRING[str] | date= DATETIME -> DATETIME[date] | long= LONG -> LONG[long] | sing= SINGLE -> SINGLE[sing] | dbl= DOUBLE -> DOUBLE[dbl] | guid= GUID -> GUID[guid] | byte= BYTE -> BYTE[byte] )
            var alt24=9;
            switch ( this.input.LA(1) ) {
            case INT:
                alt24=1;
                break;
            case BOOL:
                alt24=2;
                break;
            case STRING:
                alt24=3;
                break;
            case DATETIME:
                alt24=4;
                break;
            case LONG:
                alt24=5;
                break;
            case SINGLE:
                alt24=6;
                break;
            case DOUBLE:
                alt24=7;
                break;
            case GUID:
                alt24=8;
                break;
            case BYTE:
                alt24=9;
                break;
            default:
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 24, 0, this.input);

                throw nvae;
            }

            switch (alt24) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:88:3: int= INT
                    int=this.match(this.input,INT,LinqToQuerystringParser.FOLLOW_INT_in_constant734);  
                    stream_INT.add(int);



                    // AST REWRITE
                    // elements: INT
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 88:11: -> INT[int]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(INT, int));

                    }

                    retval.tree = root_0;

                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:89:3: bool= BOOL
                    bool=this.match(this.input,BOOL,LinqToQuerystringParser.FOLLOW_BOOL_in_constant748);  
                    stream_BOOL.add(bool);



                    // AST REWRITE
                    // elements: BOOL
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 89:13: -> BOOL[bool]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(BOOL, bool));

                    }

                    retval.tree = root_0;

                    break;
                case 3 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:90:3: str= STRING
                    str=this.match(this.input,STRING,LinqToQuerystringParser.FOLLOW_STRING_in_constant762);  
                    stream_STRING.add(str);



                    // AST REWRITE
                    // elements: STRING
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 90:14: -> STRING[str]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(STRING, str));

                    }

                    retval.tree = root_0;

                    break;
                case 4 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:91:3: date= DATETIME
                    date=this.match(this.input,DATETIME,LinqToQuerystringParser.FOLLOW_DATETIME_in_constant776);  
                    stream_DATETIME.add(date);



                    // AST REWRITE
                    // elements: DATETIME
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 91:17: -> DATETIME[date]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(DATETIME, date));

                    }

                    retval.tree = root_0;

                    break;
                case 5 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:92:3: long= LONG
                    long=this.match(this.input,LONG,LinqToQuerystringParser.FOLLOW_LONG_in_constant790);  
                    stream_LONG.add(long);



                    // AST REWRITE
                    // elements: LONG
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 92:13: -> LONG[long]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(LONG, long));

                    }

                    retval.tree = root_0;

                    break;
                case 6 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:93:3: sing= SINGLE
                    sing=this.match(this.input,SINGLE,LinqToQuerystringParser.FOLLOW_SINGLE_in_constant804);  
                    stream_SINGLE.add(sing);



                    // AST REWRITE
                    // elements: SINGLE
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 93:15: -> SINGLE[sing]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(SINGLE, sing));

                    }

                    retval.tree = root_0;

                    break;
                case 7 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:94:3: dbl= DOUBLE
                    dbl=this.match(this.input,DOUBLE,LinqToQuerystringParser.FOLLOW_DOUBLE_in_constant818);  
                    stream_DOUBLE.add(dbl);



                    // AST REWRITE
                    // elements: DOUBLE
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 94:14: -> DOUBLE[dbl]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(DOUBLE, dbl));

                    }

                    retval.tree = root_0;

                    break;
                case 8 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:95:3: guid= GUID
                    guid=this.match(this.input,GUID,LinqToQuerystringParser.FOLLOW_GUID_in_constant832);  
                    stream_GUID.add(guid);



                    // AST REWRITE
                    // elements: GUID
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 95:13: -> GUID[guid]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(GUID, guid));

                    }

                    retval.tree = root_0;

                    break;
                case 9 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:96:3: byte= BYTE
                    byte=this.match(this.input,BYTE,LinqToQuerystringParser.FOLLOW_BYTE_in_constant846);  
                    stream_BYTE.add(byte);



                    // AST REWRITE
                    // elements: BYTE
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 96:13: -> BYTE[byte]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(BYTE, byte));

                    }

                    retval.tree = root_0;

                    break;

            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    propertyname_return: (function() {
        LinqToQuerystringParser.propertyname_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.propertyname_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:99:1: propertyname[subquery] : ( identifierpart[subquery] -> identifierpart ) ( '/' next= subpropertyname[false] -> ^( $propertyname $next) )? ;
    // $ANTLR start "propertyname"
    propertyname: function(subquery) {
        var retval = new LinqToQuerystringParser.propertyname_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var char_literal74 = null;
         var next = null;
         var identifierpart73 = null;

        var char_literal74_tree=null;
        var stream_59=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token 59");
        var stream_identifierpart=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"rule identifierpart");
        var stream_subpropertyname=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"rule subpropertyname");
        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:100:2: ( ( identifierpart[subquery] -> identifierpart ) ( '/' next= subpropertyname[false] -> ^( $propertyname $next) )? )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:100:4: ( identifierpart[subquery] -> identifierpart ) ( '/' next= subpropertyname[false] -> ^( $propertyname $next) )?
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:100:4: ( identifierpart[subquery] -> identifierpart )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:100:5: identifierpart[subquery]
            this.pushFollow(LinqToQuerystringParser.FOLLOW_identifierpart_in_propertyname865);
            identifierpart73=this.identifierpart(subquery);

            this.state._fsp--;

            stream_identifierpart.add(identifierpart73.getTree());


            // AST REWRITE
            // elements: identifierpart
            // token labels: 
            // rule labels: retval
            // token list labels: 
            // rule list labels: 
            retval.tree = root_0;
            var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

            root_0 = this.adaptor.nil();
            // 100:30: -> identifierpart
            {
                this.adaptor.addChild(root_0, stream_identifierpart.nextTree());

            }

            retval.tree = root_0;


            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:100:49: ( '/' next= subpropertyname[false] -> ^( $propertyname $next) )?
            var alt25=2;
            var LA25_0 = this.input.LA(1);

            if ( (LA25_0==59) ) {
                var LA25_1 = this.input.LA(2);

                if ( (LA25_1==IDENTIFIER||LA25_1==DYNAMICIDENTIFIER) ) {
                    alt25=1;
                }
            }
            switch (alt25) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:100:50: '/' next= subpropertyname[false]
                    char_literal74=this.match(this.input,59,LinqToQuerystringParser.FOLLOW_59_in_propertyname874);  
                    stream_59.add(char_literal74);

                    this.pushFollow(LinqToQuerystringParser.FOLLOW_subpropertyname_in_propertyname878);
                    next=this.subpropertyname(false);

                    this.state._fsp--;

                    stream_subpropertyname.add(next.getTree());


                    // AST REWRITE
                    // elements: propertyname, next
                    // token labels: 
                    // rule labels: retval, next
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);
                    var stream_next=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token next",next!=null?next.tree:null);

                    root_0 = this.adaptor.nil();
                    // 100:82: -> ^( $propertyname $next)
                    {
                        // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:100:85: ^( $propertyname $next)
                        {
                        var root_1 = this.adaptor.nil();
                        root_1 = this.adaptor.becomeRoot(stream_retval.nextNode(), root_1);

                        this.adaptor.addChild(root_1, stream_next.nextTree());

                        this.adaptor.addChild(root_0, root_1);
                        }

                    }

                    retval.tree = root_0;

                    break;

            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    subpropertyname_return: (function() {
        LinqToQuerystringParser.subpropertyname_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.subpropertyname_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:102:1: subpropertyname[subquery] : propertyname[false] ;
    // $ANTLR start "subpropertyname"
    subpropertyname: function(subquery) {
        var retval = new LinqToQuerystringParser.subpropertyname_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

         var propertyname75 = null;


        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:103:2: ( propertyname[false] )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:103:4: propertyname[false]
            root_0 = this.adaptor.nil();

            this.pushFollow(LinqToQuerystringParser.FOLLOW_propertyname_in_subpropertyname901);
            propertyname75=this.propertyname(false);

            this.state._fsp--;

            this.adaptor.addChild(root_0, propertyname75.getTree());



            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    identifierpart_return: (function() {
        LinqToQuerystringParser.identifierpart_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.identifierpart_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:105:1: identifierpart[subquery] : (id= IDENTIFIER -> {subquery}? ALIAS[$id] -> IDENTIFIER[$id] | id= DYNAMICIDENTIFIER -> DYNAMICIDENTIFIER[id] ) ;
    // $ANTLR start "identifierpart"
    identifierpart: function(subquery) {
        var retval = new LinqToQuerystringParser.identifierpart_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var id = null;

        var id_tree=null;
        var stream_IDENTIFIER=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token IDENTIFIER");
        var stream_DYNAMICIDENTIFIER=new org.antlr.runtime.tree.RewriteRuleTokenStream(this.adaptor,"token DYNAMICIDENTIFIER");

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:106:2: ( (id= IDENTIFIER -> {subquery}? ALIAS[$id] -> IDENTIFIER[$id] | id= DYNAMICIDENTIFIER -> DYNAMICIDENTIFIER[id] ) )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:106:4: (id= IDENTIFIER -> {subquery}? ALIAS[$id] -> IDENTIFIER[$id] | id= DYNAMICIDENTIFIER -> DYNAMICIDENTIFIER[id] )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:106:4: (id= IDENTIFIER -> {subquery}? ALIAS[$id] -> IDENTIFIER[$id] | id= DYNAMICIDENTIFIER -> DYNAMICIDENTIFIER[id] )
            var alt26=2;
            var LA26_0 = this.input.LA(1);

            if ( (LA26_0==IDENTIFIER) ) {
                alt26=1;
            }
            else if ( (LA26_0==DYNAMICIDENTIFIER) ) {
                alt26=2;
            }
            else {
                var nvae =
                    new org.antlr.runtime.NoViableAltException("", 26, 0, this.input);

                throw nvae;
            }
            switch (alt26) {
                case 1 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:106:5: id= IDENTIFIER
                    id=this.match(this.input,IDENTIFIER,LinqToQuerystringParser.FOLLOW_IDENTIFIER_in_identifierpart916);  
                    stream_IDENTIFIER.add(id);



                    // AST REWRITE
                    // elements: IDENTIFIER
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 106:19: -> {subquery}? ALIAS[$id]
                    if (subquery) {
                        this.adaptor.addChild(root_0, this.adaptor.create(ALIAS, id));

                    }
                    else // 107:5: -> IDENTIFIER[$id]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(IDENTIFIER, id));

                    }

                    retval.tree = root_0;

                    break;
                case 2 :
                    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:108:5: id= DYNAMICIDENTIFIER
                    id=this.match(this.input,DYNAMICIDENTIFIER,LinqToQuerystringParser.FOLLOW_DYNAMICIDENTIFIER_in_identifierpart940);  
                    stream_DYNAMICIDENTIFIER.add(id);



                    // AST REWRITE
                    // elements: DYNAMICIDENTIFIER
                    // token labels: 
                    // rule labels: retval
                    // token list labels: 
                    // rule list labels: 
                    retval.tree = root_0;
                    var stream_retval=new org.antlr.runtime.tree.RewriteRuleSubtreeStream(this.adaptor,"token retval",retval!=null?retval.tree:null);

                    root_0 = this.adaptor.nil();
                    // 108:26: -> DYNAMICIDENTIFIER[id]
                    {
                        this.adaptor.addChild(root_0, this.adaptor.create(DYNAMICIDENTIFIER, id));

                    }

                    retval.tree = root_0;

                    break;

            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    },

    // inline static return class
    filteroperator_return: (function() {
        LinqToQuerystringParser.filteroperator_return = function(){};
        org.antlr.lang.extend(LinqToQuerystringParser.filteroperator_return,
                          org.antlr.runtime.ParserRuleReturnScope,
        {
            getTree: function() { return this.tree; }
        });
        return;
    })(),

    // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:110:1: filteroperator : ( EQUALS | NOTEQUALS | GREATERTHAN | GREATERTHANOREQUAL | LESSTHAN | LESSTHANOREQUAL );
    // $ANTLR start "filteroperator"
    filteroperator: function() {
        var retval = new LinqToQuerystringParser.filteroperator_return();
        retval.start = this.input.LT(1);

        var root_0 = null;

        var set76 = null;

        var set76_tree=null;

        try {
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:111:2: ( EQUALS | NOTEQUALS | GREATERTHAN | GREATERTHANOREQUAL | LESSTHAN | LESSTHANOREQUAL )
            // D:\\Code\\LinqToQuerystring\\LinqToQuerystring.Javascript\\LinqToQuerystring.g:
            root_0 = this.adaptor.nil();

            set76=this.input.LT(1);
            if ( (this.input.LA(1)>=EQUALS && this.input.LA(1)<=LESSTHANOREQUAL) ) {
                this.input.consume();
                this.adaptor.addChild(root_0, this.adaptor.create(set76));
                this.state.errorRecovery=false;
            }
            else {
                var mse = new org.antlr.runtime.MismatchedSetException(null,this.input);
                throw mse;
            }




            retval.stop = this.input.LT(-1);

            retval.tree = this.adaptor.rulePostProcessing(root_0);
            this.adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

        }
        catch (re) {
            if (re instanceof org.antlr.runtime.RecognitionException) {
                this.reportError(re);
                this.recover(this.input,re);
                retval.tree = this.adaptor.errorNode(this.input, retval.start, this.input.LT(-1), re);
            } else {
                throw re;
            }
        }
        finally {
        }
        return retval;
    }

    // Delegated rules




}, true); // important to pass true to overwrite default implementations

 

// public class variables
org.antlr.lang.augmentObject(LinqToQuerystringParser, {
    tokenNames: ["<invalid>", "<EOR>", "<DOWN>", "<UP>", "ALIAS", "SKIP", "INT", "TOP", "FILTER", "SELECT", "EXPAND", "INLINECOUNT", "ALLPAGES", "NONE", "SPACE", "OR", "AND", "NOT", "EQUALS", "NOTEQUALS", "GREATERTHAN", "GREATERTHANOREQUAL", "LESSTHAN", "LESSTHANOREQUAL", "ANY", "ALL", "COUNT", "MAX", "MIN", "SUM", "AVERAGE", "IDENTIFIER", "STARTSWITH", "ENDSWITH", "SUBSTRINGOF", "TOLOWER", "ORDERBY", "ASC", "DESC", "BOOL", "STRING", "DATETIME", "LONG", "SINGLE", "DOUBLE", "GUID", "BYTE", "DYNAMICIDENTIFIER", "ASSIGN", "HEX_PAIR", "NEWLINE", "HEX_DIGIT", "ESC_SEQ", "UNICODE_ESC", "OCTAL_ESC", "'&'", "','", "'('", "')'", "'/'", "':'"],
    FOLLOW_param_in_prog40: new org.antlr.runtime.BitSet([0x00000FA2, 0x00800010]),
    FOLLOW_55_in_prog43: new org.antlr.runtime.BitSet([0x00000FA0, 0x00800010]),
    FOLLOW_param_in_prog46: new org.antlr.runtime.BitSet([0x00000FA2, 0x00800010]),
    FOLLOW_orderby_in_param59: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_top_in_param63: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_skip_in_param67: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_filter_in_param71: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_select_in_param75: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_inlinecount_in_param79: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_expand_in_param83: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_SKIP_in_skip94: new org.antlr.runtime.BitSet([0x00000040, 0x00000000]),
    FOLLOW_INT_in_skip98: new org.antlr.runtime.BitSet([0x00000042, 0x00000000]),
    FOLLOW_TOP_in_top118: new org.antlr.runtime.BitSet([0x00000040, 0x00000000]),
    FOLLOW_INT_in_top122: new org.antlr.runtime.BitSet([0x00000042, 0x00000000]),
    FOLLOW_FILTER_in_filter142: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_filterexpression_in_filter145: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_SELECT_in_select156: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_propertyname_in_select159: new org.antlr.runtime.BitSet([0x00000002, 0x01000000]),
    FOLLOW_56_in_select163: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_propertyname_in_select166: new org.antlr.runtime.BitSet([0x00000002, 0x01000000]),
    FOLLOW_EXPAND_in_expand181: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_propertyname_in_expand184: new org.antlr.runtime.BitSet([0x00000002, 0x01000000]),
    FOLLOW_56_in_expand188: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_propertyname_in_expand191: new org.antlr.runtime.BitSet([0x00000002, 0x01000000]),
    FOLLOW_INLINECOUNT_in_inlinecount204: new org.antlr.runtime.BitSet([0x00001000, 0x00000000]),
    FOLLOW_ALLPAGES_in_inlinecount207: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_INLINECOUNT_in_inlinecount212: new org.antlr.runtime.BitSet([0x00002000, 0x00000000]),
    FOLLOW_NONE_in_inlinecount214: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_orexpression_in_filterexpression226: new org.antlr.runtime.BitSet([0x00004002, 0x00000000]),
    FOLLOW_SPACE_in_filterexpression230: new org.antlr.runtime.BitSet([0x00008000, 0x00000000]),
    FOLLOW_OR_in_filterexpression233: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_SPACE_in_filterexpression236: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_orexpression_in_filterexpression239: new org.antlr.runtime.BitSet([0x00004002, 0x00000000]),
    FOLLOW_andexpression_in_orexpression253: new org.antlr.runtime.BitSet([0x00004002, 0x00000000]),
    FOLLOW_SPACE_in_orexpression257: new org.antlr.runtime.BitSet([0x00010000, 0x00000000]),
    FOLLOW_AND_in_orexpression260: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_SPACE_in_orexpression263: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_andexpression_in_orexpression266: new org.antlr.runtime.BitSet([0x00004002, 0x00000000]),
    FOLLOW_NOT_in_andexpression280: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_SPACE_in_andexpression283: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_57_in_andexpression286: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_filterexpression_in_andexpression288: new org.antlr.runtime.BitSet([0x00000000, 0x04000000]),
    FOLLOW_58_in_andexpression291: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_booleanexpression_in_andexpression295: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_57_in_andexpression303: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_filterexpression_in_andexpression305: new org.antlr.runtime.BitSet([0x00000000, 0x04000000]),
    FOLLOW_58_in_andexpression308: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_booleanexpression_in_andexpression312: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_atom_in_booleanexpression328: new org.antlr.runtime.BitSet([0x00004002, 0x00000000]),
    FOLLOW_SPACE_in_booleanexpression336: new org.antlr.runtime.BitSet([0x00FC0000, 0x00000000]),
    FOLLOW_EQUALS_in_booleanexpression341: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_NOTEQUALS_in_booleanexpression347: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_GREATERTHAN_in_booleanexpression353: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_GREATERTHANOREQUAL_in_booleanexpression359: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_LESSTHAN_in_booleanexpression365: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_LESSTHANOREQUAL_in_booleanexpression371: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_SPACE_in_booleanexpression374: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_atom_in_booleanexpression378: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_functioncall_in_atom430: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_constant_in_atom436: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_accessor_in_atom441: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_function_in_functioncall453: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_57_in_functioncall456: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_atom_in_functioncall458: new org.antlr.runtime.BitSet([0x00000000, 0x05000000]),
    FOLLOW_56_in_functioncall462: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_atom_in_functioncall464: new org.antlr.runtime.BitSet([0x00000000, 0x05000000]),
    FOLLOW_58_in_functioncall469: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_propertyname_in_accessor481: new org.antlr.runtime.BitSet([0x00000002, 0x08000000]),
    FOLLOW_59_in_accessor494: new org.antlr.runtime.BitSet([0x7F000000, 0x00000000]),
    FOLLOW_ANY_in_accessor499: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_ALL_in_accessor505: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_COUNT_in_accessor511: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_MAX_in_accessor517: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_MIN_in_accessor523: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_SUM_in_accessor529: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_AVERAGE_in_accessor535: new org.antlr.runtime.BitSet([0x00000000, 0x02000000]),
    FOLLOW_57_in_accessor542: new org.antlr.runtime.BitSet([0x80000000, 0x04000000]),
    FOLLOW_IDENTIFIER_in_accessor553: new org.antlr.runtime.BitSet([0x00000000, 0x10000000]),
    FOLLOW_60_in_accessor555: new org.antlr.runtime.BitSet([0x00004000, 0x00000000]),
    FOLLOW_SPACE_in_accessor557: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_filterexpression_in_accessor559: new org.antlr.runtime.BitSet([0x00000000, 0x04000000]),
    FOLLOW_58_in_accessor599: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_set_in_function0: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_ORDERBY_in_orderby638: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_orderbylist_in_orderby641: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_orderpropertyname_in_orderbylist651: new org.antlr.runtime.BitSet([0x00000002, 0x01000000]),
    FOLLOW_56_in_orderbylist654: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_orderpropertyname_in_orderbylist657: new org.antlr.runtime.BitSet([0x00000002, 0x01000000]),
    FOLLOW_propertyname_in_orderpropertyname668: new org.antlr.runtime.BitSet([0x00004002, 0x00000000]),
    FOLLOW_SPACE_in_orderpropertyname691: new org.antlr.runtime.BitSet([0x00000000, 0x00000060]),
    FOLLOW_ASC_in_orderpropertyname696: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_DESC_in_orderpropertyname702: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_INT_in_constant734: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_BOOL_in_constant748: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_STRING_in_constant762: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_DATETIME_in_constant776: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_LONG_in_constant790: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_SINGLE_in_constant804: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_DOUBLE_in_constant818: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_GUID_in_constant832: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_BYTE_in_constant846: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_identifierpart_in_propertyname865: new org.antlr.runtime.BitSet([0x00000002, 0x08000000]),
    FOLLOW_59_in_propertyname874: new org.antlr.runtime.BitSet([0x80020040, 0x0200FF8F]),
    FOLLOW_subpropertyname_in_propertyname878: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_propertyname_in_subpropertyname901: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_IDENTIFIER_in_identifierpart916: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_DYNAMICIDENTIFIER_in_identifierpart940: new org.antlr.runtime.BitSet([0x00000002, 0x00000000]),
    FOLLOW_set_in_filteroperator0: new org.antlr.runtime.BitSet([0x00000002, 0x00000000])
});

})();