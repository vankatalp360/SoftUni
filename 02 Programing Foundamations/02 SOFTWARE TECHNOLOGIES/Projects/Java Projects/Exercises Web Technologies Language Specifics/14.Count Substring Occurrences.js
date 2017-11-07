function countAppears(input) {
    let text = input[0].toLowerCase();
    let word = input[1].toLowerCase();
    let pattern = new RegExp('(?=('+word+'))', 'g');
    var res = text.match(pattern);
    if (res!=null)
        console.log(res.length);
    else
        console.log('0');

}

let text = [ 'Welcome to SoftUni'
    ,'Java' ];

countAppears(text);