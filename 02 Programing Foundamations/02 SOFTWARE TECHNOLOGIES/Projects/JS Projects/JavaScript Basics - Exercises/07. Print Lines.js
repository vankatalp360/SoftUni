function PrintAllLines(input) {
    let lines = input.filter(x =>x);
    for(let line of lines)
    {
        if (line === "Stop")
        {
            break;
        }

        console.log(line);
    }
}

let text =[ 'Line 1', 'Line 2', 'Line 3', 'Stop' ];

PrintAllLines(text);