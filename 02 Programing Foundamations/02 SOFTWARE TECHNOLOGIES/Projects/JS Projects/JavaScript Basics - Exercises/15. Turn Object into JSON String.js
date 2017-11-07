function turnToJSON(input) {
let text = input.filter(x => x);
let obj = {};
for (let line of text)
{

    let str = line.split(/ -> /);
       let indificator = str[0];
       let value = str[1];
       if (indificator==="age"||indificator==="grade")
       {
           obj[indificator]=parseFloat(value);
       }
       else
       {
           obj[indificator]=value;
       }
}
console.log(JSON.stringify(obj));
}

let text =[ "name -> Angel","surname -> Georgiev" , "age -> 20","grade -> 6.00","date -> 23/05/1995", "town -> Sofia"];

turnToJSON(text);
