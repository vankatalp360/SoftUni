function manipulateArray(input) {
    let lines = input.filter(x =>x);
    let arrayOfElements = [];
    for(let i = 0 ; i < lines.length;i++)
    {
        let currentInput = input[i].split(" ").filter( x => x );
        let currentCommand =currentInput[0];
        let currentValue = parseInt(currentInput[1]);
        switch (currentCommand)
        {
            case "add":
                arrayOfElements.push(currentValue);
                break;
            case "remove":
                arrayOfElements.splice(currentValue, 1);
        }
    }
    for(let element of arrayOfElements)
    {
        console.log(element);
    }
}

let text =[ 'add 3', 'add 5','remove 1', 'add 2' ];

manipulateArray(text);
