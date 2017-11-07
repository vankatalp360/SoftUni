function printHexadecimalÀndBinary(input) {

    let decimalNumber = parseInt(input[0]);
    let heximalNumber =decimalNumber.toString(16).toUpperCase();
    let binary =decimalNumber.toString(2);
    console.log(heximalNumber);
    console.log(binary);
}


let text = ['255'];
printHexadecimal(text);