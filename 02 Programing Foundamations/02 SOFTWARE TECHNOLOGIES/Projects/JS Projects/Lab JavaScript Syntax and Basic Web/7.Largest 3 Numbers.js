function extractLasgestThreeNumbers(input) {
let allNumbers = input.map(Number);
let sortedNumbers = allNumbers.sort((a,b)=>b-a);
let result = sortedNumbers.slice(0,3);
console.log(result.join("\r\n"));
}

extractLasgestThreeNumbers(['10', '30', '15', '20', '50', '5']);
