'use strict';
let str = `156долларов - 94 евро + 17 биткоинов/5.34франка *4.4$ = `;
let newStr = str.replace(/[^+,//,-,*,/.\d\d-\d]/ig,''); // There are only numbers and +, -, /, *, =

let resNow = '';
let resStart;
let resEnd;
let total;

let index = 0;

function showLetter() {
    while(parseFloat(newStr[index])){ 
        if(newStr[index+1] == '.'){ // memorize decimal number
            resNow += newStr[index] +'.';
            index+=2;
        } else {
            resNow += newStr[index];
            // console.log(resNow);
            index++;
        }
    }
} 

function calcResStart(){
    if(total != undefined){
        resStart = total;
    }
    else{
        resStart = parseFloat(resNow);
        resNow = '';
    }
    // console.log(resStart);
}

function calcResEnd(){
    resEnd = parseFloat(resNow);
    resNow = '';
}
  
function calaResTotal(mathStr) {

    while(index < newStr.length){     
    showLetter(); 
      
        switch(newStr[index]) {            
            case '-':
                calcResStart();

                index++;
                showLetter();

                calcResEnd();
                
                total = resStart - resEnd;
                // console.log(`Worked: total = ${total}`);
                
                break;
            
            case '+': 
                calcResStart();

                index++;
                showLetter();

                calcResEnd();

                total = resStart + resEnd;
                // console.log(`Worked: total = ${total}`);
                break;

            case '/': 
                calcResStart();

                index++;
                showLetter();

                calcResEnd();

                total = resStart / resEnd;
                // console.log(`Worked: total = ${total}`);
                break;

            case '*': 
                calcResStart();

                index++;
                showLetter();

                calcResEnd();

                total = resStart * resEnd;
                // console.log(`Worked: total = ${total}`);
                break;
            
            default:
                console.log(`Error! Last calculated result: ${total}`);
                break;

        }
    }
}
calaResTotal(newStr);

let resTotal = total.toFixed(2);
console.log(`Result = ${resTotal}`);  

