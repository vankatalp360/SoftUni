function printData(input)
{
    let numbers =  input[0].split(' ').map(Number);
    let step = numbers.length/4;
    let leftSequence = numbers.slice(0,step).reverse();
    let middleSequence = numbers.slice(step,3*step);
    let rightSequence = numbers.reverse().slice(0,step);
    let result=[];
    for(let number in middleSequence)
    {
        if (number<step)
        {
            result.push(leftSequence[number]+middleSequence[number]);
        }
        else
        {
            result.push(rightSequence[number-step]+middleSequence[number]);

        }
    }
        console.log(result.join(" "));
}

let text = [ '5 2 3 6'];

printData(text);
