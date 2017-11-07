function parseObjects(arr) {
    for (let str of arr.filter(x => x))
    {
        let obj = JSON.parse(str);
        console.log(`Name: ${obj.name}`);
        console.log(`Age: ${obj.age}`);
        console.log(`Date: ${obj.date}`);
    }
}

let text =[ "{\"name\":\"Nakov\",\"age\":24,\"date\":\"04/04/2005\"}", "{\"name\":\"Nakov\",\"age\":24,\"date\":\"04/04/2005\"}"];

parseObjects(text);

function JSONObjects(input) {
    for (let i = 0; i < input.length; i++) {
        let result = JSON.parse(input[i])
        console.log(`Name: ${result.name}`)
        console.log(`Age: ${result.age}`)
        console.log(`Date: ${result.date}`)
    }
}