/*
Copyright (c) 2003-2008 Terence Parr. All rights reserved.
Code licensed under the BSD License:
http://www.antlr.org/license.html

Some parts of the ANTLR class:
Copyright (c) 2008, Yahoo! Inc. All rights reserved.
Code licensed under the BSD License:
http://developer.yahoo.net/yui/license.txt
*/
/** This is a char buffer stream that is loaded from a file
 *  all at once when you construct the object.  This looks very
 *  much like an ANTLReader or ANTLRInputStream, but it's a special case
 *  since we know the exact size of the object to load.  We can avoid lots
 *  of data copying. 
 */
org.antlr.runtime.ANTLRFileStream = function(fileName, encoding) {
    this.fileName = fileName;

    // @todo need to add support for other JS interpreters that have file i/o
    // hooks (SpiderMonkey and WSH come to mind).
    var method;
    if (typeof java !== "undefined") { // rhino
        method = "loadFileUsingJava";
    } else {
        throw new Error(
            "ANTLR File I/O is not supported in this JS implementation."
        );
    }

    var data = this[method](fileName, encoding);
    org.antlr.runtime.ANTLRFileStream.superclass.constructor.call(this, data);
};

org.antlr.lang.extend(org.antlr.runtime.ANTLRFileStream,
                  org.antlr.runtime.ANTLRStringStream,
                  {
    getSourceName: function() {
        return this.fileName;
    },

    loadFileUsingJava: function(fileName, encoding) {
        var f = new java.io.File(fileName),
            size = f.length(),
            isr,
            fis = new java.io.FileInputStream(f);
        if (encoding) {
            isr = new java.io.InputStreamReader(fis, encoding);
        } else {
            isr = new java.io.InputStreamReader(fis);
        }

        /* Should use the ternary version of isr.read here, but can't figure
         * out how to create a Java char array from JS. . .
         * @todo
         */
        var charCode, data=[];
        while ((charCode = isr.read()) >= 0) {
            data.push(String.fromCharCode(charCode));
        }
        return data.join("");
    }
});
