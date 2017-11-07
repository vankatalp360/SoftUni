function ReverseNumbers(input) {
let nums = input[0].split(' ');
let sum=0;
for(let num of nums)
{
sum+=parseInt(num.split("").reverse().join(""));
}
console.log(sum);
}

let text = [ '123 234 12' ];

ReverseNumbers(text);