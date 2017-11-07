function MultiplyTwoNumber(input) {
    let numbers = input.filter(x =>x).map(Number);
    let N = numbers[0];
    let X = numbers[1];
    let result;
    if (X>=N)
    {
        result = N*X;
    }
    else
    {
         result = N/X;
    }

    console.log(result);
}

let text = ["" , "13", "", "12"];

MultiplyTwoNumber(text);