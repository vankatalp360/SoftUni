function IsPrime(input) {

    let number = parseInt(input[0]);
    let result = false;
   if (number!=0&&number!=1)
   {
       result=true;
       for(let i = 2; i<=Math.sqrt(number);i++)
       {
           if (number%i===0)
           {
               result=false;
               break;
           }
       }
   }
    if(result)
    {
        console.log("True");
    }
    else
    {
        console.log("False");
    }
}


let text = ['2'];
IsPrime(text);