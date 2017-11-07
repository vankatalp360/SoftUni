function sortObjects(input) {
    let resultArray = [];
    let lines = input.filter(x =>x);
    for (let line of lines)
    {
               var arr = line.split(/[-> ]/).filter( x => x);

        resultArray.push(arr);
    }
    for(let person of resultArray)
    {
        console.log("Name: "+person[0]);
        console.log("Age: "+person[1]);
        console.log("Grade: "+person[2]);
    }
}

let text =[ 'Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90'];

sortObjects(text);
