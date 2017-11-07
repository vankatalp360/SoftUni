function printAllNumbersToN(input) {
    let numbers = input.filter(x =>x).map(Number);
    let top = numbers[0];
    for(let i = 1 ; i <=top; i++)
    {
        console.log(i);
    }
}

let text = ["" ,  "12"];

printAllNumbersToN(text);