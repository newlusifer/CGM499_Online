let add=function(a,b)
{
    return a+b
}

let multiply = function(a,b)
{
    return a*b
}

let calc=function(v1,v2,callback)
{
    return callback(v1,v2);
}

let powER = function(a,b) 
{
    calculated=a;

    for(x=1;x<b;x++)
    {
        calculated=calculated*a;
    }

    return calculated;
}

console.log(calc(2,5,add));

calc(2,5,function(a,b){return a-b});
console.log(calc(2,5,function(a,b){return a-b}));

calc(2,5,function(a,b){return Math.pow(a,b)});
console.log(calc(2,5,function(a,b){return Math.pow(a,b)})+ ' this math.pow');

calc(2,5,powER);
console.log(calc(2,5,powER)+' this for loop');

