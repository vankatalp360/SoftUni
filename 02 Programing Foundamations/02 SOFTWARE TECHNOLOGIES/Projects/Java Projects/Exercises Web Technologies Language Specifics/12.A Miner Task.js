function storeResources(input) {
    let resources = [];
    for(let i =0 ; i < input.length;i+=2)
    {
        let resource = input[i];
        if (resource==="stop")
        {
            break;
        }
        else
        {
            let quantity = parseInt(input[i+1]);
            if (resources[resource]===undefined)
            {
                resources[resource]=0;
            }
            resources[resource]+=quantity;
        }
    }
    for(let key in resources)
    {
;        console.log(key+" -> "+resources[key]);
    }

}

let text = [ 'Gold','155' , 'Silver' , '10','Copper' , '17' , 'stop'];

storeResources(text);