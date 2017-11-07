function manipulateArray(input) {
    let resultArray = [];
    let lines = input.filter(x =>x);
    for (let line of lines)
    {
        let input = line.split(" ").filter(x => x);
        if (input.length==2)
        {
            let key = input[0];
            let value = input[1];
            if (resultArray[key]===undefined)
            {
                resultArray[key]=new Array();
            }
            resultArray[key].push(value);
        }
        else
        {
            let key = input[0];
            if (resultArray[key]!=undefined)
            {
                for(let values of resultArray[key])
                {
                    console.log(values);
                }
            }
            else
            {
                console.log("None")
            }
            break;
        }
    }
}

let text =[ 'key value', 'key eulav','test tset', 'key' ];

manipulateArray(text);
