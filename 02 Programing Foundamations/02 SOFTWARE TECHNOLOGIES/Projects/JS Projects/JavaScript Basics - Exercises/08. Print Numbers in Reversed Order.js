function ReverseNumbers(input) {
    let numbers = input.filter(x =>x).map(Number).reverse();
            console.log(numbers.join("\r\n"));
}

let text =[ '20', '3', '20', '1', '20' ];

ReverseNumbers(text);
