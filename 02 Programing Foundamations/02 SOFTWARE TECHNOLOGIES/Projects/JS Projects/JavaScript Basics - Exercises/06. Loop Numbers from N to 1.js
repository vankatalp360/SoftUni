function printAllNumbersFromN(input) {
    let numbers = input.filter(x =>x).map(Number);
    let top = numbers[0];
    for(let i = top ; i >=1; i--)
    {
        console.log(i);
    }
}

let text = ["" ,  "12"];

printAllNumbersFromN(text);