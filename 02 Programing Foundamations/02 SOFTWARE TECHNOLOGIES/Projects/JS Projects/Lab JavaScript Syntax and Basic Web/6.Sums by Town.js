function solve(input) {

    let object = {};

    for (let line of input)
    {
        let obj = JSON.parse(line)

        let town = obj.town;

        let quantity = obj.income;

        if (!(town in object))
        {
            object[town] = quantity;
        }
        else {
            object[town] += quantity;
        }
    }

    var keys = Object.keys(object);
    keys.sort();

    for (var i = 0; i < keys.length; i++){
        console.log(keys[i]+" -> "+object[keys[i]]);
    }
}


solve(['{"town":"Sofia","income":200}',
'{"town":"Varna","income":120}' ,
'{"town":"Pleven","income":60}' ,
'{"town":"Varna","income":70}']);