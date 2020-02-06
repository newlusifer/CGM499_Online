var fs=require("fs");
/*
console.log('program started');
var data=fs.readFileSync('input.txt');   ////blocking IO = รันโค้ดเป็นบรรทัดๆไป
console.log(data.toString());
console.log('program ended');
*/

console.log('program started');

fs.readFile("input.txt",function(err,data){    ////nonBlocking IO = รันโค้ดไปจนจบโดยที่ไม่ต้องรอ readfile
    if(err)
    {
        console.log(err);
    }

    console.log(data.toString());
});


console.log('program ended');