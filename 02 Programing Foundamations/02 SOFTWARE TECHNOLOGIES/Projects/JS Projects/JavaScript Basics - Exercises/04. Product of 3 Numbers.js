function negativeOrPositive(input) {
    let numbers = input.filter(x =>x).map(Number);
    let X = numbers[0];
    let Y = numbers[1];
    let Z = numbers[2];
    let result=true;
   if (X<0)
   {
       result=!result;
   }
   if (Y<0)
   {
       result=!result;
   }
    if (Z<0)
    {
        result=!result;
    }

    if (result)
    {
        console.log("Positive")
    }
    else
    {
        console.log("Negative");
    }
}

let text = ["" , "-13", "", "12","14"];

negativeOrPositive(text);