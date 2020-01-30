function convertToRadians(degree)
{
    return Math.PI*180*degree;
}

function convertDollarToBath(Dollar)
{
    return Dollar*31.12;
}

function checkHigestNumber(number1,number2,number3)
{
    var higest=0;

    if(number1>higest){higest=number1};
    if(number2>higest){higest=number2};
    if(number3>higest){higest=number3};

    return higest;
}



module.exports.radians=convertToRadians;

module.exports.cDollar=convertDollarToBath;

module.exports.cHigest=checkHigestNumber;

//module.exports.xxx=convertToRadians;
//xxx ข้างบนคือชื่อที่จะถูกเรียกใช้ หรือชื่อไฟล์ของโมดูลที่เราสร้าง

//ส่งเลขไป 3 ค่าแล้วให้มันตอบมาว่าเลขไหนมากสุด