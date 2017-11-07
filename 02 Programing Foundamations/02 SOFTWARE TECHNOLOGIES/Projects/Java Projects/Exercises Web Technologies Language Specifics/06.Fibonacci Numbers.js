function Fibonacci(input) {

    let number = parseInt(input[0]);
    if (number==0||number==1)
    {
        console.log("1");
    }
    else
    {
        let f1 = 0;
        let f2 = 1;
        let f;
        for (let i = 1; i <= number; i++)
        {
            f = f1 + f2;
            f1 = f2;
            f2 = f;
        }
        console.log(f);
    }
}


let text = ['11'];
Fibonacci(text);