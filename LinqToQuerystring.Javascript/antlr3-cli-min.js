/*
Copyright (c) 2003-2008 Terence Parr. All rights reserved.
Code licensed under the BSD License:
http://www.antlr.org/license.html

Some parts of the ANTLR class:
Copyright (c) 2008, Yahoo! Inc. All rights reserved.
Code licensed under the BSD License:
http://developer.yahoo.net/yui/license.txt
*/
org.antlr.runtime.ANTLRFileStream=function(D,A){this.fileName=D;var C;if(typeof java!=="undefined"){C="loadFileUsingJava"}else{throw new Error("ANTLR File I/O is not supported in this JS implementation.")}var B=this[C](D,A);org.antlr.runtime.ANTLRFileStream.superclass.constructor.call(this,B)};org.antlr.lang.extend(org.antlr.runtime.ANTLRFileStream,org.antlr.runtime.ANTLRStringStream,{getSourceName:function(){return this.fileName},loadFileUsingJava:function(H,E){var G=new java.io.File(H),C=G.length(),B,D=new java.io.FileInputStream(G);if(E){B=new java.io.InputStreamReader(D,E)}else{B=new java.io.InputStreamReader(D)}var A,F=[];while((A=B.read())>=0){F.push(String.fromCharCode(A))}return F.join("")}});