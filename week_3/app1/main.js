//console.log("Hello World");

var a=5;
var b=a;
a;
b;

//console.log(a);

var a=['dog','cat'];
//console.log(a[0]);

var a='dog';
//console.log(typeof a);

var a=99;
var b='99';
/*
console.log(typeof a);
console.log(typeof b);

console.log(a==b);//print true falt จาวาสคริปจะทำการแปลงค่าเป็นตัวแปรแบบเดียวกันแล้วจะเปรียบเทียบกันได้
console.log(a===b);//ถ้า === คือตัวแปรที่เทียบจะต้องเป็นชนิดเดียวกัน
*/

var a=0; //is falt
if(a)
{
    console.log('excute');
}

//console.log(a==false);
//console.log(a===false);

function sayHello()
{
    console.log('Hello');
    
}

//sayHello();

//var f=sayHello();

var f = function sayHi()
{
    console.log('Hi');
}

//f();

/*var s = function()
{
    console.log('sawasdee');
}*/

var s = function(name)
{
    console.log('sawasdee '+name);
}

f();
s('New');