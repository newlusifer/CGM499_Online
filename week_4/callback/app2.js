let calc=function(v1,v2,calcType)
{
    if(calcType === 'add')
        return v1+v2;

    else(calcType === 'multiply')
    {
        return v1*v2;
    }
}
console.log(calc(10,6,'add'));
console.log(calc(2,5,'multiply'));