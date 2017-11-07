function printData(input)
{
    let lines = input.filter(e => e);
    console.log("First name: "+lines[0]);
    console.log("Last name: "+lines[1]);
    console.log("Age: "+lines[2]);
    console.log("Gender: "+lines[3]);
    console.log("Personal ID: "+lines[4]);
    console.log("Unique Employee number:"+lines[5]);
}

let text = [ 'Amanda', 'Jonson', '27', 'f', '8306112507', '27563571', '' ];

printData(text);