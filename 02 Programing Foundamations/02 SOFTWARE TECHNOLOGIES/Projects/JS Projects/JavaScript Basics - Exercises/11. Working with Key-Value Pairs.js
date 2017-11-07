function manipulateArray(input) {
    let resultArray = [];
    let lines = input.filter(x =>x);
   for (let line of lines)
   {
       let input = line.split(" ").filter(x => x);
       if (input.length==2)
       {
           let key = input[0];
           let value = input[1];
           resultArray[key]=value;
       }
       else
       {
           let key = input[0];
           if (resultArray[key]!=undefined)
           {
               console.log(resultArray[key]);
           }
           else
           {
               console.log("None")
           }
           break;
       }
   }
}

let text =[ 'key value', 'key eulav','test tset', 'key' ];

manipulateArray(text);
