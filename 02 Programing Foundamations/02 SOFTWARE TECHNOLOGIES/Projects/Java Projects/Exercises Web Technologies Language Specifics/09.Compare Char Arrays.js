function CompareTwoArrays(input)
{
    let arrayes =  input.filter(x=>x);
    let array1 = arrayes[0].split(' ');
    let array2 = arrayes[1].split(' ');
for(let index=0;index< Math.min(array1.length, array2.length);index++)
{
    if (array1[index]<array2[index])
    {
        PrintArrays(array1,array2);
        break;
    }
    else if (array1[index]>array2[index])
    {
        PrintArrays(array2,array1);
        break;
    }
    if(index===Math.min(array1.length, array2.length)-1)
    {
        if (array1.length<=array2.length)
        {
            PrintArrays(array1,array2);
        }
        else
        {
            PrintArrays(array2,array1);
        }
    }
}
    function PrintArrays( array1,  array2)
    {
        console.log(array1.join(""));
        console.log(array2.join(""));
    }

}



let text = [ 'a b c', 'd e f', '' ];

CompareTwoArrays(text);
