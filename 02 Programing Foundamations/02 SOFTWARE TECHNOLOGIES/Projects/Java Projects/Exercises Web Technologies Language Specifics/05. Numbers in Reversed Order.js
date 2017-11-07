function printInReverseOrder(input) {

    let number = input[0];
    let result="";
    for(let i =0; i < number.length;i++)
    {
        result+=number[number.length-1- i];
    }
    console.log(result);
}


let text = ['255.111'];
printInReverseOrder(text);