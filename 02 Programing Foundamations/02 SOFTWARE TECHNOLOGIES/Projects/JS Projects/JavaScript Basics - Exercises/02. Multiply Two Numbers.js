function MultiplyTwoNumber(input) {
    let numbers = input.filter(x =>x).map(Number);
    let num1 = numbers[0];
    let num2 = numbers[1];
    let result = num1*num2;
    console.log(result);
}

let text = ["" , "123", "", "1212"];

MultiplyTwoNumber(text);