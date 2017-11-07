function ArrayIndexes(input) {
    let numbers = input.filter(x =>x);
    let elements = parseInt(input[0]);
    let arrayOfElements = [];
    arrayOfElements.length=elements;
       for(let i = 0 ; i < numbers.length-1;i++)
   {
       let currentInput = input[i+1].split(" ").filter( x => x !='-').map(Number);
       let currentIndex = currentInput[0];
       let currentValue = currentInput[1];
       arrayOfElements[currentIndex]=currentValue;

   }
    for(let element of arrayOfElements)
    {
        if (element===undefined)
        {
            console.log("0")
        }
        else
        console.log(element);
    }
}

let text =[ '5', '0 - 3', '3 - -1', '4 - 2' ];

ArrayIndexes(text);
