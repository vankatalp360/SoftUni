function solve(input) {

    let numArray = input[0].split(' ').map(Number);
    let num1 = numArray[0];
    let num2 = numArray[1];
    let num3 = numArray[2];

    if (num1+num2==num3)
    {
        console.log(Math.min(num1,num2)+" + "+Math.max(num1,num2)+" = "+num3);
    }
    else  if (num2+num3==num1)
    {
        console.log(Math.min(num2,num3)+" + "+Math.max(num2,num3)+" = "+num1);
    }
    else if (num3+num1==num2)
    {
        console.log(Math.min(num3,num1)+" + "+Math.max(num3,num1)+" = "+num2);
    }
    else
        console.log('No');
}

