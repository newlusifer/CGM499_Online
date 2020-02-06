
let x=function()
{
    console.log('i am called from inside function');
}

let y = function(callback)
{
    callback();
}
y(x);